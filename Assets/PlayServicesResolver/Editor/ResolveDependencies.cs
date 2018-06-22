using UnityEditor;
using Google.JarResolver;

[InitializeOnLoad]
public static class ResolveDependencies
{
    static ResolveDependencies()
    {
        var SvcSupport = PlayServicesSupport.CreateInstance(
            "GooglePlayGames", EditorPrefs.GetString("AndroidSdkRoot"), "ProjectSettings"
        );
        SvcSupport.DependOn("com.android.support", "customtabs", "23.0.0");
    }
}