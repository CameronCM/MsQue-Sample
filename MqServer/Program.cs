using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MqServer
{
    class Program
    {
        static string myQPath = @".\private$\myQ";
        static void Main(string[] args)
        {
            CreateQueue(myQPath);
            do
            {
                ReceiveMessage();
            } while (true);
        }

        private static void ReceiveMessage()
        {
            MessageQueue mq = new MessageQueue(myQPath);
            
            mq.Formatter = new XmlMessageFormatter(
                new Type[] {
                    typeof(ClassLibraryDTO.Person),
                    typeof(ClassLibraryDTO.Animal),
                    typeof(ClassLibraryDTO.Dog),
                    typeof(ClassLibraryDTO.Cat),
                    typeof(ClassLibraryDTO.Bird),
                     typeof(ClassLibraryDTO.Fish)

                }
                ); 


            Message myMessage = mq.Receive();
            var obj = myMessage.Body;
            if (obj is ClassLibraryDTO.Person)
            {
                var person = (ClassLibraryDTO.Person)obj;
                Console.WriteLine($"Hello, {person.Name} {person.Surname} ({person.GetInitial()}) Age: {person.Age} Allowed to Drink? {person.IsAllowedToDrink()}");
            }

            //if obj is Animal

            if (obj is ClassLibraryDTO.Animal)
            {
                var animal = (ClassLibraryDTO.Animal)obj;
                
                Console.WriteLine($"Favorite animal : {animal.AnimalType} {animal.Talk()}");

                    }
            if (obj is ClassLibraryDTO.Bird)
                Console.WriteLine("The f!@#$ bird got out!");


            //ClassLibraryDTO.Person person = (ClassLibraryDTO.Person)myMessage.Body;


            //Person Only

            //Animal Only
            
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
