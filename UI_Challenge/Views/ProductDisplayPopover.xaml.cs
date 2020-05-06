using UI_Challenge.Extensions;
using UI_Challenge.ViewModels;
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
    public partial class ProductDisplayPopover : ContentView
    {
        public event EventHandler AddToCartClicked;
        public ProductDisplayPopover()
        {
            InitializeComponent();
        }

        internal async Task Expand()
        {
            // setup for animation
            this.Opacity = 1;
            ProductPopoverGrid.Opacity = 0;
            AddToCartButton.ScaleX = 0;
            BackgroundPanel.TranslationY = BackgroundPanel.Height;

            // animate up the white background
            _ = BackgroundPanel.TranslateTo(0, 0, 200);

            // animate in the Details
            await ProductPopoverGrid.FadeTo(1, 1000);

            // animate the button
            Animation animation = new Animation();
            animation.Add(0, 1, new Animation(t => AddToCartButton.ScaleX = t, 0, 1, Easing.SpringOut));
            animation.Commit(this, "ButtonAnimation", 16, 500);
        }

        private async void BackArrowButton_Clicked(object sender, EventArgs e)
        {
            // get the parent page
            await ((IcelandMoss)this.GetParentPage()).HidePopover();
        }

        int quantityCount = 1;

        private void IncreaseQuantity_Clicked(object sender, EventArgs e)
        {
            ((MainViewModel)this.BindingContext).SelectedProduct.numberOfOrder++;
            quantityCount++;
            UpdateDisplay();
        }

        private void DecreaseQuantity_Clicked(object sender, EventArgs e)
        {
            ((MainViewModel)this.BindingContext).SelectedProduct.numberOfOrder--;
            quantityCount--;
            if (quantityCount < 1) { 
                quantityCount = 1; 
                ((MainViewModel)this.BindingContext).SelectedProduct.numberOfOrder = 1; 
            }
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            QuantityDisplay.Text = quantityCount.ToString();
            var unitPrice = ((MainViewModel)this.BindingContext).SelectedProduct.Price;
            QuantityDisplayValue.Text = (unitPrice * quantityCount).ToString();
        }

        private async void AddToCartClicked_Tapped(object sender, EventArgs e)
        {
            EventHandler handler = AddToCartClicked;
            handler?.Invoke(((MainViewModel)this.BindingContext).SelectedProduct, new EventArgs());

            await((IcelandMoss)this.GetParentPage()).HidePopover();
        }
    }
}