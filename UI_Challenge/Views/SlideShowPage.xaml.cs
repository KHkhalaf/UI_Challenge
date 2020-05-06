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
    public partial class SlideShowPage : OrientationContentPage
    {
        public SlideShowPage()
        {
            InitializeComponent();
            PortraitLayoutType = typeof(PortraitView);
            LandscapeLayoutType = typeof(LandscapeView);
        }
    }
}