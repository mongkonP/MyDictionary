﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDictionary
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void table1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.table1BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.wordDataSet);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wordDataSet.Table1' table. You can move, or remove it, as needed.
            this.table1TableAdapter.Fill(this.wordDataSet.Table1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.table1BindingSource.Filter = "WordEng = '" + textBox1.Text + "'";
        }
    }
}
