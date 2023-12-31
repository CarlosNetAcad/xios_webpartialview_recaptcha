// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Drawing;
using CoreGraphics;
using Foundation;
using UIKit;
using WebKit;
using RecaptchaEnterprise.Services;

namespace RecaptchaEnterprise
{
	public partial class CustomViewController : UIViewController,IWKScriptMessageHandler
	{
        String _uIRecaptchaEntry;

		public CustomViewController (IntPtr handle) : base (handle)
		{
            //var frame = new CGRect(10, 10, 300, 40);
            
            //LoadingWebPage();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            /*_uIRecaptchaEntry = new UITextField();
            _uIRecaptchaEntry.Frame = new RectangleF(20, 13, 200, 31);
            View.AddSubview(_uIRecaptchaEntry);*/

            LoadingWebPage();
        }

        private void OnShowHandler(object sender, EventArgs e)
        {
            
            
        }

        private void LoadingWebPage()
        {
            var config = new WKWebViewConfiguration();

            var contentController = new WKUserContentController();

            contentController.AddScriptMessageHandler(this, "tokenHandler");

            config.UserContentController = contentController;



            RecaptchaWebViewUI = new WKWebView(
                View.Bounds,
                config
            );

        

            View.AddSubview(RecaptchaWebViewUI);
            var urlPath = NSBundle.MainBundle.PathForResource("_index","html");
            var url = new NSUrl("file://" + urlPath);
            var request = new NSUrlRequest(url);

            RecaptchaWebViewUI.LoadRequest(request);
        }

        [Export("userContentController:didReceiveScriptMessage:")]
        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            Console.WriteLine(message.Body.ToString());

            if (message.Name == "tokenHandler")
            {
                var token = message.Body as NSString;
                // Handle the reCAPTCHA response token

                Console.WriteLine(token);
            }
        }
    }
}
