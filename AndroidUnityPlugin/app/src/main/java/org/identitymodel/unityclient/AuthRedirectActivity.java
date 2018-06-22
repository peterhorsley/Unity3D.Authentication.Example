package org.identitymodel.unityclient;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.Window;

import com.unity3d.player.UnityPlayer;

// An activity to handle auth redirects on Android.
// The value query string is sent to the OnAuthReply method on the
// SignInBehavior script on the SignInCanvas object in the Unity scene.
public class AuthRedirectActivity extends Activity {

    private static String TAG = "AuthRedirectActivity";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        Log.v(TAG, "onCreate");
        Uri dataUri = getIntent().getData();
        if (dataUri != null) {
            Log.v(TAG, String.format("Data uri: [%s]", dataUri.toString()));
            String query = dataUri.getQuery();
            if (query != null) {
                Log.v(TAG, String.format("Data uri query: [%s]", query));
                UnityPlayer.UnitySendMessage("SignInCanvas", "OnAuthReply", query);
            }
        }

        Log.v(TAG, "Returning to main activity");
        Intent newIntent = new Intent(this, getMainActivityClass());
        this.startActivity(newIntent);
        finish();
    }

    private Class<?> getMainActivityClass() {
        String packageName = this.getPackageName();
        Intent launchIntent = this.getPackageManager().getLaunchIntentForPackage(packageName);
        try {
            return Class.forName(launchIntent.getComponent().getClassName());
        } catch (Exception e) {
            Log.e(TAG, "Unable to find Main Activity Class");
            return null;
        }
    }
}
