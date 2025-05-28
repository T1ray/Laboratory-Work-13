    namespace Lab12;

    public class BalancedTreeNode<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public BalancedTreeNode<TKey, TValue>? Left { get; set; }
        public BalancedTreeNode<TKey, TValue>? Right { get; set; }
        public int Height { get; set; }
        
        public BalancedTreeNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Left = null;
            Right = null;
            Height = 1;
        }

        public override string ToString()
        {
            return $"Ключ: {Key}, Значение: {Value.ToString() ?? "null"}, Высота: {Height}";
        }
    }

    public class SearchTreeNode<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public SearchTreeNode<TKey, TValue>? Left { get; set; }
        public SearchTreeNode<TKey, TValue>? Right { get; set; }
        
        public SearchTreeNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Left = null;
            Right = null;
        }

        public override string ToString()
        {
            return $"Ключ: {Key}, Значение: {Value.ToString() ?? "null"}";
        }
    }