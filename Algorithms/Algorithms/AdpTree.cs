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

        public AdpNode(int data = default, AdpNode childLeft = null
            , AdpNode childRight = null, int depth = default)
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
        // UpdateHeight(node);
        // return node; //
        return Rebalance(node);
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

    public void Delete(int data)
    {
        _root = Delete(_root, data);
    }

    public AdpNode Delete(AdpNode node, int data)
    {
        // Base case
        if (node == null) return node;
        else if (node.Data > data)
        {
            node.ListChildLeft = Delete(node.ListChildLeft, data);
        }
        else if (node.Data < data)
        {
            node.ListChildRight = Delete(node.ListChildRight, data);
        }
        else
        {
            if (node.ListChildLeft == null || node.ListChildRight == null)
            {
                node = (node.ListChildLeft == null) ? node.ListChildRight : node.ListChildLeft;
            }
            else
            {
                var mostLeftChild = MostLeftChild(node.ListChildRight);
                node.Data = mostLeftChild.Data;
                node.ListChildRight = Delete(node.ListChildRight, node.Data);
            }
        }
        if (node != null) { node = Rebalance(node); }
        return node;
    }

    private AdpNode Rebalance(AdpNode node)
    {
        UpdateHeight(node);
        int balance = GetBalance(node);
        if (balance > 1) {
            if (Height(node.ListChildRight.ListChildRight) > Height(node.ListChildRight.ListChildLeft)) {
                node = RotateLeft(node);
            } else {
                node.ListChildRight = RotateRight(node.ListChildRight);
                node = RotateLeft(node);
            }
        } else if (balance < -1) {
            if (Height(node.ListChildLeft.ListChildLeft) > Height(node.ListChildLeft.ListChildRight)) {
                node = RotateRight(node);
            } else {
                node.ListChildLeft = RotateLeft(node.ListChildLeft);
                node = RotateRight(node);
            }
        }
        return node;
    }
    private AdpNode RotateRight(AdpNode y) {
        AdpNode x = y.ListChildLeft;
        AdpNode z = x.ListChildRight;
        x.ListChildRight = y;
        y.ListChildLeft = z;
        UpdateHeight(y);
        UpdateHeight(x);
        return x;
    }
    private AdpNode RotateLeft(AdpNode y) {
        AdpNode x = y.ListChildRight;
        AdpNode z = x.ListChildLeft;
        x.ListChildLeft = y;
        y.ListChildRight = z;
        UpdateHeight(y);
        UpdateHeight(x);
        return x;
    }
    private AdpNode MostLeftChild(AdpNode node)
    {
        AdpNode current = node;
        while (current.ListChildLeft != null) {
            current = current.ListChildLeft;
        }
        return current;
    }
    
    
    public int Height()
    {
        return _root == null ? -1 : _root.ListHeight;
    }

    public int Height(AdpNode node)
    {
        return node == null ? -1 : node.ListHeight;
    }

    private void UpdateHeight(AdpNode node)
    {
        node.ListHeight = 1 + Math.Max(Height(node.ListChildLeft), Height(node.ListChildRight));
    }
    public int GetBalance(AdpNode node)
    {
        if (node == null) return 0;
        return Height(node.ListChildLeft) - Height(node.ListChildRight);
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