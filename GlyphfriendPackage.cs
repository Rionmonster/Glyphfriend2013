﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.VisualStudio.Shell;

namespace Glyphfriend2013
{
    public sealed class GlyphfriendPackage : Package
    {
        private static Dictionary<string, ImageSource> _glyphs;
        internal static Dictionary<string, ImageSource> Glyphs
        {
            get
            {
                return _glyphs;
            }
        }

        public static void LoadGlyphs()
        {
            if (_glyphs == null)
            {
                _glyphs = new Dictionary<string, ImageSource>();
            }

            // Resolve the direcotry for all Glyphs stored as content
            string assembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var glyphDirectory = Path.Combine(Path.GetDirectoryName(assembly), "Glyphs");

            foreach (var glyph in new DirectoryInfo(glyphDirectory).EnumerateFiles("*.png", SearchOption.AllDirectories))
            {
                // Generate the Glyph
                try
                {
                    var glyphBitmap = BitmapFrame.Create(new Uri(glyph.FullName, UriKind.RelativeOrAbsolute));
                    _glyphs.Add(Path.GetFileNameWithoutExtension(glyph.Name), glyphBitmap);
                }
                catch (Exception)
                {
                    // An error occurred when creating the glyph, ignore it (it will be handled in the provider)
                }
            }
        }
    }
}
