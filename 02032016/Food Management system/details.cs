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

namespace FoodManagementsystem
{
    public partial class details : Form
    {
        public static DataTable detailstable = new DataTable();

        public details()
        {
            InitializeComponent();

            DataColumn Name;
            Name = new DataColumn();
            Name.DataType = System.Type.GetType("System.String");
            Name.AllowDBNull = false;
            Name.ReadOnly = true;
            Name.ColumnName = "Name";
            detailstable.Columns.Add(Name);

            DataColumn Barcode;
            Barcode = new DataColumn();
            Barcode.DataType = System.Type.GetType("System.String");
            Barcode.AllowDBNull = false;
            Barcode.ReadOnly = true;
            Barcode.ColumnName = "Barcode";
            detailstable.Columns.Add(Barcode);

            DataColumn BoughtDate;
            BoughtDate = new DataColumn();
            BoughtDate.DataType = System.Type.GetType("System.String");
            BoughtDate.AllowDBNull = false;
            BoughtDate.ReadOnly = true;
            BoughtDate.ColumnName = "BoughtDate";
            detailstable.Columns.Add(BoughtDate);

            DataColumn ExpiryDate;
            ExpiryDate = new DataColumn();
            ExpiryDate.DataType = System.Type.GetType("System.String");
            ExpiryDate.AllowDBNull = true;
            ExpiryDate.ReadOnly = true;
            ExpiryDate.ColumnName = "ExpiryDate";
            detailstable.Columns.Add(ExpiryDate);

            DataColumn shop;
            shop = new DataColumn();
            shop.DataType = System.Type.GetType("System.String");
            shop.AllowDBNull = true;
            shop.ReadOnly = true;
            shop.ColumnName = "shop";
            detailstable.Columns.Add(shop);

            DataColumn Price;
            Price = new DataColumn();
            Price.DataType = System.Type.GetType("System.String");
            Price.AllowDBNull = true;
            Price.ReadOnly = true;
            Price.ColumnName = "Price";
            detailstable.Columns.Add(Price);

            DataColumn Location;
            Location = new DataColumn();
            Location.DataType = System.Type.GetType("System.String");
            Location.AllowDBNull = true;
            Location.ReadOnly = true;
            Location.ColumnName = "Location";
            detailstable.Columns.Add(Location);


            DataColumn Status;
            Status = new DataColumn();
            Status.DataType = System.Type.GetType("System.String");
            Status.AllowDBNull = true;
            Status.ReadOnly = true;
            Status.ColumnName = "Status";
            detailstable.Columns.Add(Status);

            DataColumn position;
            position = new DataColumn();
            position.DataType = System.Type.GetType("System.String");
            position.AllowDBNull = true;
            position.ReadOnly = true;
            position.ColumnName = "position";
            detailstable.Columns.Add(position);


            dataGridView1.DataSource = detailstable;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //user can only
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["position"].Visible = false;
        }

        private void details_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            detailstable.Clear();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string index = dataGridView1.SelectedRows[0].Cells["position"].Value.ToString();
            int indexnum = Int32.Parse(index);
            string barcode = dataGridView1.SelectedRows[0].Cells["Barcode"].Value.ToString();
            int value;
            foreach (DataRow dr in MainWindow.table.Rows)
            {
                if (barcode == dr["Barcode"].ToString())
                {
                    value = Convert.ToInt32(dr["Quantity"]);
                    value -= 1;
                    stockdatabase.stocktable.Rows.RemoveAt(indexnum);
                    MainWindow.table.Columns["Quantity"].ReadOnly = false;
                    dr["Quantity"] = value;
                    foreach (DataRow dx in productdatabase.producttable.Rows)
                    {
                        if (barcode == dx["Barcode"].ToString())
                        {
                            dx["Quantity"] = value;
                        }
                    }
                    MainWindow.table.Columns["Quantity"].ReadOnly = true;
                    MainWindow.statuscheck();
                    details detail = new details();
                    break;
                }
            }
        }
    }
}
