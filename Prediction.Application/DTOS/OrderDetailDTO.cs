﻿namespace Prediction.Application.DTOS
{
    public class OrderDetailDTO
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
    }

}
