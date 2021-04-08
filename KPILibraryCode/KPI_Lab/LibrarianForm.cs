﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPI_Lab
{
    public partial class LibrarianForm : Form
    {
        Librarian librarian;
        Reader SelectedReader;

        public LibrarianForm()
        {
            InitializeComponent();
        }

        public LibrarianForm(Librarian l)
        {
            InitializeComponent();
            librarian = l;
            SelectedReader = librarian.readers[0];
            foreach (var item in l.readers)
            {
                listBox1.Items.Add(item.Name + " " + item.Surname);
            }
            groupBox1.Text = "";
            label8.Text = l.Name;
            label9.Text = l.Surname;
            label10.Text = l.Login;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedReader = librarian.readers.Find(x => x.Name + " " + x.Surname == listBox1.SelectedItem.ToString());

            listBox2.Items.Clear();

            foreach (var item in SelectedReader.books)
            {
                listBox2.Items.Add(item.Title);
            }

            textBox2.Text = SelectedReader.Name;
            textBox3.Text = SelectedReader.Surname;
            textBox4.Text = SelectedReader.DateOfBirth;
            textBox5.Text = SelectedReader.Login;
            textBox6.Text = SelectedReader.fine.ToString();
            textBox7.Text = "********";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox6.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Reader reader = new Reader(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox7.Text);
                textBox6.Enabled = true;

                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";

                listBox1.Items.Add(reader.Name + " " + reader.Surname);

                librarian.readers.Add(reader);
                librarian.SaveReadersChangesInFile("readers.txt");
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Reader reader = librarian.readers.Find(x => x.Name + " " + x.Surname == listBox1.SelectedItem.ToString());
                librarian.readers.Remove(reader);
                librarian.SaveReadersChangesInFile("readers.txt");

                listBox1.Items.Clear();

                foreach (var item in librarian.readers)
                {
                    listBox1.Items.Add(item.Name + " " + item.Surname);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = librarian.books.Find(x => x.Title == textBox1.Text);
                Reader reader = librarian.readers.Find(x => x.Name + " " + x.Surname == listBox1.SelectedItem.ToString());
                if (reader.books.Find(x => x == book) != null)
                {
                    MessageBox.Show("This book is already here", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    reader.books.Add(book);
                    librarian.SaveReadersChangesInFile("readers.txt");

                    listBox2.Items.Clear();

                    foreach (var item in reader.books)
                    {
                        listBox2.Items.Add(item.Title);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = librarian.books.Find(x => x.Title == listBox2.SelectedItem.ToString());
                Reader reader = librarian.readers.Find(x => x.Name + " " + x.Surname == listBox1.SelectedItem.ToString());
                reader.books.Remove(book);
                librarian.SaveReadersChangesInFile("readers.txt");

                listBox2.Items.Clear();

                foreach (var item in reader.books)
                {
                    listBox2.Items.Add(item.Title);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }
    }
}
