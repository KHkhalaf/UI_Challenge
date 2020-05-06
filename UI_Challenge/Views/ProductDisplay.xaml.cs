﻿using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UI_Challenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDisplay : ContentView
    {
        public ProductDisplay()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ImageOffsetYProperty =
            BindableProperty.Create(nameof(ImageOffsetY), typeof(int), typeof(ProductDisplay), 0);

        public static readonly BindableProperty ImageOffsetXProperty =
            BindableProperty.Create(nameof(ImageOffsetX), typeof(int), typeof(ProductDisplay), 0);


        public int ImageOffsetY
        {
            get => (int)GetValue(ImageOffsetYProperty);
            set => SetValue(ImageOffsetYProperty, value);
        }

        public int ImageOffsetX
        {
            get => (int)GetValue(ImageOffsetXProperty);
            set => SetValue(ImageOffsetXProperty, value);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ImageOffsetYProperty.PropertyName)
            {
                ProductImage.TranslationY = ImageOffsetY;
            }

            if (propertyName == ImageOffsetXProperty.PropertyName)
            {
                ProductImage.TranslationX = ImageOffsetX;
            }
        }


        public event EventHandler AddToCartClicked;
        public event EventHandler ProductClicked;

        const int animationSpeed = 500;

        internal async Task ExpandToFill(Rectangle bounds)
        {
            // set the intial state
            AddBackground.Opacity = .5;
            AddButton.Opacity = 1;
            NameLabel.Opacity = 1;
            PriceLabel.Opacity = 1;
            ProductImage.Scale = 1;
            ProductImage.TranslationX = ImageOffsetX;
            ProductImage.TranslationY = ImageOffsetY;

            // destination rect
            var destRect = new Rectangle(
                x: (bounds.Width / 2) - (this.Width / 2),
                y: 40,
                width: this.Width,
                height: this.Height
                );

            _ = AddBackground.FadeTo(0, animationSpeed / 2);
            _ = AddButton.FadeTo(0, animationSpeed / 2);
            _ = NameLabel.FadeTo(0, animationSpeed / 2);
            _ = PriceLabel.FadeTo(0, animationSpeed / 2);


            _ = ProductImage.TranslateTo(0, ProductImage.TranslationY, animationSpeed * 2);
            await this.LayoutTo(destRect, animationSpeed * 2, Easing.SinInOut);


            _ = ProductImage.ScaleTo(1.1, animationSpeed * 2);
            _ = ProductImage.TranslateTo(0, 50, animationSpeed * 2);
            Rectangle expandedBounds = bounds.Inflate(50, 50);
            await this.LayoutTo(expandedBounds, animationSpeed * 2, Easing.SinInOut);
            AbsoluteLayout.SetLayoutBounds(this, expandedBounds);
        }

        private void TapProductGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            EventHandler handler = ProductClicked;
            handler?.Invoke(this, new EventArgs());
        }

        private void TapAddProductGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            EventHandler handler = AddToCartClicked;
            handler?.Invoke(this, new EventArgs());
        }
    }
}