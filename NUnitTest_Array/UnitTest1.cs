using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Compatibility;
using ArrayList;

namespace NUnitTest_Array
{
    [TestFixture(typeof(AList0))]
    [TestFixture(typeof(AList1))]
    [TestFixture(typeof(AList2))]
    public class UnitTest1<TPage> where TPage : IList, new()
    {
        IList list = new TPage();

        //Test: high simple check
        [Test]
        [TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, "10, 20, 77, 8, 11, 34")]
        [TestCase(new int[] { 10, 20 }, "10, 20")]
        [TestCase(new int[] { 10 }, "10")]
        [TestCase(new int[] { }, "")]
        [TestCase(null, "")]
        public void Test_Init_nunit(int[] ini, string exp)
        {
            list.Init(ini);
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, 6)]
        [TestCase(new int[] { 10, 20 }, 2)]
        [TestCase(new int[] { 10 }, 1)]
        [TestCase(new int[] { }, 0)]
        [TestCase(null, 0)]
        public void Test_Size_nunit(int[] ini, int exp)
        {
            list.Init(ini);
            int act = list.Size();
            Assert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, 0)]
        [TestCase(new int[] { 10, 20 }, 0)]
        [TestCase(new int[] { 10 }, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(null, 0)]
        public void Test_Clear(int[] ini, int exp)
        {
            list.Init(ini);
            list.Clear();
            int act = list.Size();
            Assert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, new int[] { 10, 20, 77, 8, 11, 34 })]
        [TestCase(new int[] { 10, 20 }, new int[] { 10, 20 })]
        [TestCase(new int[] { 10 }, new int[] { 10 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(null, new int[] { })]
        public void Test_ToArray(int[] ini, int[] exp)
        {
            list.Init(ini);
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        //Test: nolmal simple check
        [Test]
        [TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, 100, 7, new int[] { 100, 10, 20, 77, 8, 11, 34 })]
        [TestCase(new int[] { 10, 20 }, 1, 3, new int[] { 1, 10, 20 })]
        [TestCase(new int[] { 10 }, 1, 2, new int[] { 1, 10 })]
        [TestCase(new int[] { }, 15, 1, new int[] { 15 })]
        [TestCase(null, 15, 1, new int[] { 15 })]
        public void Test_AddStart(int[] ini, int val, int size, int[] exp)
        {
            list.Init(ini);
            list.AddStart(val);
            Assert.AreEqual(size, list.Size());
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, 100, 7, new int[] { 10, 20, 77, 8, 11, 34, 100 })]
        [TestCase(new int[] { 10, 20 }, 1, 3, new int[] { 10, 20, 1 })]
        [TestCase(new int[] { 10 }, 1, 2, new int[] { 10, 1 })]
        [TestCase(new int[] { }, 15, 1, new int[] { 15 })]
        [TestCase(null, 15, 1, new int[] { 15 })]
        public void Test_AddEnd(int[] ini, int val, int size, int[] exp)
        {
            list.Init(ini);
            list.AddEnd(val);
            Assert.AreEqual(size, list.Size());
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, 0, 100, 7, new int[] { 100, 10, 20, 77, 8, 11, 34 })]
        [TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, 6, 100, 7, new int[] { 10, 20, 77, 8, 11, 34, 100 })]
        [TestCase(new int[] { 10, 20 }, 1, 1, 3, new int[] { 10, 1, 20 })]
        [TestCase(new int[] { }, 0, 15, 1, new int[] { 15 })]
        [TestCase(null, 0, 15, 1, new int[] { 15 })]
        public void Test_AddPos(int[] ini, int pos, int val, int size, int[] exp)
        {
            list.Init(ini);
            list.AddPos(pos, val);
            Assert.AreEqual(size, list.Size());
            int[] act = list.ToArray();
            CollectionAssert.AreEqual(exp, act);
        }
        //[Test]
        //[ExpectedException(typeof(WrongIndexException))]
        //[TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, -1, 100, new int[] { 100, 10, 20, 77, 8, 11, 34 })]
        //[TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, 7, 100, new int[] { 10, 20, 77, 8, 11, 34, 100 })]
        //public void Test_AddPos_Ex(int[] ini, int pos, int val, int[] exp)
        //{
        //    list.Init(ini);
        //    list.AddPos(pos, val);
        //}
        [Test]
        [TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, 10, 5, new int[] { 20, 77, 8, 11, 34 })]
        [TestCase(new int[] { 20, 10 }, 20, 1, new int[] { 10 })]
        [TestCase(new int[] { 100 }, 100, 0, new int[] { })]
        public void Test_DelStart(int[] ini, int val, int size, int[] exp)
        {
            list.Init(ini);
            Assert.AreEqual(val, list.DelStart());
            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, list.ToArray());
        }
        //[Test]
        //[ExpectedException(typeof(EmptyListException))]
        //[TestCase(new int[] { }, 0)]
        //[TestCase(null, 0)]
        //public void Test_DelStart_Ex(int[] ini, int val)
        //{
        //    list.Init(ini);
        //    Assert.AreEqual(val, list.DelStart());
        //}
        [Test]
        [TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, 34, 5, new int[] { 10, 20, 77, 8, 11 })]
        [TestCase(new int[] { 10, 20 }, 20, 1, new int[] { 10 })]
        [TestCase(new int[] { 10 }, 10, 0, new int[] { })]
        public void Test_DelEnd(int[] ini, int val, int size, int[] exp)
        {
            list.Init(ini);
            Assert.AreEqual(val, list.DelEnd());
            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, list.ToArray());
        }
        //[Test]
        //[ExpectedException(typeof(EmptyListException))]
        //[TestCase(new int[] { }, 0)]
        //[TestCase(null, 0)]
        //public void Test_DelEnd_Ex(int[] ini, int val)
        //{
        //    list.Init(ini);
        //    Assert.AreEqual(val, list.DelEnd());
        //}
        [Test]
        [TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, 0, 10, 5, new int[] { 20, 77, 8, 11, 34 })]
        [TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, 5, 34, 5, new int[] { 10, 20, 77, 8, 11 })]
        [TestCase(new int[] { 10, 20, 30 }, 1, 20, 2, new int[] { 10, 30 })]
        [TestCase(new int[] { 10, 20 }, 1, 20, 1, new int[] { 10 })]
        public void Test_DelPos(int[] ini, int pos, int val, int size, int[] exp)
        {
            list.Init(ini);
            Assert.AreEqual(val, list.DelPos(pos));
            Assert.AreEqual(size, list.Size());
            CollectionAssert.AreEqual(exp, list.ToArray());
        }
        //[Test]
        //[ExpectedException(typeof(EmptyListException))]
        //[TestCase(new int[] { }, 0)]
        //[TestCase(null, 0)]
        //public void Test_DelPos_Ex_Empty(int[] ini, int pos)
        //{
        //    list.Init(ini);
        //    list.DelPos(pos);
        //}
        //[Test]
        //[ExpectedException(typeof(WrongIndexException))]
        //[TestCase(new int[] { 10, 20, 30 }, -1)]
        //[TestCase(new int[] { 10, 20, 30 }, 3)]
        //[TestCase(new int[] { 10 }, -1)]
        //[TestCase(new int[] { 10 }, 1)]
        //public void Test_DelPos_Ex_Index(int[] ini, int pos)
        //{
        //    list.Init(ini);
        //    list.DelPos(pos);
        //}
        [Test]
        [TestCase(new int[] { 10, 5, 8, 4, 7, 3, 6, 1, 22 }, 22)]
        [TestCase(new int[] { -10, -5, -2, -8, -4, -7, -3, -6, -1, -2 }, -1)]
        [TestCase(new int[] { 4, 4, 4, 4, 4 }, 4)]
        [TestCase(new int[] { 6 }, 6)]
        public void Test_Max(int[] ini, int exp)
        {
            list.Init(ini);
            int act = list.Max();
            Assert.AreEqual(exp, act);
        }
        //[Test]
        //[ExpectedException(typeof(EmptyListException))]
        //[TestCase(new int[] { })]
        //[TestCase(null)]
        //public void Test_Max_Ex(int[] ini)
        //{
        //    list.Init(ini);
        //    list.Max();
        //}
        [Test]
        [TestCase(new int[] { 10, 5, 8, 4, 7, 3, 6, 1, 22 }, 1)]
        [TestCase(new int[] { -10, -5, -2, -8, -4, -7, -3, -6, -1, -2 }, -10)]
        [TestCase(new int[] { 4, 4, 4, 4, 4 }, 4)]
        [TestCase(new int[] { 6 }, 6)]
        public void Test_Min(int[] ini, int exp)
        {
            list.Init(ini);
            int act = list.Min();
            Assert.AreEqual(exp, act);
        }
        //[Test]
        //[ExpectedException(typeof(EmptyListException))]
        //[TestCase(new int[] { })]
        //[TestCase(null)]
        //public void Test_Min_Ex(int[] ini)
        //{
        //    list.Init(ini);
        //    list.Min();
        //}
        [Test]
        [TestCase(new int[] { 10, 5, 8, 4, 7, 3, 6, 1, 22 }, 8)]
        [TestCase(new int[] { -10, -5, -2, -8, -4, -7, -3, -6, -1 }, 8)]
        [TestCase(new int[] { 4, 4, 4, 4, 4 }, 0)]
        [TestCase(new int[] { 6 }, 0)]
        public void Test_MaxPos(int[] ini, int exp)
        {
            list.Init(ini);
            int act = list.MaxPos();
            Assert.AreEqual(exp, act);
        }
        //[Test]
        //[ExpectedException(typeof(EmptyListException))]
        //[TestCase(new int[] { })]
        //[TestCase(null)]
        //public void Test_MaxPos_Ex(int[] ini)
        //{
        //    list.Init(ini);
        //    list.MaxPos();
        //}
        [Test]
        [TestCase(new int[] { 10, 5, 8, 4, 7, 3, 6, 1, 22 }, 7)]
        [TestCase(new int[] { -10, -5, -2, -8, -4, -7, -3, -6, -1, -2 }, 0)]
        [TestCase(new int[] { 4, 4, 4, 4, 4 }, 0)]
        [TestCase(new int[] { 6 }, 0)]
        public void Test_MinPos(int[] ini, int exp)
        {
            list.Init(ini);
            int act = list.MinPos();
            Assert.AreEqual(exp, act);
        }
        //[Test]
        //[ExpectedException(typeof(EmptyListException))]
        //[TestCase(new int[] { })]
        //[TestCase(null)]
        //public void Test_MinPos_Ex(int[] ini)
        //{
        //    list.Init(ini);
        //    list.MinPos();
        //}
        [Test]
        [TestCase(new int[] { 1, 2, 3 }, "3, 2, 1")]
        [TestCase(new int[] { 2, 2, 2 }, "2, 2, 2")]
        [TestCase(new int[] { -2, -3, -4 }, "-4, -3, -2")]
        [TestCase(new int[] { 2 }, "2")]
        [TestCase(new int[] { }, "")]
        [TestCase(null, "")]
        public void Test_Reverse(int[] ini, string exp)
        {
            list.Init(ini);
            list.Reverse();
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(new int[] { 1 }, "1")]
        [TestCase(new int[] { 1, 2, 3, 4 }, "3, 4, 1, 2")]
        [TestCase(new int[] { 1, 2, 1, 2 }, "1, 2, 1, 2")]
        [TestCase(new int[] { 4, 4, 4, 4 }, "4, 4, 4, 4")]
        [TestCase(new int[] { 7, 8, 9, 10, 1 }, "10, 1, 9, 7, 8")]
        [TestCase(new int[] { }, "")]
        [TestCase(null, "")]
        public void Test_HalfReverse(int[] ini, string exp)
        {
            list.Init(ini);
            list.HalfReverse();
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(new int[] { 5, 6, 4, 3, 2, 1 }, "1, 2, 3, 4, 5, 6")]
        [TestCase(new int[] { -10, -20, -30, -40 }, "-40, -30, -20, -10")]
        [TestCase(new int[] { 1 }, "1")]
        [TestCase(new int[] { 1, 1, 1, 1, 1 }, "1, 1, 1, 1, 1")]
        public void Test_Sort(int[] ini, string exp)
        {
            list.Init(ini);
            list.Sort();
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }
        //[Test]
        //[ExpectedException(typeof(EmptyListException))]
        //[TestCase(new int[] { })]
        //[TestCase(null)]
        //public void Test_Sort_Ex(int[] ini)
        //{
        //    list.Init(ini);
        //    list.Sort();
        //}
        //Test: complex check
        [Test]
        [TestCase(new int[] { 5, 6, 4, 3, 2, 1 }, "6, 5, 4, 3, 2, 1")]
        [TestCase(new int[] { -10, -20, -30, -40 }, "-10, -20, -30, -40")]
        [TestCase(new int[] { 1 }, "1")]
        [TestCase(new int[] { 1, 1, 1, 1, 1 }, "1, 1, 1, 1, 1")]
        public void Test_Complex1(int[] ini, string exp)
        {
            list.Init(ini);
            list.HalfReverse();
            list.Sort();
            list.Reverse();
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(new int[] { 5, 6, 4, 3, 2, 1 }, "5, 6, 10, 4, 2, 1")]
        [TestCase(new int[] { -10, -20, -30, -40 }, "-10, -20, 10, -30")]
        public void Test_Complex2(int[] ini, string exp)
        {
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
        [Test]
        [TestCase(new int[] { 5, 6, 4, 3, 2, 1 }, 10)]
        [TestCase(new int[] { -10, -20, -30, -40 }, 10)]
        public void Test_Complex3(int[] ini, int exp)
        {
            list.Init(ini);
            list.AddStart(8);
            list.AddEnd(9);
            list.AddPos(3, 10);
            int act = list.Max();
            Assert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(new int[] { 5, 6, 4, 3, 2, 1 }, 0)]
        [TestCase(new int[] { -10, -20, -30, -40 }, -40)]
        public void Test_Complex4(int[] ini, int exp)
        {
            list.Init(ini);
            list.AddStart(0);
            list.AddEnd(9);
            list.AddPos(3, 10);
            int act = list.Min();
            Assert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(new int[] { 5, 6, 4, 3, 2, 11 }, 3)]
        [TestCase(new int[] { -10, -20, -30, -40 }, 3)]
        public void Test_Complex5(int[] ini, int exp)
        {
            list.Init(ini);
            list.AddStart(8);
            list.DelEnd();
            list.AddPos(3, 10);
            int act = list.MaxPos();
            Assert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(new int[] { 5, 6, 4, 3, 2, 11 }, 4)]
        [TestCase(new int[] { -10, -20, -30, -40 }, 3)]
        public void Test_Complex6(int[] ini, int exp)
        {
            list.Init(ini);
            list.AddStart(8);
            list.DelPos(2);
            list.AddEnd(3);
            int act = list.MinPos();
            Assert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(new int[] { 10, 20, 77, 8, 11, 34 }, 6)]
        [TestCase(new int[] { 10, 20 }, 2)]
        public void Test_Complex7(int[] ini, int exp)
        {
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
        [Test]
        [TestCase(new int[] { 10, 100, 1, 5, 6, 9, 0 }, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 5)]
        public void Test_Complex8(int[] ini, int exp)
        {
            list.Init(ini);
            list.DelStart();
            list.DelEnd();
            list.DelPos(2);
            list.Set(2, 0);
            list.AddPos(1, 20);
            int act = list.Size();
            Assert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(new int[] { 10, 100, 1, 5, 6, 9, 0 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0)]
        public void Test_Complex9(int[] ini, int exp)
        {
            list.Init(ini);
            list.DelEnd();
            list.AddEnd(36);
            list.Set(2, 5);
            list.AddPos(1, 8);
            list.Clear();
            int act = list.Size();
            Assert.AreEqual(exp, act);
        }
        [Test]
        [TestCase(new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 }, "0, 1, 2, 3, 4, 5, 6")]
        [TestCase(new int[] { 123, 56, 8, 9, -5, 7, 300 }, "-5, 0, 7, 9, 56")]
        public void Test_Complex10(int[] ini, string exp)
        {
            list.Init(ini);
            list.HalfReverse();
            list.Reverse();
            list.Set(2, 0);
            list.DelStart();
            list.Sort();
            list.DelEnd();
            string act = list.ToString();
            Assert.AreEqual(exp, act);
        }
    }
}
