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
                Resize(2);
            }

            array[size] = item;
            this.size++;
        }

        public void Prepend(T item)
        {
            if(size == capacity)
            {
                Resize(2);
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
                Resize(2);
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
            
            if(size / (double) capacity < 0.25)
            {
                Resize(0.5);
            }

            return item;            
        }

        public void Delete(int index)
        {
            ShiftArrayValuesLeft(index);
            array[size - 1] = default(T);
            size--;

            if(size / (double) capacity < 0.25)
            {
                Resize(0.5);
            }
        }

        public void Remove(T item)
        {
            int index = 0;
            while(index < size && size != 0)
            {
                if(array[index].Equals(item))
                {
                    Delete(index);
                }
                else
                {
                    index++;
                }
            }
        }

        public int Find(T item)
        {
            for(int i = 0; i < size; i++)
            {
                if(array[i].Equals(item)) 
                {
                    return i;
                }
            }

            return -1;
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

            return array;
        }

        private void Resize(double capacityMultiplier)
        {
            T[] tempArray = array;
            int newCapacity = Convert.ToInt32(capacity * capacityMultiplier);
            array = new T[newCapacity];
            
            for(int i = 0; i < size; i++)
            {
                array[i] = tempArray[i];
            }
            
            this.capacity = newCapacity;
        }
    }
}