using UnityEngine;

/// <summary>
/// Provides extension methods for the Vector3 class
/// </summary>
/// <see cref="https://www.tutorialsteacher.com/csharp/csharp-extension-method"/>

public static class Vector3Extensions
{
    /// <summary>
    /// Sets the x, y, z values in a source Vector3 object, if provided, otherwise uses original x, y, or z value
    /// </summary>
    /// <param name="source">Vector3</param>
    /// <param name="x">float</param>
    /// <param name="y">float</param>
    /// <param name="z">float</param>
    /// <returns>Vector3 instance with x, y, z set, where provided</returns>
    public static Vector3 Set(this Vector3 source, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? source.x, y ?? source.y, z ?? source.z);
    }

    /// <summary>
    /// Returns a normalized vector in the direction of target - source
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static Vector3 GetDirection(this Vector3 source, Vector3 target)
    {
        Vector3 direction = target - source;
        (target - source).Normalize();
        return direction;
    }

    /// <summary>
    /// Sets any vector to a user-specified Y-axis ground level
    /// </summary>
    /// <param name="original"></param>
    /// <param name="ground"></param>
    public static void ToGround(this Vector3 original, float ground)
    {
        original.y = ground;
    }
}