using System;
using System.Diagnostics;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Xamarin.iOS.Experiments
{
	public static class ButtonStyling
	{
		/// <summary>
		/// Vertically aligns the image and text center on button.
		/// <remarks>
		/// 1) Button control alignment should be center for vertical and horizontal directions in IB.
		/// 2) Image should be able to fit into the button without scaling for the calculation to work.
		/// 3) Set Button type to Custom to avoid the image being displayed in blue as a System button.
		/// </remarks>
		/// </summary>
		/// <returns>The image and text center on button.</returns>
		/// <param name="button">Button.</param>
		/// <param name="spacing">The space between the image and text.</param>
		/// <param name="textLines">How many lines of the text.</param>
		public static void VerticalAlignImageAndText(UIButton button, float spacing = 6, int textLines = 1)
		{
			// UIButton: how to center an image and a text using imageEdgeInsets and titleEdgeInsets?
			// http://stackoverflow.com/questions/2451223/uibutton-how-to-center-an-image-and-a-text-using-imageedgeinsets-and-titleedgei

			// Reset the content edge inset
			button.ContentEdgeInsets = new UIEdgeInsets(0, 0, 0, 0);

			// Lower the text and push it left so it appears centered below the image
			CGSize imageSize = button.ImageView.Image.Size;
			button.TitleEdgeInsets = new UIEdgeInsets(0, -imageSize.Width, -(imageSize.Height + spacing), 0);

			button.TitleLabel.TextAlignment = UITextAlignment.Center;

			// Raise the image and push it right so it appears centered above the text
			CGSize titleSize = (new NSString(button.TitleLabel.Text)).GetSizeUsingAttributes(new UIStringAttributes { Font = button.TitleLabel.Font });

			button.ImageEdgeInsets = new UIEdgeInsets(-(titleSize.Height * textLines + spacing), 0, 0, -titleSize.Width);

			// Increase the content height to avoid clipping
			float edgeOffset = (float)Math.Abs(titleSize.Height - imageSize.Height) / 2;
			button.ContentEdgeInsets = new UIEdgeInsets(edgeOffset, 0, edgeOffset, 0);

			Debug.WriteLine("ButtonStyling.VerticalAlignImageAndText result:");
			Debug.WriteLine("button.ImageEdgeInsets: " + button.ImageEdgeInsets);
			Debug.WriteLine("button.TitleEdgeInsets: " + button.TitleEdgeInsets);
		}

		/// <summary>
		/// Horizontally aligns the text and image on button.
		/// </summary>
		/// <returns>The align image and text.</returns>
		/// <param name="button">Button.</param>
		public static void HorizontalAlignTextAndImage(UIButton button)
		{
			// Display Button With Text & Image In Xamarin IOS
			// http://stackoverflow.com/questions/37089317/display-button-with-text-image-in-xamarin-ios

			button.TitleEdgeInsets = new UIEdgeInsets(0, -button.ImageView.Frame.Size.Width, 0, button.ImageView.Frame.Size.Width);
			button.ImageEdgeInsets = new UIEdgeInsets(0, button.TitleLabel.Frame.Size.Width, 0, -button.TitleLabel.Frame.Size.Width);
		}
	}
}

