using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayList;

namespace UnitTestAListNull
{
    [TestClass]
    public class TestSizeAList1 : MyList
    {
        protected override IList CreateList()
        {
            return new AList1();
        }
    }
    [TestClass]
    public class TestSizeAList2 : MyList
    {
        protected override IList CreateList()
        {
            return new AList2();
        }
    }

    [TestClass]
    public abstract class MyList
    {
        protected abstract IList CreateList();

        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34, 1, 2 }, "10, 20, 77, 8, 11, 34, 1, 2")]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34, 1, 2, 3, 4, 1, 2, 3, 4 }, "10, 20, 77, 8, 11, 34, 1, 2, 3, 4, 1, 2, 3, 4")]
        public void TestSize_Init(int[] ini, string exp)
        {
            IList list = CreateList();
            list.Init(ini);
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }

        //Test: nolmal simple check
        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34, 1, 2 }, 4, 9, "4, 10, 20, 77, 8, 11, 34, 1, 2")]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34, 1, 2, 3, 4, 1, 2, 3, 4 }, 5, 15, "5, 10, 20, 77, 8, 11, 34, 1, 2, 3, 4, 1, 2, 3, 4")]
        public void TestSize_AddStart(int[] ini, int val, int size, string exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.AddStart(val);
            Assert.AreEqual(size, list.Size());
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34, 1, 2 }, 4, 9, "10, 20, 77, 8, 11, 34, 1, 2, 4")]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34, 1, 2, 3, 4, 1, 2, 3, 4 }, 5, 15, "10, 20, 77, 8, 11, 34, 1, 2, 3, 4, 1, 2, 3, 4, 5")]
        public void TestSize_AddEnd(int[] ini, int val, int size, string exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.AddEnd(val);
            Assert.AreEqual(size, list.Size());
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34, 1, 2 }, 4, 4, 9, "10, 20, 77, 8, 4, 11, 34, 1, 2")]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34, 1, 2, 3, 4, 1, 2, 3, 4 }, 5, 5, 15, "10, 20, 77, 8, 11, 5, 34, 1, 2, 3, 4, 1, 2, 3, 4")]
        public void TestSize_AddPos(int[] ini, int pos, int val, int size, string exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.AddPos(pos, val);
            Assert.AreEqual(size, list.Size());
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }
        //Test: complex check
        [DataTestMethod]
        [DataRow(new int[] { 5, 6, 4, 3, 2, 1, 5, 6, 8 }, "8, 6, 6, 5, 5, 4, 3, 2, 1")]
        [DataRow(new int[] { -10, -20, -30, -40, 1, 2, 3, 4, 5, 6, 7, 8 }, "8, 7, 6, 5, 4, 3, 2, 1, -10, -20, -30, -40")]
        public void TestSize_Complex1(int[] ini, string exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.HalfReverse();
            list.Sort();
            list.Reverse();
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 5, 6, 4, 3, 2, 1, 1, 3 }, "5, 6, 10, 4, 2, 1, 1, 3")]
        public void TestSize_Complex2(int[] ini, string exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.AddStart(8);
            list.AddEnd(9);
            list.AddPos(3, 10);
            list.DelStart();
            list.DelEnd();
            list.DelPos(4);
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 5, 6, 4, 3, 2, 1, 1, 2, 3, 4, 5 }, 10)]
        public void TestSize_Complex3(int[] ini, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.AddStart(8);
            list.AddEnd(9);
            list.AddPos(3, 10);
            int act = list.Max();
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 5, 6, 4, 3, 2, 1, 3, 4, 5, 6, 6 }, 0)]
        public void TestSize_Complex4(int[] ini, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.AddStart(0);
            list.AddEnd(9);
            list.AddPos(3, 10);
            int act = list.Min();
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 5, 6, 4, 3, 2, 1, 2, 3, 4, 5, 22 }, 3)]
        public void TestSize_Complex5(int[] ini, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.AddStart(8);
            list.DelEnd();
            list.AddPos(3, 10);
            int act = list.MaxPos();
            Assert.AreEqual(exp, act);
        }

    }
}
