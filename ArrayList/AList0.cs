using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class AList0: IList
    {
        int[] arr = { };
        public void Init(int[] ini)
        {
            if (ini == null)
                ini = new int[0];
            arr = new int[ini.Length];
            for (int i = 0; i < ini.Length; i++)
            {
                arr[i] = ini[i];
            }
        }
        public int Size()
        {
            return arr.Length;
        }
        public void Clear()
        {
            arr = new int[0];
        }
        public override String ToString()
        {
            string net = "";
            for (int i = 0; i < arr.Length; i++)
            {
                net += arr[i] + ((i == arr.Length - 1) ? "" : ", ");
            }
            return net;
        }
        public int[] ToArray()
        {
            int[] net = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                net[i] = arr[i];
            }
            return net;
        }
        public void AddStart(int val)
        {
            int[] t = new int[arr.Length + 1];
            t[0] = val;
            for (int i = 0; i < arr.Length; i++)
            {
                t[i + 1] = arr[i];
            }
            arr = t;
        }
        public void AddEnd(int val)
        {
            int[] t = new int[arr.Length + 1];
            t[arr.Length] = val;
            for (int i = 0; i < arr.Length; i++)
            {
                t[i] = arr[i];
            }
            arr = t;
        }
        public void AddPos(int pos, int val)
        {
            if (pos > arr.Length || pos < 0)
                throw new WrongIndexException();
            int[] t = new int[arr.Length + 1];
            t[pos] = val;
            for (int i = 0; i < t.Length; i++)
            {
                if (i < pos)
                    t[i] = arr[i];
                if (i > pos)
                    t[i] = arr[i - 1];
            }
            arr = t;
        }
        public int DelStart()
        {
            if (arr.Length == 0)
                throw new EmptyListException();
            int val = arr[0];
            int[] t = new int[arr.Length - 1];
            for (int i = 1; i < arr.Length; i++)
            {
                t[i - 1] = arr[i];
            }
            arr = t;
            return val;
        }
        public int DelEnd()
        {
            if (arr.Length == 0)
                throw new EmptyListException();
            int val = arr[arr.Length - 1];
            int[] t = new int[arr.Length - 1];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                t[i] = arr[i];
            }
            arr = t;
            return val;
        }
        public int DelPos(int pos)
        {
            if (arr.Length == 0)
                throw new EmptyListException();
            if (pos < 0 || pos >= arr.Length)
                throw new WrongIndexException();
            int val = arr[pos];
            int[] t = new int[arr.Length - 1];
            int k = 0;
            for (int i = 0; i < arr.Length; i++)
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
            return val;
        }
        public int Min()
        {
            if (arr.Length == 0)
                throw new EmptyListException();
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }
        public int Max()
        {
            if (arr.Length == 0)
                throw new EmptyListException();
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }
        public int MinPos()
        {
            if (arr.Length == 0)
                throw new EmptyListException();
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < arr[index])
                    index = i;
            }
            return index;
        }
        public int MaxPos()
        {
            if (arr.Length == 0)
                throw new EmptyListException();
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > arr[index])
                    index = i;
            }
            return index;
        }
        public void Set(int pos, int val)
        {
            if (pos < 0 || pos >= arr.Length)
                throw new WrongIndexException();
            arr[pos] = val;
        }
        public int Get(int pos)
        {
            if (pos < 0 || pos >= arr.Length)
                throw new WrongIndexException();
            int a = arr[pos];
            return a;
        }
        public void Sort() //Insert
        {
            if (arr.Length == 0)
                throw new EmptyListException();
            int key;
            for (int i = 1; i < arr.Length; i++)
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
            int[] t = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                t[i] = arr[arr.Length - 1 - i];
            }
            arr = t;
        }
        public void HalfReverse()
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
