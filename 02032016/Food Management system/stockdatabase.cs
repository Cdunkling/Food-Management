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
    public partial class stockdatabase : Form
    {

        public static DataTable stocktable = new DataTable();
        public static product newproduct = new product();
        string filename = "stock.csv";
        public static int rows;

        public stockdatabase()
        {
            InitializeComponent();
            
            DataColumn Barcode;
            Barcode = new DataColumn();
            Barcode.DataType = System.Type.GetType("System.String");
            Barcode.AllowDBNull = false;
            Barcode.ReadOnly = true;
            Barcode.ColumnName = "Barcode";
            stocktable.Columns.Add(Barcode);


            DataColumn BoughtDate;
            BoughtDate = new DataColumn();
            BoughtDate.DataType = System.Type.GetType("System.String");
            BoughtDate.AllowDBNull = false;
            BoughtDate.ReadOnly = true;
            BoughtDate.ColumnName = "BoughtDate";
            stocktable.Columns.Add(BoughtDate);

            DataColumn ExpiryDate;
            ExpiryDate = new DataColumn();
            ExpiryDate.DataType = System.Type.GetType("System.String");
            ExpiryDate.AllowDBNull = false;
            ExpiryDate.ReadOnly = true;
            ExpiryDate.ColumnName = "ExpiryDate";
            stocktable.Columns.Add(ExpiryDate);

            DataColumn Status;
            Status = new DataColumn();
            Status.DataType = System.Type.GetType("System.String");
            Status.AllowDBNull = true;
            Status.ReadOnly = false;
            Status.ColumnName = "Status";
            stocktable.Columns.Add(Status);

            DataColumn shop;
            shop = new DataColumn();
            shop.DataType = System.Type.GetType("System.String");
            shop.AllowDBNull = true;
            shop.ReadOnly = false;
            shop.ColumnName = "shop";
            stocktable.Columns.Add(shop);

            DataColumn Location;
            Location = new DataColumn();
            Location.DataType = System.Type.GetType("System.String");
            Location.AllowDBNull = true;
            Location.ReadOnly = false;
            Location.ColumnName = "Location";
            stocktable.Columns.Add(Location);

            DataColumn Price;
            Price = new DataColumn();
            Price.DataType = System.Type.GetType("System.String");
            Price.AllowDBNull = true;
            Price.ReadOnly = false;
            Price.ColumnName = "Price";
            stocktable.Columns.Add(Price);

            DataColumn position;
            position = new DataColumn();
            position.DataType = System.Type.GetType("System.String");
            position.AllowDBNull = true;
            position.ReadOnly = false;
            position.ColumnName = "position";
            stocktable.Columns.Add(position);
            dataGridView1.DataSource = stocktable;

            var lines = File.ReadLines(filename);
            string[] values = new string[6];
            foreach (var line in lines)
            {
                values = line.Split(',').ToArray();
                stocktable.Rows.Add(values);
                rows++;
            }
        }
    }
}
