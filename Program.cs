using IndusApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndusApp
{
    class Program
    {
        //1) кастомный делегат никогда не юзай! Юзай EventHandler!
        //2)Gethashcode нужен для использования в хеш таблицах больше нигде не используется (не юзай для сравнения объектов)
        //3)Юзай интерфейсы

        static void Main(string[] args)
        { 
            List<int> _list = new List<int>() { 1, 1, 3, 4, 5, 6, 7, 8 };
            Set<int> _setiche = new Set<int>(_list);



            _setiche.Remove(4);
            _setiche.Add(1);
            _setiche.Add(2);
            _setiche.Add(3);
        }
    }


    public class LinkedList<T>
    {
      public T Data { get; }
      public  LinkedList(T data)
        {
            Data = data;


        }

        public LinkedList<T> Next { get; set; }

    }



    public class Set<T> : ISet<T> where T: System.IEquatable<T>/*,  ISet<T> */
    {

        LinkedList<T> head;
        LinkedList<T> tail;
        /*  readonly */
        int count;  
        public Set()
        {

        }

        public Set(List<T> list)
        {
            foreach(var s in list)
            {
                Add(s);
            }
        }

        public Set(IEnumerable<T> enumer)
        {

            foreach (var s in enumer)
            {
                Add(s);
            }
        }


        public void Add(T elem)
        {
            if (!Contains(elem))
            {
            LinkedList<T> node = new LinkedList<T>(elem);
           
            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;
                count++;
            }
        }

        public bool Remove(T elem)
        {

            LinkedList<T> current = head;
            LinkedList<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(elem))
                {
                    if (previous != null)
                    {                 
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {

                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            throw new Exception("Sorry bro:(");          
        }

        //public T Find()

        public bool Contains(T data)
        {
            LinkedList<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }



    }




    


    

}
