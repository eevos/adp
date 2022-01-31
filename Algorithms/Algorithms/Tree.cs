namespace Implementations.DataStructures;

public class AdpBinaryTreeAVL<T>
{
    public BTNode<T>? Root { get; set; }
    

    public int Height(BTNode<T>? node)
    {
        return node?.Height ?? 0;
    }
    
    public string PreOrder(BTNode<T>? node)
    {
        if (node == null) return "";
        return node.Key + 
               (node.Left != null ? " " + PreOrder(node.Left) : "") +
               (node.Right != null ? " " + PreOrder(node.Right) : "");
    }
    
    public BTNode<T>? Search(T key)
    {
        return Search(Root, key);
    }

    public BTNode<T>? Search(BTNode<T>? node, T key)
    {
        while (true)
        {
            if (node == null) return null;
            if (node.Key.Equals(key)) return node;
            node = (Compare(key, node.Key) < 0 ? node.Left : node.Right);
        }
    }

    public T MinValue(BTNode<T>? node)
    {
        if (node == null) return default;
        while (node.Left != null)
        {
            node = node.Left;
        }
        return node.Key;
    }
    
    public T MaxValue(BTNode<T>? node)
    {
        if (node == null) return default;
        while (node.Right != null)
        {
            node = node.Right;
        }
        return node.Key;
    }

    public BTNode<T> Insert(BTNode<T>? node, T key)
    {
        if (node == null)
        {
            return new BTNode<T>(key);
        }

        if (Compare(key, node.Key) < 0)
        {
            node.Left = Insert(node.Left, key);
        }
        else if (Compare(key, node.Key) > 0)
        {
            node.Right = Insert(node.Right, key);
        }
        else
        {
            return node;
        }

        node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        var balance = GetBalance(node);

        if (balance > 1 && Compare(key, node.Left.Key) < 0)
        {
            return RightRotate(node);
        }
        
        if (balance < -1 && Compare(key, node.Right.Key) > 0)
        {
            return LeftRotate(node);
        }
        
        if (balance > 1 && Compare(key, node.Left.Key) > 0)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }
        
        if (balance < -1 && Compare(key, node.Right.Key) < 0)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node;
    }

    private BTNode<T> LeftRotate(BTNode<T> node)
    {
        var nodeRight = node.Right;
        var nodeRightLeft = nodeRight.Left;
        
        nodeRight.Left = node;
        node.Right = nodeRightLeft;
        
        node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        nodeRight.Height = Math.Max(Height(nodeRight.Left), Height(nodeRight.Right)) + 1;
        
        return nodeRight;
    }

    private BTNode<T> RightRotate(BTNode<T> node)
    {
        var nodeLeft = node.Left;
        var nodeLeftRight = nodeLeft.Right;
        
        nodeLeft.Right = node;
        node.Left = nodeLeftRight;
        
        node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        nodeLeft.Height = Math.Max(Height(nodeLeft.Left), Height(nodeLeft.Right)) + 1;
        
        return nodeLeft;
    }

    private int GetBalance(BTNode<T> node)
    {
        return Height(node.Left) - Height(node.Right);
    }

    private static int Compare(T a, T b)
    {
        try
        {
            var comparer = Comparer<T>.Default;
            return comparer.Compare(a, b);
        }
        catch (ArgumentException e)
        {
            throw new InvalidOperationException("Can't compare types", e);
        }

    }
}
public class BTNode<T>
{
    public T Key { get; set; }
    public BTNode<T>? Left { get; set; }
    public BTNode<T>? Right { get; set; }
    public int Height { get; set; }

    public BTNode(T key)
    {
        Key = key;
        Height = 1;
    }
}