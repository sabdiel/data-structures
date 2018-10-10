using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListCSharpImpl
{
    public class MyArrayList<TValue> : IDisposable
    {
        private int _max = 5;
        private int _end = -1;
        private TValue[] _staticArray;

        public TValue this[int i]
        {
            get { return _staticArray[i]; }
            set { Insert(value, i); }
        }

        public MyArrayList()
        {
            _staticArray = new TValue[_max];
        }

        /// <summary>
        /// Allow you to insert values to the Array. 
        /// It won't allow you to modified the array besides
        /// its current size for memory saving.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="position"></param>
        public void Insert(TValue value, int position = -1)
        {

            if(IsMax())
                DoubleArraySize();

            // Add elements in linear order when position not specified
            if (position == -1 || StackOverflow(position))
                InsertToEnd(value);

            // Override first element of array
            if (position == 0)
                _staticArray[position] = value;

            // Handle inserts in specific positions
            if (position > 0 && !StackOverflow(position))
            {
                ShiftToRight(position);
                _staticArray[position] = value;
            }  
        }

        private void DoubleArraySize()
        {
            var copiedArray = _staticArray;
            _max *= 2;
            _staticArray = new TValue[_max];
            copiedArray.CopyTo(_staticArray, 0);
        }

        public int Count()
        {
            return _end + 1;
        }

        public bool IsEmpty()
        {
            return _end == -1;
        }

        public void Remove(int position)
        {
            ShifToLeft(position);
        }

        private void InsertToEnd(TValue value)
        {
            _staticArray[++_end] = value;
        }

        private void InsertIntoPosition(int position, TValue value)
        {
            ShiftToRight(position);
            _staticArray[position] = value;
        }

        private void ShiftToRight(int startIndex)
        {
            var currentValue = _staticArray[startIndex];
            var lenght = _max - 1;

            for (int i = startIndex; i < lenght; i++)
            {
                var nextValue = _staticArray[i + 1];
                _staticArray[i + 1] = currentValue;
                currentValue = nextValue;
            }
            _end++;
        }

        private void ShifToLeft(int startIndex)
        {
            var length = _max - 1;
            for (int i = 0; i < length; i++)
            {
                var nextValue = _staticArray[i + 1];
                _staticArray[i] = nextValue;
            }
        }

        private bool IsMax()
        {
            return _end == (_max - 1);
        }

        private bool StackOverflow(int position)
        {
            return position >= _max;
        }
        public void Dispose()
        {
            _staticArray = null;
        }
    }
}
