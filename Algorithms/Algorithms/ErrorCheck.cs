// namespace Algorithms.Algorithms;
//
// public class ErrorCheck<T>
// {
//     private T _items;
//
//
//     public ErrorCheck(T items)
//     {
//         _items = items;
//     }
//
//     private void ErrorCheck(LinkedListNode<T> node)
//     {
//         if (_items.First.Value == null || node.Value == null || _items.Count == 0)
//         {
//             throw new Exception("LinkedList is empty");
//         }
//
//         if (_items.Count > 2500)
//         {
//             throw new Exception("LinkedList is too big for memory");
//         }
//     }
//     private void ErrorCheck()
//     {
//         if (_items.First.Value == null || _items.Count == 0)
//         {
//             throw new Exception("LinkedList is empty");
//         }
//
//         if (_items.Count > 2500)
//         {
//             throw new Exception("LinkedList is too big for memory");
//         }
//     }
// }