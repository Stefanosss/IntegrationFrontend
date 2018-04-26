using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System;
using RabbitMQ.Client;
using System.Text;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpPost("reserveren")]
        public int Create([FromBody]Bezoeker b)
        {
            Console.WriteLine("separtiii");
            var factory = new ConnectionFactory() { HostName = "10.3.50.48", Port = 5672, UserName = "radmin", Password = "radmin" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "rabbitmq", type: "fanout", durable: true);

                var message = b.ToXML();
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "rabbitmq",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            return 1;

        }
    }
    
}