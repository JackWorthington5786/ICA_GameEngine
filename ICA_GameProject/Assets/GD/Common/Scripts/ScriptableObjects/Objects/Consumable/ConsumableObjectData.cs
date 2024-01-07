using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "ConsumableObjectData", menuName = "DkIT/Scriptable Objects/Objects/Consumable")]
    public class ConsumableObjectData : InteractableObjectData
    {
        [TabGroup("tab1", "Buffs", SdfIconType.Gem)]
        [TableList(ShowIndexLabels = true, AlwaysExpanded = true, DrawScrollView = false)]
        [Tooltip("Buffs modify more than one attribute of the entity when consumed (e.g. a potion adds strength and speed")]
        [Searchable]
        public List<ItemBuff> buffs;

        [TabGroup("tab1", "Buffs")]
        [Tooltip("Define if all buffs are applied or just a random buff on pickup")]
        [EnumToggleButtons]
        public BuffApplyPolicyType ApplyPolicy = BuffApplyPolicyType.ApplyAll;
    }

    [System.Serializable]
    public class ItemBuff
    {
        [Tooltip("Specify what attribute of the player does this consumable modify (e.g. strength)")]
        [EnumPaging]
        public AttributeType Attribute;

        [Tooltip("Specify the value of the attribute (e.g. 10 stamina points)")]
        [ProgressBar(0, 100, 0, 1, 0, ColorGetter = "GetColor", DrawValueLabel = true, ValueLabelAlignment = TextAlignment.Center)]
        public int Value;

        public Color GetColor(float value)
        {
            return Color.Lerp(Color.red, Color.green, Mathf.Pow(value / 100, 2));
        }
    }
}