﻿namespace Prediction.Domain.Entities
{

    public class Customer
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public string ContactTitle { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Fax { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}
