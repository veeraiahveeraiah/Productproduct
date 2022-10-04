using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace crud.Models
{
    public class Product
    {

        [Required(ErrorMessage = "Please enter productcode")]
        [Display(Name = "Productcode")]
        public string productcode{ get; set; }

        [Required(ErrorMessage = "Please enter productName")]
        [Display(Name = "ProductName")]
        public string productName { get; set; }

        [Required(ErrorMessage = "Please enter productcategory")]
        [Display(Name = "productcategory")]
        public string productcategory{ get; set; }
        [Required(ErrorMessage = "Please enter Salesrate")]
        [Display(Name = "Salesrate")]
        public float Salesrate { get; set; }
        [Required(ErrorMessage = "Please enter Hsncode")]
        [Display(Name = "Hsncode")]
        public string Hsncode { get; set; }


    }
}