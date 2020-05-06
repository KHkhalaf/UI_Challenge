using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UI_Challenge.ViewModels;

namespace UI_Challenge.Models
{

    public static class Location
    {
        public static ObservableCollection<LocationModel> LocationPages { get; set; }

        static Location()
        {
            LocationPages = new ObservableCollection<LocationModel>()
            {
                new LocationModel() {
                    Title ="Thórsmörk",
                    Description ="Thórsmörk is a mountain ridge in Iceland that was named after the Norse god Thor (Þór). It is situated in the south of Iceland between the glaciers Tindfjallajökull and Eyjafjallajökull.",
                    ImageResource="UI_Challenge.Images.Thorsmork.jpg"},

                 new LocationModel() {
                    Title ="Öræfajökull",
                    Description ="Öræfajökull is located at the southern extremity of the Vatnajökull glacier and overlooking the Ring Road between Höfn and Vík.",
                    ImageResource="UI_Challenge.Images.Oraefojokull.jpg"},

                 new LocationModel() {
                    Title ="Bárðarbunga",
                    Description ="Bárðarbunga is a subglacial stratovolcano located under the ice cap of Vatnajökull glacier within the Vatnajökull National Park in Iceland. It rises to 2,009 metres above sea level",
                    ImageResource="UI_Challenge.Images.bardarbunga.jpg"},
            };
        }
    }
}
