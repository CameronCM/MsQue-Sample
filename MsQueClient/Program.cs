using System;

namespace MsQueClient
{
    class Program
    {
        private string myQPath = @".\private$\myQ";

        static void Main(string[] args)
        {
            CreateQueue();

            var name = Console.ReadLine();


            SendQ(Name);


            Console.WriteLine("Hello World!");
        }

        private static SendMessage(string value)
        {
            try
            {
                MessageQueue mq = new MessageQueue(myQPath);

                Message myMessage = new Message();
                myMessage.Body = value;

                mq.Send(myMessage);
            }
            catch (Exception)
            {

                throw;
            }
        }

        static void CreateQueue(string queuePath)
        {


            try
            {
                if (!MessageQueue.Exists(queuePath))
                {
                    MessageQueue.Create(queuePath);
                }
                else
                {
                    Console.WriteLine(queuePath + " already exists.");
                }
            }
            catch (MessageQueueException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
