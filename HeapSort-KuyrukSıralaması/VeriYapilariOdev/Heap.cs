using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriYapilariOdev
{
    internal class Heap
    {
        public int currentSize = 0;
        public int maxSize = 10;
        public HeapDugumu[] heapArray;

        public Heap(int maxSize)
        {
            this.maxSize = maxSize;
            heapArray = new HeapDugumu[maxSize];
        }
        public class HeapDugumu
        {
            public int deger;
            public HeapDugumu(int deger)
            {
                this.deger = deger;
            }
        }
        public bool Insert(int value)
        {
            if (currentSize == maxSize)
            {
                return false;
            }
            HeapDugumu newHeapDugumu = new HeapDugumu(value);
            heapArray[currentSize] = newHeapDugumu;
            MoveToUp(currentSize++);
            return true;
        }
        public void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugumu bottom = heapArray[index];
            while (index > 0 && heapArray[parent].deger < bottom.deger)
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }
        public HeapDugumu RemoveMax()
        {
            HeapDugumu root = heapArray[0];
            heapArray[0] = heapArray[--currentSize];
            MoveToDown(0);
            return root;

        }
        public void MoveToDown(int index)
        {
            int largerChild;
            HeapDugumu top = heapArray[index];
            while (index < currentSize / 2)
            {
                int lefChild = 2 * index + 1;
                int rigtChild = lefChild + 1;
              
                if (rigtChild < currentSize && heapArray[lefChild].deger < heapArray[rigtChild].deger)
                {
                    largerChild = rigtChild;
                }
                else { largerChild = lefChild; }
                if (top.deger >= heapArray[largerChild].deger)
                    break;
                heapArray[index] = heapArray[largerChild];
                index = largerChild;
            }
            heapArray[index] = top;
        }
        public bool isEmpty()
        {
            if (currentSize == 0)
                return true;
            else
                return false;
        }
        public bool Remove(int deger)
        {
            for (int i = 0; i < currentSize; i++)
            {
                if (heapArray[i].deger == deger)
                {
                    heapArray[i] = heapArray[--currentSize];
                    heapArray[currentSize] = null; // Silinen düğümü burada null olarak ayarlandı.
                    MoveToDown(i);
                    return true;
                }
            }
            return false; 
        }
    }
}
