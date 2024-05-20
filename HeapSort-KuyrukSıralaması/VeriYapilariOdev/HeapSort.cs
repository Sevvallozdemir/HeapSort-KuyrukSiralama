using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriYapilariOdev
{
    public class HeapSort
    {
        private int[] dizi;
        public HeapSort(int[] dizi)
        {
            this.dizi = dizi;
        }
        public int[] Sort()
        {
            Heap h = new Heap(dizi.Length);
            int[] sorted = new int[dizi.Length];
            foreach (var item in dizi)
                h.Insert(item);
            int i = 0;
            while (!h.isEmpty())
                sorted[i++] = h.RemoveMax().deger;
            return sorted;
        }
    }
}
