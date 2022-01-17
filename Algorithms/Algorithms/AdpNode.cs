namespace Algorithms.Algorithms;


public class AdpNode
{
    private int _depth;
    private AdpNode _childRight;
    private AdpNode _childLeft;
    private AdpNode _parent;
    private int? _data;

    public AdpNode(int data)
    {
        this._data = data;
    }
    public AdpNode(int? data = default, 
        AdpNode parent = null, AdpNode childLeft = null,
        AdpNode childRight = null, int depth = default)
    {
        this._data = data;
        this._parent = parent;
        this._childLeft = childLeft;
        this._childRight = childRight;
        this._depth = depth;
    }

    public void SetDepth(int depth)
    {
        this._depth = depth;
    }

    public int GetDepth()
    {
        return this._depth;
    }

    public int? GetData()
    {
        return this._data;
    }

    public void SetData(int data)
    {
        this._data = data;
    }

    public AdpNode GetParent()
    {
        return this._parent;
    }

    public void SetParent(AdpNode parent)
    {
        this._parent = parent;
    }

    public AdpNode GetLeftChild()
    {
        return this._childLeft;
    }

    public void SetLeftChild(AdpNode childLeft)
    {
        this._childLeft = childLeft;
    }

    public AdpNode GetRightChild()
    {
        return this._childRight;
    }

    public void SetRightChild(AdpNode childRight)
    {
        this._childRight = childRight;
    }
}