using OfficeOpenXml;
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

namespace MyDictionary
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void table1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.table1BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.wordDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wordDataSet.Table1' table. You can move, or remove it, as needed.
            this.table1TableAdapter.Fill(this.wordDataSet.Table1);
          /*  FileInfo existingFile = new FileInfo(@"D:\MyDictionary\MyDictionary\MyDictionary\ชาบู&หมูกระทะ.xlsx");
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
                            string cri = worksheet.Cells[row, 1].Value?.ToString().Trim();
                            this.table1BindingSource.Filter = "WordEng = '" + cri + "'";
                            if (string.IsNullOrEmpty(wordEngTextBox.Text))
                            {
                                table1TableAdapter.Insert(worksheet.Cells[row, 1].Value?.ToString().Trim(),
                                  worksheet.Cells[row, 2].Value?.ToString().Trim(),
                                  worksheet.Cells[row, 3].Value?.ToString().Trim());
                            }

                     

                            // MessageBox.Show(worksheet.Cells[row, 1].Value?.ToString().Trim());
                        }

                    }
                }


            };

            this.table1TableAdapter.Fill(this.wordDataSet.Table1);*/

        }
    }
}
