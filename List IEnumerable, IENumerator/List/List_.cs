using System;
using System.Collections;

namespace List
{
    public class List_ : IEnumerable, IEnumerator
    {
        private const int InitialSize = 4;
        private const int ExtendIn = 2;
        public object[] _array;
        private int _count;
        private int _currentIndex = -1;
        public int Count { get { return _count; } }

        public object Current
        {
            get
            {
                try
                {
                    return _array[_currentIndex];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public object this[int index]
        {
            get
            {
                if (index < _count)
                {
                    return _array[index];
                }
                throw new IndexOutOfRangeException();
            }
        }

        public List_()
        {
            _array = new object[InitialSize];
        }

        public void Add(object objectToAdd)
        {
            if (objectToAdd == null)
            {
                throw new ArgumentNullException("objectToAdd");
            }

            bool added = false;

            TryAddToFirstEmptyPosition(objectToAdd, out added);

            if (!added)
            {
                ExtendArray();
                AddToLastPosition(objectToAdd);
            }

            _count++;
        }

        private void TryAddToFirstEmptyPosition(object objectToAdd, out bool added)
        {
            added = false;

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == null)
                {
                    _array[i] = objectToAdd;
                    added = true;
                    return;
                }
            }
        }

        private void ExtendArray()
        {
            var newArray = new object[_array.Length * ExtendIn];

            for (int i = 0; i < _array.Length; i++)
            {
                newArray[i] = _array[i];
            }

            _array = newArray;
        }

        private void AddToLastPosition(object objectToAdd)
        {
            _array[_count] = objectToAdd;
        }

        public void Insert(int index, object objectToSet)
        {
            if (index <= _count)
            {
                if (_count == _array.Length)
                {
                    ExtendArray();
                }

                for (int i = _array.Length - 2; i > index - 1; i--)
                {
                    _array[i + 1] = _array[i];
                }
                _array[index] = objectToSet;
                _count++;
            }
            else
            {
                throw new Exception("Index is greater that array length.");
            }
        }

        public void Remove(object objectToRemove)
        {
            int indexRemoved = -1;

            for (int i = 0; i < _count; i++)
            {
                if (_array[i].Equals(objectToRemove))
                {
                    _array[i] = null;
                    indexRemoved = i;
                }
            }

            if (indexRemoved == -1)
            {
                return;
            }

            for (int i = indexRemoved; i < _count - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _count--;
            _array[_count] = null;
        }

        public void RemoveAt(int indexToRemove)
        {
            if (indexToRemove < _count)
            {

                _array[indexToRemove] = null;

                for (int i = indexToRemove; i < _count - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }

                _count--;
                _array[_count] = null;
                return;
            }
            throw new IndexOutOfRangeException();
        }

        public void Clear()
        {
            if (_count > 0)
            {
                _array = new object[InitialSize];
                _count = 0;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            _currentIndex++;
            return (_currentIndex < _count);
        }

        public void Reset()
        {
            _array = new object[InitialSize];
            _currentIndex = -1;
            _count = 0;
        }
    }
}
