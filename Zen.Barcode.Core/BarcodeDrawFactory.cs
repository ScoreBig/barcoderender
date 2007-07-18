using System;
using System.Collections.Generic;
using System.Text;

using Zen.Barcode.Properties;

namespace Zen.Barcode
{
	/// <summary>
	/// <b>BarcodeDrawFactory</b> returns draw agents capable of generating 
	/// the appropriate bar-code image.
	/// </summary>
	public static class BarcodeDrawFactory
	{
		#region Private Fields
		private static Code39BarcodeDraw _code39WithoutChecksum;
		private static Code39BarcodeDraw _code39WithChecksum;
		private static Code93BarcodeDraw _code93WithChecksum;
		private static Code128BarcodeDraw _code128WithChecksum;
		private static Code11BarcodeDraw _code11WithoutChecksum;
		private static Code11BarcodeDraw _code11WithChecksum;
		private static CodeEan13BarcodeDraw _codeEan13WithChecksum;
		private static CodeEan8BarcodeDraw _codeEan8WithChecksum;
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets an agent capable of rendering a Code39 barcode without
		/// adding a checksum glyph.
		/// </summary>
		/// <value>A <see cref="T:Code39BarcodeDraw"/> object.</value>
		public static Code39BarcodeDraw Code39WithoutChecksum
		{
			get
			{
				if (_code39WithoutChecksum == null)
				{
					_code39WithoutChecksum = new Code39BarcodeDraw (
						Code39GlyphFactory.Instance);
				}
				return _code39WithoutChecksum;
			}
		}

		/// <summary>
		/// Gets an agent capable of rendering a Code39 barcode with an
		/// added checksum glyph.
		/// </summary>
		/// <value>A <see cref="T:Code39BarcodeDraw"/> object.</value>
		public static Code39BarcodeDraw Code39WithChecksum
		{
			get
			{
				if (_code39WithChecksum == null)
				{
					_code39WithChecksum = new Code39BarcodeDraw (
						Code39Checksum.Instance);
				}
				return _code39WithChecksum;
			}
		}

		/// <summary>
		/// Gets an agent capable of rendering a Code93 barcode with added
		/// checksum glyphs.
		/// </summary>
		/// <value>A <see cref="T:Code93BarcodeDraw"/> object.</value>
		public static Code93BarcodeDraw Code93WithChecksum
		{
			get
			{
				if (_code93WithChecksum == null)
				{
					_code93WithChecksum = new Code93BarcodeDraw (
						Code93Checksum.Instance);
				}
				return _code93WithChecksum;
			}
		}

		/// <summary>
		/// Gets an agent capable of rendering a Code128 barcode with added
		/// checksum glyphs.
		/// </summary>
		/// <value>A <see cref="T:Code128BarcodeDraw"/> object.</value>
		public static Code128BarcodeDraw Code128WithChecksum
		{
			get
			{
				if (_code128WithChecksum == null)
				{
					_code128WithChecksum = new Code128BarcodeDraw (
						Code128Checksum.Instance);
				}
				return _code128WithChecksum;
			}
		}

		/// <summary>
		/// Gets an agent capable of rendering a Code11 barcode.
		/// </summary>
		/// <value>A <see cref="T:Code11BarcodeDraw"/> object.</value>
		public static Code11BarcodeDraw Code11WithoutChecksum
		{
			get
			{
				if (_code11WithoutChecksum == null)
				{
					_code11WithoutChecksum = new Code11BarcodeDraw (
						Code11GlyphFactory.Instance);
				}
				return _code11WithoutChecksum;
			}
		}

		/// <summary>
		/// Gets an agent capable of rendering a Code11 barcode with added
		/// checksum glyphs.
		/// </summary>
		/// <value>A <see cref="T:Code11BarcodeDraw"/> object.</value>
		public static Code11BarcodeDraw Code11WithChecksum
		{
			get
			{
				if (_code11WithChecksum == null)
				{
					_code11WithChecksum = new Code11BarcodeDraw (
						Code11Checksum.Instance);
				}
				return _code11WithChecksum;
			}
		}

		/// <summary>
		/// Gets an agent capable of rendering a Code EAN-13 barcode with
		/// added checksum glyphs.
		/// </summary>
		/// <value>A <see cref="T:CodeEan13BarcodeDraw"/> object.</value>
		public static CodeEan13BarcodeDraw CodeEan13WithChecksum
		{
			get
			{
				if (_codeEan13WithChecksum == null)
				{
					_codeEan13WithChecksum = new CodeEan13BarcodeDraw (
						CodeEan13Checksum.Instance);
				}
				return _codeEan13WithChecksum;
			}
		}

		/// <summary>
		/// Gets an agent capable of rendering a Code EAN-8 barcode with
		/// added checksum glyphs.
		/// </summary>
		/// <value>A <see cref="T:CodeEan8BarcodeDraw"/> object.</value>
		public static CodeEan8BarcodeDraw CodeEan8WithChecksum
		{
			get
			{
				if (_codeEan8WithChecksum == null)
				{
					_codeEan8WithChecksum = new CodeEan8BarcodeDraw (
						CodeEan8Checksum.Instance);
				}
				return _codeEan8WithChecksum;
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Gets the barcode drawing object for rendering the specified
		/// barcode symbology.
		/// </summary>
		/// <param name="symbology">
		/// A value from the <see cref="T:BarcodeSymbology"/> enumeration.
		/// </param>
		/// <returns>
		/// A class derived from <see cref="T:BarcodeDraw"/>.
		/// </returns>
		/// <exception cref="T:ArgumentException">
		/// Thrown if the specified symbology is invalid or unknown.
		/// </exception>
		public static BarcodeDraw GetSymbology (BarcodeSymbology symbology)
		{
			switch (symbology)
			{
				case BarcodeSymbology.Code39NC:
					return Code39WithoutChecksum;
				case BarcodeSymbology.Code39C:
					return Code39WithChecksum;
				case BarcodeSymbology.Code93:
					return Code93WithChecksum;
				case BarcodeSymbology.Code128:
					return Code128WithChecksum;
				case BarcodeSymbology.Code11NC:
					return Code11WithoutChecksum;
				case BarcodeSymbology.Code11C:
					return Code11WithChecksum;
				case BarcodeSymbology.CodeEan13:
					return CodeEan13WithChecksum;
				case BarcodeSymbology.CodeEan8:
					return CodeEan8WithChecksum;
				default:
					throw new ArgumentException (
						Resources.BarcodeSymbologyInvalid, "symbology");
			}
		}
		#endregion
	}

	/// <summary>
	/// <c>BarcodeSymbology</c> defines the supported barcode symbologies.
	/// </summary>
	public enum BarcodeSymbology
	{
		/// <summary>
		/// Unknown symbology.
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// Code 39 (aka Code 3 of 9) without checksum
		/// </summary>
		Code39NC = 1,

		/// <summary>
		/// Code 39 (aka Code 3 of 9) with checksum
		/// </summary>
		Code39C = 2,

		/// <summary>
		/// Code 93 with checksum
		/// </summary>
		Code93 = 3,

		/// <summary>
		/// Code 128 with checksum
		/// </summary>
		Code128 = 4,

		/// <summary>
		/// Code 11 without checksum
		/// </summary>
		Code11NC = 5,

		/// <summary>
		/// Code 11 with checksum
		/// </summary>
		Code11C = 6,

		/// <summary>
		/// Code EAN-13 with checksum
		/// </summary>
		CodeEan13 = 7,

		/// <summary>
		/// Code EAN-8 with checksum
		/// </summary>
		CodeEan8 = 8,
	}
}
