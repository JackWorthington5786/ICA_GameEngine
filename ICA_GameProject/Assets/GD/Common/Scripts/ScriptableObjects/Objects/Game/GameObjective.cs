using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores data relating to a level objective
/// </summary>
/// <see cref="ARVR.ScriptableTypes.RuntimeGameObjectiveList"/>
namespace GD
{
    [CreateAssetMenu(fileName = "GameObjective", menuName = "DkIT/Scriptable Objects/Game/Objective", order = 4)]
    public class GameObjective : ScriptableObject
    {
        //[ColorPalette]  //Odin Inspector Demo
        //public Color color;

        [Tooltip("Set by the script attached to the object or by the game manager. By default all objectives are not completed at level startup")]
        public bool IsCompleted;

        [Tooltip("Shown on-screen as dialog text or in a UI. Note: Length will affect UI layout and font size")]
        public string Description;

        [Tooltip("Transform specifying the position for the objective")]
        public Transform Position;

        [Tooltip("May be used by a dialog box or UI element to add an icon to the objective description")]
        [PreviewField(50, ObjectFieldAlignment.Left)]
        public Sprite Icon;

        #region Waypoint Prompt

        [TabGroup("tab1", "Waypoint Prompt", SdfIconType.ChatTextFill)]
        [Tooltip("Flag indicating that we show a keyword on proximity to the objective")]
        public bool ShowPrompt = true;

        [TabGroup("tab1", "Waypoint Prompt")]
        [ShowIf("ShowPrompt")]
        [Tooltip("Specify action keyword shown with objective waypoint marker (e.g. Activate, Protect, Unlock)")]
        public string Keyword;

        [TabGroup("tab1", "Waypoint Prompt")]
        [ShowIf("ShowPrompt")]
        [Tooltip("Priority used to mark how important objectives are when completing the level (default is Normal)")]
        [EnumToggleButtons]
        public PriorityType Priority = PriorityType.Normal;

        [TabGroup("tab1", "Waypoint Prompt")]
        [ShowIf("ShowPrompt")]
        [Tooltip("Specify when an onscreen waypoint is shown")]
        [EnumToggleButtons]
        public VisibilityStrategyType KeyworkVisibility = VisibilityStrategyType.AlwaysShow;

        [TabGroup("tab1", "Waypoint Prompt")]
        [ShowIf("ShowPrompt")]
        [MinValue(0)]
        [Unit(Units.Meter)]
        [Tooltip("If visibility is Show Within then the waypoint will only show within the radius specified")]
        public float ShowRadius;

        #endregion Waypoint Prompt

        #region Time Dependent

        [TabGroup("tab1", "Time Dependent (optional)", SdfIconType.HourglassSplit)]
        [Tooltip("Flag indicating that the objective must be completed in the timeLimitSecs duration")]
        public bool IsTimeLimited = true;

        [TabGroup("tab1", "Time Dependent (optional)")]
        [MinValue(0)]
        [Unit(Units.Second)]
        [ShowIf("IsTimeLimited")]
        [Tooltip("Amount of time before which the player will automatically fail to complete the level objectives")]
        public int timeLimitSecs;

        #endregion Time Dependent

        #region Feedback

        [TabGroup("tab1", "Feedback (optional)", SdfIconType.HandThumbsUpFill)]
        [Tooltip("Completion text shown when the objective has been achieved")]
        public string AchievementText;

        [TabGroup("tab1", "Feedback (optional)")]
        [Tooltip("Audio clip played when the objective has been achieved")]
        public AudioClip AchievementAudioClip;

        [TabGroup("tab1", "Feedback (optional)")]
        [Tooltip("Audio clip played when the time limit is being reached")]
        public AudioClip TimeLimitAudioClip;

        [TabGroup("tab1", "Feedback (optional)")]
        [Range(0, 60)]
        [Tooltip("Time in seconds before the time limit elapses when we start to play the time limit audio clip. Must be less than Time Limit Secs value.")]
        public float PlayBeforeSecs = 0;

        #endregion Feedback
    }
}