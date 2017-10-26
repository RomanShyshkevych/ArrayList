using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class LListF : IList
    {
        class Node
        {
            public int val;
            public Node next = null;
            public Node(int val)
            {
                this.val = val;
            }
        }

        Node root = null;


        private Node GetNode(Node node, int pos)
        {
            if (pos != 0)
                node = GetNode(node.next, pos - 1);
            return node;
        }
        private Node GetEnd(Node node)
        {
            if (node == null)
                return null;

            if (node.next != null)
                node = GetEnd(node.next);
            return node;
        }


        public void AddEnd(int val)
        {
            if (Size() == 0)
            {
                AddStart(val);
            }
            else
            {
                GetEnd(root).next = new Node(val);
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
            else if (pos == Size())
            {
                AddEnd(val);
            }
            else
            {
                Node cur = GetNode(root, pos - 1);
                Node newNode = new Node(val);
                newNode.next = cur.next;
                cur.next = newNode;
            }

        }
        public void AddStart(int val)
        {
            Node temp = new Node(val);
            temp.next = root;
            root = temp;
        }

        public void Clear()
        {
            root = null;
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
            else
            {
                Node cur = GetNode(root, Size() - 2);
                ret = cur.next.val;
                cur.next = null;
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
                Node cur = GetNode(root, pos - 1);
                ret = cur.next.val;
                cur.next = cur.next.next;
            }
            return ret;
        }
        public int DelStart()
        {
            if (Size() == 0)
                throw new EmptyListException();

            int ret = root.val;

            if (Size() != 1)
                root = root.next;
            else
                root = null;

            return ret;
        }


        public int Get(int pos)
        {
            if (Size() == 0)
                throw new EmptyListException();
            if (pos < 0 || pos > Size() - 1)
                throw new WrongIndexException();

            return GetNode(root, pos).val;
        }

        public void HalfReverse()
        {
            if (Size() == 1 || Size() == 0)
                return;

            Node cur = GetEnd(root);
            Node mid = GetNode(root, Size() / 2 - 1);
            if (Size() % 2 != 0)
            {
                cur.next = mid.next;
                mid.next = mid.next.next;
                cur = cur.next;
            }
            cur.next = root;
            root = mid.next;
            mid.next = null;
        }

        private void InitArray(int[] ini, int n)
        {
            AddStart(ini[n--]);
            if (n >= 0) InitArray(ini, n);
        }
        public void Init(int[] ini)
        {
            if (ini == null || ini.Length == 0)
            {
                ini = new int[0];
                return;
            }

            InitArray(ini, ini.Length - 1);
        }


        private int GetMax(Node node, int max)
        {
            if (node.next != null)
                max = GetMax(node.next, max);

            max = (max > node.val) ? max : node.val;
            return max;
        }
        public int Max()
        {
            if (Size() == 0)
                throw new EmptyListException();

            return GetMax(root, root.val);
        }


        private int GetMaxPos(Node node, int n, int max)
        {
            if (node.val != max)
                n = GetMaxPos(node.next, n + 1, max);

            return n;
        }
        public int MaxPos()
        {
            if (Size() == 0)
                throw new EmptyListException();

            return GetMaxPos(root, 0, Max());
        }

        private int GetMin(Node node, int min)
        {
            if (node.next != null)
                min = GetMin(node.next, min);

            min = (min < node.val) ? min : node.val;
            return min;
        }
        public int Min()
        {
            if (Size() == 0)
                throw new EmptyListException();

            return GetMin(root, root.val);
        }

        private int GetMinPos(Node node, int n, int min)
        {
            if (node.val != min)
                n = GetMinPos(node.next, n + 1, min);

            return n;
        }
        public int MinPos()
        {
            if (Size() == 0)
                throw new EmptyListException();

            return GetMinPos(root, 0, Min());
        }

        private Node RecReverse(Node node)
        {
            if (node.next != null)
                RecReverse(node.next).next = node;

            return node;
        }
        public void Reverse()
        {
            if (Size() == 1 || Size() == 0)
                return;

            Node nRoot = GetEnd(root);
            RecReverse(root);
            root.next = null;
            root = nRoot;
        }

        public void Set(int pos, int val)
        {
            if (Size() == 0)
                throw new EmptyListException();
            if (pos < 0 || pos > Size() - 1)
                throw new WrongIndexException();

            GetNode(root, pos).val = val;
        }

        private int GetSize(Node node)
        {
            int size = 1;
            if (node.next != null)
                size += GetSize(node.next);

            return size;
        }
        public int Size()
        {
            if (root == null)
                return 0;

            return GetSize(root);
        }

        private void QuickSort(int b, int e)
        {
            if (b < e)
            {
                int p = partition(b, e);
                QuickSort(b, p - 1);
                QuickSort(p + 1, e);
            }
        }
        private int partition(int b, int e)
        {
            int i = b;
            for (int j = b; j <= e; j++)         // просматриваем с a по b
            {
                if (Get(j).CompareTo(Get(e)) <= 0)  // если элемент m[j] не превосходит m[b],
                {
                    int t = Get(i);                  // меняем местами m[j] и m[a], m[a+1], m[a+2] и так далее...
                    Set(i, Get(j));                 // то есть переносим элементы меньшие m[b] в начало,
                    Set(j, t);                    // а затем и сам m[b] «сверху»
                    i++;                         // таким образом последний обмен: m[b] и m[i], после чего i++
                }
            }
            return i - 1;
        }
        public void Sort()
        {
            if (root == null || Size() == 0)
                return;
            int size = Size();
            QuickSort(0, size - 1);
        }

        private void NodeToArray(Node node, int[] ini, int n)
        {
            ini[n++] = node.val;
            if (n < ini.Length) NodeToArray(node.next, ini, n);
        }
        public int[] ToArray()
        {
            if (root == null)
                return new int[0];

            int[] temp = new int[Size()];
            NodeToArray(root, temp, 0);
            return temp;
        }
        
        public override String ToString()
        {
            return NodeToString(root);
        }
        private String NodeToString(Node node)
        {
            if (node == null)
                return "";

            String str = "";
            str += node.val + ((node.next != null) ? ", " : "");
            if (node.next != null)
                str += NodeToString(node.next);
            return str;
        }
    }
}
