using System.IO;
using UnityEditor;

/// <summary>
/// Add an Assets menu option to build an assets bundle
/// </summary>
/// <see cref="https://vraulet.medium.com/using-asset-bundles-to-load-external-asset-in-unity-1b69f85ea7c7#:~:text=Scene%20in%20AssetBundle,%2FScene1%20in%20this%20example)."/>
/// <see cref="https://learn.unity.com/tutorial/introduction-to-asset-bundles-1#5ce589b4edbc2a106aa7b47c"/>
/// <seealso cref="Bootloader"/>

public static class BuildAssetBundles
{
    [MenuItem("Tools/DkIT/Asset Bundles/Build AssetBundles")]
    private static void BuildAssetBundlesMenu()
    {
        if (AssetBundleAndroidTarget.IsEnabled)
            BuildAssetBundle("AssetBundles/Android", BuildTarget.Android);

        if (AssetBundleWindowsTarget.IsEnabled)
            BuildAssetBundle("AssetBundles/Windows", BuildTarget.StandaloneWindows64);
    }

    private static void BuildAssetBundle(string assetBundleDirectory, BuildTarget target)
    {
        if (!Directory.Exists(assetBundleDirectory))
            Directory.CreateDirectory(assetBundleDirectory);

        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, target);
    }
}