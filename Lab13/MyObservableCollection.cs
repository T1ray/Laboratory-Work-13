using Lab10;
using Lab12;

namespace Lab13;

public class MyObservableCollection<TKey, TValue> : MyCollection<TKey, TValue> 
    where TKey : IComparable<TKey> 
    where TValue : MusicalInstrument, new()
{
    public string Name { get; }

    public event CollectionHandler CollectionCountChanged;
    public event CollectionHandler CollectionReferenceChanged;

    public MyObservableCollection(string name) : base()
    {
        Name = name;
    }

    public MyObservableCollection(string name, int length) : base(length)
    {
        Name = name;
    }

    public void EventCollectionCountChanged(CollectionHandlerEventArgs collectionHandler)
    {
        CollectionCountChanged?.Invoke(this, collectionHandler);
    }

    public void EventCollectionReferenceChanged(CollectionHandlerEventArgs collectionHandler)
    {
        CollectionReferenceChanged?.Invoke(this, collectionHandler);
    }

    public new void Add(TKey key, TValue value)
    {
        bool isContains = base.ContainsKey(key);
        base.Add(key, value);
        if (!isContains && base.ContainsKey(key))
            EventCollectionCountChanged(new CollectionHandlerEventArgs("Добавлен элемент", new KeyValuePair<TKey, TValue>(key, value)));
    }

    public new void Add(KeyValuePair<TKey, TValue> item)
    {
        bool isContains = base.ContainsKey(item.Key);
        base.Add(item);
        if (!isContains && base.ContainsKey(item.Key))
            EventCollectionCountChanged(new CollectionHandlerEventArgs("Добавлен элемент", item));
    }

    public new bool Remove(TKey key)
    {
        TValue? value;
        bool isDeleted = false;
        base.TryGetValue(key, out value);
        if (value != null)
        {
            isDeleted = base.Remove(key);
            EventCollectionCountChanged(new CollectionHandlerEventArgs("Удален элемент", new KeyValuePair<TKey, TValue>(key, value)));
        }
        return isDeleted;
    }

    public new bool Remove(KeyValuePair<TKey, TValue> item)
    {
        TValue? value;
        bool isDeleted = false;
        base.TryGetValue(item.Key, out value);
        if (item.Value.Equals(value))
        {
            isDeleted = base.Remove(item);
            EventCollectionCountChanged(new CollectionHandlerEventArgs("Удален элемент", item));
        }
        return isDeleted;
    }

    public new void Clear()
    {
        foreach (KeyValuePair<TKey, TValue> item in this)
        {
            EventCollectionCountChanged(new CollectionHandlerEventArgs("Удален элемент", item));
        }
        base.Clear();
    }
    
    public new TValue this[TKey key]
    {
        get
        {
            return base[key];
        }
        set
        {
            bool isContainsKey = base.ContainsKey(key);
            base[key] = value;
            if (isContainsKey)
            {
                EventCollectionReferenceChanged(new CollectionHandlerEventArgs("Элемент изменен", new KeyValuePair<TKey, TValue>(key, value)));
            }
            else
            {
                EventCollectionCountChanged(new CollectionHandlerEventArgs("Добавлен элемент", new KeyValuePair<TKey, TValue>(key, value)));
            }
        }
    }
}