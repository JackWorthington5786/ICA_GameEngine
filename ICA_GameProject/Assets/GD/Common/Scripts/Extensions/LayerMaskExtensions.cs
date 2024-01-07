using UnityEngine;

/// <summary>
/// Extend LayerMask to add useful functions related to selection
/// </summary>
public static class LayerMaskExtensions
{
    public static bool OnLayer(this ref LayerMask target, GameObject gameObject)
    {
        return ((1 << gameObject.layer) & target.value) != 0;
    }
}