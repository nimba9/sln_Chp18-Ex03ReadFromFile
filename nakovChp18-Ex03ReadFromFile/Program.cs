using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CountInFile
{
    class File_WordCounter
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();
            string text = string.Empty;
            try
            {
                text = File.ReadAllText(filePath, Encoding.ASCII);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
                return;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found.");
                return;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("No path specified.");
                return;
            }

            Dictionary<string, int> dictio = new Dictionary<string, int>();
            string[] wordsArr = text.Split(new char[] { ' ', ',', '!', '.', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string unit in wordsArr)
            {
                string lowerWord = unit.ToLower();
                if (dictio.ContainsKey(lowerWord))
                {
                    dictio[lowerWord]++;
                }
                else
                {
                    dictio.Add(lowerWord, 1);
                }
            }

            foreach (KeyValuePair<string, int> word in dictio.OrderBy(word => word.Value).ThenBy(word => word.Key))
            {
                Console.WriteLine("{0} -> {1} times", word.Key, word.Value);
            }
        }
    }
}