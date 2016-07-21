using System;
using UIKit;

namespace Xamarin.iOS.Experiments
{
	public static class UIColorExtensions
	{
		/// <summary>
		/// Converts the HEX color value to UIColor.
		/// Usage example: 
		/// <code>var color = UIColor.Clear.FromHex(0xD12229);</code>
		/// </summary>
		/// <returns>The <see cref="UIColor"/> value.</returns>
		/// <param name="color">Color.</param>
		/// <param name="hexValue">Color HEX value.</param>
		public static UIColor FromHex(this UIColor color, int hexValue)
		{
			// UIColor from Hex in Monotouch
			// http://stackoverflow.com/questions/10310917/uicolor-from-hex-in-monotouch
			return UIColor.FromRGB(
				(((float)((hexValue & 0xFF0000) >> 16)) / 255.0f),
				(((float)((hexValue & 0xFF00) >> 8)) / 255.0f),
				(((float)(hexValue & 0xFF)) / 255.0f)
			);
		}
	}
}

