using Prediction.Domain.Entities;

namespace Prediction.Application.DTOS
{
    public class OrderDTO
    {
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipperId { get; set; }
        public decimal Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipCountry { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }

}
