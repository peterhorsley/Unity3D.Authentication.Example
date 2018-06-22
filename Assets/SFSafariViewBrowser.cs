namespace Assets
{
    public class SFSafariViewBrowser : MobileBrowser
    {
        protected override void Launch(string url)
        {
            SFSafariView.LaunchUrl(url);
        }

        public override void Dismiss()
        {
            SFSafariView.Dismiss();
        }
    }
}
