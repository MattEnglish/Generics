using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counting_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var apple = new Apple();
            var apples = new Counter<Apple>();
            for (int appleNumber = 0; appleNumber < 10; appleNumber++)
            {
                apples.AddItem(new Apple());
            }
            Console.WriteLine("number of apples {0}",apples.Count);

            var boxes = new List<Box<Apple>>();
            for (int boxNumber = 0; boxNumber < 10; boxNumber++)
            {
                var apples2 = new List<Apple>();
                for (int appleNumber = 0; appleNumber < 12; appleNumber++)
                {
                    apples2.Add(new Apple());
                }
                Box<Apple> box2 = new Box<Apple>(apples2);
                boxes.Add(box2);
            }
            var cart = new Cart<Apple>(boxes);
            
            for (int appleNumber = 0; appleNumber < 10; appleNumber++)
            {
                apples.AddItem(new Apple());
            }


            Console.WriteLine("number of apples in cart {0}", cart.Count);
            Console.Read();
        }
    }

    public class Counter<T> where T:ICountable
    {
        public int Count = 0;
        
        public void AddItem(T item)
        {
            Count += item.Count;
        }
    }

    public interface ICountable
    {
        int Count { get; }
    }

    public class Apple : ICountable
    {
        public int Count { get; } = 1;
    }

    public class Box<T> : ICountable
    {
        public int Count { get; }

        public Box(List<T> list)
        {
            Count = list.Count;
        }      
    }

    public class Cart<T> : ICountable
    {
        public int Count { get; } = 0;

        public Cart(List<Box<T>> boxes)
        {
            foreach (var box in boxes)
            {
                Count += box.Count;
            }
        }    
    }
}
