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
            // node.left = Insert(node.left, key);
        }
        else if (node.GetData() < data)     //data uit rootNode kleiner dan ingezonden data? nieuwe node is childRight
        {
            node.SetRightChild(Insert(node.GetRightChild(),data)); 
            // node.right = Insert(node.right, key);   
        }
        else
        {
            throw new Exception("data already exists!");
        }

        return _root;
        // return rebalance(node);
    }


    public AdpNode ListRoot
    {
        get => _root;
        set => _root = value ?? throw new ArgumentNullException(nameof(value));
    }
}