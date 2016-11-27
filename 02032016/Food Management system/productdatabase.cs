using FoodManagmentsystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace FoodManagementsystem
{
    public partial class productdatabase : Form
    {
        
        public static DataTable producttable = new DataTable();
        string filename = "product.csv";
        public static int rows;

        public productdatabase()
        {
            InitializeComponent();

            DataColumn Name;
            Name = new DataColumn();
            Name.DataType = System.Type.GetType("System.String");
            Name.AllowDBNull = false;
            Name.ReadOnly = false;
            Name.ColumnName = "Name";
            producttable.Columns.Add(Name);

            DataColumn Barcode;
            Barcode = new DataColumn();
            Barcode.DataType = System.Type.GetType("System.String");
            Barcode.AllowDBNull = false;
            Barcode.ReadOnly = true;
            Barcode.ColumnName = "Barcode";
            producttable.Columns.Add(Barcode);

            DataColumn Quantity;
            Quantity = new DataColumn();
            Quantity.DataType = System.Type.GetType("System.String");
            Quantity.AllowDBNull = true;
            Quantity.ReadOnly = false;
            Quantity.ColumnName = "Quantity";
            producttable.Columns.Add(Quantity);

            DataColumn minquantity;
            minquantity = new DataColumn();
            minquantity.DataType = System.Type.GetType("System.String");
            minquantity.AllowDBNull = true;
            minquantity.ReadOnly = false;
            minquantity.ColumnName = "minquantity";
            producttable.Columns.Add(minquantity);

            DataColumn Status;
            Status = new DataColumn();
            Status.DataType = System.Type.GetType("System.String");
            Status.AllowDBNull = true;
            Status.ReadOnly = false;
            Status.ColumnName = "Status";
            producttable.Columns.Add(Status);
            dataGridView1.DataSource = producttable;
            try { 
            var lines = File.ReadLines(filename);
            string[] values = new string[4];
            foreach (var line in lines)
            {
                values = line.Split(',').ToArray();
                producttable.Rows.Add(values);
                rows++;
            }
            }
            catch (FileNotFoundException ex)
            {
                File.Create("product.csv");
            }
        }
    }
}
