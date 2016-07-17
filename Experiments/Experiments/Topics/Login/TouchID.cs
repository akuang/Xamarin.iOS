using System;
using Foundation;
using LocalAuthentication;
using UIKit;

namespace Xamarin.iOS.Experiments
{
    public class TouchID
    {
        /// <summary>
        /// Introduction to Touch ID:
        /// https://developer.xamarin.com/guides/ios/platform_features/introduction_to_touchid/
        /// </summary>
        public static void Login(UIViewController owner)
        {
            var context = new LAContext();
            NSError AuthError;
            var myReason = new NSString("Please authenticate to proceed");

            if (context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out AuthError))
            {
                var replyHandler = new LAContextReplyHandler((success, error) =>
                {
                    owner.InvokeOnMainThread(() =>
                    {
                        if (success)
                        {
                            Alert.Success("You logged in!");
                        }
                        else
                        {
                            Alert.Error("Login Failed");
                        }
                    });

                });
                context.EvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, myReason, replyHandler);
            }
            else
            {
				Alert.Message("Reminder!", "TouchID not Enabled.");
            }
        }
   }
}

