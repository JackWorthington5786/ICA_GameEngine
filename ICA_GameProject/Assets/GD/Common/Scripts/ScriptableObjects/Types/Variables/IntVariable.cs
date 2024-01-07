using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "DkIT/Scriptable Objects/Types/Variables/Int", order = 2)]
    public class IntVariable : ScriptableDataType<int>
    {
        public void Add(int a)
        {
            Value += a;
        }

        public void Add(IntVariable a)
        {
            Add(a.Value);
        }
    }
}