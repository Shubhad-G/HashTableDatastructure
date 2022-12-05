using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableDataStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hash table program");
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            string sentence = "To be or not to be";
            hash.CountNumbOfOccurence(sentence);
            Console.ReadLine();

        }
    }
}
