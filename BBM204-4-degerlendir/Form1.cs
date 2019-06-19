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

namespace BBM204_4_degerlendir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string testfolder = @"D:\bbm204-19-4\204-4-test\";
            string outstr = "";
            foreach (var student in Directory.GetDirectories(@"D:\bbm204-19-4\bbm204-4\bbm204-19-4\"))
            {
                Console.WriteLine(student);
                string studentno = student.Split('\\')[4];
                outstr += studentno + ';';
                for (int i = 1; i < 5; i++)
                {
                    string[] testlines = File.ReadAllLines(testfolder + "output" + i.ToString() + ".txt");
                    string[] stulines = { };
                    try
                    {
                        stulines = File.ReadAllLines(student + @"\src\output" + i.ToString() + ".txt");
                    }
                    catch (Exception)
                    {
                        outstr += "err";
                    }
                    for (int line = 0; line < testlines.Length; line++)
                    {
                        if (stulines.Length > line)
                        {
                            if (testlines[line].ToLower().Replace(" ", "") == stulines[line].ToLower().Replace(" ", ""))
                                outstr += "1;";
                            else
                                outstr += "0;";
                        }
                        else
                            outstr += "0;";
                    }
                }
                outstr += "\n";
            }
            File.WriteAllText(@"D:\bbm204-19-4\results.csv", outstr);
        }
         
    }
}
