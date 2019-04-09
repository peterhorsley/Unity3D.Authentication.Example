# Unity3D Android/iOS Authentication Example

Mobile applications that need OpenID Connect / OAuth 2 authentication would normally use a library like Google's [AppAuth](https://github.com/openid/AppAuth-Android), which is available for Android and iOS, but unfortunatley *not* for Unity Android/iOS apps.

Luckily, there's a C# library that does work: [IdentityModel.OidcClient2](https://github.com/IdentityModel/IdentityModel.OidcClient2).  This is not just a drop-in package, however - there are quite a few steps to configure your Unity project to use it successfully.  
But it's not too onerous, and the end result is your app will use SFSafariViewController on iOS and Chrome Custom Tabs on Android, and be able to work with any OAuth 2 / OpenID Connect server.

This repository contains an example Unity 2018.1 Android/iOS app that demonstrates how this can be achieved.  It uses a demo instance of identityserver (https://demo.identityserver.io) - you can see the source code [here](https://github.com/IdentityServer/IdentityServer4.Demo). Vidoes of the example running: [Android](https://codenature.info/pub/unityauth/android-identitymodel-unity-sample.mp4) and [iOS](https://codenature.info/pub/unityauth/iphone-identitymodel-unity-sample.mp4).

You can login with `alice/alice` or `bob/bob`

## Unity configuration notes:

* Ensure your Unity project's .NET version is set to 4.x in player settings.
* Unity does not support nuget nicely, so you must clone and compile IdentityModel.OidcClient2 solution using Visual Studio 2017.
* Copy the release binaries from IdentityModel.OidcClient/bin/release/net452 to a folder in your Unity project's Assets folder.
* Delete System.Runtime.InteropServices.RuntimeInformation.dll as this DLL is not compatible with Unity.  
* Import Json.Net.Unity3D package available from https://github.com/SaladLab/Json.Net.Unity3D.
* You must then move Newtonsoft.Json.dll from Assets/UnityPackages/JsonNet/ to the same location as your OidcClient binaries.
* Add link.xml and mcs.rsp files to your Assets folder.

## iOS support

* Derive an objective-c class from UnityAppController to handle auth redirects (see OAuthUnityAppController.mm).
* Include a class for interacting with SFSafariViewController in Assets/Plugins/iOS (see SafariView.mm).
* In Unity, select SafariView.mm in Project view, and in Inspector pane, under 'Rarely used services' select 'SafariServices'.

## Android support

* Import the Google Play Services Resolver for Unity package from https://github.com/googlesamples/unity-jar-resolver
 (currently play-services-resolver-1.2.72.0.unitypackage)
* Add ResolveDependencies.cs to /Assets/PlayServicesResolver/Editor/ with code to include the android support library.
* In Unity, go to menu Assets -> Play Services Resolver -> Android Resolver -> Resolve Client Jars.
* You should now have customtabs-23.0.0 and support-annotations-23.0.0 in /Assets/Plugins/Android folder.
* Add an Android Unity plugin project to handle auth redirects (see AndroidUnityPlugin project).
* You will need to copy classes.jar from your Unity install folder e.g. C:\Program Files\Unity\Editor\Data\PlaybackEngines\AndroidPlayer\Variations\mono\Release\Classes\classes.jar to AndroidUnityPlugin/app/libs.
* This project contains an activity that handles auth redirects and some build scripts to export the project as a JAR file.
* Create/modify Assets/Plugins/Android/AndroidManifest.xml to include the OAuthRedirectActivity, ensuring it has the redirect URL specified in the data element's schema attribute.

## Important: Unity Version Update

* Use with Unity 2018.3
* When using Unity in a newer version, it may be necessary to copy the classes.jar file from:
   C:\Program Files\Unity 2018.x\Editor\Data\PlaybackEngines\AndroidPlayer\Variations\mono\Release\Classes\classes.jar
   to:
   \AndroidUnityPlugin\app\libs\classes.jar

## References

Two critical blog posts that enabled me to work out how to achieve this:

* [Open SFSafariViewController / Chrome Custom Tabs from Unity](https://qiita.com/lucifuges/items/b17d602417a9a249689f) (use Google Translate)
* [Create An Android Plugin For Unity Using Android Studio](http://www.thegamecontriver.com/2015/04/android-plugin-unity-android-studio.html)

Code samples using IdentityModel.OidcClient2 for other platforms [here](https://github.com/IdentityModel/IdentityModel.OidcClient.Samples).