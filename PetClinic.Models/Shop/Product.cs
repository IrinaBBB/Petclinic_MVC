﻿//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace PetClinic.Models.Shop
//{
//    public class Product
//    {
//        public int Id { get; set; }

//        [Required]
//        public string Name { get; set; }

//        public string Description { get; set; }
//        public string Producer { get; set; }

//        [Required]
//        [Range(1, 10000)]
//        public double ListPrice { get; set; }

//        [Required]
//        [Range(1, 10000)]
//        public double Price { get; set; }

//        [Required]
//        [Range(1, 10000)]
//        public double Price50 { get; set; }

//        [Required]
//        [Range(1, 10000)]
//        public double Price100 { get; set; }
//        public string ImageUrl { get; set; }

//        [Required]
//        public int CategoryId { get; set; }

//        [ForeignKey("CategoryId")]
//        public Category Category { get; set; }
//    }
//}