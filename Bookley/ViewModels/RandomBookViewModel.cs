using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookley.Models;

namespace Bookley.ViewModels
{
    public class RandomBookViewModel
    {
        public Book Book { get; set; }
        public List<Customer> Customers { get; set; }
    }
}