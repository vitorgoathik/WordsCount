using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> occurrences = new Dictionary<string, int>();
            using (StreamReader reader = File.OpenText(@"C:\Users\goathik\Downloads\textdocument.txt"))
            {
                //read our text until the end, use it in a variable removing the \r\n formatting
                string text = reader.ReadToEnd().Replace(System.Environment.NewLine, " ");
                //grab the list of words by trimmed space split
                string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //go through the distincted words only, find and store the amount of times each word shows in the words list
                words.Distinct().ToList().ForEach(o => occurrences.Add(o, words.Count(j => j == o)));
            }//close the reader
            //print it out
            foreach(var group in occurrences)
            {
                Console.WriteLine($"{group.Value}: {group.Key}");
            }
            Console.Read();
        }
    }
}
