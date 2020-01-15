using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDTO
{

    public interface IAnimal
    {
        string AnimalType { get; set; }

    }
    public interface IAnimalLand
    {
        int NumberOfLegs { get; set; }
        string Talk();
    }

    

    public class Animal
    {
        public string AnimalType { get; set; } = "";


        public virtual string Talk()
        {
            return "";
       
        }

    }



    public class Dog : Animal
    {
        //Constructor
        public Dog()
        {
            AnimalType = "Dog";
        }
        public override string Talk()
        {
            return "Woof";
        }
    }

    public class Cat : Animal
    {
        public Cat()
        {
            AnimalType = "Cat";

        }
        public override string Talk()
        {
            return "Meow";
        }

    }


    public class Fish : Animal
    {
        public Fish()
        {
            AnimalType = "Fish";

        }
        public override string Talk()
        {
            return "Nothing";
        }

    }


    public class Person
    {

        public string Name { get; set; }
        public string Surname { get; set; }

        public int Age { get; set; }
        

        public string GetInitial()
        {
            return Name[0].ToString().ToUpper() + Surname[0].ToString();
           
        }

        public string IsAllowedToDrink()
        {
            if (Age == 18)
                return "just made it.";

            if(Age >= 18) 
            {
                return "Yes, Drink Responsibly";
            }

            return "Sorry dude";
            // End of Code Block Here
        }





    }
}
