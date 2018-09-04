using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShaKyList
{

    #region
    public class Node
    {
        public Node Next;
        public object Value;
    }

    public class ShaKyList : IEnumerable, IEnumerator
    {
        public Node head;
        public Node current;
        public int Count;

        ///<summary>
        ///Create a new instance of this class.
        ///</summary>
        public ShaKyList()
        {
            head = new Node();
            current = head;
        }

        ///<summary>
        ///Used to index the current list.
        ///</summary>
        public object this[int index]
        {

            get
            {
                int count = 0;
                Node curr = head;
                while (count < Count)
                {
                    curr = curr.Next;
                    if (index != count)
                    {
                        count++;
                    }
                    else
                    {
                        return curr.Value;
                    }
                }
                return curr.Value;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                else if (index > Count)
                    throw new IndexOutOfRangeException();

                Node curr = head;
                int count = -1;

                while (count < Count)
                {
                    count++;
                    if (index == count)
                    {
                        Node newNode = new Node();
                        newNode.Value = value;

                        if (index == Count)
                        {
                            Count++;
                        }

                        if (curr.Next != null)
                        {
                            newNode.Next = curr.Next;
                            curr.Next = newNode;
                        }
                        else
                        {
                            current.Next = newNode;
                            current = newNode;
                        }
                        count = Count;
                    }
                    else
                    {
                        curr = curr.Next;
                    }
                }
            }
        }

        ///<summary>
        ///Remove a node at a specified index.
        ///</summary>
        public void RemoveAt(int index)
        {
            int count = 0;
            Node curr = head;

            //this checks if index requested is out of bounds
            try
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException e)
            {//if out of bounds throw exception and let user now of issue
                Console.WriteLine("Operation could not be performed!");
                Console.WriteLine(e.Message);
                Console.WriteLine();
                //set counter to Count so that preceeding while loop does not run
                count = Count;
            }


            while (count < Count)
            {
                if (index == count && count + 1 != Count)
                {
                    curr.Next = curr.Next.Next;
                    Count--;
                    count = Count;
                }
                else if (index == count && count + 1 == Count)
                {
                    curr.Next = null;
                    Count--;
                    count = Count;
                }
                else
                {
                    count++;
                    curr = curr.Next;
                }
            }

        }

        ///<summary>
        ///Remove all occurences of a specific object.
        ///</summary>
        public void RemoveAllOf(object o)
        {
            Node curr = head;
            //Node prev = curr;
            int count = 0;

            while (count < Count)
            {
                if (curr.Next != null && curr.Next.Value == o)
                {
                    curr.Next = (curr.Next.Next != null) ? curr.Next = curr.Next.Next : curr.Next = null;
                    Count--;
                    count--;
                }
                else if (curr.Next != null)
                {
                    curr = curr.Next;
                }
                count++;
            }

        }

        ///<summary>
        ///Insert a new node at the specified index.
        ///</summary>
        public void Insert(object data, int index)
        {
            this[index] = data;
        }

        ///<summary>
        ///Adds new node at the start of the list.
        /// </summary>
        public void Add(object data)
        {
            Node newNode = new Node() { Value = data };
            newNode.Next = head.Next;
            head.Next = newNode;
            Count++;
        }

        ///<summary>
        ///Adds new node at the end of the list.
        ///</summary>
        public void AddAtLast(object data)
        {
            Node newNode = new Node();
            newNode.Value = data;
            current.Next = newNode;
            current = newNode;
            Count++;
        }

        ///<summary>
        ///Checks if current List Contains object
        /// </summary>
        public bool Contains(object data)
        {
            foreach (object item in this)
            {
                if (item.Equals(data)) return true;
            }

            return false;
        }

        ///<summary>
        ///Print all nodes from start to end.
        ///</summary>        
        public void PrintAllNodes(ShaKyList data)
        {
            Console.WriteLine("Head");
            Node curr = data.head;
            while (curr.Next != null)
            {
                curr = curr.Next;
                Console.WriteLine(curr.Value);
            }
            Console.WriteLine("Null");
        }

        /// <summary>
        /// Prints all nodes in reverse order
        /// </summary>
        public void PrintReverse()
        {
            int count = 0;
            Node curr = head;

            ShaKyList reverseList = new ShaKyList();

            while (count < Count)
            {
                if (curr != null && curr.Next != null)
                {
                    curr = curr.Next;
                    reverseList.Add(curr.Value);
                }
                count++;
            }
            reverseList.PrintAllNodes(reverseList);
        }

        /// <summary>
        /// ToList method
        /// </summary>
        public List<object> ToList()
        {
            List<object> temp = new List<object>();
            foreach (var item in this)
            {
                temp.Add(item);
            }
            return temp;
        }

        /// <summary>
        /// ToArray method
        /// </summary>
        public object[] ToArray()
        {
            object[] temp = new object[this.Count];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = this[i];
            }
            return temp;
        }

        //enumerator for foreach loop
        #region
        int position = -1;
        public Node enumNode;

        public IEnumerator GetEnumerator()
        {
            enumNode = head;
            return (IEnumerator)this;
        }

        //IEnumerator
        public bool MoveNext()
        {
            position++;
            enumNode = enumNode.Next;
            return (position < Count);
        }

        //IEnumerable
        public void Reset()
        { position = 0; }

        //IEnumerable
        public object Current
        {
            get { return enumNode.Value; }
        }
        #endregion

    }

    #endregion

}
