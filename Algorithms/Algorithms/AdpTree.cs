using System.Runtime.CompilerServices;

namespace Algorithms.Algorithms;

public class AdpTree
{
    private AdpNode _root;

    public AdpTree(AdpNode root)
    {
        this._root = root;
    }

    public AdpTree()
    {
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
        else if (node.GetData() > data) //data uit rootNode groter dan ingezonden data? nieuwe node is childLeft
        {
            node.SetLeftChild(Insert(node.GetLeftChild(), data));
            // node.GetLeftChild().SetDepth(childNodeDepth);
        }
        else if (node.GetData() < data) //data uit rootNode kleiner dan ingezonden data? nieuwe node is childRight
        {
            node.SetRightChild(Insert(node.GetRightChild(), data));
            // node.GetRightChild().SetDepth(childNodeDepth);
        }
        else
        {
            throw new Exception("data already exists!");
        }
// // # Work out the hieght of the current node after the insertion
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

            return node; // return rebalance(node);
    }

    public int height()
    {
        return _root == null ? -1 : _root.GetDepth();
    }

    public int Height(AdpNode node)
    {
        return node == null ? -1 : node.GetDepth();
    }

    public AdpNode Find(int data)
    {
        var node = _root;
        while (node != null)
        {
            if (node.GetData() == data)
            {
                break;
            }

            node = node.GetData() < data ? node.GetRightChild() : node.GetLeftChild();
        }

        return node;
    }

    public int GetSize()
    {
        return GetSizeRecursive(_root);
    }

    private int GetSizeRecursive(AdpNode node)
    {
        int size;
        if (node == null)
        {
            return 0;
        }
        else
        {
            size = GetSizeRecursive(node.GetLeftChild()) + 1 + GetSizeRecursive(node.GetRightChild());
        }

        return size;
    }


    public AdpNode ListRoot
    {
        get => _root;
        set => _root = value ?? throw new ArgumentNullException(nameof(value));
    }
}