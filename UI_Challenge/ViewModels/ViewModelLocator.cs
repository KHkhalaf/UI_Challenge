using System;
using System.Collections.Generic;
using System.Text;

namespace UI_Challenge.ViewModels
{
    public static class ViewModelLocator
    {
        static SlideShowViewModel slideshowVM;

        public static SlideShowViewModel SlideshowViewModel =>
            slideshowVM ?? (slideshowVM = new SlideShowViewModel());
    }
}
