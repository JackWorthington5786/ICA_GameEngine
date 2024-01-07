using GD.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD
{
    #region Generic Type

    //Note - We cannot directly instantiate a GENERIC ScriptableObject from the Context Menu - see RuntimeStringList
    [System.Serializable]
    public abstract class RuntimeQueue<T> : ScriptableGameObject, IEnumerable<T>
    {
        [Header("Queue Contents")]
        private Queue<T> queue = new Queue<T>();

        public void Enqueue(T obj)
        {
            queue.Enqueue(obj);
        }

        public T Dequeue()
        {
            return queue.Dequeue();
        }

        public T Peek()
        {
            return queue.Peek();
        }

        public void Clear()
        {
            queue.Clear();
        }

        public int Count()
        {
            return queue.Count;
        }

        public bool IsEmpty()
        {
            return queue.Count == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)queue).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)queue).GetEnumerator();
        }
    }

    #endregion Generic Type

    #region Specific List Types

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeBoolQueue", menuName = "DkIT/Scriptable Objects/Types/Collections/Queue/Bool", order = 1)]
    public class RuntimeBoolQueue : RuntimeQueue<bool>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeIntQueue", menuName = "DkIT/Scriptable Objects/Types/Collections/Queue/Int", order = 2)]
    public class RuntimeIntQueue : RuntimeQueue<int>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeFloatQueue", menuName = "DkIT/Scriptable Objects/Types/Collections/Queue/Float", order = 3)]
    public class RuntimeFloatQueue : RuntimeQueue<float>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeStringQueue", menuName = "DkIT/Scriptable Objects/Types/Collections/Queue/String", order = 4)]
    public class RuntimeStringQueue : RuntimeQueue<string>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeVector3Queue", menuName = "DkIT/Scriptable Objects/Types/Collections/Queue/Vector3", order = 5)]
    public class RuntimeVector3Queue : RuntimeQueue<Vector3>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeTransformQueue", menuName = "DkIT/Scriptable Objects/Types/Collections/Queue/Transform", order = 6)]
    public class RuntimeTransformQueue : RuntimeQueue<Transform>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeGameObjectQueue", menuName = "DkIT/Scriptable Objects/Types/Collections/Queue/Game Object", order = 7)]
    public class RuntimeGameObjectQueue : RuntimeQueue<GameObject>
    {
    }

    #endregion Specific List Types
}