using System;
using ArrayList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class TestAList0 : MyList
    {

        protected override IList CreateList()
        {
            return new AList0();
        }
    }
    [TestClass]
    public class TestAList1 : MyList
    {
        protected override IList CreateList()
        {
            return new AList1();
        }
    }
    [TestClass]
    public class TestAList2 : MyList
    {
        protected override IList CreateList()
        {
            return new AList2();
        }
    }
    [TestClass]
    public class TestLList1 : MyList
    {
        protected override IList CreateList()
        {
            return new LList1();
        }
    }
    [TestClass]
    public class TestLList2 : MyList
    {
        protected override IList CreateList()
        {
            return new LList2();
        }
    }
    [TestClass]
    public class TestAListR : MyList
    {
        protected override IList CreateList()
        {
            return new AListR();
        }
    }
    [TestClass]
    public class TestLListR : MyList
    {
        protected override IList CreateList()
        {
            return new LListR();
        }
    }
    [TestClass]
    public class TestLListF : MyList
    {
        protected override IList CreateList()
        {
            return new LListF();
        }
    }
    [TestClass]
    public abstract class MyList
    {
        protected abstract IList CreateList();

        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, "10, 20, 77, 8, 11, 34")]
        [DataRow(new int[] { 10, 20 }, "10, 20")]
        [DataRow(new int[] { 10 }, "10")]
        [DataRow(new int[] { }, "")]
        [DataRow(null, "")]
        public void Test_Init(int[] ini, string exp)
        {
            IList list = CreateList();
            list.Init(ini);
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }
        public void Test_Size(int[] ini, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            int act = list.Size();
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 0)]
        [DataRow(new int[] { 10, 20 }, 0)]
        [DataRow(new int[] { 10 }, 0)]
        [DataRow(new int[] { }, 0)]
        [DataRow(null, 0)]
        public void Test_Clear(int[] ini, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.Clear();
            int act = list.Size();
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, new int[] { 10, 20, 77, 8, 11, 34 })]
        [DataRow(new int[] { 10, 20 }, new int[] { 10, 20 })]
        [DataRow(new int[] { 10 }, new int[] { 10 })]
        [DataRow(new int[] { }, new int[] { })]
        [DataRow(null, new int[] { })]
        public void Test_ToArray(int[] ini, int[] exp)
        {
            IList list = CreateList();
            list.Init(ini);
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        //Test: nolmal simple check
        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 100, 7, new int[] { 100, 10, 20, 77, 8, 11, 34 })]
        [DataRow(new int[] { 10, 20 }, 1, 3, new int[] { 1, 10, 20 })]
        [DataRow(new int[] { 10 }, 1, 2, new int[] { 1, 10 })]
        [DataRow(new int[] { }, 15, 1, new int[] { 15 })]
        [DataRow(null, 15, 1, new int[] { 15 })]
        public void Test_AddStart(int[] ini, int val, int size, int[] exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.AddStart(val);
            Assert.AreEqual(size, list.Size());
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 100, 7, new int[] { 10, 20, 77, 8, 11, 34, 100 })]
        [DataRow(new int[] { 10, 20 }, 1, 3, new int[] { 10, 20, 1 })]
        [DataRow(new int[] { 10 }, 1, 2, new int[] { 10, 1 })]
        [DataRow(new int[] { }, 15, 1, new int[] { 15 })]
        [DataRow(null, 15, 1, new int[] { 15 })]
        public void Test_AddEnd(int[] ini, int val, int size, int[] exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.AddEnd(val);
            Assert.AreEqual(size, list.Size());
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 0, 100, 7, new int[] { 100, 10, 20, 77, 8, 11, 34 })]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 6, 100, 7, new int[] { 10, 20, 77, 8, 11, 34, 100 })]
        [DataRow(new int[] { 10, 20 }, 1, 1, 3, new int[] { 10, 1, 20 })]
        [DataRow(new int[] { }, 0, 15, 1, new int[] { 15 })]
        [DataRow(null, 0, 15, 1, new int[] { 15 })]
        public void Test_AddPos(int[] ini, int pos, int val, int size, int[] exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.AddPos(pos, val);
            Assert.AreEqual(size, list.Size());
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [ExpectedException(typeof(WrongIndexException))]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, -1, 100, new int[] { 100, 10, 20, 77, 8, 11, 34 })]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 7, 100, new int[] { 10, 20, 77, 8, 11, 34, 100 })]
        public void Test_AddPos_Ex(int[] ini, int pos, int val, int[] exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.AddPos(pos, val);
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 10, 5, new int[] { 20, 77, 8, 11, 34 })]
        [DataRow(new int[] { 20, 10 }, 20, 1, new int[] { 10 })]
        [DataRow(new int[] { 100 }, 100, 0, new int[] { })]
        public void Test_DelStart(int[] ini, int val, int size, int[] exp)
        {
            IList list = CreateList();
            list.Init(ini);
            Assert.AreEqual(val, list.DelStart());
            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, list.ToArray());
        }
        [DataTestMethod]
        [ExpectedException(typeof(EmptyListException))]
        [DataRow(new int[] { }, 0)]
        [DataRow(null, 0)]
        public void Test_DelStart_Ex(int[] ini, int val)
        {
            IList list = CreateList();
            list.Init(ini);
            Assert.AreEqual(val, list.DelStart());
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 34, 5, new int[] { 10, 20, 77, 8, 11 })]
        [DataRow(new int[] { 10, 20 }, 20, 1, new int[] { 10 })]
        [DataRow(new int[] { 10 }, 10, 0, new int[] { })]
        public void Test_DelEnd(int[] ini, int val, int size, int[] exp)
        {
            IList list = CreateList();
            list.Init(ini);
            Assert.AreEqual(val, list.DelEnd());
            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, list.ToArray());
        }
        [DataTestMethod]
        [ExpectedException(typeof(EmptyListException))]
        [DataRow(new int[] { }, 0)]
        [DataRow(null, 0)]
        public void Test_DelEnd_Ex(int[] ini, int val)
        {
            IList list = CreateList();
            list.Init(ini);
            Assert.AreEqual(val, list.DelEnd());
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 0, 10, 5, new int[] { 20, 77, 8, 11, 34 })]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 5, 34, 5, new int[] { 10, 20, 77, 8, 11 })]
        [DataRow(new int[] { 10, 20, 30 }, 1, 20, 2, new int[] { 10, 30 })]
        [DataRow(new int[] { 10, 20 }, 1, 20, 1, new int[] { 10 })]
        public void Test_DelPos(int[] ini, int pos, int val, int size, int[] exp)
        {
            IList list = CreateList();
            list.Init(ini);
            Assert.AreEqual(val, list.DelPos(pos));
            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, list.ToArray());
        }
        [DataTestMethod]
        [ExpectedException(typeof(EmptyListException))]
        [DataRow(new int[] { }, 0)]
        [DataRow(null, 0)]
        public void Test_DelPos_Ex_Empty(int[] ini, int pos)
        {
            IList list = CreateList();
            list.Init(ini);
            list.DelPos(pos);
        }
        [DataTestMethod]
        [ExpectedException(typeof(WrongIndexException))]
        [DataRow(new int[] { 10, 20, 30 }, -1)]
        [DataRow(new int[] { 10, 20, 30 }, 3)]
        [DataRow(new int[] { 10 }, -1)]
        [DataRow(new int[] { 10 }, 1)]
        public void Test_DelPos_Ex_Index(int[] ini, int pos)
        {
            IList list = CreateList();
            list.Init(ini);
            list.DelPos(pos);
        }
        //---------------------------------------------------------------------
        [DataTestMethod]
        [DataRow(new int[] { 10, 5, 8, 4, 7, 3, 6, 1, 22 }, 22)]
        [DataRow(new int[] { -10, -5, -2, -8, -4, -7, -3, -6, -1, -2 }, -1)]
        [DataRow(new int[] { 4, 4, 4, 4, 4 }, 4)]
        [DataRow(new int[] { 6 }, 6)]
        public void Test_Max(int[] ini, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            int act = list.Max();
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        [ExpectedException(typeof(EmptyListException))]
        public void Test_MaxEx()
        {
            IList list = CreateList();
            list.Init(new int[] { });
            list.Max();
        }
        [TestMethod]
        [ExpectedException(typeof(EmptyListException))]
        public void Test_MaxNullEx()
        {
            IList list = CreateList();
            list.Init(null);
            list.Max();
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 5, 8, 4, 7, 3, 6, 1, 22 }, 1)]
        [DataRow(new int[] { -10, -5, -2, -8, -4, -7, -3, -6, -1, -2 }, -10)]
        [DataRow(new int[] { 4, 4, 4, 4, 4 }, 4)]
        [DataRow(new int[] { 6 }, 6)]
        public void Test_Min(int[] ini, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            int act = list.Min();
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        [ExpectedException(typeof(EmptyListException))]
        public void Test_MinEx()
        {
            IList list = CreateList();
            list.Init(new int[] { });
            list.Min();
        }
        [TestMethod]
        [ExpectedException(typeof(EmptyListException))]
        public void Test_MinNullEx()
        {
            IList list = CreateList();
            list.Init(null);
            list.Min();
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 5, 8, 4, 7, 3, 6, 1, 22 }, 8)]
        [DataRow(new int[] { -10, -5, -2, -8, -4, -7, -3, -6, -1 }, 8)]
        [DataRow(new int[] { 4, 4, 4, 4, 4 }, 0)]
        [DataRow(new int[] { 6 }, 0)]
        public void Test_MaxPos(int[] ini, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            int act = list.MaxPos();
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        [ExpectedException(typeof(EmptyListException))]
        public void Test_MaxPosEx()
        {
            IList list = CreateList();
            list.Init(new int[] { });
            list.MaxPos();
        }
        [TestMethod]
        [ExpectedException(typeof(EmptyListException))]
        public void Test_MaxPosNullEx()
        {
            IList list = CreateList();
            list.Init(null);
            list.MaxPos();
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 5, 8, 4, 7, 3, 6, 1, 22 }, 7)]
        [DataRow(new int[] { -10, -5, -2, -8, -4, -7, -3, -6, -1, -2 }, 0)]
        [DataRow(new int[] { 4, 4, 4, 4, 4 }, 0)]
        [DataRow(new int[] { 6 }, 0)]
        public void Test_MinPos(int[] ini, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            int act = list.MinPos();
            Assert.AreEqual(exp, act);
        }
        [TestMethod]
        [ExpectedException(typeof(EmptyListException))]
        public void Test_MinPosEx()
        {
            IList list = CreateList();
            list.Init(new int[] { });
            list.MinPos();
        }
        [TestMethod]
        [ExpectedException(typeof(EmptyListException))]
        public void Test_MinPosNullEx()
        {
            IList list = CreateList();
            list.Init(null);
            list.MinPos();
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 0, 100, new int[] { 100, 20, 77, 8, 11, 34 })]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 5, 100, new int[] { 10, 20, 77, 8, 11, 100 })]
        [DataRow(new int[] { 10, 20 }, 1, 1, new int[] { 10, 1 })]
        public void Test_Set(int[] ini, int pos, int val, int[] exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.Set(pos, val);
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 0, 10)]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 5, 34)]
        [DataRow(new int[] { 10, 20 }, 1, 20)]
        public void Test_Get(int[] ini, int pos, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            int act = list.Get(pos);
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, "3, 2, 1")]
        [DataRow(new int[] { 2, 2, 2 }, "2, 2, 2")]
        [DataRow(new int[] { 2 }, "2")]
        [DataRow(new int[] { -2, -3, -4 }, "-4, -3, -2")]
        [DataRow(new int[] { }, "")]
        [DataRow(null, "")]
        public void Test_Reverse(int[] ini, string exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.Reverse();
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 1 }, "1")]
        [DataRow(new int[] { 1, 2, 3, 4 }, "3, 4, 1, 2")]
        [DataRow(new int[] { 1, 2, 1, 2 }, "1, 2, 1, 2")]
        [DataRow(new int[] { 4, 4, 4, 4 }, "4, 4, 4, 4")]
        [DataRow(new int[] { 7, 8, 9, 10, 1 }, "10, 1, 9, 7, 8")]
        [DataRow(new int[] { }, "")]
        [DataRow(null, "")]
        public void Test_HalfReverse(int[] ini, string exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.HalfReverse();
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 5, 6, 4, 3, 2, 1 }, "1, 2, 3, 4, 5, 6")]
        [DataRow(new int[] { -10, -20, -30, -40 }, "-40, -30, -20, -10")]
        [DataRow(new int[] { 1 }, "1")]
        [DataRow(new int[] { 1, 1, 1, 1, 1 }, "1, 1, 1, 1, 1")]
        public void Test_Sort(int[] ini, string exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.Sort();
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }

        //Test: complex check
        
        [DataTestMethod]
        [DataRow(new int[] { 5, 6, 4, 3, 2, 1 }, "5, 6, 10, 4, 2, 1")]
        [DataRow(new int[] { -10, -20, -30, -40 }, "-10, -20, 10, -30")]
        public void Test_Complex1(int[] ini, string exp)
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
        [DataRow(new int[] { 5, 6, 4, 3, 2, 1 }, 10)]
        [DataRow(new int[] { -10, -20, -30, -40 }, 10)]
        public void Test_Complex2(int[] ini, int exp)
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
        [DataRow(new int[] { 5, 6, 4, 3, 2, 1 }, 0)]
        [DataRow(new int[] { -10, -20, -30, -40 }, -40)]
        public void Test_Complex3(int[] ini, int exp)
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
        [DataRow(new int[] { 5, 6, 4, 3, 2, 11 }, 3)]
        [DataRow(new int[] { -10, -20, -30, -40 }, 3)]
        public void Test_Complex4(int[] ini, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.AddStart(8);
            list.DelEnd();
            list.AddPos(3, 10);
            int act = list.MaxPos();
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 5, 6, 4, 3, 2, 11 }, 4)]
        [DataRow(new int[] { -10, -20, -30, -40 }, 3)]
        public void Test_Complex5(int[] ini, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.AddStart(8);
            list.DelPos(2);
            list.AddEnd(3);
            int act = list.MinPos();
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 20, 77, 8, 11, 34 }, 6)]
        [DataRow(new int[] { 10, 20 }, 2)]
        public void Test_Complex6(int[] ini, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.AddEnd(11);
            list.AddPos(2, 33);
            list.AddStart(5);
            list.DelEnd();
            list.DelStart();
            list.DelPos(1);
            int act = list.Size();
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 100, 1, 5, 6, 9, 0 }, 5)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 5)]
        public void Test_Complex7(int[] ini, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.DelStart();
            list.DelEnd();
            list.DelPos(2);
            list.Set(2, 0);
            list.AddPos(1, 20);
            int act = list.Size();
            Assert.AreEqual(exp, act);
        }
        [DataTestMethod]
        [DataRow(new int[] { 10, 100, 1, 5, 6, 9, 0 }, 0)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0)]
        public void Test_Complex8(int[] ini, int exp)
        {
            IList list = CreateList();
            list.Init(ini);
            list.DelEnd();
            list.AddEnd(36);
            list.Set(2, 5);
            list.AddPos(1, 8);
            list.Clear();
            int act = list.Size();
            Assert.AreEqual(exp, act);
        }        
    }
}
