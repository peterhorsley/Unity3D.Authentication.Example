using System.Runtime.InteropServices;
using UnityEngine;

public static class SFSafariView
{
#if UNITY_IOS
    [DllImport("__Internal")]
    extern static void launchUrl(string url);
    [DllImport("__Internal")]
    extern static void dismiss();
#endif

    public static void LaunchUrl(string url)
    {
#if UNITY_IOS
        launchUrl(url);
#endif
    }

    public static void Dismiss()
    {
#if UNITY_IOS
        dismiss();
#endif
    }
}
