using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VeriYapilariOdevg;

namespace VeriYapilariOdev
{
    public partial class Form1 : Form
    {
        private Heap heap;
        private PriorityQueue priorityQueue;

        public Form1()
        {
            InitializeComponent();
            heap = new Heap(100); // Heap nesnesi olu�turdum
            priorityQueue = new PriorityQueue();  //kuyruk nesnesi olu�turdum.

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            string adSoyad = textBox2.Text;
            int ogrenciNo;
            int devamsizlikSayisi;
            double ortalama;
            bool aktifGorev;

            if (!int.TryParse(textBox1.Text, out ogrenciNo))
            {
                MessageBox.Show("Ge�erli bir ��renci numaras� giriniz.");
                return;
            }


            // Kullan�c�dan ald���m de�erleri de�i�kenlere atad�m.
            if (!double.TryParse(textBox3.Text, out ortalama))
            {
                MessageBox.Show("Ge�erli bir diploma notu giriniz.");
                return;
            }

            if (!int.TryParse(textBox4.Text, out devamsizlikSayisi))
            {
                MessageBox.Show("Ge�erli bir devams�zl�k say�s� giriniz.");
                return;
            }

            aktifGorev = checkBox1.Checked;

            Student ogrenci = new Student(adSoyad, ogrenciNo,devamsizlikSayisi, ortalama, aktifGorev);

            
            priorityQueue.Enqueue(ogrenci);  // ��renciyi kuyru�a �ncelikli olarak ekledim

            ShowStudents();
        }

        private void ShowStudents()
        {
            listBox1.Items.Clear();
            foreach (Student ogrenci in priorityQueue.GetStudents())
            {
                listBox1.Items.Add($"Ad Soyad: {ogrenci.AdSoyad},��renci No:{ogrenci.OgrenciNo}, Ortalama: {ogrenci.Ortalama}, Devams�zl�k: {ogrenci.DevamsizlikSayisi}, {(ogrenci.GorevAliyormu ? "G�rev Al�yor" : "G�rev alm�yor")}");
            }
        }
        private void UpdateTextBoxes(Student student)
        {
            textBox1.Text = student.OgrenciNo.ToString();
            textBox2.Text = student.AdSoyad;
            textBox3.Text = student.Ortalama.ToString();
            textBox4.Text = student.DevamsizlikSayisi.ToString();
        }

        private void UpdateListBox1()
        {
            listBox1.Items.Clear();
            foreach (var item in heap.heapArray)
            {
                if (item != null)
                    listBox1.Items.Add(item.deger);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Student cikanOgrenci = priorityQueue.Dequeue();

            if (cikanOgrenci != null)
            {
                
                textBox6.Text = cikanOgrenci.AdSoyad;
                textBox5.Text = cikanOgrenci.OgrenciNo.ToString();
                textBox7.Text = cikanOgrenci.Ortalama.ToString();
                textBox8.Text = cikanOgrenci.DevamsizlikSayisi.ToString();
                checkBox2.Checked = cikanOgrenci.GorevAliyormu;
            }
            else
            {
                MessageBox.Show("Kuyruk bo�.");
            }

       
            ShowStudents();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
