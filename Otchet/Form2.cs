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

namespace Otchet
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string OtchetFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), textBox1.Text + ".txt");
            if (File.Exists(OtchetFile))
            {
                DialogResult overwriteresult = MessageBox.Show("Файл уже существует! Перезаписать?", "Затираем?", MessageBoxButtons.YesNo);
                if (overwriteresult == DialogResult.Yes)
                {
                    try
                    {
                        File.Copy(Form1.otchetPath, OtchetFile, overwrite: true);
                        using (StreamWriter sw = File.AppendText(OtchetFile))
                        {
                            sw.WriteLine("\nВсего обновлено " + Form1.GetAllBases() + " баз");
                        }
                    }
                    
                    catch (FileNotFoundException ex)
                    {
                        MessageBox.Show(Convert.ToString(ex));
                        return;
                    }
                    DialogResult delfileresult1 = MessageBox.Show("Удаляем данные и начинаем вести отчет заново?", "Sure?", MessageBoxButtons.YesNo);
                    if (delfileresult1 == DialogResult.Yes)
                    {
                        File.Delete(Form1.otchetPath);
                        return;
                    }
                        

                    else
                    {
                        MessageBox.Show("Делай с этим что хочешь теперь :)");
                        return;
                    }



                }
                else
                {
                    MessageBox.Show("Приодите позже :)");
                    return;
                    
                }
            }

            try
            {
                File.Copy(Form1.otchetPath, OtchetFile, overwrite: true);
                using (StreamWriter sw = File.AppendText(OtchetFile))
                {
                    sw.WriteLine("\nВсего обновлено " + Form1.GetAllBases() + " баз");
                }
                    
            }
            catch (FileNotFoundException ex2)
            {
                MessageBox.Show(Convert.ToString(ex2));
                return;
            }
            DialogResult delfileresult2 = MessageBox.Show("Удаляем данные и начинаем вести отчет заново?", "Sure?", MessageBoxButtons.YesNo);
            if (delfileresult2 == DialogResult.Yes)
                File.Delete(Form1.otchetPath);
            else
                MessageBox.Show("Делай с этим что хочешь теперь :)");
                
        }
    }

    
}
