namespace Lab12;

// Идеально сбалансированное дерево с использованием АВЛ алгоритма
public class BalancedTree<TKey, TValue>
    where TKey : IComparable<TKey>
{
    public BalancedTreeNode<TKey, TValue>? Root { get; set; }
    
    public int GetHeight(BalancedTreeNode<TKey, TValue>? node)
    {
        return node == null ? 0 : node.Height;
    }

    public int GetBalance(BalancedTreeNode<TKey, TValue>? node)
    {
        return node == null ? 0 : GetHeight(node.Right) - GetHeight(node.Left);
    }

    public void UpdateHeight(BalancedTreeNode<TKey, TValue>? node)
    {
        if (node == null) return;
        
        int heightLeft = GetHeight(node.Left);
        int heightRight = GetHeight(node.Right);
        node.Height = (heightLeft > heightRight ? heightLeft : heightRight) + 1;
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

    public BalancedTreeNode<TKey, TValue>? GetMinNode()
    {
        if (Root == null) return null;
        BalancedTreeNode<TKey, TValue> node = Root;
        while (node.Left != null) node = node.Left;
        return node;
    }

    public BalancedTreeNode<TKey, TValue> RotateLeft(BalancedTreeNode<TKey, TValue> nodeq)
    {
        BalancedTreeNode<TKey, TValue> nodep = nodeq.Right;
        nodeq.Right = nodep.Left;
        nodep.Left = nodeq;
        
        UpdateHeight(nodeq);
        UpdateHeight(nodep);
        return nodep;
    }
    
    public BalancedTreeNode<TKey, TValue> RotateRight(BalancedTreeNode<TKey, TValue> nodep)
    {
        BalancedTreeNode<TKey, TValue> nodeq = nodep.Left;
        nodep.Left = nodeq.Right;
        nodeq.Right = nodep;
        
        UpdateHeight(nodep);
        UpdateHeight(nodeq);
        return nodeq;
    }

    public BalancedTreeNode<TKey, TValue> Balance(BalancedTreeNode<TKey, TValue> node)
    {
        UpdateHeight(node);
        int balance = GetBalance(node);

        if (balance < -1)
        {
            if (GetBalance(node.Left) > 0) node.Left = RotateLeft(node.Left); 
            return RotateRight(node);
        }

        if (balance > 1)
        {
            if (GetBalance(node.Right) < 0) node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }
        
        return node;
    }

    public void Insert(TKey key, TValue value)
    {
        Root = Insert(Root, key, value);
    }

    private BalancedTreeNode<TKey, TValue> Insert(BalancedTreeNode<TKey, TValue>? node, TKey key, TValue value)
    {
        if (node == null)
            return new BalancedTreeNode<TKey, TValue>(CloneKeyIfPossible(key), CloneValueIfPossible(value));
        
        int compareResult = key.CompareTo(node.Key);
        if (compareResult < 0) node.Left = Insert(node.Left, key, value);
        else if (compareResult > 0) node.Right = Insert(node.Right, key, value);
        else
        {
            Console.WriteLine("Уже есть значение в дереве с данным ключом!");
            return node;
        }

        return Balance(node);
    }

    public void PrintByLevel(int length, BalancedTreeNode<TKey, TValue>? node)
    {
        if (node != null)
        {
            PrintByLevel(length + 3, node.Left);
            for (int i = 0; i < length; i++)
            {
                Console.Write("    ");
            }

            Console.WriteLine($"Ключ: {node.Key}, Значение: {node.Value}");
            PrintByLevel(length + 3, node.Right);
        }
    }

    public SearchTree<TKey, TValue> ConvertToSearchTree()
    {
        SearchTree<TKey, TValue> searchTree = new SearchTree<TKey, TValue>();
        if (Root != null)
        {
            Queue<BalancedTreeNode<TKey, TValue>> queue = new Queue<BalancedTreeNode<TKey, TValue>>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                BalancedTreeNode<TKey, TValue> node = queue.Dequeue();
                searchTree.Insert(node.Key, node.Value);
                if (node.Right != null) queue.Enqueue(node.Right);
                if (node.Left != null) queue.Enqueue(node.Left);
            }
        }
        return searchTree;
    }

    public void Clear()
    {
        Root = null;
        Console.WriteLine("АВЛ-дерево очищено!");
    }
}