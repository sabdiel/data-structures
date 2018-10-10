using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayListCSharpImpl.Tests
{
    [TestClass]
    public class ArrayListCSharpImplTests
    {
        private MyArrayList<int> _myArray;

        [TestInitialize]
        public void Initialize()
        {
            _myArray = new MyArrayList<int>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _myArray.Dispose();
        }


        [TestMethod]
        public void InsertWithNoPositionAndNoMax()
        {
            AssertNLinearInserts(5);
        }

        [TestMethod]
        public void Stackoverflow()
        {
            try
            {
                AssertNLinearInserts(5);
                _myArray.Insert(6);
                Assert.Fail();
            }
            catch (Exception)
            {
                // Success
            }

        }

        [TestMethod]
        public void OverrideFirstPosition()
        {
            AssertNLinearInserts(5);
            _myArray.Insert(7, 0);
            AssertValue(7, 0);
        }

        [TestMethod]
        public void InsertElementInSpecificPosition()
        {
            AssertNLinearInserts(4);
            _myArray.Insert(8, 2);
            AssertValue(8, 2);
        }

        [TestMethod]
        public void InsertElementsUntilMax()
        {
            AssertNLinearInserts(10);
        }

        [TestMethod]
        public void InsertElementsUntilMaxWithSpecificPosition()
        {
            AssertNLinearInserts(10);
            _myArray.Insert(8, 2);
            AssertValue(8, 2);
        }

        [TestMethod]
        public void ModifyPositionWithIndexer()
        {
            AssertNLinearInserts(10);

            _myArray[5] = 100;            
            AssertValue(100, 5);
            
            _myArray[15] = 200;
            AssertValue(200, 15);

            _myArray[100] = 500;
            Assert.IsTrue(_myArray.Count() < 50, "This should not expand that much");

        }

        [TestMethod]
        public void GetCount()
        {
            AssertNLinearInserts(10);
            Assert.AreEqual(10, _myArray.Count(), "Values should be equals");
        }

        [TestMethod]
        public void IsEmpty()
        {
            Assert.IsTrue(_myArray.IsEmpty(), "This should be true");
            AssertNLinearInserts(10);
            Assert.IsFalse(_myArray.IsEmpty(), "This should be true");
        }

        [TestMethod]
        public void RemoveByIndex()
        {
            AssertNLinearInserts(10);
            AssertValue(6, 5);
            _myArray.Remove(5);
            AssertValue(7, 5);
        }

        private void AssertNLinearInserts(int numberOfInserts)
        {
            foreach (var item in Enumerable.Range(1, numberOfInserts).Select((value, index) => new { value, index }))
            {
                _myArray.Insert(item.value);
                AssertValue(item.value, item.index);
            }
        }

        private void AssertValue(int value, int index)
        {
            Assert.AreEqual(_myArray[index], value, $"It should be equal to {value}");
        }
    }
}
