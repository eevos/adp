namespace Algorithms.Algorithms;

public class AdpTree<T>
{
    private AdpNode<T> _root;

    public AdpTree(AdpNode<T> root)
    {
        this._root = root;
    }

    public AdpNode<T> ListRoot
    {
        get => _root;
        set => _root = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    
}