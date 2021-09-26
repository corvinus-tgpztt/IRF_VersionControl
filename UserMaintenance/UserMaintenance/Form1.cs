using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;
using System.IO;



namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName;
            button2.Text = Resource1.Save_in_file;
            button1.Text = Resource1.Add;
            button3.Text = Resource1.Delete;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";


           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog mentes = new SaveFileDialog() {
               
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,


            };

            
            

            if (mentes.ShowDialog() == DialogResult.OK)
            {
                StreamWriter r = File.CreateText(mentes.FileName);
                foreach (var item in users)
                {
                    r.WriteLine(item.ID + " " + item.FullName);
                }
                r.Close();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User(){FullName = textBox1.Text};
            users.Add(u);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                users.Remove((User)listBox1.SelectedItem);
            }
        }
    }
}
