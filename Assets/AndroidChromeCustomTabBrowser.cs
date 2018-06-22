namespace Assets
{
    public class AndroidChromeCustomTabBrowser : MobileBrowser
    {
        protected override void Launch(string url)
        {
            AndroidChromeCustomTab.LaunchUrl(url);
        }
    }
}
