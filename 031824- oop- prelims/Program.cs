using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _031824__oop__prelims
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter the path of the text file:");
            Console.ResetColor();
            string filePath = Console.ReadLine();

            string text = File.ReadAllText(filePath);

            int wordCount = CountWords(text);
            int sentenceCount = CountSentences(text);

            bool generateWordCountBreakdown = AskUserForOption("Do you want to generate the word count breakdown? (Y/N)");
            (string[], int[]) wordCountBreakdown = generateWordCountBreakdown ? CountWordBreakdownArray(text) : (null, null);

            WriteResultsToFile(wordCount, sentenceCount, wordCountBreakdown);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Results have been written to the output file.");
            Console.ResetColor();
        }

        static int CountWords(string text)
        {
            string[] words = text.Split(new char[] { ' ', '\n', '\r', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        static int CountSentences(string text)
        {
            string[] sentences = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            return sentences.Length;
        }

        static (string[], int[]) CountWordBreakdownArray(string text)
        {
            string[] words = text.Split(new char[] { ' ', '\n', '\r', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> uniqueWords = new List<string>(); 
            List<int> counts = new List<int>(); 
            foreach (string word in words)
            {
                int index = uniqueWords.IndexOf(word);
                if (index != -1)
                {
                    counts[index]++;
                }
                else
                {
                    uniqueWords.Add(word);
                    counts.Add(1);
                }
            }

            return (uniqueWords.ToArray(), counts.ToArray()); 
        }

        static void WriteResultsToFile(int wordCount, int sentenceCount, (string[], int[]) wordCountBreakdown)
        {
            if (wordCountBreakdown.Item1 == null) return; 

            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                writer.WriteLine("⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽");

                writer.WriteLine("Word Count: " + wordCount);
                writer.WriteLine("Sentence Count: " + sentenceCount);
                writer.WriteLine("Word Count Breakdown:");

                for (int i = 0; i < wordCountBreakdown.Item1.Length; i++)
                {
                    writer.WriteLine(wordCountBreakdown.Item1[i] + ": " + wordCountBreakdown.Item2[i]);
                }
                writer.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣯⣽⣿⣿⢗⣲⣿⣼⡰⣺⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                writer.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣭⠹⣿⣾⠿⣿⣷⣾⣿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                writer.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣍⣨⠾⣿⣷⣽⣾⣻⣦⣽⣾⣸⢿⣿⣮⣝⣿⣿⣟⣿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                writer.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⢯⢫⡜⢿⣿⣿⣿⣿⡋⢿⢿⡋⢩⣝⣿⠻⣽⣿⡛⣿⣛⣵⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                writer.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣮⡟⠰⣾⣿⣏⠛⠫⣿⢿⣧⢻⣦⡛⢚⣿⣦⣨⠿⣧⣽⡺⣿⣿⣿⢛⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                writer.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⣷⣿⣿⣿⣏⣧⠸⣼⣿⣏⣿⠿⠞⣘⣹⣗⣦⣌⢧⣹⡯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                writer.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⣽⣿⣿⣾⡈⣿⠛⢿⡙⠢⡞⢃⢻⠻⡿⣈⣏⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                writer.WriteLine("⣿⣿⣿⣿⣿⣿⣿⠿⠿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢟⣿⣳⣻⣷⠿⠃⠿⠃⢐⡨⣼⣷⡾⠷⠭⢷⣻⣚⠲⢤⡻⣿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⣩⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                writer.WriteLine("⣿⣿⣿⢿⣿⣿⣿⢹⣾⣿⠿⣛⣿⣿⠛⠿⠱⢷⣼⣎⣱⣿⣅⡠⠀⠀⢀⡾⠀⠙⠛⣃⡴⠶⣜⠛⠉⠀⠀⢱⣈⢚⣻⣿⢿⢿⡿⢿⣭⡽⢿⣾⣿⣾⣿⣌⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                writer.WriteLine("⣿⣿⣿⣿⣽⣿⣿⣿⣿⣿⡷⣀⠍⢑⣶⡶⣆⣇⣏⢪⡇⠙⠡⡊⣠⣤⣾⢿⣷⣿⣿⣿⡀⠀⢈⣷⣶⣶⡾⣿⡿⣵⣟⠺⣒⠋⡿⢧⡈⣹⣿⣿⣻⡾⢛⢇⣽⣿⣿⣿⣿⣿⣿⢟⣿");
                writer.WriteLine("⣿⣿⣻⣿⣟⣻⣏⠻⣿⣿⣿⣟⣶⣖⡋⢫⠓⣿⡿⣎⣡⣤⣤⣾⣿⣿⢷⣿⣿⣿⣿⣿⣿⣶⣿⣿⣿⣿⣿⣿⣿⣿⣻⣷⣾⡟⠁⣰⣾⣿⣟⣽⠿⢱⣋⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                writer.WriteLine("⠿⣿⢟⣼⣿⣿⣮⣳⣭⠻⣿⣿⡿⣿⣷⣌⠻⢹⠖⠘⢿⣿⣿⣧⣧⣿⣿⣿⣦⣛⣾⣾⣻⣘⣿⡿⠋⣻⣻⣿⣿⢿⣿⣷⣽⢧⣽⣿⠛⣿⡿⣽⣖⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
                writer.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣯⣿⡛⡝⢻⣿⣿⣿⣷⣄⡀⠀⠸⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡵⣿⣿⣿⣦⣿⣴⣿⣿⢿⢇⣹⣿⡽⢃⣰⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⠿⢿⣿");
                writer.WriteLine("⣻⣿⣿⣿⣿⣿⣿⠻⣆⢿⣿⢁⡦⠙⣿⣿⡿⣿⣿⣦⣄⡐⢼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡽⢻⣵⣿⣿⣿⣿⣿⣿⣿⠿⣿⣿⢏⡔⣾⣿⣿⣿⣿⣿⡷⣿⣿⣷⣿⣯⣽⡿⢻⣿");
                writer.WriteLine("⠛⢿⣿⣿⣿⣿⣿⣿⣟⢿⣿⣯⢹⡼⡕⣝⠻⣿⣿⣿⣿⣿⣿⣮⣿⣿⡝⢻⣿⣿⣿⣿⣿⣽⣿⣦⣿⣿⣿⣯⣿⣿⣿⣽⣿⡟⠩⣽⣽⣿⣿⣿⣿⠿⠋⣿⣿⢿⣽⣿⣿⣷⣿⡌⠉");
                writer.WriteLine("⠀⢸⠱⣩⣿⡿⡙⣇⣾⣿⣱⡽⠽⠤⠧⣽⣆⡉⠻⣷⣾⣿⣿⢿⣿⣻⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣽⢿⣏⣹⢿⣿⣿⣿⣿⠃⢸⢻⣿⣿⢿⣿⣿⣿⣿⣿⣧⣝⠿⠻⢿⣹⠟⠡⠂");
                writer.WriteLine("⠀⠀⠛⠇⣿⣿⣇⣉⠿⣵⣿⡉⡳⣦⢹⡇⡞⠳⡆⣼⣿⢯⣻⣿⣿⠿⣼⣃⣽⣾⡻⠏⡿⠿⣿⠿⠗⠠⠏⢶⠿⣭⣿⣾⣿⡆⠀⠘⠷⢻⣿⣋⣁⢻⢿⡛⡩⣽⣷⣧⠎⡛⠀⠀");
                writer.WriteLine();
                writer.WriteLine("⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽ ◯ ☾₊‧˙⋆˚｡⁺⋆⋆⁺｡˚⋆˙‧₊☽");
            }
        }
        static bool AskUserForOption(string message)
        {
            Console.WriteLine(message);

            string response = Console.ReadLine().Trim().ToUpper();
            return response == "Y" || response == "YES";
        }

    }
}
