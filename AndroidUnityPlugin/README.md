# AndroidUnityPlugin

What is this project?
- This is a minimal Android library project that provides auth redirect handling back to the Unity Android app.

How does it work?
 - The AndroidManifest.xml file stored in Assets/Plugins/Android folder includes the definition of the AuthRedirectActivity
   and adds an intent filter for the custom scheme used for the redirect.  When an intent is launched on Android with this custom
   scheme, the AuthRedirectActivity is instantiated and the value of the uri is sent in a message back to a Unity game object.
   Then, the main activity (UnityPlayerActivity) is launched and the AuthRedirectActivity is finished.

How is it built?
-  Run (double-click) the exportJar Gradle task, this will produce a new AndroidUnityPlugin.jar 
   file and copy it into the the Assets/Plugins/Android folder in the Unity project.
   This jar file and associated source code changes should be committed to your repo.
   
Anything else?
 - If a new version of Unity is released, it may be necessary to copy the classes.jar file from:
   C:\Program Files\Unity 2018.1\Editor\Data\PlaybackEngines\AndroidPlayer\Variations\mono\Release\Classes\classes.jar
   to:
   \AndroidUnityPlugin\app\libs\classes.jar
   
Relevent links for how this project was constructed are:
 - https://blog.getsocial.im/android-unity-app-and-the-intent-issue/
 - http://addcomponent.com/android-native-plugin-unity/
 - https://www.theseus.fi/bitstream/handle/10024/139801/kuitunen_jeremias.pdf?sequence=1&isAllowed=y