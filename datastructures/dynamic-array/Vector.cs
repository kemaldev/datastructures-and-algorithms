using System;

namespace test
{
    public class Vector<T>
    {
        private int capacity;
        private int size;
        private T[] array;

        public Vector(int capacity)
        {
            this.capacity = capacity;
            this.size = 0;
            array = new T[capacity];
        }

        public int Capacity()
        {
            return capacity;
        }

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public T At(int index)
        {
            return array[index];
        }

        public void Push(T item)
        {
            if(size == capacity)
            {
                DoubleVectorSize();
            }

            array[size] = item;
            this.size++;
        }

        public void Prepend(T item)
        {
            if(size == capacity)
            {
                DoubleVectorSize();
            }

            array = ShiftArrayValuesRight(0);
            array[0] = item;

            this.size++;
        }

        public void Insert(int index, T item)
        {
            if(index > size && size != capacity)
            {
                throw new 
                    ArgumentException($"Tried to add element to index: {index} which is outside of the size: {size} of the vector ");
            }
            if(size == capacity)
            {
                DoubleVectorSize();
            }

            array = ShiftArrayValuesRight(index);
            array[index] = item;

            this.size++;
        }

        public T Pop()
        {
            T item = array[size - 1];
            array[size - 1] = default(T);

            size--;

            return item;            
        }

        public void Delete(int index)
        {
            ShiftArrayValuesLeft(index);

            size--;
        }

        private T[] ShiftArrayValuesRight(int index)
        {
            for(int i = size; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            return array;
        }

        private T[] ShiftArrayValuesLeft(int index)
        {
            for(int i = index + 1; i < size; i++)
            {
                array[i - 1] = array[i];
            }
        }

        private void DoubleVectorSize()
        {
            T[] tempArray = array;
            array = new T[capacity * 2];
            
            for(int i = 0; i < size; i++)
            {
                array[i] = tempArray[i];
            }
            
            this.capacity *= 2;
        }
    }
}