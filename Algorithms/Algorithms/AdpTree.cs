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
        public int _height;

        public int ListDepth
        {
            get => _height;
            set => _height = value;
        }

        public AdpNode _childRight;
        public AdpNode _childLeft;
        public int _data;

        public AdpNode(int data)
        {
            _data = data;
        }
        public AdpNode(int data, int height)
        {
            _data = data;
            _height = height;
        }
        public AdpNode(int data = default ,AdpNode childLeft = null
            , AdpNode childRight = null ,int depth = default)
        {
            _data = data;
            _childLeft = childLeft;
            _childRight = childRight;
            _height = 0;
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
        else if (node._data > data) //data uit rootNode groter dan ingezonden data? nieuwe node is childLeft
        {
            node._childLeft = Insert(node._childLeft, data);
        }
        else if (node._data < data) //data uit rootNode kleiner dan ingezonden data? nieuwe node is childRight
        {
            node._childRight = Insert(node._childRight, data);
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
        return _root == null ? -1 : _root._height;
    }
    public int Height(AdpNode node)
    {
        return node == null ? -1 : node._height;
    }
    private void UpdateHeight(AdpNode node) {
        node._height = 1 + Math.Max(Height(node._childLeft), Height(node._childRight));
    }
    
    public AdpNode Find(int data)
    {
        var node = _root;
        while (node != null)
        {
            if (node._data == data)
            {
                break;
            }
            node = node._data < data ? node._childRight : node._childLeft;
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
        var size = GetSizeRecursive(node._childLeft) + 1 + GetSizeRecursive(node._childRight);
        return size;
    }


    public AdpNode ListRoot
    {
        get => _root;
        set => _root = value ?? throw new ArgumentNullException(nameof(value));
    }


}