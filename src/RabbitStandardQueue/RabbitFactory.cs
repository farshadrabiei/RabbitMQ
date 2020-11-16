using Common;
using Newtonsoft.Json.Converters;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RabbitStandardQueue
{
    public class RabbitFactory
    {

        private static IConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _model;
        private static string QueueName = "StandardQueue_ExampleQueue";

        public   void CreateQueue()
        {
            _factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            _connection = _factory.CreateConnection();
            _model = _connection.CreateModel();
            _model.QueueDeclare(QueueName, true, false, false, null);
        }


        public   void SendMessage(Payment message) 
        {
            _model.BasicPublish("", QueueName, null, message.Serialize());
            Console.WriteLine(" [x] Payment Message Sent : {0} : {1} : {2}", message.CardNumber, message.AmountToPay, message.Name);

        }
        public void Recieve()
        {
            EventingBasicConsumer consumer = new EventingBasicConsumer(_model);

            consumer.Received += (o, e) => {
                Payment data =  (Payment)e.Body.ToArray().DeSerialize(typeof(Payment));
                Console.WriteLine($"received: AmountToPay : {data.AmountToPay} , CardNumber : {data.CardNumber} , Name :{data.Name}" );
                Thread.Sleep(1000);
                Console.WriteLine("done."); //Received event will not be fired again before done.
            };
            _model.BasicConsume(queue: QueueName,
                                autoAck: true,
                                consumer: consumer);

        }
    }
}
