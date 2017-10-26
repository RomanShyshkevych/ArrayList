using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class LListR: IList
    {
        class Node
        {
            public int val;
            public Node next = null;
            public Node prev = null;
            public Node(int val)
            {
                this.val = val;
            }
        }

        Node start = null;

        private Node GetNode(int pos)
        {
            Node p = start;
            for (int i = 0; i < pos; i++)
            {
                p = p.next;
            }
            return p;
        }

        public void AddEnd(int val)
        {
            if (Size() == 0)
            {
                AddStart(val);
            }
            else
            {
                AddPos(Size(), val);
            }
        }

        public void AddPos(int pos, int val)
        {
            if (pos < 0 || pos > Size())
                throw new WrongIndexException();

            if (pos == 0)
            {
                AddStart(val);
            }
            else
            {
                Node cur = GetNode(pos - 1);
                Node newNode = new Node(val);
                cur.next.prev = newNode;
                newNode.next = cur.next;
                cur.next = newNode;
                newNode.prev = cur;
            }

        }

        public void AddStart(int val)
        {
            if (Size() == 0)
            {
                Node temp = new Node(val);
                start = temp;
                start.next = start;
                start.prev = start;
            }
            else
            {
                Node newNode = new Node(val);
                start.prev.next = newNode;
                newNode.prev = start.prev;
                newNode.next = start;
                start.prev = newNode;
                start = newNode;
            }
        }

        public void Clear()
        {
            start = null;
        }

        public int DelEnd()
        {
            if (Size() == 0)
                throw new EmptyListException();

            int ret = 0;

            if (Size() == 1)
            {
                ret = DelStart();
                return ret;
            }
            else if (Size() == 2)
            {
                ret = start.prev.val;
                start.prev = start;
                start.next = start;
            }
            else
            {
                ret = start.prev.val;
                start.prev.prev.next = start;
                start.prev = start.prev.prev;
            }
            return ret;
        }

        public int DelPos(int pos)
        {
            if (Size() == 0)
                throw new EmptyListException();
            if (pos < 0 || pos > Size() - 1)
                throw new WrongIndexException();

            int ret = 0;
            if (pos == 0)
            {
                ret = DelStart();
            }
            else if (pos == Size() - 1)
            {
                ret = DelEnd();
            }
            else
            {
                Node cur = GetNode(pos - 1);
                ret = cur.next.val;
                cur.next.next.prev = cur;
                cur.next = cur.next.next;
            }
            return ret;
        }

        public int DelStart()
        {
            if (Size() == 0)
                throw new EmptyListException();

            int ret = start.val;

            if (Size() != 1)
            {
                if (Size() == 2)
                {
                    start = start.next;
                    start.next = start;
                    start.prev = start;
                }
                else
                {
                    start.prev.next = start.next;
                    start.next.prev = start.prev;
                    start = start.next;
                }
            }
            else
            {
                Clear();
            }

            return ret;
        }

        public int Get(int pos)
        {
            if (Size() == 0)
                throw new EmptyListException();
            if (pos < 0 || pos > Size() - 1)
                throw new WrongIndexException();

            return GetNode(pos).val;
        }

        public void HalfReverse()
        {
            if (Size() == 1 || Size() == 0)
                return;

            Node beforeMid = GetNode(Size() / 2 - 1);
            if (Size() % 2 != 0)
            {
                Node mid = beforeMid.next;
                beforeMid.next.next.prev = beforeMid;
                beforeMid.next = beforeMid.next.next;
                mid.prev = start.prev;
                mid.next = start;
                start.prev.next = mid;
            }
            start = beforeMid.next;
        }

        public void Init(int[] ini)
        {
            if (ini == null)
                ini = new int[0];

            for (int i = ini.Length - 1; i >= 0; i--)
            {
                AddStart(ini[i]);
            }
        }

        public int Max()
        {
            if (Size() == 0)
                throw new EmptyListException();

            int max = start.val;
            Node cur = start;
            for (int i = 0; cur.next != start; i++)
            {
                cur = cur.next;
                if (cur.val > max)
                    max = cur.val;
            }
            return max;
        }

        public int MaxPos()
        {
            if (Size() == 0)
                throw new EmptyListException();

            int ret = 0;
            Node cur = start;
            while (cur.next != start)
            {
                if (cur.val == Max())
                    break;
                ret++;
                cur = cur.next;
            }
            return ret;
        }

        public int Min()
        {
            if (Size() == 0)
                throw new EmptyListException();

            int min = start.val;
            Node cur = start;
            for (int i = 0; cur.next != start; i++)
            {
                cur = cur.next;
                if (cur.val < min)
                    min = cur.val;
            }
            return min;
        }

        public int MinPos()
        {
            if (Size() == 0)
                throw new EmptyListException();

            int ret = 0;
            Node cur = start;
            while (cur.next != start)
            {
                if (cur.val == Min())
                    break;
                ret++;
                cur = cur.next;
            }
            return ret;
        }

        public void Reverse()
        {
            if (Size() == 1 || Size() == 0)
                return;

            Node cur = start;

            do
            {
                Node tempCur = cur.next;
                cur.next = cur.prev;
                cur.prev = tempCur;
                cur = cur.prev;
            } while (cur != start);
            start = start.next;
        }

        public void Set(int pos, int val)
        {
            if (Size() == 0)
                throw new EmptyListException();
            if (pos < 0 || pos > Size() - 1)
                throw new WrongIndexException();

            GetNode(pos).val = val;
        }

        public int Size()
        {
            if (start == null)
                return 0;

            int ret = 1;
            Node cur = start;
            while (cur.next != start)
            {
                ret++;
                cur = cur.next;
            }
            return ret;
        }

        public void Sort()
        {
            for (int i = 0; i < Size() - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < Size(); j++)
                {
                    if (Get(j) < Get(min))
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    int temp = Get(i);
                    Set(i, Get(min));
                    Set(min, temp);
                }
            }
        }

        public int[] ToArray()
        {
            int[] temp = new int[Size()];
            for (int i = 0; i < Size(); i++)
            {
                temp[i] = Get(i);
            }
            return temp;
        }

        public override String ToString()
        {
            string ret = "";
            for (int i = 0; i < Size(); i++)
            {
                ret += Get(i) + ((i != Size() - 1) ? ", " : "");
            }
            return ret;
        }
    }
}
