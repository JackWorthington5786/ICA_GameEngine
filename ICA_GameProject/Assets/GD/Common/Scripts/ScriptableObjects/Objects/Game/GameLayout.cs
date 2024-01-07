using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores data relating to a complete game (i.e. multiple levels)
/// </summary>
/// <see cref="https://blogs.unity3d.com/2020/07/01/achieve-better-scene-workflow-with-scriptableobjects/"/>
namespace GD
{
    [CreateAssetMenu(fileName = "GameLayout", menuName = "DkIT/Scriptable Objects/Game/Layout", order = 1)]
    public class GameLayout : ScriptableObject
    {
        #region Title & Level Layout

        [Header("Title")]
        public string Title;

        #region Level

        [TabGroup("layout_tabs", "Levels", SdfIconType.Diagram2Fill)]
        [Min(0)]
        [Tooltip("Zero-based index in the list of level layouts for the start level in the game (e.g. 0)")]
        public int StartLevel;

        [TabGroup("layout_tabs", "Levels")]
        [Searchable]
        public List<GameLevel> Levels;

        [TabGroup("layout_tabs", "Levels")]
        [Header("Debug")]
        [ReadOnly]
        public bool IsLevelLoaded;

        [TabGroup("layout_tabs", "Levels")]
        [ReadOnly]
        public int CurrentLevel;

        #endregion Level

        #endregion Title & Level Layout

        #region Menu

        [TabGroup("layout_tabs", "Menus", SdfIconType.MenuAppFill)]
        public GameScene MainMenu;

        [TabGroup("layout_tabs", "Menus")]
        public GameScene PauseMenu;

        [TabGroup("layout_tabs", "Menus")]
        public GameScene UIMenu;

        #endregion Menu

        #region Development Team & Version

        [TabGroup("layout_tabs", "Development Team", SdfIconType.PeopleFill)]
        public string ProductOwner;

        [TabGroup("layout_tabs", "Development Team")]
        public string TeamLead;

        [TabGroup("layout_tabs", "Development Team")]
        public string TestLead;

        [TabGroup("layout_tabs", "Development Team")]
        [TableList(AlwaysExpanded = true, DrawScrollView = true, ShowIndexLabels = false)]
        [Searchable]
        public List<TeamMember> TeamMembers;

        [TabGroup("layout_tabs", "Documentation (optional)", SdfIconType.BookFill)]
        [EnumPaging]
        public LifecycleStageType Stage;

        [TabGroup("layout_tabs", "Documentation (optional)")]
        [ReadOnly]
        public string StageDescription;

        [TabGroup("layout_tabs", "Documentation (optional)")]
        public string RepositoryURL;

        [TabGroup("layout_tabs", "Documentation (optional)")]
        [Min(1)]
        public float Version;

        private void OnValidate()
        {
            //set the description for the lifecycle stage
            StageDescription = EnumExtensions.GetDescription(Stage);
        }

        #endregion Development Team & Version

        [ContextMenu("Load Level")]
        public void LoadLayout()
        {
            if (Levels.Count == 0)
                return;

            Levels[StartLevel].LoadLevel();

            IsLevelLoaded = true;
        }

        [ContextMenu("Unload Level")]
        public void UnloadLayout()
        {
            if (Levels.Count == 0)
                return;

            Levels[StartLevel].UnloadLevel();

            IsLevelLoaded = false;
        }

        #region TODO

        //TODO
        public void NextLevel()
        {
            //load next level
        }

        //Restart current level
        public void RestartLevel()
        {
            //reset
        }

        //New game, load level 1
        public void NewGame()
        {
            //set current back to start level
        }

        public void LoadMainMenu()
        {
            // SceneManager.LoadSceneAsync(/*main name*/);
        }

        public void LoadPauseMenu()
        {
            // SceneManager.LoadSceneAsync(/*pause name*/);
        }

        public void SaveGame()
        {
            // AssetDatabase
        }

        #endregion TODO
    }
}