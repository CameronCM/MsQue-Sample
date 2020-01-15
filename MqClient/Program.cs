using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MqClient
{
    class Program
    {
        static string myQPath = @".\private$\myQ";

        static void Main(string[] args)
        {
            CreateQueue(myQPath);

            do
            {


                //--Person
                //Create instance of Person Class = Person Object
                ClassLibraryDTO.Person p = new ClassLibraryDTO.Person();

                //Get User Input and assign Properties of Object with return 
                Console.WriteLine("Enter Name:");
                p.Name = Console.ReadLine();
                Console.WriteLine("Enter Surname:");
                p.Surname = Console.ReadLine();
                Console.WriteLine("Enter Age:");
                p.Age =Convert.ToInt32(Console.ReadLine());
                



                //--Animal
                Console.WriteLine("Enter Favorite animal? Cat/Dog/Fish:");

                var animalType = Console.ReadLine();

                ClassLibraryDTO.Animal a = new ClassLibraryDTO.Animal();
                if (animalType.ToUpper() == "CAT")
                    a = new ClassLibraryDTO.Cat();
                if (animalType.ToUpper() == "DOG")
                    a = new ClassLibraryDTO.Dog();
                if (animalType.ToUpper() == "FISH")
                    a = new ClassLibraryDTO.Fish();

                //a.AnimalType = Console.ReadLine();




                //Call Method SendMessage and pass object Person
                SendMessage(p);
                SendMessage(a);// ?
                

            } while (true);


            //Console.WriteLine("Hello World!");
        }


        private static void SendMessage(ClassLibraryDTO.Animal value)
        {
            try
            {

                MessageQueue amq = new MessageQueue(myQPath);
                amq.Send(value);
                //Try and execute the code in ths code block if it fails / Exeptions etc.
            }
            catch (Exception e)
            {
                //Do something if try failed
                throw e;
            }
        }

        private static void SendMessage(ClassLibraryDTO.Person value)
        {
            try
            {
                MessageQueue mq = new MessageQueue(myQPath);
                //mq.Formatter = new XmlMessageFormatter(new Type[] { });
                //Message myMessage = new Message(value);
                mq.Send(value);
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
