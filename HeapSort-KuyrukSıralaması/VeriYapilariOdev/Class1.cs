using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeriYapilariOdevg;

namespace VeriYapilariOdev
{
    public class PriorityQueue
    {
        private List<Student> student;

        public PriorityQueue()
        {
            student = new List<Student>();
        }

        public void Enqueue(Student ogrenci)
        {
            student.Add(ogrenci);
            student.Sort((x, y) =>
            {
                if (x.Ortalama != y.Ortalama)
                    return y.Ortalama.CompareTo(x.Ortalama); 


                if (x.GorevAliyormu != y.GorevAliyormu)
                    return y.GorevAliyormu.CompareTo(x.GorevAliyormu); 
                return x.DevamsizlikSayisi.CompareTo(y.DevamsizlikSayisi); 


            });
        }

        public Student Dequeue()
        {
            if (student.Count > 0)
            {
                Student ogrenci = student[0];
                student.RemoveAt(0);
                return ogrenci;
            }
            return null;
        }

        public List<Student> GetStudents()
        {
            return student;
        }
    }
}
