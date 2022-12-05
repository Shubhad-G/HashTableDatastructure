using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableDataStructure
{
    internal class MyMapNode<K,V>
    {
        int size;//size of the hash table
      private readonly LinkedList<KeyValue<K, V>>[] items;
        public MyMapNode(int size)//size of array is initialized in the constructor
        {
            this.size = size;
            items=new LinkedList<KeyValue<K, V>>[size];//here initialize the items linkedlist variable
        }
        public int GetArrayPosition(K key)//method for calculating the array(hash table) position to insert or retrieve the value from the hash table based on the key
        {
            int position=key.GetHashCode()%size;//here GetHashCode() is the built in fuction which is used to calculate the modulus with size
            return Math.Abs(position);//to get absulute integer value (since key can be anything like string or floating point number but we have to convert it to integer value so that index positon can be calculated)
        }
        public V Get(K key)
        {
            int position=GetArrayPosition(key);
            LinkedList<KeyValue<K,V>> linkedList =GetLinkedList(position);//here we will get the linked list present in the hash table at that position
            foreach(KeyValue<K,V> item in linkedList)//to iterate through the linked list to get the value based on the key
            {
                if(item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        public LinkedList<KeyValue<K,V>> GetLinkedList(int position)//method to get the linked list present at the index value(position) in the hash table
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if(linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        public void Add(K key,V value)//method add the data in the hash table 
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K,V>> linkedList=GetLinkedList(position);
            KeyValue<K,V> item= new KeyValue<K, V>() { Key=key,Value=value };
            linkedList.AddLast(item);
        }
        public void Remove(K key)//method to remove the data from the hash table
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K,V> foundItem = default(KeyValue<K,V>);
            foreach(KeyValue<K,V> item in linkedList)
            {
                if(item.Key.Equals(key))
                {
                    itemFound=true;
                    foundItem=item;
                }
            }
            if(itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
        public bool Exists(K key)
        {
            var linkedList = GetLinkedList(GetArrayPosition(key));
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }



        public void Display()
        {
            foreach (var linkedList in items)
            {
                if (linkedList != null)
                    foreach (var element in linkedList)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key + " " + element.Value);
                    }
            }
        }




        public void CountNumbOfOccurence(string paragraph)
        {
            MyMapNode<string, int> hashTabe = new MyMapNode<string, int>(6);
            string[] words = paragraph.Split(' ');
            foreach (string word in words)
            {
                if (hashTabe.Exists(word.ToLower()))
                    hashTabe.Add(word.ToLower(), hashTabe.Get(word.ToLower()) + 1);
                else
                    hashTabe.Add(word.ToLower(), 1); //to,1 
            }
            Console.WriteLine("Words and their frequency of occurrences ");
            hashTabe.Display();
        }
        public struct KeyValue<k,v>
        {
            public K Key { get; set; }
            public V Value { get; set; }
        }
    }
}
