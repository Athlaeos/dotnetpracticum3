using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DotnetPracticum3
{
    class Program
    {
        static void Main()
        {
            String path = @"D:\dotnet_workspace\DotnetPracticum3\randomtext.txt";
            foreach (String word in GetWords(path, s => s.StartsWith("a")))
                Console.Write("{0}; ", word);
            Console.WriteLine("\nPress any key to continue\n");
            Console.ReadKey();

            String[] words = GetWords(path, s => s.StartsWith("b")).ToArray();
            Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));
            foreach (String word in words)
                Console.Write("{0}; ", word);
            Console.WriteLine("\nPress any key to quit program\n");
            Console.ReadKey();
        }

        public static IEnumerable<String> GetWords(string path, Func<String, bool> condition)
        {
            String text = "";
            try
            {
                text = System.IO.File.ReadAllText(path);
            } catch (DirectoryNotFoundException)
            { Console.WriteLine("\nInvalid directory, are you sure it's written correctly?\n"); }
            String[] words = text.Split(new char[] {' ', '\n'});
            foreach (String word in words)
            if (condition(word)) yield return word;
        }
    }
}
