namespace KafkaProducer.Models
{
    public class OrderRequest
    {
        public string OrderNo { get; set; }
        public decimal Amount { get; set; }  
        public string CustomerId { get; set; }
    }
}
