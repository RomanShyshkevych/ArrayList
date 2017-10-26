using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class AList1 : IList
    {

        int[] arr = { };
        int top = 0;
        int topSize = 10;
        public void Init(int[] ini)
        {
            if (ini == null)
                ini = new int[0];
            if (ini.Length >= topSize - 1)
                topSize = ini.Length + (int)(ini.Length * 0.3);
            top = ini.Length;
            arr = new int[topSize];
            for (int i = 0; i < top; i++)
            {
                arr[i] = ini[i];
            }
        }
        public int Size()
        {
            return top;
        }
        public void Clear()
        {
            arr = new int[0];
            top = 0;
        }
        public override String ToString()
        {
            string net = "";
            for (int i = 0; i < top; i++)
            {
                net += arr[i] + ((i == top - 1) ? "" : ", ");
            }
            return net;
        }
        public int[] ToArray()
        {
            int[] net = new int[top];
            for (int i = 0; i < top; i++)
            {
                net[i] = arr[i];
            }
            return net;
        }
        public void AddStart(int val)
        {
            int[] t = new int[topSize];
            t[0] = val;
            for (int i = 0; i < top; i++)
            {
                t[i + 1] = arr[i];
            }
            arr = t;
            top++;
            if (top == topSize - 1)
                Swap();
        }
        private void Swap()
        {
            top = topSize - 1;
            topSize = topSize + (int)(topSize * 0.3);
            int[] t = new int[topSize];
            for (int i = 0; i < top; i++)
            {
                t[i] = arr[i];
            }
            arr = t;
        }
        public void AddEnd(int val)
        {
            arr[Size()] = val;
            top++;
            if (top == topSize - 1)
                Swap();
        }
        public void AddPos(int pos, int val)
        {
            if (pos > top || pos < 0)
                throw new WrongIndexException();
            int[] t = new int[topSize];
            t[pos] = val;
            for (int i = 0; i < top + 1; i++)
            {
                if (i < pos)
                    t[i] = arr[i];
                if (i > pos)
                    t[i] = arr[i - 1];
            }
            arr = t;
            top++;
            if (top == topSize - 1)
                Swap();
        }
        public int DelStart()
        {
            if (top == 0)
                throw new EmptyListException();
            int val = arr[0];
            int[] t = new int[topSize];
            for (int i = 1; i < top; i++)
            {
                t[i - 1] = arr[i];
            }
            arr = t;
            top--;
            return val;
        }
        public int DelEnd()
        {
            if (top == 0)
                throw new EmptyListException();
            int val = arr[top - 1];
            int[] t = new int[topSize];
            for (int i = 0; i < top - 1; i++)
            {
                t[i] = arr[i];
            }
            arr = t;
            top--;
            return val;
        }
        public int DelPos(int pos)
        {
            if (top == 0)
                throw new EmptyListException();
            if (pos < 0 || pos >= top)
                throw new WrongIndexException();
            int val = arr[pos];
            int[] t = new int[topSize];
            int k = 0;
            for (int i = 0; i < top; i++)
            {
                if (i == pos)
                    continue;
                else
                {
                    t[k] = arr[i];
                    k++;
                }
            }
            arr = t;
            top--;
            return val;
        }
        public int Min()
        {
            if (top == 0)
                throw new EmptyListException();
            int min = arr[0];
            for (int i = 1; i < top; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }
        public int Max()
        {
            if (top == 0)
                throw new EmptyListException();
            int max = arr[0];
            for (int i = 1; i < top; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }
        public int MinPos()
        {
            if (top == 0)
                throw new EmptyListException();
            int index = 0;
            for (int i = 0; i < top; i++)
            {
                if (arr[i] < arr[index])
                    index = i;
            }
            return index;
        }
        public int MaxPos()
        {
            if (top == 0)
                throw new EmptyListException();
            int index = 0;
            for (int i = 0; i < top; i++)
            {
                if (arr[i] > arr[index])
                    index = i;
            }
            return index;
        }
        public void Set(int pos, int val)
        {
            if (pos < 0 || pos >= top)
                throw new WrongIndexException();
            arr[pos] = val;
        }
        public int Get(int pos)
        {
            if (pos < 0 || pos >= top)
                throw new WrongIndexException();
            int a = arr[pos];
            return a;
        }
        public void Sort() //Insert
        {
            if (top == 0)
                throw new EmptyListException();
            int key;
            for (int i = 1; i < top; i++)
            {
                for (int q = i; q > 0 && arr[q - 1] > arr[q]; q--)
                {
                    key = arr[q - 1];
                    arr[q - 1] = arr[q];
                    arr[q] = key;
                }
            }
        }
        public void Reverse()
        {
            int[] t = new int[top];
            for (int i = 0; i < top; i++)
            {
                t[i] = arr[top - 1 - i];
            }
            for (int i = 0; i < top; i++)
            {
                arr[i] = t[i];
            }
        }
        public void HalfReverse()
        {
            int[] t = new int[top];
            for (int i = 0; i < top; i++)
            {
                t[i] = arr[i];
            }
            int n = top / 2;
            for (int i = 0; i < n; i++)
            {
                arr[i] = t[top - n + i];
                arr[top - n + i] = t[i];
            }
        }
    }
}