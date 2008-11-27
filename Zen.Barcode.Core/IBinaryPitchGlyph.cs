//-----------------------------------------------------------------------
// <copyright file="IBinaryPitchGlyph.cs" company="Zen Design">
//     Copyright (c) Zen Design 2008. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Zen.Barcode
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// <c>IBinaryPitchGlyph</c> defines the contract with binary pitched
    /// glyphs.
    /// </summary>
    public interface IBinaryPitchGlyph : IBarGlyph
    {
        /// <summary>
        /// Gets the width encoding.
        /// </summary>
        /// <value>The width encoding.</value>
        short WidthEncoding
        {
            get;
        }
    }
}
