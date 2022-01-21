namespace Algorithms.Algorithms;


public class AdpNode
{
    public int _depth;
    private AdpNode _childRight;
    private AdpNode _childLeft;
    // private AdpNode _parent;
    private int _data;

    public AdpNode(int data)
    {
        _data = data;
        _depth = 0;
    }
    public AdpNode(int data = default
        // , AdpNode parent = null
        ,AdpNode childLeft = null,
        AdpNode childRight = null
        ,int depth = default)
    {
        _data = data;
        // _parent = parent;
        _childLeft = childLeft;
        _childRight = childRight;
        _depth = 0;
    }

    public void SetDepth(int depth)
    {
        _depth = depth;
    }

    public int GetDepth()
    {
        return _depth;
    }

    public int GetData()
    {
        return _data;
    }

    public void SetData(int data)
    {
        _data = data;
    }

    // public AdpNode GetParent()
    // {
    //     // return _parent;
    // }

    // public void SetParent(AdpNode parent)
    // {
    //     _parent = parent;
    // }

    public AdpNode GetLeftChild()
    {
        return _childLeft;
    }

    public void SetLeftChild(AdpNode childLeft)
    {
        _childLeft = childLeft;
    }

    public AdpNode GetRightChild()
    {
        return _childRight;
    }

    public void SetRightChild(AdpNode childRight)
    {
        _childRight = childRight;
    }
}