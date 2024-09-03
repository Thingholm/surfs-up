﻿namespace SurfsUpWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Thickness { get; set; }
        public double Volume { get; set; }
        public int Type { get; set; }
        public double Price { get; set; }
        public List<string> Equipment { get; set; }
        public string ImageUrl { get; set; }
    }
}
        