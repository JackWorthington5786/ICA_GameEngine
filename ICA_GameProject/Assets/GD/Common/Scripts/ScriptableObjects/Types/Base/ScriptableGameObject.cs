using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace GD
{
    public class ScriptableGameObject : ScriptableObject
    {
        private static readonly string LastUpdateStringFormat = "dd/MM/yy HH:mm:ss";

        #region Fields

        [PropertyOrder(1000)]
        [FoldoutGroup("Developer Info")]
        [SerializeField]
        //   [ReadOnly]
        [Tooltip("A unique ID to identify each consumable, interactable, placeable instance")]
        private string uniqueID = System.Guid.NewGuid().ToString();

        [PropertyOrder(1000)]
        [FoldoutGroup("Developer Info")]
        [SerializeField]
        [ReadOnly]
        [Tooltip("Show time of last update")]
        public string LastUpdated = DateTime.Now.ToString(LastUpdateStringFormat);

        [PropertyOrder(1000)]
        [FoldoutGroup("Developer Info")]
        [SerializeField]
        [Tooltip("Team member who last updated this object")]
        public string LastUpdatedBy = string.Empty;

        [PropertyOrder(1000)]
        [FoldoutGroup("Developer Info")]
        [SerializeField]
        [Tooltip("Add notes on changes, bugs, future features")]
        [TextArea(2, 4)]
        public string Notes = string.Empty;

        [ContextMenuItem("Reset Description", "ResetDescription")]
        [TextArea(2, 4)]
        public string Description = string.Empty;

        public string UniqueID { get => uniqueID; protected set => uniqueID = value; }

        #endregion Fields

        #region Core Methods

        /// <summary>
        /// Self-explanatory...I hope
        /// </summary>
        public void ResetName()
        {
            Description = "";
        }

        /// <summary>
        /// Update some fields when we change something in the object
        /// </summary>
        private void OnValidate()
        {
            LastUpdated = DateTime.Now.ToString(LastUpdateStringFormat);
        }

        /// <summary>
        /// Overridden in child classes to specify what a reset means (e.g. clear the list, reset the int, empty the string
        /// </summary>
        public virtual void Reset()
        {
            //noop - (no operation - not called)
        }

        #endregion Core Methods
    }
}