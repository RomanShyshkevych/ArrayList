using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class LList2 : IList
    {
        class Node
        {
            public int val;
            public Node next;
            public Node end;
            public Node(int val)
            {
                this.val = val;
            }
        }
        Node head = null;
        Node tail = null;
        public void Init(int[] ini)
        {
            if (ini == null)
                ini = new int[0];
            for (int i = ini.Length - 1; i >= 0; i--)
            {
                AddStart(ini[i]);
            }
        }
        public int Size()
        {
            int ret = 0;
            Node p = head;
            while (p != null)
            {
                p = p.next;
                ret++;
            }
            return ret;
        }
        public void Clear()
        {
            head = null;
        }
        public override String ToString()
        {
            string net = "";
            int i = 0;
            Node p = head;
            while (p != null)
            {
                net += p.val + ((i == Size() - 1) ? "" : ", ");
                p = p.next;
                i++;
            }
            return net;
        }
        public int[] ToArray()
        {
            int[] ret = new int[Size()];
            int i = 0;
            Node p = head;
            while (p != null)
            {
                ret[i++] = p.val;
                p = p.next;
            }
            return ret;
        }
        public void AddStart(int val)
        {
            Node tmp = new Node(val);
            tmp.next = head;
            tmp.end = null;
            head = tmp;
        }
        public void AddEnd(int val)
        {
            AddPos(Size(), val);
        }
        public void AddPos(int pos, int val)
        {
            if (pos > Size() || pos < 0)
                throw new WrongIndexException();
            if (pos == 0)
                AddStart(val);
            else
            {
                int i = 1;
                Node p = head;
                while (true)
                {
                    if (i == pos)
                    {
                        Node tmp = new Node(val);
                        if (p.next == null)
                            tail = tmp;
                        tmp.next = p.next;
                        tmp.end = p;
                        p.next = tmp;
                        break;
                    }
                    p = p.next;
                    i++;
                }
            }
        }
        public int DelStart()
        {
            if (head == null)
                throw new EmptyListException();
            int ret = head.val;
            head.end = null;
            head = head.next;
            return ret;
        }
        public int DelEnd()
        {
            if (Size() == 0)
                throw new EmptyListException();
            int ret = DelPos(Size() - 1);
            return ret;
        }
        public int DelPos(int pos)
        {
            if (Size() == 0)
                throw new EmptyListException();
            if (pos >= Size() || pos < 0)
                throw new WrongIndexException();
            int ret = 0;
            if (pos == 0)
                ret = DelStart();
            else
            {
                int i = 1;
                Node p = head;
                while (true)
                {
                    if (i == pos)
                    {
                        ret = p.next.val;
                        p.next = p.next.next;
                        tail = p.next;
                        break;
                    }
                    p = p.next;
                    i++;
                }
            }
            return ret;
        }
        public int Min()
        {
            if (Size() == 0)
                throw new EmptyListException();
            Node p = head;
            int min = head.val;
            while (p != null)
            {
                if (p.val < min)
                    min = p.val;
                p = p.next;
            }
            return min;
        }
        public int Max()
        {
            if (Size() == 0)
                throw new EmptyListException();
            Node p = head;
            int max = head.val;
            while (p != null)
            {
                if (p.val > max)
                    max = p.val;
                p = p.next;
            }
            return max;
        }
        public int MinPos()
        {
            if (Size() == 0)
                throw new EmptyListException();
            Node p = head;
            int minPos = 0;
            int min = p.val;
            int i = 0;
            while (p != null)
            {
                if (p.val < min)
                {
                    min = p.val;
                    minPos = i;
                }
                p = p.next;
                i++;
            }
            return minPos;
        }
        public int MaxPos()
        {
            if (Size() == 0)
                throw new EmptyListException();
            Node p = head;
            int maxPos = 0;
            int max = p.val;
            int i = 0;
            while (p != null)
            {
                if (p.val > max)
                {
                    max = p.val;
                    maxPos = i;
                }
                p = p.next;
                i++;
            }
            return maxPos;
        }
        public void Set(int pos, int val)
        {
            if (Size() == 0)
                throw new EmptyListException();
            if (pos > Size() || pos < 0)
                throw new WrongIndexException();
            if (pos == 0)
                head.val = val;
            int i = 0;
            Node p = head;
            while (true)
            {
                if (i == pos)
                {
                    p.val = val;
                    break;
                }
                p = p.next;
                i++;
            }
        }
        public int Get(int pos)
        {
            if (Size() == 0)
                throw new EmptyListException();
            if (pos > Size() || pos < 0)
                throw new WrongIndexException();
            int res = 0;
            int i = 0;
            Node p = head;
            while (true)
            {
                if (i == pos)
                {
                    res = p.val;
                    break;
                }
                p = p.next;
                i++;
            }
            return res;
        }
        public void Sort()
        {
            if (Size() == 0)
                throw new EmptyListException();
            bool found;
            do
            {
                found = false;
                Node p = head;
                while (p != null && p.next != null)
                {
                    if (p.val > p.next.val)
                    {
                        int temp = p.val;
                        p.val = p.next.val;
                        p.next.val = temp;
                        found = true;
                    }
                    p = p.next;
                }
            } while (found);
        }
        public void Reverse()
        {
            if (head == null)
                return;

            Node cp = head;
            Node prev = null;

            while (cp != null)
            {
                Node next = cp.next;
                cp.next = prev;
                prev = cp;
                cp = next;
            }
            head = prev;
        }
        public void HalfReverse()
        {
            if (head == null)
                return;
            int[] arr = ToArray();
            HalfRev(arr);
            Clear();
            Init(arr);

        }
        private void HalfRev(int[] arr)
        {
            int[] t = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                t[i] = arr[i];
            }
            int n = arr.Length / 2;
            for (int i = 0; i < n; i++)
            {
                arr[i] = t[arr.Length - n + i];
                arr[arr.Length - n + i] = t[i];
            }
        }
    }
}
