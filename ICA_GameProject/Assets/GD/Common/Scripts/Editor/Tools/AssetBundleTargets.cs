using UnityEditor;

/// <summary>
/// Adds Tools menu option to set build target for Asset Bundles
/// </summary>
/// <see cref="https://vraulet.medium.com/using-asset-bundles-to-load-external-asset-in-unity-1b69f85ea7c7#:~:text=Scene%20in%20AssetBundle,%2FScene1%20in%20this%20example)."/>
[InitializeOnLoad]
public static class AssetBundleAndroidTarget
{
    private const string MenuPath = "Tools/DkIT/Asset Bundles/Targets/Android";

    public static bool IsEnabled;

    static AssetBundleAndroidTarget()
    {
        IsEnabled = EditorPrefs.GetBool(MenuPath, true);
    }

    [MenuItem(MenuPath)]
    private static void ToggleAction()
    {
        IsEnabled = !IsEnabled;
        EditorPrefs.SetBool(MenuPath, IsEnabled);
    }

    [MenuItem(MenuPath, true)]
    private static bool ToggleActionValidate()
    {
        Menu.SetChecked(MenuPath, IsEnabled);
        return true;
    }
}

[InitializeOnLoad]
public static class AssetBundleWindowsTarget
{
    private const string MenuPath = "Tools/DkIT/Asset Bundles/Targets/Windows";

    public static bool IsEnabled;

    static AssetBundleWindowsTarget()
    {
        IsEnabled = EditorPrefs.GetBool(MenuPath, true);
    }

    [MenuItem(MenuPath)]
    private static void ToggleAction()
    {
        IsEnabled = !IsEnabled;
        EditorPrefs.SetBool(MenuPath, IsEnabled);
    }

    [MenuItem(MenuPath, true)]
    private static bool ToggleActionValidate()
    {
        Menu.SetChecked(MenuPath, IsEnabled);
        return true;
    }
}