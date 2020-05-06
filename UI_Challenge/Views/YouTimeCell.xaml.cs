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
    public partial class YouTimeCell : ContentView
    {
        public YouTimeCell()
        {
            InitializeComponent(); 
            
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {

                Device.BeginInvokeOnMainThread(() => {
                    var timeNow = DateTime.Now.ToString("hh:mm:ss tt");
                    PMAMlbl.Text = timeNow.Substring(9);
                    youlbl.Text = timeNow.Substring(0,8);
                });
                return true;
            });
        }
    }
}