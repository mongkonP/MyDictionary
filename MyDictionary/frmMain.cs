using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDictionary
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        AutoCompleteStringCollection collection ;

        void RefreshData()
        {

            // TODO: This line of code loads data into the 'wordDataSet.Table1' table. You can move, or remove it, as needed.
            this.table1TableAdapter.Fill(this.wordDataSet.Table1);
            collection = new AutoCompleteStringCollection();

            for (int i = 0; i < this.table1DataGridView.RowCount - 1; i++)
            {
                collection.Add(table1DataGridView[0, i].Value.ToString());
            }

            //  MessageBox.Show(collection.Count.ToString());
            textBox1.AutoCompleteCustomSource = collection;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            RefreshData();


            /*  FileInfo existingFile = new FileInfo(@"D:\Mega_TOR\Test_Code\test_Csharp_TOR\TestCode\MyDictionary\MyDictionary\Sentences_1.xlsx");
              ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
              using (ExcelPackage package = new ExcelPackage(existingFile))
              {

                  ExcelWorksheet worksheet = package.Workbook.Worksheets[0];//EAT
                  int colCount = worksheet.Dimension.End.Column;  //get Column Count
                  int rowCount = worksheet.Dimension.End.Row;     //get row count

                  for (int row = 1; row <= rowCount; row++)
                  {


                      if (!string.IsNullOrEmpty(worksheet.Cells[row, 1].Value?.ToString().Trim()))
                      {
                          if (!worksheet.Cells[row, 1].Value.ToString().Trim().Contains(" "))
                          {

                              table1TableAdapter.Insert(worksheet.Cells[row, 1].Value?.ToString().Trim(),
                                  worksheet.Cells[row, 2].Value?.ToString().Trim(),
                                  worksheet.Cells[row, 3].Value?.ToString().Trim());
                          }

                      }
                  }


              };

              this.table1TableAdapter.Fill(this.wordDataSet.Table1);*/


            if (string.IsNullOrEmpty(Properties.Settings.Default.pic1) || !System.IO.File.Exists(Properties.Settings.Default.pic1))
            { pictureBox1.Image = Properties.Resources._6954615_black_cat_cat_fear_halloween_scary_icon1; }
            else
            {
                pictureBox1.Image = Image.FromFile(Properties.Settings.Default.pic1);
            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.pic2) || !System.IO.File.Exists(Properties.Settings.Default.pic2))
            { pictureBox2.Image = Properties.Resources._182507_cat_walk_icon; }
            else
            {
                pictureBox2.Image = Image.FromFile(Properties.Settings.Default.pic2);
            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.pic3) || !System.IO.File.Exists(Properties.Settings.Default.pic3))
            { pictureBox3.Image = Properties.Resources._185520_pirate_cat_icon; }
            else
            {
                pictureBox3.Image = Image.FromFile(Properties.Settings.Default.pic3);
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            this.table1BindingSource.Filter = "WordEng = '" + textBox1.Text.Trim() + "'";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.table1BindingSource.Filter = "WordEng = '" + textBox1.Text.Trim() + "'";
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string f = SelectImage();
            if (!string.IsNullOrEmpty(f))
            {
                pictureBox3.Image = Image.FromFile(f);
                Properties.Settings.Default.pic3 = f;
                Properties.Settings.Default.Save();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string f = SelectImage();
            if (!string.IsNullOrEmpty(f))
            {
                pictureBox2.Image = Image.FromFile(f);
                Properties.Settings.Default.pic2 = f;
                Properties.Settings.Default.Save();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string f = SelectImage();
            if (!string.IsNullOrEmpty(f))
            {
                pictureBox1.Image = Image.FromFile(f);
                Properties.Settings.Default.pic1 = f;
                Properties.Settings.Default.Save();
            }
        }

        string SelectImage()
        {
            //Create a new instance of openFileDialog
            OpenFileDialog res = new OpenFileDialog();
            string filePath = "";
            //Filter
            res.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";

            //When the user select the file
            if (res.ShowDialog() == DialogResult.OK)
            {
                //Get the file's path
                 filePath = res.FileName;
                //Do something
               
            }
            return filePath;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.table1BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.wordDataSet);
            MessageBox.Show("Save word compete");
            RefreshData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string w1 = textBox1.Text;
            string w2 = _VoidTextBox.Text;
            string w3 = wordThTextBox.Text;


            this.table1BindingSource.Filter = "WordEng = '" + textBox1.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("We have word in data \nCan't save data");
            }
            else
            {
                table1TableAdapter.Insert(w1, w2, w3);
                MessageBox.Show("Save word compete");
                RefreshData();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmData().ShowDialog();
        }
        string fileexc;
        private void button2_Click(object sender, EventArgs e)
        {
          /*  BackgroundWorker1.WorkerReportsProgress = true;
            BackgroundWorker1.WorkerSupportsCancellation = true;
            if (BackgroundWorker1.IsBusy != true)
            {*/
                // Start the asynchronous operation.
                using (OpenFileDialog of = new OpenFileDialog())
                {
                    of.Filter = "Excel Files(.xlsx) | *.xlsx";
                    if (of.ShowDialog() == DialogResult.OK)
                    {
                        fileexc = of.FileName;

                    string s = "";
                        FileInfo existingFile = new FileInfo(fileexc);
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        int i = 0;
                    using (frmWaitFormDialog f = new frmWaitFormDialog(new Action(() =>
                    {
                        this.toolStripStatusLabel1.Text = "Adding new word";
                        using (ExcelPackage package = new ExcelPackage(existingFile))
                        {

                            /* ExcelWorksheet worksheet = package.Workbook.Worksheets[0];//EAT
                             int colCount = worksheet.Dimension.End.Column;  //get Column Count
                             int rowCount = worksheet.Dimension.End.Row;     //get row count

                             for (int row = 1; row <= rowCount; row++)
                             {


                                 if (!string.IsNullOrEmpty(worksheet.Cells[row, 1].Value?.ToString().Trim()))
                                 {
                                     if (!worksheet.Cells[row, 1].Value.ToString().Trim().Contains(" "))
                                     {
                                         string cri = worksheet.Cells[row, 1].Value?.ToString().Trim().ToLower();
                                         //this.toolStripStatusLabel1.Text = "check:" + cri;

                                         this.table1BindingSource.Filter = "WordEng = '" + cri + "'";
                                         //  System.Threading.Thread.Sleep(1000);
                                         // MessageBox.Show(cri + "\n" + textBox1.Text);
                                         if (string.IsNullOrEmpty(textBox1.Text))
                                         {
                                             i++;
                                             table1TableAdapter.Insert(cri,
                                                   worksheet.Cells[row, 2].Value?.ToString().Trim(),
                                                   worksheet.Cells[row, 3].Value?.ToString().Trim());

                                             s += "_" + worksheet.Cells[row, 1].Value?.ToString().Trim();
                                         }

                                     }

                                 }



                              }*/
                            /* string connectionString = Properties.Settings.Default.wordConnectionString;
                             string insertQuery = "INSERT INTO Table1 (WordEng, _Void, WordTh) VALUES(@WordEng, @_Void, @WordTh)";
                             string sql = "";
                             int batchSize = 0;
                             using (System.Data.OleDb.OleDbConnection connection = new  System.Data.OleDb.OleDbConnection(connectionString))
                             {
                                 using (System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand(insertQuery, connection))
                                 {
                                     // define your parameters ONCE outside the loop, and use EXPLICIT typing
                                     command.Parameters.Add("@WordEng", System.Data.OleDb.OleDbType.LongVarWChar);
                                     command.Parameters.Add("@_Void", System.Data.OleDb.OleDbType.LongVarWChar);
                                     command.Parameters.Add("@WordTh", System.Data.OleDb.OleDbType.LongVarWChar);

                                     connection.Open();


                                     foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)
                                     {

                                         int colCount = worksheet.Dimension.End.Column;  //get Column Count
                                         int rowCount = worksheet.Dimension.End.Row;     //get row count

                                         for (int row = 1; row <= rowCount; row++)
                                         {


                                             if (!string.IsNullOrEmpty(worksheet.Cells[row, 1].Value?.ToString().Trim()))
                                             {
                                                 if (!worksheet.Cells[row, 1].Value.ToString().Trim().Contains(" "))
                                                 {
                                                     string cri = worksheet.Cells[row, 1].Value?.ToString().Trim().ToLower();
                                                     //this.toolStripStatusLabel1.Text = "check:" + cri;

                                                     if (!string.IsNullOrEmpty(cri) &&
                                                     !string.IsNullOrEmpty(worksheet.Cells[row, 2].Value?.ToString().Trim())
                                                     && !string.IsNullOrEmpty(worksheet.Cells[row, 3].Value?.ToString().Trim())
                                                     && !s.Contains(cri))
                                                     {
                                                         this.table1BindingSource.Filter = "WordEng = '" + cri + "'";
                                                         System.Threading.Thread.Sleep(1000);
                                                         if (string.IsNullOrEmpty(textBox1.Text))
                                                         {
                                                             i++;
                                                             /* table1TableAdapter.Insert(cri,
                                                                    worksheet.Cells[row, 2].Value?.ToString().Trim(),
                                                                    worksheet.Cells[row, 3].Value?.ToString().Trim());*

                                                             // now just SET the values
                                                             command.Parameters["@WordEng"].Value = cri;
                                                             command.Parameters["@_Void"].Value = worksheet.Cells[row, 2].Value?.ToString().Trim();
                                                             command.Parameters["@WordTh"].Value = worksheet.Cells[row, 2].Value?.ToString().Trim();
                                                             command.ExecuteNonQuery();
                                                             toolStripStatusLabel1.Text = "Add:" + cri;
                                                             s += "_" + worksheet.Cells[row, 1].Value?.ToString().Trim();
                                                         }

                                                     }


                                                 }

                                             }



                                         }
                                     }

                                     connection.Close();
                                 }




                             }
                             */

                            //https://stackoverflow.com/questions/2972974/how-should-i-multiple-insert-multiple-records
                            string connectionString = Properties.Settings.Default.wordConnectionString;
                           
                            StringBuilder sql = new StringBuilder("");
                            int batchSize = 0;
                            using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection(connectionString))
                            {
                                  

                                    connection.Open();


                                    foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)
                                    {

                                        int colCount = worksheet.Dimension.End.Column;  //get Column Count
                                        int rowCount = worksheet.Dimension.End.Row;     //get row count

                                        for (int row = 1; row <= rowCount; row++)
                                        {


                                            if (!string.IsNullOrEmpty(worksheet.Cells[row, 1].Value?.ToString().Trim()))
                                            {
                                                if (!worksheet.Cells[row, 1].Value.ToString().Trim().Contains(" "))
                                                {
                                                    string cri = worksheet.Cells[row, 1].Value?.ToString().Trim().ToLower();
                                                    //this.toolStripStatusLabel1.Text = "check:" + cri;

                                                    if (!string.IsNullOrEmpty(cri) &&
                                                    !string.IsNullOrEmpty(worksheet.Cells[row, 2].Value?.ToString().Trim())
                                                    && !string.IsNullOrEmpty(worksheet.Cells[row, 3].Value?.ToString().Trim())
                                                    && !s.Contains(cri))
                                                    {
                                                        this.table1BindingSource.Filter = "WordEng = '" + cri + "'";
                                                       // System.Threading.Thread.Sleep(1000);
                                                        if (string.IsNullOrEmpty(textBox1.Text))
                                                        {
                                                            i++;

                                                            String r = String.Format($"('{cri}', '{worksheet.Cells[row, 2].Value?.ToString().Trim()}', '{worksheet.Cells[row, 2].Value?.ToString().Trim()}')");
                                                            //Add the row to our running SQL batch
                                                            if (batchSize > 0)
                                                                sql.AppendLine(",");
                                                            sql.Append(r);
                                                            batchSize ++;
                                                            
                                                            toolStripStatusLabel1.Text = "Add:" + cri;
                                                            s += "_" + worksheet.Cells[row, 1].Value?.ToString().Trim();
                                                            if (batchSize >= 20)
                                                            {
                                                                String insertQuery = "INSERT INTO Table1 (WordEng, _Void, WordTh) VALUES" + sql.ToString() + ";";
                                                            using (System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand(insertQuery,connection))
                                                            {
                                                                command.ExecuteNonQuery();
                                                                sql.Clear();
                                                                batchSize = 0;
                                                                
                                                            }

                                                        
                                                        }

                                                    }


                                                }

                                            }



                                        }
                                    }

                                    connection.Close();
                                }




                            }
                        };
                        MessageBox.Show($"Add {i} wold");
                        this.table1TableAdapter.Fill(this.wordDataSet.Table1);
                        this.toolStripStatusLabel1.Text = "Add complete";

                        // BackgroundWorker1.RunWorkerAsync();


                    })))
                    {
                        f.ShowDialog(this);
                    }
                   }  
              //  }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string url =  $"https://dictionary.sanook.com/search/dict-en-th-sedthabut/{textBox1.Text}";
            ProcessStartInfo sInfo = new ProcessStartInfo(url);
            Process.Start(sInfo);
        }

       

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
                    // Task.Factory.StartNew(() => {

                    

                    //  });

        }
    }
}
