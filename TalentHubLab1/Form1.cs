using Newtonsoft.Json;
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
using TalentHubLab1.AVL;

namespace TalentHubLab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Elements used to open a .csv file with information about applicant records
        OpenFileDialog pathSearcher = new OpenFileDialog();
        FileStream file;
        StreamReader read;
        StreamWriter writer;
        public AVLclass AVL = new AVLclass();
        
       
        // Function dedicated to convert a string into json format  
        public void JsonConverter(StreamReader file)
        {
            //while the end of the stream is not reached, take one line of the file content
            while  (!file.EndOfStream)
            {
                string line = file.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    //array that contains the necessary instructions to create the AVL with all the applicant records
                    string[] instructions = line.Split(';');
                    instructions[0].ToLower();

                    //deserialize string with newtonsoft.json to create a new applicant element
                    Applicant applicant = JsonConvert.DeserializeObject<Applicant>(instructions[1]);

                    //the first position of the array indicates what kind of operation the AVL needs to do to generate its structure
                  
                    switch (instructions[0].ToLower())
                    {
                        case "insert":
                            AVL.Root = AVL.Insert(AVL.Root, applicant);
                            break;
                        case "patch":
                            AVL.Edit(AVL.Root, applicant);
                            break;
                        case "delete":
                            AVL.Delete(AVL.Root, applicant);
                            break;
                    }

                }
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pathSearcher.Filter = "CSV files |*.csv";
            if (pathSearcher.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = pathSearcher.FileName;
                file = new FileStream(pathSearcher.FileName, FileMode.OpenOrCreate);
                read = new StreamReader(file);
                JsonConverter(read);
                file.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                richTextBox1.Clear();
                AVL.NodeList.Clear();
                string name = textBox2.Text;
                AVL.InorderSearch(AVL.Root, name);

                if (AVL.NodeList.Count != 0)
                {
                    foreach(Applicant a in AVL.NodeList)
                    {
                        //serialization
                        string line = JsonConvert.SerializeObject(a);
                        richTextBox1.Text += line + Environment.NewLine;
                    }
                }
                else
                    richTextBox1.Text = "There are no applicants with the name given";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "archivo Json|*.json";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    file.Close();
                    file = new FileStream(save.FileName, FileMode.Create, FileAccess.Write);
                    writer = new StreamWriter(file, Encoding.UTF8);
                    // File.WriteAllLines(save.FileName, richTextBox1.Lines);

                    //writer.Write(richTextBox1.Text);

                    
                    for (int i = 0; i < richTextBox1.Lines.Length; i++)
                    {
                        if (!string.IsNullOrEmpty( richTextBox1.Lines[i]))
                            writer.WriteLine(richTextBox1.Lines[i].Trim());
                    }
                    writer.Close();
                    file.Close();

                }
            }
        }
    }
}
