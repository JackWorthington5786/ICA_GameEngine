using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory",
    menuName = "DkIT/Scriptable Objects/Game/Inventory")]
public class Inventory : SerializedScriptableObject
{
    public Dictionary<ItemData, int> Contents = new Dictionary<ItemData, int>();
}