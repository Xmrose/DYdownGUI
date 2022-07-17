using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DYdownGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DirectoryInfo folder = new DirectoryInfo(Environment.CurrentDirectory);

        private void cCMD(string folder, string idx)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            p.StandardInput.WriteLine(string.Format("python{0}" + folder + "{1}{2}{3}{4}{5}", 
                                                                              " ", 
                                                                              "\\DYdown_preview.py",
                                                                              " ", txtB.Text,
                                                                              " ", idx));
            Application.DoEvents();
            p.StandardInput.WriteLine("exit");

            p.WaitForExit();
            p.Close();
        }

        private void sReader(string fPath)
        {
            StreamReader sr = new StreamReader(fPath, Encoding.UTF8);
            string line;
            int a = 0;

            while ((line = sr.ReadLine()) != null)
            {
                if (line != null)
                {
                    string[] bSplt = Regex.Split(line, "', 'vaddr': '");

                    string lS = bSplt[0].Replace("{'title': '", "");
                    lstViewMain.Items.Add(lS);
                    string rS = bSplt[1].Replace("'}", "");
                    lstViewMain.Items[a].SubItems.Add(rS);
                }
                a++;
            }
            sr.Close();
        }

        private void btnAlys_Click(object sender, EventArgs e)
        {
            string fPath = folder + "\\urls.txt";
            try
            {
                sReader(fPath);
            }
            catch (Exception)
            {
                //starting call python and retrieve urls only
                cCMD(Convert.ToString(folder), "-999");
                //end of process
                sReader(fPath);
            }
        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            cCMD(Convert.ToString(folder), "-1");
        }
    }
}
