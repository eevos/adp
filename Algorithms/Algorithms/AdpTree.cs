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
        _root = Insert(_root, data);    //recursief nodes toevoegen, iedere node is meteen ook een root
    }

    public AdpNode Insert(AdpNode node, int data)
    {
        if (node == null)       // Als er nog geen rootNode is maak je een nieuwe rootNode
        {
            return new AdpNode(data);
        }
        else if (node.GetData() > data)     //data uit rootNode groter dan ingezonden data? nieuwe node is childLeft
        {
            node.SetLeftChild(Insert(node.GetLeftChild(),data));
        }
        else if (node.GetData() < data)     //data uit rootNode kleiner dan ingezonden data? nieuwe node is childRight
        {
            node.SetRightChild(Insert(node.GetRightChild(),data)); 
        }
        else
        {
            throw new Exception("data already exists!");
        }
        return node;    // return rebalance(node);
    }

    public AdpNode Find(int data)
    {
        var node = _root;
        if (node.GetData() == data)
        {
            return node;
        }
        else if (node.GetData() < data)
        {
            Find(node.GetRightChild().GetData());
        }
        else
        {
            Find(node.GetLeftChild().GetData());
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