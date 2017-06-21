using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckOfCards.Common.Models;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to the Deck Manager 2000!");
            Console.WriteLine("For all of your deck making, sorting and shuffling needs, please press any key to continue...");

            Console.ReadKey();

            var deck = new Deck();
            Console.WriteLine("A deck of cards has been created for you, enter a command to do something with it.");

            while (true)
            {
                Console.WriteLine("Please enter a command...");
                var input = Console.ReadLine()?.ToLower();

                if (input == "exit")
                {
                    break;
                }

                switch (input)
                {
                    case "new":
                        deck = new Deck();
                        Console.WriteLine("A new deck has been created for you!");
                        break;
                    case "shuffle":
                        deck.Shuffle();
                        Console.WriteLine("Your deck has been shuffled!");
                        break;
                    case "view":
                        PrintDeck(deck);
                        break;
                    case "sort":
                        deck.SortAscending();
                        Console.WriteLine("Your deck has been sorted by suit first then by card value (spades are 0).");
                        break;
                    case null:
                    case "":
                        break;
                    default:
                        WriteHelp();
                        break;
                }
            }
        }

        static void PrintDeck(Deck deck)
        {
            Console.WriteLine("Currently, your deck looks like this: ");
            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine($"{deck.Cards[i].Value} of {deck.Cards[i].Suit}s");
            }
        }

        static void WriteHelp()
        {
            Console.WriteLine("Commands: ");
            Console.WriteLine("new - generates a new deck for you!");
            Console.WriteLine("shuffle - shuffles your deck for you!");
            Console.WriteLine("view - prints your deck out so you can look at it!");
            Console.WriteLine("sort - sorts your deck in ascending order!");
            Console.WriteLine("exit - Exits program.");
            Console.WriteLine("help - Prints this message again for your viewing pleasure.");
        }
    }
}
