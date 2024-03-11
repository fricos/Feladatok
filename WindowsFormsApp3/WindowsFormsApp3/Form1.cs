using Konyvesbolt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();

            List<Books> books_list = new List<Books>();
            string[] lines = File.ReadAllLines("books.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(',');
                Books books_object = new Books(values[0], values[1], values[2], values[3], values[4]);
                books_list.Add(books_object);
            }
            int book_db = 0;
            foreach(var book in books_list){
                book_db += book.db;
            }

            label1.Text = string.Format("Összdarabszám: {0}", book_db);


            List<Books> legdragabbak = new List<Books>(); 
            Books legdragabb = books_list[0];
            legdragabbak.Add(legdragabb);

            foreach (var termek in books_list)
            {
                if (termek.ar > legdragabb.ar)
                {

                    legdragabb = termek;
                    legdragabbak.Clear();
                    legdragabbak.Add(legdragabb);
                }
                else if (termek.ar == legdragabb.ar)
                {

                    legdragabbak.Add(termek);
                }
            }
            foreach (var legdragabbTermek in legdragabbak)
            {
                dataGridView1.Rows.Add(legdragabbTermek.kategoria, legdragabbTermek.konyv, legdragabbTermek.ar);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedCategory = (string)comboBox1.SelectedItem;
            List<Books>books = new List<Books>();
            string[] sorok = File.ReadAllLines("books.txt");
            foreach (var s in sorok)
            {
                string[] values = s.Split(',');
                Books books_object = new Books(values[0], values[1], values[2], values[3], values[4]);
                books.Add(books_object);
            }
            listBox1.Items.Clear();

            foreach (var book in books)
            {
                if (book.kategoria == selectedCategory)
                {
                    string text = "Cím: " + book.konyv + ", Ár: " + book.ar + ", Darabszam: " + book.db;
                    listBox1.Items.Add(text);
                }
            }
        }
    }
}
