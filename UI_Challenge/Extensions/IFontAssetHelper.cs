using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI_Challenge.Extensions
{
    public interface IFontAssetHelper
    {
        SKTypeface GetSkiaTypefaceFromAssetFont(string fontName);
    }
}
