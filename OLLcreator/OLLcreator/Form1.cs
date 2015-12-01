using BitMiracle.LibTiff.Classic;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLLcreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Source_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            FolderBrowserDialog FolderBrowserSource = new FolderBrowserDialog();

            DialogResult result = FolderBrowserSource.ShowDialog();
            if (result == DialogResult.OK)
            {
                sourceFolderText = FolderBrowserSource.SelectedPath;
                textBox_Source.Text = sourceFolderText;
            }

        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            create_OLL();
        }

        private void create_OLL()//TODO
        {
            //store all of the files in an array
            string[] files = Directory.GetFiles(sourceFolderText);
            MessageBox.Show("Files found: " + files.Length.ToString(), "Message");

            //create oll builders
            StringBuilder sb = new StringBuilder();
            StringBuilder sbNew = new StringBuilder();

            //look at each file,check for number of pages, and send each page to format_OLL
            for (int i = 0; i < files.Length; i++)
            {
                //check if pdf, tiff, or other
                FileInfo info = new FileInfo(files[i]);
                if(info.Extension.Equals(".pdf"))//pdf
                {
                    int pages = getNumberOfPdfPages(files[i]);//get number of pages and send to formatter
                    sbNew = format_OLL(files[i], pages, 5, sb);
                    sb = sbNew;
                }
                else if (info.Extension.Equals(".tiff") || info.Extension.Equals(".tif"))//tiff TODO
                {
                    int pages = 1;

                    using (Tiff tiffFromFile = Tiff.Open(files[i], "r"))
                    {
                        pages = getNumberofTiffPages(tiffFromFile);
                    }
                    sbNew = format_OLL(files[i], pages, 1, sb);
                    sb = sbNew;
                }
                else if (info.Extension.Equals(".mpg"))//media TODO, add other media types as well
                {

                }
                else //other (assumes everything that is other is a single page photo, could use some work)
                {
                    sb = format_OLL(files[i], 1, 2, sb);
                    sb = sbNew;
                }
                
                
            }

            //output oll
            string folder = "";
            int index = sourceFolderText.LastIndexOf('\\');
            folder = sourceFolderText.Substring(0, index);

            string[] paths = new string[] {folder, "LoadFile.oll" };
            using (StreamWriter outfile = new StreamWriter(Path.Combine(paths)))
            {
                outfile.Write(sb.ToString());
            }
            MessageBox.Show(".OLL Created");
        }

        private StringBuilder format_OLL(string sourceFile, int pageNumber, int fileType, StringBuilder sb)//TODO
        {
            //Send each page of a document to the formatter, format_OLL_Page.
            //get a string back that gets appended to the oll
            //MessageBox.Show(sourceFile + ":" + pageNumber + ":" + fileType);
            string ollLine = "";
            for(int i = 1; i <= pageNumber; i++)
            {
                if(fileType.Equals(5))//if it is a pdf
                {
                    PdfReader pdfReader = new PdfReader(sourceFile);
                    //string pageName = pdfReader.GetPageN(i).ToString();//this is not correct TODO
                    //for now it just puts in standard formatting, should have an if that will use this or use the real name
                    string pageName = Path.GetFileNameWithoutExtension(sourceFile) + "-" + leadingZeros(i);
                    ollLine = format_OLL_Page(sourceFile, i, fileType, pageName);
                    sb.AppendLine(ollLine);
                }
                //add for tiff and other TODO
                else if (fileType.Equals(1))
                {
                    //for now it just puts in standard formatting, should have an if that will use this or use the real name
                    string pageName = Path.GetFileNameWithoutExtension(sourceFile) + "-" + leadingZeros(i);
                    ollLine = format_OLL_Page(sourceFile, i, fileType, pageName);
                    sb.AppendLine(ollLine);
                }
                else
                {
                    string pageName = Path.GetFileNameWithoutExtension(sourceFile) + "-" + leadingZeros(i);
                    ollLine = format_OLL_Page(sourceFile, i, fileType, pageName);
                    sb.AppendLine(ollLine);
                }
            }

            
            return sb;
        }

        private string format_OLL_Page(string sourceFile, int pageNumber, int fileType, string pageName)
        {
            //Takes the input file and its page number and outputs a string that is one line of the oll.
            //For multi page files this would be run for each page.
            //Should check for file type, and if there is a unique page name.
            string output = "";
           //MessageBox.Show(sourceFile + ":" + pageNumber + ":" + fileType + ":" + pageName);


            string docID = Path.GetFileNameWithoutExtension(sourceFile);
            string path = Path.GetDirectoryName(sourceFile);
            string folder = "";
            int index = path.LastIndexOf('\\');
            folder = path.Substring(index, path.Length - index);
            string filename = Path.GetFileName(sourceFile);
            output = "\"" + fileType + "\",\"" + docID + "\",\"" + pageName + "\",\"" + pageNumber + "\",\"\",\"\",\"" + folder + "\",\"" + filename + "\",\"\"";
            //MessageBox.Show(output);
            return output;
        }

        public int getNumberOfPdfPages(string fileName)
        {
            PdfReader pdfReader = new PdfReader(fileName);
            int numberOfPages = pdfReader.NumberOfPages;
            return numberOfPages;
        }

        public int getNumberofTiffPages(Tiff image)
        {
            int pageCount = 0;
            do
            {
                ++pageCount;
            } while (image.ReadDirectory());

            return pageCount;
        }

        public string leadingZeros(int number)
        {
            return number.ToString().PadLeft(3, '0');
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
