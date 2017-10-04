using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Otchet
{
    public partial class Form1 : Form
    {
        public static string otchetPath
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "otchet.txt");
            }
            
        }

        public static int GetAllBases()
        {
            string[] lines = File.ReadAllLines(otchetPath);
            int total = 0;
            foreach (string line in lines)
            {
                string[] array = line.Split(',');
                total += Convert.ToInt32(array[2]);
            }
            return total;
        }

        public static void CreateReport()
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("dd.MM.yyyy");
            StreamWriter filew = new StreamWriter(otchetPath, append: true);
            filew.WriteLine(today + "," + textBox1.Text + "," + numericUpDown1.Value +"," + textBox3.Text);
            filew.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Обновлено " + GetAllBases() + " баз");
            Process.Start(otchetPath);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }
    }
}
