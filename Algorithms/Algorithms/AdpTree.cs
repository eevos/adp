using System.Runtime.CompilerServices;

namespace Algorithms.Algorithms;

public class AdpTree
{
    public AdpNode ListRoot { get; set; }
    
    public class AdpNode
    {
        public int ListHeight { get; set; }
        public AdpNode? Right { get; set; }
        public AdpNode? Left { get; set; }
        public int Data { get; set; }

        public AdpNode(int data)
        {
            Data = data;
        }

        public AdpNode(int data, int height)
        {
            Data = data;
            ListHeight = height;
        }
    }

    public void Insert(int data)
    {
        ListRoot = Insert(ListRoot, data); //recursief nodes toevoegen, iedere node is meteen ook een root
    }

    public AdpNode Insert(AdpNode? node, int data)
    {
        if (node == null) // Als er nog geen rootNode is maak je een nieuwe rootNode
        {
            return new AdpNode(data);
        }
        if (node.Data > data) //data uit rootNode groter dan ingezonden data? nieuwe node is childLeft
        {
            node.Left = Insert(node.Left, data);
        }
        else if (node.Data < data) //data uit rootNode kleiner dan ingezonden data? nieuwe node is childRight
        {
            node.Right = Insert(node.Right, data);
        }
        else
        {
            throw new Exception("data already exists!");
        }
        UpdateHeight(node);
        int balance = GetBalance(node);
        if (balance > 1 && node.Data < node.Left.Data)
        {
            return RotateRight(node);
        }
        
        if (balance < -1 && node.Data > node.Right.Data)
        {
            return RotateLeft(node);
        }
        
        if (balance > 1 && node.Data > node.Left.Data)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }
        
        if (balance < -1 && node.Data < node.Right.Data)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }
        return node;
        // return Rebalance(node);
    }
    // private AdpNode Rebalance(AdpNode node)
    // {
    //     UpdateHeight(node);
    //     int balance = GetBalance(node);
    //
    //     if (balance > 1 && node.Data < node.Left.Data)
    //     {
    //         return RotateRight(node);
    //     }
    //     
    //     if (balance < -1 && node.Data > node.Right.Data)
    //     {
    //         return RotateLeft(node);
    //     }
    //     
    //     if (balance > 1 && node.Data > node.Left.Data)
    //     {
    //         node.Left = RotateLeft(node.Left);
    //         return RotateRight(node);
    //     }
    //     
    //     if (balance < -1 && node.Data < node.Right.Data)
    //     {
    //         node.Right = RotateRight(node.Right);
    //         return RotateLeft(node);
    //     }
    //     
    //     return node;
    // }
    private AdpNode RotateRight(AdpNode node) {
        var left = node.Left;
        var leftRight = left?.Right;
        left!.Right = node;
        node.Left = leftRight;
        UpdateHeight(node);
        UpdateHeight(left);
        return left;
    }
    private AdpNode RotateLeft(AdpNode node) {
        var right = node.Right;
        var rightLeft = right?.Left;
        right!.Left = node;
        node.Right = rightLeft;
        UpdateHeight(node);
        UpdateHeight(right);
        return right;
    }
    private void UpdateHeight(AdpNode node)
    {
        node.ListHeight = 1 + Math.Max(Height(node.Left), Height(node.Right));
    }
    public int Height()
    {
        return ListRoot?.ListHeight ?? -1;
    }

    public int Height(AdpNode? node)
    {
        return node == null ? -1 : node.ListHeight;
    }


    public int GetBalance(AdpNode? node)
    {
        if (node == null) return 0;
        return Height(node.Left) - Height(node.Right);
    }
    public AdpNode Find(int data)
    {
        var node = ListRoot;
        while (node != null)
        {
            if (node.Data == data)
            {
                break;
            }

            node = node.Data < data ? node.Right : node.Left;
        }

        return node;
    }

    // public void Delete(int data)
    // {
    //     _root = Delete(_root, data);
    // }
    //
    // public AdpNode Delete(AdpNode? node, int data)
    // {
    //     // Base case
    //     if (node == null) return node;
    //     else if (node.Data > data)
    //     {
    //         node.Left = Delete(node.Left, data);
    //     }
    //     else if (node.Data < data)
    //     {
    //         node.Right = Delete(node.Right, data);
    //     }
    //     else
    //     {
    //         if (node.Left == null || node.Right == null)
    //         {
    //             node = (node.Left == null) ? node.Right : node.Left;
    //         }
    //         else
    //         {
    //             var mostLeftChild = MostLeftChild(node.Right);
    //             node.Data = mostLeftChild.Data;
    //             node.Right = Delete(node.Right, node.Data);
    //         }
    //     }
    //     if (node != null) { node = Rebalance(node); }
    //     return node;
    // }
    //
    // private AdpNode MostLeftChild(AdpNode node)
    // {
    //     AdpNode current = node;
    //     while (current.Left != null) {
    //         current = current.Left;
    //     }
    //     return current;
    // }
    
    public int GetSize()
    {
        return GetSizeRecursive(ListRoot);
    }
    private int GetSizeRecursive(AdpNode? node)
    {
        if (node == null)
        {
            return 0;
        }

        var size = GetSizeRecursive(node.Left) + 1 + GetSizeRecursive(node.Right);
        return size;
    }
    
}