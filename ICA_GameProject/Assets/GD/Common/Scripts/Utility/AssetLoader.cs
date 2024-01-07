using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GD
{
    /// <summary>
    /// Used to load GameObject prefabs or ScriptableGameObjects from a specified folder
    /// </summary>
    public static class AssetLoader

    {
        public static List<AudioClip> FindAudioClips(string folderPath, string filter = "t:AudioClip")
        {
            List<AudioClip> assetList = new List<AudioClip>();

            // Get all asset paths in the specified folder
            string[] assetPaths = AssetDatabase.FindAssets(filter, new[] { folderPath });

            foreach (string assetPath in assetPaths)
            {
                // Load the prefab at the given path
                AudioClip clip = AssetDatabase.LoadAssetAtPath<AudioClip>(AssetDatabase.GUIDToAssetPath(assetPath));

                if (clip != null)
                    assetList.Add(clip);
            }

            return assetList;
        }

        public static List<GameObject> FindPrefabs(string folderPath, string filter = "t:Prefab")
        {
            List<GameObject> assetList = new List<GameObject>();

            // Get all asset paths in the specified folder
            string[] assetPaths = AssetDatabase.FindAssets(filter, new[] { folderPath });

            foreach (string assetPath in assetPaths)
            {
                // Load the prefab at the given path
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(assetPath));

                if (prefab != null)
                    assetList.Add(prefab);
            }

            return assetList;
        }

        public static List<T> FindByType<T>(string folderPath) where T : Object
        {
            string[] guids = AssetDatabase.FindAssets($"t:{typeof(T)}", new[] { folderPath });
            List<T> assetList = new List<T>();

            foreach (string guid in guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                T asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);

                if (asset != null)
                {
                    assetList.Add(asset);
                }
            }

            return assetList;
        }

        public static List<ScriptableObject> FindScriptableObjects(string folderPath, string filter = "t:Asset")
        {
            List<ScriptableObject> assetList = new List<ScriptableObject>();

            // Get all asset paths in the specified folder
            string[] assetPaths = AssetDatabase.FindAssets(filter, new[] { folderPath });

            foreach (string assetPath in assetPaths)
            {
                // Load the prefab at the given path
                ScriptableObject prefab
                    = AssetDatabase.LoadAssetAtPath<ScriptableObject>(AssetDatabase.GUIDToAssetPath(assetPath));

                if (prefab != null)
                    assetList.Add(prefab);
            }

            return assetList;
        }
    }
}