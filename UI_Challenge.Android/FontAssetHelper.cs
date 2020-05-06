using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SkiaSharp;
using UI_Challenge.Droid;
using UI_Challenge.Extensions;
using Xamarin.Forms;

[assembly: Dependency(typeof(FontAssetHelper))]
namespace UI_Challenge.Droid
{
    public class FontAssetHelper:IFontAssetHelper
    {
        public SKTypeface GetSkiaTypefaceFromAssetFont(string fontName)
        {
            SKTypeface typeFace;

            using (var asset = Android.App.Application.Context.Assets.Open(fontName))
            {
                var fontStream = new MemoryStream();
                asset.CopyTo(fontStream);
                fontStream.Flush();
                fontStream.Position = 0;
                typeFace = SKTypeface.FromStream(fontStream);
            }

            return typeFace;
        }
    }
}