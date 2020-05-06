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
    public partial class CreditCard : ContentView
    {
        public event EventHandler BackStep;
        public event EventHandler NextStep;
        public CreditCard()
        {
            InitializeComponent();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            EventHandler handler = BackStep;
            handler?.Invoke(null, new EventArgs());
        }

        private void Next_Clicked(object sender, EventArgs e)
        {

            EventHandler handler = NextStep;
            handler?.Invoke(null, new EventArgs());
        }
    }
}