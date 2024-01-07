using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "GameElementDataMapping",
        menuName = "DkIT/Scriptable Objects/Mappings/GameElements")]
    public class GameElementDataMapping : SerializedScriptableObject
    {
        [SerializeField]
        public Dictionary<string, ConsumableObjectData> Consumables;
    }
}