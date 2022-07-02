namespace KafkaProducer.CoreProducer
{
    public interface IKafkaProducer
    {
        Task SendMessage(string topic, string message);
    }
}
