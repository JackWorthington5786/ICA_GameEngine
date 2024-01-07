using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "BoolGameEvent",
    menuName = "DkIT/Scriptable Objects/Patterns/Events/Bool", order = 2)]
    public class BoolGameEvent : BaseGameEvent<bool>
    {
    }

    [CreateAssetMenu(fileName = "ScriptableObjectGameEvent",
menuName = "DkIT/Scriptable Objects/Patterns/Events/ScriptableObject", order = 7)]
    public class ScriptableObjectGameEvent : BaseGameEvent<ScriptableObject>
    {
    }
}