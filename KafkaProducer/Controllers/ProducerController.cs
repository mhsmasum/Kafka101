using KafkaProducer.CoreProducer;
using KafkaProducer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace KafkaProducer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private IKafkaProducer _kafkaProducer;

        public ProducerController(IKafkaProducer kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] OrderRequest aRequest)
        {

            string topic = "MyFirstTopic";
            string message = JsonSerializer.Serialize(aRequest);
            _kafkaProducer.SendMessage(topic, message);
            

            return Ok(1);
        }
    }
}
