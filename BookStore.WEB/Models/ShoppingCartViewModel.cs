using BookStore.BLL.DTO;
using BookStore.BLL.ShoppinCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WEB.Models
{
    public class ShoppingCartViewModel
    {
       
        public Cart Cart { get; set; }
        public string returnUrl { get; set; }
    }
}