using System;
using System.Collections.Generic;

namespace HashtagGenerator
{
    public class Generator
    {
        private bool isLaunched = false;

        private List<string> hashtags;

        public Generator()
        {
            hashtags = Saving.Load();
            MainMenu();
        }

        public void MainMenu()
        {
            if (isLaunched)
                Console.Clear();
            else
                isLaunched = true;

            Console.WriteLine("What do you want to do? Enter the corresponding number");
            Console.WriteLine("\n1 - See all hashtags" +
                              "\n2 - Add hashtag" +
                              "\n3 - Remove hashtag" +
                              "\n4 - Generate hashtags");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowAllHashtags();
                    break;
                case "2":
                    AddHashtag();
                    break;
                case "3":
                    RemoveHashtag();
                    break;
                case "4":
                    GenerateHashtags();
                    break;
                default:
                    Console.WriteLine("Please enter a valid command");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }

        public void ShowAllHashtags()
        {
            Console.Clear();

            // No hashtags
            if (hashtags.Count == 0)
            {
                Console.WriteLine("No hashtags saved!");
                Console.ReadKey();

                MainMenu();
                return;
            }

            foreach (string hashtag in hashtags)
                Console.WriteLine(hashtag);

            Console.ReadKey();
            MainMenu();
        }

        public void AddHashtag()
        {
            bool correctAnswer = false;

            Console.Clear();

            Console.WriteLine("Enter the hashtag you wish to add: ");
            string newHashtag = Console.ReadLine();

            while (!correctAnswer)
            {
                Console.Clear();
                Console.WriteLine("Is '" + newHashtag + "' correct? y/n");
                string answer = Console.ReadLine();

                // Wrong hashtag entered
                if (answer == "n")
                {
                    correctAnswer = true;
                    AddHashtag();
                    return;
                } // Good hashtag entered
                else if (answer == "y")
                {
                    correctAnswer = true;
                    break;
                }

                // Wrong key entered
                if (answer != "n" || answer != "y")
                {
                    Console.WriteLine("Please enter a valid command");
                    Console.ReadKey();
                }
            }

            // Hashtag already exits
            if (hashtags.Contains(newHashtag))
            {
                Console.WriteLine("Hashtag already exits!");
                Console.ReadKey();

                MainMenu();
                return;
            }

            // Adding the hashtag
            hashtags.Add(newHashtag);
            Saving.Save(hashtags);
            Console.WriteLine("Hashtag added!");
            Console.ReadKey();

            MainMenu();
        }

        public void RemoveHashtag()
        {
            bool correctAnswer = false;

            Console.Clear();

            // No hashtags
            if (hashtags.Count == 0)
            {
                MainMenu();
                return;
            }

            Console.WriteLine("Enter the hashtag you wish to remove: ");
            string oldHashtag = Console.ReadLine();

            while (!correctAnswer)
            {
                Console.Clear();
                Console.WriteLine("Do you wish to remove '" + oldHashtag + "' ? y/n");
                string answer = Console.ReadLine();

                // Wrong hashtag entered
                if (answer == "n")
                {
                    correctAnswer = true;
                    RemoveHashtag();
                    return;
                } // Good hashtag entered
                else if (answer == "y")
                {
                    correctAnswer = true;
                    break;
                }

                // Wrong key entered
                if (answer != "n" || answer != "y")
                {
                    Console.WriteLine("Please enter a valid command");
                    Console.ReadKey();
                }
            }

            // Hashtag doesn't exist
            if (!hashtags.Contains(oldHashtag))
            {
                Console.WriteLine("Hashtag doesn't exits!");
                Console.ReadKey();

                MainMenu();
                return;
            }

            // Removing the hashtag
            hashtags.Remove(oldHashtag);
            Saving.Save(hashtags);
            Console.WriteLine("Hashtag removed!");
            Console.ReadKey();

            MainMenu();
        }

        public void GenerateHashtags()
        {
            Console.Clear();

            // No hashtags
            if (hashtags.Count == 0)
            {
                MainMenu();
                return;
            }

            Console.WriteLine("How many hashtags do you want?");
            int amountHashtags = int.Parse(Console.ReadLine());
            Console.Clear();

            Random rand = new Random();

            for (int i = 0; i < amountHashtags; i++)
            {
                int randNumber = rand.Next(0, hashtags.Count);
                Console.WriteLine(hashtags[randNumber]);
            }

            Console.ReadKey();
            MainMenu();
        }
    }
}
