using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {

        static void Main(string[] args)
        {
            Random rng = new Random();
            bool cont = true;
            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            string contString = Console.ReadLine();

            if (contString.ToLower() == "no")
            {
                return;
            }

            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();

            Console.Write("What is your age? ");
            int userAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            string seeListString = Console.ReadLine();
            bool seeList = false;
            if (seeListString.ToLower() == "sure")
            {
                seeList = true;
            }

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.WriteLine($"{activity}");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                string addToListString = Console.ReadLine();
                bool addToList = false;

                if (addToListString.ToLower() == "yes")
                {
                    addToList = true;
                }

                Console.WriteLine();

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();

                    activities.Add(userAddition);

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addToListString = Console.ReadLine();
                    if (addToListString.ToLower() == "no")
                    {
                        addToList = false;
                    }
                }
            }

            string randomActivity = "";

            while (cont)
            {
                Console.Write("Connecting to the database");

                for (int i = 0; i < 5; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();

                Console.Write("Choosing your random activity");

                for (int i = 0; i < 5; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();

                var randomNumber = rng.Next(activities.Count);

                randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");

                    activities.Remove(randomActivity);

                    randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                contString = Console.ReadLine();
                if (contString.ToLower() == "keep")
                {
                    cont = false;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Okay {userName}, enjoy your {randomActivity}");
        }
    }
}
