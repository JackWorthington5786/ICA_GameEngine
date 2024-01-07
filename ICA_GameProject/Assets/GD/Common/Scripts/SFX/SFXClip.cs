using GD;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "SFXClip", menuName = "DkIT/Scriptable Objects/Audio/SFX Clip")]
public class SFXClip : ScriptableGameObject
{
    [Title("Audio Clip")]
    [Required]
    public AudioClip clip;

    [FoldoutGroup("Clip Settings")]
    [Range(0f, 1f)]
    public float Volume = 1f;

    [FoldoutGroup("Clip Settings")]
    [Range(0f, 0.2f)]
    public float VolumeVariation = 0.05f;

    [FoldoutGroup("Clip Settings")]
    [Range(0f, 2f)]
    public float Pitch = 1f;

    [FoldoutGroup("Clip Settings")]
    [Range(0f, 0.2f)]
    public float PitchVariation = 0.05f;
}