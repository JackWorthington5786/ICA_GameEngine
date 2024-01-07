using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "StringGameEvent",
        menuName = "DkIT/Scriptable Objects/Patterns/Events/string", order = 4)]
    public class StringGameEvent : BaseGameEvent<string>
    { }
}