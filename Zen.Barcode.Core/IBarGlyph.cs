using System;
using System.Collections.Generic;
using System.Text;

namespace Zen.Barcode
{
	/// <summary>
	/// <c>IBarGlyph</c> extends <see cref="T:IGlyph"/> by specifying a bit
	/// encoding for a given character. The bits indicate where bars are
	/// drawn.
	/// </summary>
	public interface IBarGlyph : IGlyph
	{
		/// <summary>
		/// Gets the bit encoding.
		/// </summary>
		/// <value>The bit encoding.</value>
		short BitEncoding
		{
			get;
		}
	}
}
