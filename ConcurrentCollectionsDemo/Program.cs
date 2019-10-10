using System;
using System.Collections.Generic;
using System.Threading;

namespace ConcurrentCollectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<int> listOfIntegers = new List<int> { 1, 2, 3, 4, 5 };
            //Hilo de ejecución 1
            new Thread(() => {
                
                Console.WriteLine("Adición, thread #{0}", Thread.CurrentThread.GetHashCode());
                
                for (int i = 0; i < 1000; i++)//Agrega elementos a la lista
                    listOfIntegers.Add(i);
               
            }).Start();
            //Hilo de ejecución 2
            new Thread(() => {

                Console.WriteLine("Recorrido, thread #{0}", Thread.CurrentThread.GetHashCode());

                foreach (var num in listOfIntegers)//Recorre la lista
                    Console.WriteLine(num);

            }).Start();

            Console.ReadKey();
        }
    }
}


