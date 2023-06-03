namespace CsharpUtilsLib.Collection.Types
{
    public sealed class TreeCollection<TKey, TValue>
    {
        public TreeNode<TKey, TValue> Root { get; }

        public TreeCollection(TKey rootKey, TValue rootValue)
        {
            Root = new TreeNode<TKey, TValue>(rootKey, rootValue);
        }

        public TreeNode<TKey, TValue> SearchByKey(TKey key)
        {
            return SearchByKey(key, Root);
        }

        public TreeNode<TKey, TValue> SearchByKey(TKey key, TreeNode<TKey, TValue> currentNode)
        {
            if (currentNode == null || key == null || currentNode!.Key!.Equals(key))
                return currentNode!;

            foreach (var child in currentNode.Children)
            {
                var result = SearchByKey(key, child);
                if (result != null)
                    return result;
            }

            return null!;
        }
    }

    public sealed class TreeNode<TKey, TValue>
    {
        public TKey Key { get; }
        public TValue Value { get; }
        public List<TreeNode<TKey, TValue>> Children { get; }

        public TreeNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Children = new List<TreeNode<TKey, TValue>>();
        }

        public void AddChild(TreeNode<TKey, TValue> child)
        {
            Children.Add(child);
        }

        public void RemoveChild(TreeNode<TKey, TValue> child)
        {
            Children.Remove(child);
        }

        public void RemoveAllChildren()
        {
            Children.Clear();
        }
    }
}
