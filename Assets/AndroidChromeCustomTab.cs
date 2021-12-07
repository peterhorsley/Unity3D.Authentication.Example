using UnityEngine;

namespace Assets
{
    public static class AndroidChromeCustomTab
    {
        // See: https://qiita.com/lucifuges/items/b17d602417a9a249689f (Google translate to English!)
        public static void LaunchUrl(string url)
        {
#if UNITY_ANDROID
            using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            using (var intentBuilder = new AndroidJavaObject("androidx.browser.customtabs.CustomTabsIntent$Builder"))
            using (var intent = intentBuilder.Call<AndroidJavaObject>("build"))
            using (var uriClass = new AndroidJavaClass("android.net.Uri"))
            using (var uri = uriClass.CallStatic<AndroidJavaObject>("parse", url))
            {
                intent.Call("launchUrl", activity , uri);
            } 
#endif
        }
    }
}
