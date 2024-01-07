using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "PlaceableObjectData", menuName = "DkIT/Scriptable Objects/Objects/Placeable")]
    public class PlaceableObjectData : BaseObjectData
    {
        //add game event here - OnDestroy, OnSpawn

        [TabGroup("tab1", "Audio", SdfIconType.Soundwave)]
        [Tooltip("One audio clip from this list is played when this placeable object is attacking")]
        public List<AudioClip> AttackClip;

        [TabGroup("tab1", "Audio")]
        [Tooltip("One audio clip from this list is played when this placeable object is destroyed")]
        public List<AudioClip> DieClip;

        [TabGroup("tab1", "Attack", SdfIconType.Hammer)]
        [Tooltip("Enable if this placeable object can attack units")]
        public bool IsOffensive = true;

        [TabGroup("tab1", "Attack")]
        [ShowIf("IsOffensive")]
        [Tooltip("Type of targets attacked by this placeable object")]
        [EnumToggleButtons]
        public AttackTargetType TargetType;

        [TabGroup("tab1", "Attack")]
        [ShowIf("IsOffensive")]
        [Tooltip("Attack type used by this placeable object")]
        [EnumToggleButtons]
        public AttackType AttackType;

        [TabGroup("tab1", "Attack")]
        [ShowIf("IsOffensive")]
        [Tooltip("Damage inflicted by this object with each attack")]
        [ProgressBar(0, 100, 0, 1, 0)]
        public int DamagePerAttack;

        [TabGroup("tab1", "Attack")]
        [ShowIf("IsOffensive")]
        [Tooltip("Range over which this unit can attack")]
        [ProgressBar(0, 100, 0, 1, 0)]
        public int AttackRange;

        [TabGroup("tab1", "Attack")]
        [ShowIf("IsOffensive")]
        [Tooltip("Rate at which this unit can attack (-1 for random rate in range)")]
        [Range(0, 60)]
        [Unit(Units.Millisecond)]
        public float AttackRateSecs;

        [TabGroup("tab1", "Movement", SdfIconType.ArrowsMove)]
        [Header("Movement")]
        [Range(0, 10)]
        public float MoveSpeed;

        [TabGroup("tab1", "Movement")]
        [Range(0, 10)]
        public float StrafeSpeed;

        [TabGroup("tab1", "Movement")]
        [Range(-180, 180)]
        public float RotateSpeed;
    }
}