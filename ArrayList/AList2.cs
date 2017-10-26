using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class AList2 : IList
    {
        int[] arr = { };
        int start;
        int end;
        int topSize = 10;
        public void Init(int[] ini)
        {
            if (ini == null)
                ini = new int[0];
            if (ini.Length >= topSize - 1)
                topSize = ini.Length + (int)(ini.Length * 0.3);
            arr = new int[topSize];
            end = topSize / 2;
            start = end - 1;
            int k = 0;
            for (int i = 0; i < ini.Length; i++)
            {
                k++;
                arr[end] = ini[i];
                end += 1;
                if (k == 2)
                {
                    k = 0;
                    SwapToStart();
                }
            }
        }
        private void SwapToStart()
        {
            for (int i = start; i < end - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            start--;
            end--;
        }
        private void SwapToEnd()
        {
            for (int i = end; i > start; i--)
            {
                arr[i] = arr[i - 1];
            }
            start++;
            end++;
        }
        private void Swap()
        {
            int k = (int)(topSize * 0.3);
            topSize = topSize + k;
            int[] t = new int[topSize];
            for (int i = 0; i < topSize - k; i++)
            {
                t[i + k - 1] = arr[i];
            }
            end += (k - 1);
            start += (k - 1);
            arr = t;
        }
        public int Size()
        {
            return end - start - 1;
        }
        public void Clear()
        {
            arr = new int[0];
            end = 1;
            start = 0;
        }
        public override String ToString()
        {
            string net = "";
            for (int i = start + 1; i < end; i++)
            {
                net += arr[i] + ((i == end - 1) ? "" : ", ");
            }
            return net;
        }
        public int[] ToArray()
        {
            int[] net = new int[end - start - 1];
            int j = 0;
            for (int i = start + 1; i < end; i++)
            {
                net[j] = arr[i];
                j++;
            }
            return net;
        }
        public void AddStart(int val)
        {
            if ((end - start) % 2 == 0)
            {
                arr[start] = val;
                start--;
            }
            else
            {
                int[] t = new int[topSize];
                t[start + 1] = val;
                for (int i = start + 2; i <= end; i++)
                {
                    t[i] = arr[i - 1];
                }
                end++;
                arr = t;
            }
            if (Size() == topSize - 1)
                Swap();
        }
        public void AddEnd(int val)
        {
            if ((end - start) % 2 != 0)
            {
                arr[end] = val;
                end++;
            }
            else
            {
                int[] t = new int[topSize];
                t[end - 1] = val;
                for (int i = end - 2; i >= start; i--)
                {
                    t[i] = arr[i + 1];
                }
                start--;
                arr = t;
            }
            if (Size() == topSize - 1)
                Swap();
        }
        public void AddPos(int pos, int val)
        {
            if (pos > Size() || pos < 0)
                throw new WrongIndexException();
            int[] t = new int[topSize];
            if ((end - start) % 2 != 0)
                SwapToEnd();
            t[start + pos] = val;
            int j = start + 1;
            for (int i = start; i < end; i++)
            {
                if (i == start + pos)
                    continue;
                t[i] = arr[j];
                j++;
            }
            start--;
            arr = t;
        }
        public int DelStart()
        {
            if (Size() == 0)
                throw new EmptyListException();
            if ((end - start) % 2 == 0)
                SwapToStart();
            int val = arr[start + 1];
            start += 1;
            return val;
        }
        public int DelEnd()
        {
            if (Size() == 0)
                throw new EmptyListException();
            if ((end - start) % 2 == 0)
                SwapToEnd();
            int val = arr[end - 1];
            end -= 1;
            return val;
        }
        public int DelPos(int pos)
        {
            if (Size() == 0)
                throw new EmptyListException();
            if (pos >= Size() || pos < 0)
                throw new WrongIndexException();
            int val = arr[start + 1 + pos];
            int[] t = new int[Size() - 1];
            int j = 0;
            for (int i = start + 1; i < end; i++)
            {
                if (i == start + 1 + pos)
                    continue;
                t[j] = arr[i];
                j++;
            }
            Clear();
            Init(t);
            return val;
        }
        public int Min()
        {
            if (Size() == 0)
                throw new EmptyListException();
            int min = arr[start + 1];
            for (int i = start + 2; i < end; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }
        public int Max()
        {
            if (Size() == 0)
                throw new EmptyListException();
            int max = arr[start + 1];
            for (int i = start + 2; i < end; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }
        public int MinPos()
        {
            if (Size() == 0)
                throw new EmptyListException();
            int index = start + 1;
            for (int i = start + 2; i < end; i++)
            {
                if (arr[i] < arr[index])
                    index = i;
            }
            index = index - start - 1;
            return index;
        }
        public int MaxPos()
        {
            if (Size() == 0)
                throw new EmptyListException();
            int index = start + 1;
            for (int i = start + 2; i < end; i++)
            {
                if (arr[i] > arr[index])
                    index = i;
            }
            index = index - start - 1;
            return index;
        }
        public void Set(int pos, int val)
        {
            if (pos < 0 || pos >= Size())
                throw new WrongIndexException();
            arr[start + pos + 1] = val;
        }
        public int Get(int pos)
        {
            if (pos < 0 || pos >= Size())
                throw new WrongIndexException();
            int a = arr[start + pos + 1];
            return a;
        }
        public void Sort() //Insert
        {
            if (Size() == 0)
                throw new EmptyListException();
            int key;
            for (int i = start + 2; i < end; i++)
            {
                for (int q = i; q > start + 1 && arr[q - 1] > arr[q]; q--)
                {
                    key = arr[q - 1];
                    arr[q - 1] = arr[q];
                    arr[q] = key;
                }
            }
        }
        public void Reverse()
        {
            int[] t = new int[Size()];
            int j = 0;
            for (int i = start + 1; i < end; i++)
            {
                t[j] = arr[end - 1 - j];
                j++;
            }
            Clear();
            Init(t);
        }
        public void HalfReverse()
        {
            int[] t = new int[Size()];
            int j = 0;
            for (int i = start + 1; i < end; i++)
            {
                t[j] = arr[i];
                j++;
            }
            int n = Size() / 2;
            j = 0;
            for (int i = start + 1; j < n; i++)
            {
                arr[i] = t[t.Length - n + j];
                arr[end - n + j] = t[j];
                j++;
            }
        }
    }
}
