using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Collections;
using System.Text;

namespace TheDarkTowerMVC.Utils
{
    public class RegisterEmailQueue : IMessageProducer
    {

        //public Queue queue()
        //{
        //    return new Queue(QUEUE, false);
        //}

        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("register-orders");
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "orders", body: body);
        }



    }
}
