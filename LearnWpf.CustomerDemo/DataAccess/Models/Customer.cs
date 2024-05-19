﻿using System.ComponentModel.DataAnnotations;

namespace LearnWpf.CustomerDemo.DataAccess.Models
{
    class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
    }
}
