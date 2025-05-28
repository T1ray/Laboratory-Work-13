    namespace Lab12;

    public class SearchTree<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        public SearchTreeNode<TKey, TValue>? Root { get; set; }
        
        public void Insert(TKey key, TValue value)
        {
            Root = Insert(Root, key, value);
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

        private SearchTreeNode<TKey, TValue> Insert(SearchTreeNode<TKey, TValue>? node, TKey key, TValue value)
        {
            if (node == null)
                return new SearchTreeNode<TKey, TValue>(CloneKeyIfPossible(key), CloneValueIfPossible(value));

            int compareResult = key.CompareTo(node.Key);
            if (compareResult < 0) node.Left = Insert(node.Left, key, value);
            else if (compareResult > 0) node.Right = Insert(node.Right, key, value);
            else Console.WriteLine($"Значение с ключом {key} уже существует. Значение проигнорировано!");
            return node;
        }
        
        public void PrintByLevel(int length, SearchTreeNode<TKey, TValue>? node)
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

        public void Delete(TKey key)
        {
            Root = Delete(Root, key);
        }

        private SearchTreeNode<TKey, TValue>? Delete(SearchTreeNode<TKey, TValue>? node, TKey key)
        {
            if (node == null)
            {
                Console.WriteLine("Элемент с данным ключом не найден в дереве!");
                return node;
            }
            
            int resultCompare = key.CompareTo(node.Key);
            if (resultCompare < 0) node.Left = Delete(node.Left, key);
            else if (resultCompare > 0) node.Right = Delete(node.Right, key);
            else
            {
                if (node.Left == null) return node.Right;
                else if (node.Right == null) return node.Left;

                SearchTreeNode<TKey, TValue> minNode = node.Right;
                while (minNode.Left != null) minNode = minNode.Left;
                
                node.Key = minNode.Key;
                node.Value = minNode.Value;
                node.Right = Delete(node.Right, minNode.Key);
            }

            return node;
        }

        public SearchTreeNode<TKey, TValue>? Find(TKey key)
        {
            SearchTreeNode<TKey, TValue>? node = Root;

            while (node != null)
            {
                int compareResult = key.CompareTo(node.Key);
                if (compareResult < 0) node = node.Left;
                else if (compareResult > 0) node = node.Right;
                else return node;
            }
            return node;
        }
        
        public void Clear()
        {
            Root = null;
            Console.WriteLine("Дерево поиска очищено!");
        }
    }