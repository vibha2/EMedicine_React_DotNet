namespace EMedicineBackend.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int UsertId { get; set; }
        public string OrderNo { get; set; }
        public decimal OrderTotal { get; set; }
        public string OrderStatus { get; set; }

    }
}

