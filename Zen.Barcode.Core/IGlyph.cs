using System;
using System.Collections.Generic;
using System.Text;

namespace Zen.Barcode
{
	/// <summary>
	/// <c>IGlyph</c> defines barcode for a given character.
	/// </summary>
	public interface IGlyph
	{
		/// <summary>
		/// Gets the character.
		/// </summary>
		/// <value>The character.</value>
		char Character
		{
			get;
		}
	}
}
