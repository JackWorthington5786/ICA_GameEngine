using System;

namespace GD
{
    /// <summary>
    /// Defines the type of unit that an NPC will attack
    /// </summary>
    /// <see cref="ARVR.Objects.PlaceableObjectData"/>
    [Flags]
    public enum AttackTargetType : sbyte
    {
        Building = 1,
        Unit = 2,
        Vehicle = 8,
        None = 0
    }
}