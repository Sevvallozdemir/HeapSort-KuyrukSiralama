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
            heap = new Heap(100); // Heap nesnesi oluþturdum
            priorityQueue = new PriorityQueue();  //kuyruk nesnesi oluþturdum.

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
                MessageBox.Show("Geçerli bir öðrenci numarasý giriniz.");
                return;
            }


            // Kullanýcýdan aldýðým deðerleri deðiþkenlere atadým.
            if (!double.TryParse(textBox3.Text, out ortalama))
            {
                MessageBox.Show("Geçerli bir diploma notu giriniz.");
                return;
            }

            if (!int.TryParse(textBox4.Text, out devamsizlikSayisi))
            {
                MessageBox.Show("Geçerli bir devamsýzlýk sayýsý giriniz.");
                return;
            }

            aktifGorev = checkBox1.Checked;

            Student ogrenci = new Student(adSoyad, ogrenciNo,devamsizlikSayisi, ortalama, aktifGorev);

            
            priorityQueue.Enqueue(ogrenci);  // Öðrenciyi kuyruða öncelikli olarak ekledim

            ShowStudents();
        }

        private void ShowStudents()
        {
            listBox1.Items.Clear();
            foreach (Student ogrenci in priorityQueue.GetStudents())
            {
                listBox1.Items.Add($"Ad Soyad: {ogrenci.AdSoyad},Öðrenci No:{ogrenci.OgrenciNo}, Ortalama: {ogrenci.Ortalama}, Devamsýzlýk: {ogrenci.DevamsizlikSayisi}, {(ogrenci.GorevAliyormu ? "Görev Alýyor" : "Görev almýyor")}");
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
                MessageBox.Show("Kuyruk boþ.");
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
