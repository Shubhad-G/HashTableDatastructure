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
            Console.WriteLine("Hash table program");
          
            MyMapNode<string, int> hashTabe = new MyMapNode<string, int>(6);
            string paragraph = "Paranoids are not paranoid " +
                        "because they are paranoid but " +
                        "because they keep putting themselves " +
                        "deliberately into paranoid avoidable " +
                        "situations";
             hashTabe.CountNumbOfOccurence(paragraph);
           
            
            Console.ReadLine();

        }
    }
}
