using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitStandardQueue
{
    public class RabbitFactory
    {

        private static IConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _model;

        public static void CreateQueue()
        {


            _factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
        }

    }
}
