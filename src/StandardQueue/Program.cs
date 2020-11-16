using Common;
using RabbitStandardQueue;
using System;
using System.Threading;

namespace StandardQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            RabbitFactory rabbitFactory = new RabbitFactory();

               var payment1 = new Payment { AmountToPay = 25.0m, CardNumber = "1234123412341234", Name = "Mr S Hants 1" };
            var payment2 = new Payment { AmountToPay = 2.0m, CardNumber = "1234123412341234", Name = "Mr S Hants 2" };
            var payment3 = new Payment { AmountToPay =  5.0m, CardNumber = "1234123412341234", Name = "Mr S Hants 3" };
            var payment4 = new Payment { AmountToPay = 236.0m, CardNumber = "1234123412341234", Name = "Mr S Hants 4" };

            rabbitFactory.CreateQueue();
            rabbitFactory.SendMessage(payment1);
            rabbitFactory.SendMessage(payment2);
            rabbitFactory.SendMessage(payment3);
            rabbitFactory.SendMessage(payment4);

            Thread.Sleep(10000);
            rabbitFactory.Recieve();
            Console.ReadKey();
        }
    }
}
