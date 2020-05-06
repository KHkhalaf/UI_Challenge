﻿using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UI_Challenge.ViewModels
{
    public class ProductViewModel : ObservableObject
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string HeroColor { get; set; }
        public bool IsFeatured { get; set; }
        public string Humidity { get; set; } 
        public string Light { get; set; }
        public string Temperature { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Diameter { get; set; }
        public int numberOfOrder { get; set; }
    }
}
