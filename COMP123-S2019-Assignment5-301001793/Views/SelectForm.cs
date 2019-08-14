﻿using COMP123_S2019_Assignment5_301001793.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2019_Assignment5_301001793.Views
{
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            //var ProductList =
            //    from product in this.
            //    select product;

            //foreach (var product in ProductList.ToList())
            //{
            //    Debug.WriteLine("ProductID: " + product.productID + " Model: " + product.model);
            //}

            Program.Forms[FormName.PRODUCT_INFO_FORM].Show();
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SelectForm_Load(object sender, EventArgs e)
        {
            using (var db = new DollarComputersContext())
            {
                db.products.Load();
                productBindingSource.DataSource = db.products.Local.ToBindingList();
            }
        }

        private void ProductDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // local scope aliases
            var rowIndex = ProductDataGridView.CurrentCell.RowIndex;
            var rows = ProductDataGridView.Rows;
            var columnCount = ProductDataGridView.ColumnCount;
            var cells = rows[rowIndex].Cells;
            
            string outputString = string.Empty;
            //for (int index = 0; index < columnCount; index++)            
            outputString = cells[(int)ProductField.MANUFACTURER].Value.ToString() + " " + cells[(int)ProductField.MODEL].Value.ToString() 
                + " Priced at: $" + cells[(int)ProductField.COST].Value.ToString();
            
            YourSelectionTextBox.Text = outputString;

            Program.product.productID = short.Parse(cells[(int)ProductField.PRODUCT_ID].Value.ToString());
            Program.product.cost = decimal.Parse(cells[(int)ProductField.COST].Value.ToString());
            Program.product.manufacturer = cells[(int)ProductField.MANUFACTURER].Value.ToString();
            Program.product.model = cells[(int)ProductField.MODEL].Value.ToString();
            Program.product.RAM_type = cells[(int)ProductField.RAM_TYPE].Value.ToString();
            Program.product.RAM_size = cells[(int)ProductField.RAM_SIZE].Value.ToString();
            Program.product.displaytype = cells[(int)ProductField.DISPLAY_TYPE].Value.ToString();
            Program.product.screensize = cells[(int)ProductField.SCREEN_SIZE].Value.ToString();
            Program.product.resolution = cells[(int)ProductField.RESOLUTION].Value.ToString();
            Program.product.CPU_Class = cells[(int)ProductField.CPU_CLASS].Value.ToString();
            Program.product.CPU_brand = cells[(int)ProductField.CPU_BRAND].Value.ToString();
            Program.product.CPU_type = cells[(int)ProductField.CPU_TYPE].Value.ToString();
            Program.product.CPU_speed = cells[(int)ProductField.CPU_SPEED].Value.ToString();
            Program.product.CPU_number = cells[(int)ProductField.CPU_NUMBER].Value.ToString();
            Program.product.condition = cells[(int)ProductField.CONDITION].Value.ToString();
            Program.product.OS = cells[(int)ProductField.OS].Value.ToString();
            Program.product.platform = cells[(int)ProductField.PLATFORM].Value.ToString();
            Program.product.HDD_size = cells[(int)ProductField.HDD_SIZE].Value.ToString();
            Program.product.HDD_speed = cells[(int)ProductField.HDD_SPEED].Value.ToString();
            Program.product.GPU_Type = cells[(int)ProductField.GPU_TYPE].Value.ToString();
            Program.product.optical_drive = cells[(int)ProductField.OPTICAL_DRIVE].Value.ToString();
            Program.product.Audio_type = cells[(int)ProductField.AUDIO_TYPE].Value.ToString();
            Program.product.LAN = cells[(int)ProductField.LAN].Value.ToString();
            Program.product.WIFI = cells[(int)ProductField.WIFI].Value.ToString();
            Program.product.width = cells[(int)ProductField.WIDTH].Value.ToString();
            Program.product.height = cells[(int)ProductField.HEIGHT].Value.ToString();
            Program.product.depth = cells[(int)ProductField.DEPTH].Value.ToString();
            Program.product.weight = cells[(int)ProductField.WEIGHT].Value.ToString();
            Program.product.moust_type = cells[(int)ProductField.MOUSE_TYPE].Value.ToString();
            Program.product.power = cells[(int)ProductField.POWER].Value.ToString();
            Program.product.webcam = cells[(int)ProductField.WEBCAM].Value.ToString();
        }

        private void ProductDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = ProductDataGridView.CurrentCell.RowIndex;
            var rows = ProductDataGridView.Rows;

            rows[rowIndex].Selected = true;
            NextButton.Enabled = true;
        }
    }
}