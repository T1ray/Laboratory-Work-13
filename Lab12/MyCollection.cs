using System.Collections;
using Lab10;

namespace Lab12;

public class MyCollection<TKey, TValue> : IDictionary<TKey, TValue>
    where TKey : IComparable<TKey>
    where TValue : MusicalInstrument, ICloneable, new()
{
    private AVLTree<TKey, TValue> tree = new AVLTree<TKey, TValue>();
    private int numberNodes = 0;
    
    public MyCollection() {}

    public MyCollection(int length)
    {
        if (length < 0) throw new ArgumentOutOfRangeException(nameof(length), "length must be greater than or equal to zero");
        
        Random rnd = new Random();
        for (int i = 0; i < length; i++)
        {
            TKey key;
            TValue value = new TValue();
            value.RandomInit();
            if (typeof(TKey) == typeof(int)) key = (TKey)(object)(value.Id.Id);
            else throw new NotSupportedException("Поддерживаются только ключи типа int");
            Add(key, value);
        }
    }

    public MyCollection(MyCollection<TKey, TValue> otherCollection) : this()
    {
        if (otherCollection == null) throw new ArgumentNullException(nameof(otherCollection));
        foreach (KeyValuePair<TKey, TValue> pair in otherCollection) 
            Add(CloneKeyIfPossible(pair.Key), CloneValueIfPossible(pair.Value));
    }
    
    private TKey CloneKeyIfPossible(TKey key)
    {
        if (key is ICloneable cloneableKey) return (TKey)cloneableKey.Clone();
        return key;
    }
    
    private TValue CloneValueIfPossible(TValue value)
    {
        if (value is ICloneable cloneableKey) return (TValue)cloneableKey.Clone();
        return value;
    }
    
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        if (tree.Root == null) yield break;
        
        Queue<BalancedTreeNode<TKey, TValue>> queue = new Queue<BalancedTreeNode<TKey, TValue>>();
        queue.Enqueue(tree.Root);

        while (queue.Count > 0)
        {
            BalancedTreeNode<TKey, TValue> node = queue.Dequeue();
            yield return new KeyValuePair<TKey, TValue>(CloneKeyIfPossible(node.Key), CloneValueIfPossible(node.Value));
            
            if (node.Left != null) queue.Enqueue(node.Left);
            if (node.Right != null) queue.Enqueue(node.Right);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        Add(item.Key, item.Value);
    }

    public void Clear()
    {
        tree.Clear();
        numberNodes = 0;
    }

    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
        if (item.Key == null || item.Value == null) throw new ArgumentNullException(nameof(item));
        TValue? returnedValue;
        
        if (TryGetValue(item.Key, out returnedValue))
        {
            if (returnedValue == null || !returnedValue.Equals(item.Value)) return false;
            return true;
        }
        return false;
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        if (array.Length - arrayIndex < Count) throw new ArgumentException("Длина массива не достаточно большая!");

        int i = 0;
        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            array[arrayIndex + i] = new KeyValuePair<TKey, TValue>(CloneKeyIfPossible(pair.Key), CloneValueIfPossible(pair.Value));
        i++;
        }
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        if (item.Key == null || item.Value == null) throw new ArgumentNullException(nameof(item));
        TValue? returnedValue;
        if (TryGetValue(item.Key, out returnedValue))
        {
            if (returnedValue == null) return false;
            if (returnedValue.Equals(item.Value))
            {
                tree.Delete(item.Key);
                numberNodes--;
                return true;
            }
        }
        return false;
    }

    public int Count => numberNodes;
    public bool IsReadOnly => false;
    public void Add(TKey key, TValue value)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));
        if (value == null) throw new ArgumentNullException(nameof(value));

        if (!ContainsKey(key))
        {
            tree.Insert(key, value);
            numberNodes++;
        }
    }

    public bool ContainsKey(TKey key)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));
        return tree.Find(key) != null;
    }

    public bool Remove(TKey key)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));
        if (!ContainsKey(key)) return false;
        tree.Delete(key);
        numberNodes--;
        return true;
    }

    public bool TryGetValue(TKey key, out TValue? value)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));

        BalancedTreeNode<TKey, TValue>? node = tree.Find(key);
        if (node == null)
        {
            value = null;
            return false;
        }
        else
        {
            value = CloneValueIfPossible(node.Value);
            return true;
        }
    }

    public TValue this[TKey key]
    {
        get
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            BalancedTreeNode<TKey, TValue>? node = tree.Find(key);
            
            if (node == null) throw new KeyNotFoundException();
            return node.Value;
        }
        set
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (value == null) throw new ArgumentNullException(nameof(value));
            
            BalancedTreeNode<TKey, TValue>? node = tree.Find(key);
            if (node == null) Add(key, value);
            else node.Value = CloneValueIfPossible(value);
        }
    }

    public ICollection<TKey> Keys
    {
        get
        {
            List<TKey> keys = new List<TKey>();
            foreach (KeyValuePair<TKey, TValue> pair in this)
            {
                keys.Add(pair.Key);
            }
            return keys;
        }
    }

    public ICollection<TValue> Values
    {
        get
        {
            List<TValue> values = new List<TValue>();
            foreach (KeyValuePair<TKey, TValue> pair in this)
            {
                values.Add(pair.Value);
            }
            return values;
        }
    }
    
    public void CollectionPrintTree(int initialIndent = 3)
    {
        if (tree.Root == null)
        {
            Console.WriteLine("Коллекция пуста");
            return;
        }
        Console.WriteLine("Элементы коллекции: ");
        tree.PrintByLevel(initialIndent, tree.Root);
    }
}