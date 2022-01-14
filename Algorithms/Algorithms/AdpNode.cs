namespace Algorithms.Algorithms;


public class AdpNode<T>
{
    private int _depth;
    private AdpNode<T>? _childRight;
    private AdpNode<T>? _childLeft;
    private AdpNode<T>? _parent;
    private T? _data;

    public AdpNode(T? data = default, 
        AdpNode<T>? parent = null, AdpNode<T>? childLeft = null,
        AdpNode<T>? childRight = null, int depth = default)
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

    public T? GetData()
    {
        return this._data;
    }

    public void SetData(T data)
    {
        this._data = data;
    }

    public AdpNode<T>? GetParent()
    {
        return this._parent;
    }

    public void SetParent(AdpNode<T> parent)
    {
        this._parent = parent;
    }

    public AdpNode<T>? GetLeftChild()
    {
        return this._childLeft;
    }

    public void SetLeftChild(AdpNode<T> childLeft)
    {
        this._childLeft = childLeft;
    }

    public AdpNode<T>? GetRightChild()
    {
        return this._childRight;
    }

    public void SetRightChild(AdpNode<T> childRight)
    {
        this._childRight = childRight;
    }
}