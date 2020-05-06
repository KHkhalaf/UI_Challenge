using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using UI_Challenge.Models;
using Xamarin.Forms;

namespace UI_Challenge.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public IList<TimeInfo> Locations { get; }

        public IList<ProductViewModel> Products { get; set; }

        private ProductViewModel _selectedProduct;

        public ProductViewModel SelectedProduct
        {
            get { return _selectedProduct; }
            set { SetProperty(ref _selectedProduct, value); }
        }

        public ShoppingCartViewModel ShoppingCart { get; set; }

        public ICommand RemoveItemCommand { private set; get; }


        public MainViewModel()
        {
            ItemSelected = new Command<ItemsViewModel>(ItemSelectedExecute);

            Categories = new ObservableRangeCollection<Category>();
            Categories.AddRange(DataStore.GetCategories());
            CategorySelectionChanged = new Command(DoThing);

            var items = DataStore.GetItemsForCategory(SelectedCategory);

            Items = new ObservableRangeCollection<ItemsViewModel>();
            foreach (var item in items)
            {
                Items.Add(new ItemsViewModel(item));
            }

            Locations = new ObservableCollection<TimeInfo>();
            Locations.Add(new TimeInfo() { UserName = "Kym", CurrentTime = "10:49", Location = "Melbourne", TimeZoneId = "AEST", TimeInfoType = TimeInfo.TimeInfoTypeEnum.Person });
            Locations.Add(new TimeInfo() { UserName = "Frank", CurrentTime = "14:49", Location = "Berlin", TimeZoneId = "CST", TimeInfoType = TimeInfo.TimeInfoTypeEnum.Person });
            Locations.Add(new TimeInfo() { UserName = "Helen", CurrentTime = "23:00", Location = "Copenhagen", TimeZoneId = "CST", TimeInfoType = TimeInfo.TimeInfoTypeEnum.Person });
            Locations.Add(new TimeInfo() { UserName = "James", CurrentTime = "11:30", Location = "Seattle", TimeZoneId = "PST", TimeInfoType = TimeInfo.TimeInfoTypeEnum.Person });
            Locations.Add(new TimeInfo() { UserName = "You", CurrentTime = DateTime.Now.ToString("HH:mm:ss"), Location = "Melborune", TimeZoneId = "AEST", TimeInfoType = TimeInfo.TimeInfoTypeEnum.You });


            Products = new ObservableRangeCollection<ProductViewModel>()
            {
                new ProductViewModel()
                {
                    HeroColor = "#95C9F7",
                    Name="Sky Blue",
                    Price = 12,
                    ImageUrl = "blue_moss",
                    IsFeatured = true,
                    Description = "Contained in a glass polygonal florarium",
                    Humidity = "50 - 75%",
                    Light = "5k - 10k lux",
                    Temperature = "18 - 27 ℃",
                    Size = "150x150 mm",
                    Diameter = "190 mm"
                },
                new ProductViewModel()
                {
                    HeroColor = "#FFCA81",
                    Name="Yellow Sun",
                    Price = 17,
                    ImageUrl = "yellow_moss",
                    IsFeatured = true,
                    Description = "Contained in a yellow glass polygonal florarium",
                    Humidity = "50 - 60%",
                    Light = "5k - 15k lux",
                    Temperature = "18 - 27 ℃",
                    Size = "150x150 mm",
                    Diameter = "200 mm"
                },

                new ProductViewModel()
                {
                    HeroColor = "#A2BAD3",
                    Name="Grey Blue",
                    Price = 19,
                    ImageUrl = "grey_moss",
                    IsFeatured = true,
                    Description = "Contained in a glass polygonal florarium",
                    Humidity = "50 - 75%",
                    Light = "5k - 10k lux",
                    Temperature = "18 - 27 ℃",
                    Size = "150x150 mm",
                    Diameter = "190 mm"
                },

                new ProductViewModel()
                {
                    HeroColor = "#F796DD",
                    Name="Pink",
                    Price = 21,
                    ImageUrl = "pink_moss",
                    IsFeatured = false,
                    Description = "Contained in a glass polygonal florarium",
                    Humidity = "50 - 75%",
                    Light = "5k - 10k lux",
                    Temperature = "18 - 27 ℃",
                    Size = "150x150 mm",
                    Diameter = "190 mm"
                },

                 new ProductViewModel()
                {
                    HeroColor = "#95C9F7",
                    Name="Sky Blue",
                    Price = 12,
                    ImageUrl = "blue_moss",
                    IsFeatured = false,
                    Description = "Contained in a glass polygonal florarium",
                    Humidity = "50 - 75%",
                    Light = "5k - 10k lux",
                    Temperature = "18 - 27 ℃",
                    Size = "150x150 mm",
                    Diameter = "190 mm"
                },

                new ProductViewModel()
                {
                    HeroColor = "#D69EFC",
                    Name="Lavender",
                    Price = 19,
                    ImageUrl = "lavender_moss",
                    IsFeatured = false,
                    Description = "Contained in a glass polygonal florarium",
                    Humidity = "50 - 75%",
                    Light = "5k - 10k lux",
                    Temperature = "18 - 27 ℃",
                    Size = "150x150 mm",
                    Diameter = "190 mm"
                },
                new ProductViewModel()
                {
                    HeroColor = "#74D69E",
                    Name="Green Life",
                    Price = 14,
                    ImageUrl = "green_moss",
                    IsFeatured = true,
                    Description = "Contained in a glass polygonal florarium",
                    Humidity = "50 - 75%",
                    Light = "5k - 10k lux",
                    Temperature = "18 - 27 ℃",
                    Size = "150x150 mm",
                    Diameter = "190 mm"
                },
                new ProductViewModel()
                {
                    HeroColor = "#FB8183",
                    Name="Red",
                    Price = 21,
                    ImageUrl = "red_moss",
                    IsFeatured = false,
                    Description = "Contained in a glass polygonal florarium",
                    Humidity = "50 - 75%",
                    Light = "5k - 10k lux",
                    Temperature = "18 - 27 ℃",
                    Size = "150x150 mm",
                    Diameter = "190 mm"
                },
                new ProductViewModel()
                {
                    HeroColor = "#FB9B64",
                    Name="Orange",
                    Price = 14,
                    ImageUrl = "orange_moss",
                    IsFeatured = false,
                    Description = "Contained in a glass polygonal florarium",
                    Humidity = "50 - 75%",
                    Light = "5k - 10k lux",
                    Temperature = "18 - 27 ℃",
                    Size = "150x150 mm",
                    Diameter = "190 mm"
                },
                new ProductViewModel()
                {
                    HeroColor = "#D69EFC",
                    Name="Lavender",
                    Price = 19,
                    ImageUrl = "lavender_moss",
                    IsFeatured = false,
                    Description = "Contained in a glass polygonal florarium",
                    Humidity = "50 - 75%",
                    Light = "5k - 10k lux",
                    Temperature = "18 - 27 ℃",
                    Size = "150x150 mm",
                    Diameter = "190 mm"
                },

            };

            ShoppingCart = new ShoppingCartViewModel();
            ShoppingCart.Items.Add(new FreightItem() { FreightCharge = 15 });

            RemoveItemCommand = new Command<ShoppingCartItem>(i => RemoveItem(i));

        }

        private void RemoveItem(ShoppingCartItem i)
        {
            ShoppingCart.RemoveItem(i);
        }
        public ObservableRangeCollection<Category> Categories { get; set; }

        public ObservableRangeCollection<ItemsViewModel> Items { get; set; }

        public Category SelectedCategory { get; set; }

        public ICommand ItemSelected { get; set; }

        public ICommand CategorySelectionChanged { get; set; }

        private void ItemSelectedExecute(ItemsViewModel obj)
        {

        }

        private void DoThing(object obj)
        {
            Items.Clear();
            var items = DataStore.GetItemsForCategory(obj.ToString());

            foreach (var item in items)
            {
                Items.Add(new ItemsViewModel(item));
            }

        }
    }

}