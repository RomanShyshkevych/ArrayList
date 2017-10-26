﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public interface IList
    {
        void Init(int[] ini);
        int Size();
        void Clear();
        String ToString();
        int[] ToArray();
        void AddStart(int val);
        void AddEnd(int val);
        void AddPos(int pos, int val);
        int DelStart();
        int DelEnd();
        int DelPos(int pos);
        int Min();
        int Max();
        int MinPos();
        int MaxPos();
        void Set(int pos, int val);
        int Get(int pos);
        void Sort();
        void Reverse();
        void HalfReverse();
    }
}
