using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriYapilariOdevg
{
    public class Student
    {
        public string AdSoyad { get; set; }
        public int OgrenciNo { get; set; }
        public int DevamsizlikSayisi { get; set; }
        public double Ortalama { get; set; }
        public bool GorevAliyormu { get; set; }

        public Student(string adSoyad, int ogrenciNo, int devamsizlikSayisi, double ortalama, bool gorevAliyormu)
        {
            AdSoyad = adSoyad;
            OgrenciNo = ogrenciNo;
            DevamsizlikSayisi = devamsizlikSayisi;
            Ortalama = ortalama;
            GorevAliyormu = gorevAliyormu;
        }
    }


}
