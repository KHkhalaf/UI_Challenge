﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UI_Challenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsSection : ContentView
    {
        int selectionIndex = 0;
        List<Label> tabHeaders = new List<Label>();
        List<VisualElement> tabContents = new List<VisualElement>();
        public DetailsSection()
        {
            InitializeComponent();

            tabHeaders.Add(CastTab);
            tabHeaders.Add(InfoTab);
            tabHeaders.Add(NewsTab);
            tabHeaders.Add(CriticsTab);
            tabHeaders.Add(MediaTab);

            tabContents.Add(CastContent);
            tabContents.Add(InfoContent);
            tabContents.Add(NewsContent);
            tabContents.Add(CriticsContent);
            tabContents.Add(MediaContent);

        }

        private async Task ShowSelection(int newTab)
        {
            if (newTab == selectionIndex) return;

            // navigate the selection pill
            var selectdTabLabel = tabHeaders[newTab];
            _ = SelectionUnderline.TranslateTo(selectdTabLabel.Bounds.X, 0, 150, easing: Easing.SinInOut);

            // update the style of the header to show it's selcted
            var unselectedStyle = (Style)Application.Current.Resources["TabLabel"];
            var selectedStyle = (Style)Application.Current.Resources["SelectedTabLabel"];
            tabHeaders[selectionIndex].Style = unselectedStyle;
            selectdTabLabel.Style = selectedStyle;

            /// reveal the contents
            await tabContents[selectionIndex].FadeTo(0);
            tabContents[selectionIndex].IsVisible = false;
            tabContents[newTab].IsVisible = true;
            _ = tabContents[newTab].FadeTo(1); //ybadragon thanks!

            selectionIndex = newTab;

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var tabIndex = tabHeaders.IndexOf((Label)sender);
            await ShowSelection(tabIndex);
        }

        private async void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            if(e.Direction == SwipeDirection.Left) {
                if (selectionIndex + 1 == 5)
                {
                    await ShowSelection(0);
                }
                else
                {
                    await ShowSelection(selectionIndex + 1);
                }
            }
            else
            {
                if (selectionIndex - 1 == -1)
                {
                    await ShowSelection(4);
                }
                else
                {
                    await ShowSelection(selectionIndex-1);
                }
            }
        }
    }
}