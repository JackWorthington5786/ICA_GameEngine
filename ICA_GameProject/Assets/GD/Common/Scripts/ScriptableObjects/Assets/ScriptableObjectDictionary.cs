using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "ScriptableObjectDictionary",
        menuName = "DkIT/Scriptable Objects/Assets/ScriptableObjects")]
    public class ScriptableObjectDictionary : ScriptableGameObject
    {
        [Tooltip("Relative folder path under Assets")]
        [Required]
        [InlineButton("LoadScriptableObjects", "Load ScriptableObjects", Icon = SdfIconType.FileTextFill)]
        [FolderPath(ParentFolder = "Assets", RequireExistingPath = true)]
        public string FolderPath;

        [Tooltip("Stores <GUID, object dictionary> for all ScriptableObjects within a user-defined folder")]
        public Dictionary<string, ScriptableObject> Prefabs;

        private void LoadScriptableObjects()
        {
            if (FolderPath == null || FolderPath.Length == 0)
                return;

            if (Prefabs == null)
                Prefabs = new Dictionary<string, ScriptableObject>();

            if (Prefabs.Count > 0)
                Prefabs.Clear();

            List<ScriptableObject> prefabList
                = AssetLoader.FindByType<ScriptableObject>("Assets/" + FolderPath);

            foreach (ScriptableObject prefab in prefabList)
                Prefabs.TryAdd(prefab.name, prefab);
        }
    }
}