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
using System.Threading;
using System.Diagnostics;

namespace MStarter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string FSdocPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MStarter\MStarter.fsdoc");
            string FSdocPathSafe = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MStarter\MStarterSafe.fsdoc");

            if (System.AppDomain.CurrentDomain.FriendlyName != "MStarter.exe")
             {
                 Run(FSdocPath);
             }

            string today = DateTime.Now.ToString("dd/MM/yyyy");
            string month = DateTime.Now.Month.ToString();
           // MessageBox.Show(today + "- BETA 1.0");


            FileStream FSdoc;
            FileStream FSdocSafe;
            string limiteresp = "undefined";
            bool limiteinterruptor = true;

            if (File.Exists(FSdocPath))
            {
                FSdoc = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MStarter\MStarter.fsdoc"), FileMode.Open, FileAccess.ReadWrite);
                FSdocSafe = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MStarter\MStarterSafe.fsdoc"), FileMode.Open, FileAccess.ReadWrite);
                // MessageBox.Show("MStarter.fsdoc Encontrado");
            }
            else
            {
                MessageBox.Show("Arquivo 'MStarter.fsdoc' não foi encontrado\nCriando um novo arquivo 'MStarter.fsdoc'");
                /*  Console.WriteLine("Qual o limite mensal do seu cartão (Deixe em branco caso não tenha limite)");
                  Console.Write("R$: ");
                  do
                  {
                      try
                      {
                          limiteresp = Console.ReadLine().Replace(',', '.');
                          if (String.IsNullOrEmpty(limiteresp))
                              limiteresp = "0";
                          Convert.ToDouble(limiteresp);
                          limiteinterruptor = false;
                      }
                      catch (Exception e)
                      {
                          Console.WriteLine("Você tentou inserir um valor invalido, insira apenas numeros");
                          Console.Write("R$: ");
                      }
                  } while (limiteinterruptor); */
                
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MStarter"));
                using (File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MStarter\MStarterSafe.fsdoc"))) { }
                using (File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MStarter\MStarter.fsdoc"))) { }
                FSdoc = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MStarter\MStarter.fsdoc"), FileMode.Open, FileAccess.ReadWrite);
                FSdocSafe = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MStarter\MStarterSafe.fsdoc"), FileMode.Open, FileAccess.ReadWrite);
            }
            FSdoc.Close();
            FSdocSafe.Close();
            /*  if (limiteresp != "undefined")
                  File.AppendAllText(FSdocPath, limiteresp + Environment.NewLine); */
            var textLines = File.ReadAllLines(FSdocPathSafe);
            comboBoxExe.DataSource = textLines;
            //MessageBox.Show("Feito!");

            //Start(today, FSdocPath);
        }

        static void Run(string FSdocPath)
        {
            var textlines = File.ReadAllLines(FSdocPath);
            foreach(var line in textlines)
            {
                System.Diagnostics.Process.Start(line);
            }
            Process[] processes = Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            foreach (var process in processes)
            {
                process.Kill();
            }
        } 

        private void botaoAdd_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Selecione um programa ou arquivo";
            openFileDialog1.InitialDirectory = "C:\\";

            string FSdocPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MStarter\MStarter.fsdoc");
            string FSdocPathSafe = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MStarter\MStarterSafe.fsdoc");
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {


                string strfilename = openFileDialog1.FileName;
                string strsafefilename = openFileDialog1.SafeFileName;
                MessageBox.Show(strsafefilename);
                File.AppendAllText(FSdocPath, strfilename + Environment.NewLine);
                File.AppendAllText(FSdocPathSafe, strsafefilename + Environment.NewLine);

                var textLines = File.ReadAllLines(FSdocPathSafe);
                comboBoxExe.DataSource = textLines;

            }
        }

        static void Remover(string FSdocPath, string[] textlines, int selected)
        {
            string[] dataArrayOrg = new string[textlines.Length - 1];
            textlines[selected] = null;
            int count = 0;
            for (int i = 0; i < textlines.Length; i++)
            {
                if (textlines[i] != null)
                {
                    if (i == count)
                    {
                        string dataArraystring = textlines[i];
                        dataArrayOrg[i] = dataArraystring;
                        count++;
                    }
                    else
                    {
                        string dataArraystring = textlines[i];
                        dataArrayOrg[i - 1] = dataArraystring;
                        count++;
                    }
                }

            }
            File.WriteAllLines(FSdocPath, dataArrayOrg);
        }

        private void botaoRemover_Click(object sender, EventArgs e)
        {
            string FSdocPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MStarter\MStarter.fsdoc");
            string FSdocPathSafe = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MStarter\MStarterSafe.fsdoc");
            int selected = comboBoxExe.SelectedIndex;
            var textlines = File.ReadAllLines(FSdocPath);
            var textlinessafe = File.ReadAllLines(FSdocPathSafe);

            Remover(FSdocPath, textlines, selected);
            Remover(FSdocPathSafe, textlinessafe, selected);
            textlinessafe = File.ReadAllLines(FSdocPathSafe);
            comboBoxExe.DataSource = textlinessafe;

        }
    }
}
