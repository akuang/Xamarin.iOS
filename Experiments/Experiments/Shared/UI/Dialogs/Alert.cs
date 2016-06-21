using System;
using UIKit;

namespace Xamarin.iOS.Experiments
{
    public class Alert
    {
		/// <summary>
		/// Shows Alert dialog with specified titile and message.
		/// </summary>
		/// <remarks><see cref="UIAlertView"/> API is deprecated in iOS 9.0</remarks>
		/// <param name="titile">Titile.</param>
		/// <param name="message">Message.</param>
		public static UIAlertView Message(string titile, string message)
        {
            UIAlertView alertView = new UIAlertView(
                titile,
                message,
                null,
                "OK",
                null);
            alertView.Show();

            return alertView;
        }

        /// <summary>
        /// Shows Error Alert dialog with specified message.
        /// </summary>
        /// <param name="message">Message.</param>
        public static UIAlertView Error(string message)
        {
            return Message("Error!", message);
        }

		/// <summary>
		/// Shows Success Alert dialog with specified message.
		/// </summary>
		/// <param name="message">Message.</param>
		public static UIAlertView Success(string message)
		{
			return Message("Success!", message);
		}

	}
}

