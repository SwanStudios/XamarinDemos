using System.Threading.Tasks;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Phoneword.iOS;
using System;

[assembly: Dependency(typeof(PhoneDialer))]

namespace Phoneword.iOS
{
	public class PhoneDialer : PhoneWord.IDialer
	{
        public Task<bool> DialAsync(string number)
		{
			return Task.FromResult( 
				UIApplication.SharedApplication.OpenUrl(
				new NSUrl("tel:" + number))
			);
		}
	}
}
