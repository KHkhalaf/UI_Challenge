using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UI_Challenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingCartPopover : ContentView
    {
        enum Steps
        {
            first,
            second,
            third
        }
        Steps step = Steps.first;
        public ShoppingCartPopover()
        {
            InitializeComponent();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            this.IsVisible = false;
            Init_Components();
        }

        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // paint object for circles
            SKPaint circlePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.FromHex("#75D59F").ToSKColor(),
                StrokeWidth = 3,
                IsAntialias = true
            };

            SKPaint filledCirclePaint = new SKPaint
            {
                Style = SKPaintStyle.StrokeAndFill,
                Color = Color.FromHex("#75D59F").ToSKColor(),
                StrokeWidth = 3,
                IsAntialias = true
            };

            SKPaint dottedCirclePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.FromHex("#75D59F").ToSKColor(),
                StrokeWidth = 3,
                IsAntialias = true,
                PathEffect = SKPathEffect.CreateDash(new float[] { 8, 6 }, 0)
            };

            SKPaint dottndLinePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.FromHex("#75D59F").ToSKColor(),
                StrokeWidth = 3,
                IsAntialias = true,
                PathEffect = SKPathEffect.CreateDash(new float[] { 20, 15}, 0)
            };

            float margin = 40;
            double radius = 15;
            float linePadding = 100;
            if (step == Steps.first)
            {
                canvas.DrawCircle(new SKPoint(margin, info.Height / 2),(float) radius, filledCirclePaint);
                canvas.DrawCircle(new SKPoint(margin, info.Height / 2),(float) (radius * 1.5), circlePaint);

                canvas.DrawLine(
                    new SKPoint(linePadding, info.Height / 2),
                    new SKPoint(info.Width / 2 - linePadding, +info.Height / 2),
                    circlePaint
                    );

                canvas.DrawCircle(new SKPoint(info.Width / 2, info.Height / 2), (float)radius, circlePaint);
                canvas.DrawCircle(new SKPoint(info.Width / 2, info.Height / 2), (float)(radius * 1.5), dottedCirclePaint);

                canvas.DrawLine(
                    new SKPoint(info.Width / 2 + linePadding, info.Height / 2),
                    new SKPoint(info.Width - linePadding, info.Height / 2),
                    dottndLinePaint
                    );

                canvas.DrawCircle(new SKPoint(info.Width - margin, info.Height / 2), (float)radius, circlePaint);
                canvas.DrawCircle(new SKPoint(info.Width - margin, info.Height / 2), (float)(radius * 1.5), dottedCirclePaint);
            }

            else if(step == Steps.second)
            {
                canvas.DrawCircle(new SKPoint(margin, info.Height / 2), (float)radius, filledCirclePaint);

                canvas.DrawLine(
                    new SKPoint(linePadding, info.Height / 2),
                    new SKPoint(info.Width / 2 - linePadding, +info.Height / 2),
                    circlePaint
                    );

                canvas.DrawCircle(new SKPoint(info.Width / 2, info.Height / 2), (float)radius, filledCirclePaint);
                canvas.DrawCircle(new SKPoint(info.Width / 2, info.Height / 2), (float)(radius * 1.5), circlePaint);

                canvas.DrawLine(
                   new SKPoint(info.Width / 2 + linePadding, info.Height / 2),
                   new SKPoint(info.Width - linePadding, info.Height / 2),
                   circlePaint
                   );

                canvas.DrawCircle(new SKPoint(info.Width - margin, info.Height / 2), (float)radius, circlePaint);
                canvas.DrawCircle(new SKPoint(info.Width - margin, info.Height / 2), (float)(radius * 1.5), dottedCirclePaint);
            }

            else if (step == Steps.third)
            {
                canvas.DrawCircle(new SKPoint(margin, info.Height / 2), (float)radius, filledCirclePaint);

                canvas.DrawLine(
                    new SKPoint(linePadding, info.Height / 2),
                    new SKPoint(info.Width / 2 - linePadding, +info.Height / 2),
                    circlePaint
                    );

                canvas.DrawCircle(new SKPoint(info.Width / 2, info.Height / 2), (float)radius, filledCirclePaint);

                canvas.DrawLine(
                   new SKPoint(info.Width / 2 + linePadding, info.Height / 2),
                   new SKPoint(info.Width - linePadding, info.Height / 2),
                   circlePaint
                   );

                canvas.DrawCircle(new SKPoint(info.Width - margin, info.Height / 2), (float)radius, filledCirclePaint);
                canvas.DrawCircle(new SKPoint(info.Width - margin, info.Height / 2), (float)(radius * 1.5), circlePaint); 
            }
        }

        private void TapGestureCheckout_Tapped(object sender, EventArgs e)
        {
            // move the current stuff off the screen
            var onscreenItemsShoppingCartSlideOut = new Animation(v => ItemsShoppingCart.TranslationX = v, 0, -this.Width, Easing.SinIn);
            var onscreenItemsShoppingCartFade = new Animation(v => ItemsShoppingCart.Opacity = v, 1, 0, Easing.SinIn);
            var onscreenEmptyViewSlideOut = new Animation(v => EmptyView.TranslationX = v, 0, -this.Width, Easing.SinIn);
            var onscreenEmptyViewFade = new Animation(v => EmptyView.Opacity = v, 1, 0, Easing.SinIn);

            var onscreenTotalCostSlideOut = new Animation(v => TotalCost.TranslationX = v,0, -this.Width, Easing.SinIn);
            var onscreenTotalCostFade = new Animation(v => TotalCost.Opacity = v, 1, 0, Easing.SinIn);
            var onscreenCheckOutButtonSlideOut = new Animation(v => CheckOutButton.TranslationX = v, 0, -this.Width, Easing.SinIn);
            var onscreenCheckOutButtonFade = new Animation(v => CheckOutButton.Opacity = v, 1, 0, Easing.SinIn);

            // move the offscreen stuff onto the screen
            var offscreenCreditCardSlideIn = new Animation(v => creditCard.TranslationX = v, this.Width, 0, Easing.SinOut);
            var offscreenCreditCardFadeIn = new Animation(v => creditCard.Opacity = v, 0, 1, Easing.SinOut);

            var parentAnimation = new Animation();
            // outgoing child animations
            parentAnimation.Add(0, 1, onscreenItemsShoppingCartSlideOut);
            parentAnimation.Add(0, .5, onscreenItemsShoppingCartFade);
            parentAnimation.Add(0, 1, onscreenEmptyViewSlideOut);
            parentAnimation.Add(0, .5, onscreenEmptyViewFade);
            parentAnimation.Add(0, 1, onscreenTotalCostSlideOut);
            parentAnimation.Add(0, .5, onscreenTotalCostFade);
            parentAnimation.Add(0, 1, onscreenCheckOutButtonSlideOut);
            parentAnimation.Add(0, .58, onscreenCheckOutButtonFade);
            // inbound child animations
            parentAnimation.Add(.2, 1, offscreenCreditCardSlideIn);
            parentAnimation.Add(.2, 1, offscreenCreditCardFadeIn);


            // animation for skia elements
            var skiaAnimation = new Animation(
                callback: v =>
                {
                    creditCard.IsVisible = true;
                    step = Steps.second;
                    skiaBar.InvalidateSurface();
                }, start: 0, end: 1, easing: Easing.SinInOut);

            parentAnimation.Add(0, 1, skiaAnimation);

            parentAnimation.Commit(this, "creditCardTransitionAnimation", 16, 500, null);

        }

        private void creditCard_BackStep(object sender, EventArgs e)
        {
            // move the current stuff off the screen
            var offscreenCreditCardSlideIn = new Animation(v => creditCard.TranslationX = v, 0, this.Width, Easing.SinOut);
            var offscreenCreditCardFadeIn = new Animation(v => creditCard.Opacity = v, 0, 1, Easing.SinOut);

            // move the offscreen stuff onto the screen
            var onscreenItemsShoppingCartSlideOut = new Animation(v => ItemsShoppingCart.TranslationX = v, -this.Width, 0, Easing.SinIn);
            var onscreenItemsShoppingCartFade = new Animation(v => ItemsShoppingCart.Opacity = v, 0, 1, Easing.SinIn);
            var onscreenEmptyViewSlideOut = new Animation(v => EmptyView.TranslationX = v, -this.Width, 0, Easing.SinIn);
            var onscreenEmptyViewFade = new Animation(v => EmptyView.Opacity = v, 0, 1, Easing.SinIn);

            var onscreenTotalCostSlideOut = new Animation(v => TotalCost.TranslationX = v, -this.Width, 0, Easing.SinIn);
            var onscreenTotalCostFade = new Animation(v => TotalCost.Opacity = v, 0, 1, Easing.SinIn);
            var onscreenCheckOutButtonSlideOut = new Animation(v => CheckOutButton.TranslationX = v, -this.Width, 0, Easing.SinIn);
            var onscreenCheckOutButtonFade = new Animation(v => CheckOutButton.Opacity = v, 0, 1, Easing.SinIn);

            var parentAnimation = new Animation();
            // outgoing child animations
            parentAnimation.Add(0, 1, onscreenItemsShoppingCartSlideOut);
            parentAnimation.Add(0, .5, onscreenItemsShoppingCartFade);
            parentAnimation.Add(0, 1, onscreenEmptyViewSlideOut);
            parentAnimation.Add(0, .5, onscreenEmptyViewFade);
            parentAnimation.Add(0, 1, onscreenTotalCostSlideOut);
            parentAnimation.Add(0, .5, onscreenTotalCostFade);
            parentAnimation.Add(0, 1, onscreenCheckOutButtonSlideOut);
            parentAnimation.Add(0, .58, onscreenCheckOutButtonFade);
            // inbound child animations
            parentAnimation.Add(.2, 1, offscreenCreditCardSlideIn);
            parentAnimation.Add(.2, 1, offscreenCreditCardFadeIn);

            // animation for skia elements
            var skiaAnimation = new Animation(
                callback: v =>
                {
                    step = Steps.first;
                    skiaBar.InvalidateSurface();
                }, start: 0, end: 1, easing: Easing.SinInOut);

            parentAnimation.Add(0, 1, skiaAnimation);

            parentAnimation.Commit(this, "creditCardTransitionAnimation", 16, 500, null);
        }

        private void creditCard_NextStep(object sender, EventArgs e)
        {
            // move the current stuff off the screen
            var onscreencreditCardSlideOut = new Animation(v => creditCard.TranslationX = v, 0, -this.Width, Easing.SinIn);
            var onscreencreditCardFade = new Animation(v => creditCard.Opacity = v, 1, 0, Easing.SinIn);

            // move the offscreen stuff onto the screen
            var offscreenLastStepSlideIn = new Animation(v => LastStep.TranslationX = v, this.Width, 0, Easing.SinOut);
            var offscreenLastStepFadeIn = new Animation(v => LastStep.Opacity = v, 0, 1, Easing.SinOut);

            var parentAnimation = new Animation();
            // outgoing child animations
            parentAnimation.Add(0, 1, onscreencreditCardSlideOut);
            parentAnimation.Add(0, .5, onscreencreditCardFade);
            // inbound child animations
            parentAnimation.Add(.2, 1, offscreenLastStepSlideIn);
            parentAnimation.Add(.2, 1, offscreenLastStepFadeIn);


            // animation for skia elements
            var skiaAnimation = new Animation(
                callback: v =>
                {
                    LastStep.IsVisible = true;
                    step = Steps.third;
                    skiaBar.InvalidateSurface();
                }, start: 0, end: 1, easing: Easing.SinInOut);

            parentAnimation.Add(0, 1, skiaAnimation);

            parentAnimation.Commit(this, "creditCardTransitionAnimation", 16, 500, null);
        }

        private void Done_Clicked(object sender, EventArgs e)
        {
            this.IsVisible = false;
            Init_Components();
        }
        private void Init_Components()
        {
            var behindscreenItemsShoppingCartSlideOut = new Animation(v => ItemsShoppingCart.TranslationX = v, -this.Width, 0, Easing.SinIn);
            var behindscreenItemsShoppingCartFade = new Animation(v => ItemsShoppingCart.Opacity = v, 0, 1, Easing.SinIn);
            var behindscreenEmptyViewSlideOut = new Animation(v => EmptyView.TranslationX = v, -this.Width, 0, Easing.SinIn);
            var behindscreenEmptyViewFade = new Animation(v => EmptyView.Opacity = v, 0, 1, Easing.SinIn);

            var behindscreenTotalCostSlideOut = new Animation(v => TotalCost.TranslationX = v, -this.Width, 0, Easing.SinIn);
            var behindscreenTotalCostFade = new Animation(v => TotalCost.Opacity = v, 0, 1, Easing.SinIn);
            var behindscreenCheckOutButtonSlideOut = new Animation(v => CheckOutButton.TranslationX = v, -this.Width, 0, Easing.SinIn);
            var behindscreenCheckOutButtonFade = new Animation(v => CheckOutButton.Opacity = v, 0, 1, Easing.SinIn);


            var parentAnimation = new Animation();
            parentAnimation.Add(0, .1, behindscreenItemsShoppingCartFade);
            parentAnimation.Add(0, .1, behindscreenItemsShoppingCartSlideOut);
            parentAnimation.Add(0, .1, behindscreenEmptyViewSlideOut);
            parentAnimation.Add(0, .1, behindscreenTotalCostSlideOut);
            parentAnimation.Add(0, .1, behindscreenCheckOutButtonSlideOut);
            parentAnimation.Add(0, .1, behindscreenEmptyViewFade);
            parentAnimation.Add(0, .1, behindscreenTotalCostFade);
            parentAnimation.Add(0, .1, behindscreenCheckOutButtonFade);

            creditCard.IsVisible = false;
            LastStep.IsVisible = false;

            // animation for skia elements
            var skiaAnimation = new Animation(
                callback: v =>
                {
                    step = Steps.first;
                    skiaBar.InvalidateSurface();
                }, start: 0, end: .1, easing: Easing.SinInOut);

            parentAnimation.Add(0, .1, skiaAnimation);

            parentAnimation.Commit(this, "creditCardTransitionAnimation", 16, 50, null);
        }
    }
}