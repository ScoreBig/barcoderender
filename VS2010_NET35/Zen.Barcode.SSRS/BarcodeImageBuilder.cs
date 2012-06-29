// -----------------------------------------------------------------------
// <copyright file="BarcodeImageBuilder.cs" company="Zen Design Corp">
//     Copyright © Zen Design Corp 2012. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Zen.Barcode.SSRS
{
	using System.Drawing;
	using System.Drawing.Imaging;
	using System.IO;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public class BarcodeImageBuilder
	{
		public BarcodeImageBuilder()
		{
			Symbology = BarcodeSymbology.Unknown;
			MaximumBarHeight = 30;
		}

		/// <summary>
		/// Gets or sets the symbology.
		/// </summary>
		/// <value>The symbology.</value>
		public BarcodeSymbology Symbology
		{
			get;
			set;
		}

		public int MaximumBarHeight
		{
			get;
			set;
		}

		public string Text
		{
			get;
			set;
		}

		public bool RenderVertically
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the barcode image based on the current barcode builder
		/// properties.
		/// </summary>
		/// <returns>
		/// Returns a raw byte array of the barcode in standard BMP format.
		/// </returns>
		public byte[] GetBarcodeImage()
		{
			// Create draw object
			BarcodeDraw drawObject = BarcodeDrawFactory.GetSymbology(Symbology);

			// Get default metrics
			BarcodeMetrics metrics = drawObject.GetDefaultMetrics(MaximumBarHeight);

			// TODO: Allow overriding of defaults with builder properties

			// Draw image
			Image image = drawObject.Draw(Text, metrics);

			// Handle rotating if necessary
			if (RenderVertically)
			{
				image.RotateFlip(RotateFlipType.Rotate90FlipNone);
			}

			// Create memory stream for new image
			using (MemoryStream stream = new MemoryStream())
			{
				// Save image and return raw byte array
				image.Save(stream, ImageFormat.Bmp);
				return stream.ToArray();
			}
		}
	}
}
