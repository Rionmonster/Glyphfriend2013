using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.CSS.Editor.Intellisense;
using Microsoft.VisualStudio.Utilities;

namespace Glyphfriend2013.GlyphCompletionFilters
{
    [Export(typeof(ICssCompletionListFilter))]
    [Name("Glyphfriend Bootstrap Filter")]
    internal class BootstrapGlyphCompletionFilter : ICssCompletionListFilter
    {
        public void FilterCompletionList(IList<CssCompletionEntry> completions, CssCompletionContext context)
        {
            if (context.ContextType != CssCompletionContextType.PropertyValue)
            {
                return;
            }

            foreach (CssCompletionEntry entry in completions)
            {
                // Target the appropriate Glyph here via GlyphfriendPackage.Glyphs[entry.Name] or something similar
                entry.IconSource = GlyphfriendPackage.Glyphs["glyphicon-default"];
            }
        }
    }
}
