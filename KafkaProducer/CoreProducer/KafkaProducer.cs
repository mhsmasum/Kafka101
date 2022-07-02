using Confluent.Kafka;
using KafkaProducer.Models;
using System.Net;

namespace KafkaProducer.CoreProducer
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly string bootstrapServers = "localhost:9092";
        public async Task  SendMessage(string topic, string message)
        {
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers,
                ClientId = Dns.GetHostName()
            };

            try
            {
                using (var producer = new ProducerBuilder
                <Null, string>(config).Build())
                {
                    var result = await producer.ProduceAsync
                    (topic, new Message<Null, string>
                    {
                        Value = message
                    });

                    //Debug.WriteLine($"Delivery Timestamp:{result.Timestamp.UtcDateTime}");
                    //return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
        }
    }
}
