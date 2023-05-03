using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Palabras;
using Globaless;
using Scann;
using static System.Windows.Forms.LinkLabel;

namespace CompiladoresProy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openFileDialog, filePath;
        SaveFileDialog saveFileDialog, saveSalida;

        public MainWindow()
        {
            this.saveFileDialog = new SaveFileDialog();
            this.openFileDialog = new OpenFileDialog();
            this.filePath = new OpenFileDialog();
            this.saveSalida = new SaveFileDialog();
            InitializeComponent();
            XmlReader reader = XmlReader.Create("../../../Controlador/palabras.xml");//xshd
            areatexto.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
        }

        private void abrirarchivo(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFile = new OpenFileDialog();
            openFileDialog.Filter = "Texto|*.txt";


            if (openFileDialog.ShowDialog() == true)
            {
                this.saveFileDialog.FileName = this.openFileDialog.FileName;
                this.areatexto.Text = File.ReadAllText(this.saveFileDialog.FileName);


            }
        }

        private void guardar(object sender, RoutedEventArgs e)
        {
            this.saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (File.Exists(this.saveFileDialog.FileName) || File.Exists(this.openFileDialog.FileName))
            {
                if (File.Exists(this.saveFileDialog.FileName))
                    File.WriteAllText(this.saveFileDialog.FileName, this.areatexto.Text);
                else File.WriteAllText(this.openFileDialog.FileName, this.areatexto.Text);
            }
            else
            {
                if (this.saveFileDialog.ShowDialog() == true)
                {
                    this.openFileDialog.FileName = this.saveFileDialog.FileName;
                    File.WriteAllText(this.saveFileDialog.FileName, this.areatexto.Text);
                }
            }
        }

        private void guardarcomo(object sender, RoutedEventArgs e)
        {
            this.openFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (File.Exists(this.openFileDialog.FileName) || File.Exists(this.saveFileDialog.FileName))
            {
                if (File.Exists(this.openFileDialog.FileName))
                    File.WriteAllText(this.openFileDialog.FileName, this.areatexto.Text);
                else File.WriteAllText(this.saveFileDialog.FileName, this.areatexto.Text);
            }
            else
            {
                if (this.openFileDialog.ShowDialog() == true)
                {
                    this.saveFileDialog.FileName = this.openFileDialog.FileName;
                    File.WriteAllText(this.openFileDialog.FileName, this.areatexto.Text);
                }
            }
        }

        private void salir(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //prueba de listas 


            //Prueba de Equals
            //if (String.Equals("Hola", "hola"))
            //{
            //    this.text.Text = "Son iguales";
            //}
            //else { this.text.Text = "No son iguales"; }
            
            //Prueba Leer archivo de texto
           /*string[] lines= Scan.Scaan.getNextChar();
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                this.text.Text = line+"\n";
            }*/

            //Crear Archivo de Texto

            //string fileName = this.saveFileDialog.FileName.Remove(this.saveFileDialog.FileName.Length-4,4)+"_Lexico.txt";



            //FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            //stream.Close();
            //StreamWriter writer = new StreamWriter(fileName);
            //Util.printToken(Globals.Global.TokenType.IF, "if", writer);
            //Util.printToken(Globals.Global.TokenType.END, "end", writer);
            //Util.printToken(Globals.Global.TokenType.MAIN, "main", writer);
            //Util.printToken(Globals.Global.TokenType.SUMA, "+", writer);
            //writer.Close();
            //this.codigofinal.Text = fileName;

        }

        private void cerrar(object sender, RoutedEventArgs e)
        {
            if (this.openFileDialog.FileName == null || this.openFileDialog.FileName == "")
            {
                if (this.areatexto.Text != "")
                {
                    this.saveFileDialog.Filter = "Text file (*.txt)|*.txt";

                    if (this.saveFileDialog.ShowDialog() == true)
                    {
                        

                        File.WriteAllText(this.saveFileDialog.FileName, this.areatexto.Text);

                    }
                }
                this.areatexto.Text = "";
                this.saveFileDialog.FileName = "";
                this.openFileDialog.FileName = "";
                return;
            }

            string txt = File.ReadAllText(this.openFileDialog.FileName);
            if (txt == this.areatexto.Text)
            {

            }
            else
            {
                if (MessageBox.Show("¿Deseas guardar tu archivo?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    File.WriteAllText(this.openFileDialog.FileName, this.areatexto.Text);
                    MessageBox.Show("Guardando");

                }

            }
            this.areatexto.Text = "";
            this.saveFileDialog.FileName = "";
            this.openFileDialog.FileName = "";


        }





    }
}
