using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Challenge.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UI_Challenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RottenUI : ContentPage
    {
        private MockRepository mockRepository = new MockRepository();
        public RottenUI()
        {
            InitializeComponent();
        }
            private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
            {
                SKImageInfo info = args.Info;
                SKSurface surface = args.Surface;
                SKCanvas canvas = surface.Canvas;

                canvas.Clear();

                using (SKPaint paint = new SKPaint())
                {
                    // define the color for the shadow
                    SKColor shadowColor = Color.FromHex("#5ACB6E").ToSKColor();

                    paint.IsDither = true;
                    paint.IsAntialias = true;
                    paint.Color = shadowColor;

                    // create filter for drop shadow
                    paint.ImageFilter = SKImageFilter.CreateDropShadow(
                        dx: 0, dy: 0,
                        sigmaX: 40, sigmaY: 40,
                        color: shadowColor,
                        shadowMode: SKDropShadowImageFilterShadowMode.DrawShadowOnly);

                    // define where I want to draw the object
                    var margin = info.Width / 10;
                    var shadowBounds = new SKRect(margin, -40, info.Width - margin, 10);
                    canvas.DrawRoundRect(shadowBounds, 10, 10, paint);

                }

            }

    }
}