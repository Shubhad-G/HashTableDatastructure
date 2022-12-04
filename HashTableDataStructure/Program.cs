using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HashTableDataStructure
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            MyMapNode<string, int> hashTabe = new MyMapNode<string, int>(6);
            string paragraph2 = "Paranoids are not paranoid " +
                "because they are paranoid but " +
                "because they keep putting themselves " +
                "deliberately into paranoid avoidable " +
                "situations";
            string[] words = paragraph2.Split(' ');
            foreach (string word in words)
            {
                if (hashTabe.Exists(word.ToLower()))
                    hashTabe.Add(word.ToLower(), hashTabe.Get(word.ToLower()) + 1);
                else
                    hashTabe.Add(word.ToLower(), 1); //to,1 
            }
            Console.WriteLine("All words counted .");
            hashTabe.Display();
            string s = "avoidable";
            hashTabe.Remove(s);
            Console.WriteLine();
            Console.WriteLine($"A word \"{s}\" has been removed ");
            hashTabe.Display();

            Console.ReadLine();

        }
    }
}
