using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding requirements: Multiple scriptures in a list
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.")
        };

        // Randomly choose one scripture
        Random rnd = new Random();
        Scripture selectedScripture = scriptures[rnd.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            selectedScripture.Display();

            if (selectedScripture.AllWordsHidden())
                break;

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            selectedScripture.HideRandomWords();
        }
    }

}