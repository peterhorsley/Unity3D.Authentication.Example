using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
using System.Collections;

public class BuildPostProcess {

    // Runs all the post process build steps. Called from Unity during build
    [PostProcessBuildAttribute(0)] // Configures this this post process to run first
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
#if UNITY_IOS

        var infoPlist = new UnityEditor.iOS.Xcode.PlistDocument();
        var infoPlistPath = pathToBuiltProject + "/Info.plist";
        infoPlist.ReadFromFile(infoPlistPath);

        // Register ios URL scheme for external apps to launch this app.
        var urlTypeDict = infoPlist.root.CreateArray("CFBundleURLTypes").AddDict();
        urlTypeDict.SetString("CFBundleURLName","org.identitymodel.unityclient");
        var urlSchemes = urlTypeDict.CreateArray("CFBundleURLSchemes");
        urlSchemes.AddString("io.identitymodel.native");

        infoPlist.WriteToFile(infoPlistPath);

#endif
    }
}
