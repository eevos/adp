using System.Runtime.CompilerServices;

namespace Algorithms.Algorithms;

public class AdpTree
{
    private AdpNode _root;
    public AdpTree()
    {
    }
    public AdpTree(AdpNode root)
    {
        this._root = root;
    }
    public class AdpNode
    {
        public int ListHeight { get; set; }
        public AdpNode ListChildRight { get; set; }
        public AdpNode ListChildLeft { get; set; }
        public int Data;
        
        public AdpNode(int data)
        {
            Data = data;
        }
        public AdpNode(int data, int height)
        {
            Data = data;
            ListHeight = height;
        }
        public AdpNode(int data = default ,AdpNode childLeft = null
            , AdpNode childRight = null ,int depth = default)
        {
            Data = data;
            ListChildLeft = childLeft;
            ListChildRight = childRight;
        }
    }


    public void Insert(int data)
    {
        _root = Insert(_root, data); //recursief nodes toevoegen, iedere node is meteen ook een root
    }

    public AdpNode Insert(AdpNode node, int data)
    {
        // int childNodeDepth = node.GetDepth() + 1;
        if (node == null) // Als er nog geen rootNode is maak je een nieuwe rootNode
        {
            return new AdpNode(data);
        }
        else if (node.Data > data) //data uit rootNode groter dan ingezonden data? nieuwe node is childLeft
        {
            node.ListChildLeft = Insert(node.ListChildLeft, data);
        }
        else if (node.Data < data) //data uit rootNode kleiner dan ingezonden data? nieuwe node is childRight
        {
            node.ListChildRight = Insert(node.ListChildRight, data);
        }
        else
        {
            throw new Exception("data already exists!");
        }
        
// // # Work out the hegiht of the current node after the insertion
//         if (node.GetLeftChild() != null)
//         {
//             node.GetLeftChild().SetDepth(node.GetLeftChild().GetDepth());
//         }
//
//         if (node.GetRightChild() != null)
//         {
//             node.GetRightChild().SetDepth(node.GetRightChild().GetDepth());
//         }
//
// // # Calculate the height after the recursive call is made
//             if (node.GetLeftChild().GetDepth() > node.GetRightChild().GetDepth())
//             {
//                 node.SetDepth(node.GetLeftChild().GetDepth() + 1);
//             }
//             else
//             {
//                 node.SetDepth(node.GetRightChild().GetDepth() + 1);
//             };
            UpdateHeight(node);
            return node; // return rebalance(node);
    }

    public int Height()
    {
        return _root == null ? -1 : _root.ListHeight;
    }
    public int Height(AdpNode node)
    {
        return node == null ? -1 : node.ListHeight;
    }
    private void UpdateHeight(AdpNode node) {
        node.ListHeight = 1 + Math.Max(Height(node.ListChildLeft), Height(node.ListChildRight));
    }
    public int GetBalance(AdpNode node)
    {
        if (node == null) return 0;
        return Height(node.ListChildLeft) - Height(node.ListChildRight);
    }

    public AdpNode Find(int data)
    {
        var node = _root;
        while (node != null)
        {
            if (node.Data == data)
            {
                break;
            }
            node = node.Data < data ? node.ListChildRight : node.ListChildLeft;
        }
        return node;
    }
    
    public int GetSize()
    {
        return GetSizeRecursive(_root);
    }
    
    private int GetSizeRecursive(AdpNode node)
    {
        if (node == null)
        {
            return 0;
        }
        var size = GetSizeRecursive(node.ListChildLeft) + 1 + GetSizeRecursive(node.ListChildRight);
        return size;
    }
    
    public AdpNode ListRoot
    {
        get => _root;
        set => _root = value ?? throw new ArgumentNullException(nameof(value));
    }


}