using System.Threading.Tasks;
using IdentityModel.OidcClient.Browser;
using UnityEngine;

namespace Assets
{
    public abstract class MobileBrowser : IBrowser
    {
        private TaskCompletionSource<BrowserResult> _task;

        public Task<BrowserResult> InvokeAsync(BrowserOptions options)
        {
            _task = new TaskCompletionSource<BrowserResult>();
            Launch(options.StartUrl);
            return _task.Task;
        }

        protected abstract void Launch(string url);
        public virtual void Dismiss() { }

        public void OnAuthReply(string value)
        {
            Debug.Log("MobileBrowser.OnAuthReply: " + value);
            _task.SetResult(new BrowserResult()
            {
                Response = value
            });
        }
    }
}
