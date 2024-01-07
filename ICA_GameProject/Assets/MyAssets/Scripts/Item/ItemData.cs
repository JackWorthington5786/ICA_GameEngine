using Sirenix.OdinInspector;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Banana", menuName = "NMCG/Item")]
public class ItemData : ScriptableObject
{
    [Required]
    public string Name;

    [Tooltip("Used by SpawnManager to instantiate an object")]
    public GameObject itemPrefab;

    [Min(-1000)]
    public int Value;

    [AudioClipButton]
    public AudioClip PickupClip;

    [PreviewField(50, Alignment = ObjectFieldAlignment.Left)]
    public Sprite WaypointIcon;

    private void DoPress()
    {
        Debug.Log("Pressing...");
    }
}