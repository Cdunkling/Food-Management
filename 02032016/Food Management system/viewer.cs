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
    public partial class viewer : Form
    {
        public static DataTable viewtable = new DataTable();
        public static DataTable viewtable2 = new DataTable();
        public static DataTable viewtable3 = new DataTable();
        public static bool hasbeenopened;
        public viewer()
        {
            InitializeComponent();
            if (hasbeenopened == true)
            {
                if (Form1.viewerstate == "Runout")
                {
                    dataGridView1.DataSource = viewtable;
                }
                else if (Form1.viewerstate == "Expired")
                {
                    dataGridView1.DataSource = viewtable2;
                }
                else if (Form1.viewerstate == "Info")
                {
                    dataGridView1.DataSource = viewtable3;
                    textBox1.Enabled = true;
                    button1.Enabled = true;
                }
            }
            else
            {
                if (Form1.viewerstate == "Runout")
                {
                    DataColumn Name;
                    Name = new DataColumn();
                    Name.DataType = System.Type.GetType("System.String");
                    Name.AllowDBNull = false;
                    Name.ReadOnly = false;
                    Name.ColumnName = "Name";
                    viewtable.Columns.Add(Name);

                    DataColumn Barcode;
                    Barcode = new DataColumn();
                    Barcode.DataType = System.Type.GetType("System.String");
                    Barcode.AllowDBNull = false;
                    Barcode.ReadOnly = true;
                    Barcode.ColumnName = "Barcode";
                    viewtable.Columns.Add(Barcode);

                    DataColumn Quantity;
                    Quantity = new DataColumn();
                    Quantity.DataType = System.Type.GetType("System.String");
                    Quantity.AllowDBNull = true;
                    Quantity.ReadOnly = false;
                    Quantity.ColumnName = "Quantity";
                    viewtable.Columns.Add(Quantity);


                    dataGridView1.DataSource = viewtable;

                    foreach (DataRow dr in productdatabase.producttable.Rows)
                    {
                        string rowvalue = dr["Status"].ToString();
                        if (rowvalue == "runout")
                        {
                            string[] row = new string[3];
                            row[0] = dr[0].ToString();
                            row[1] = dr[1].ToString();
                            row[2] = dr[2].ToString();
                            viewtable.Rows.Add(row);
                        }
                    }
                    dataGridView1.Update();
                    dataGridView1.Refresh();
                }
                else if (Form1.viewerstate == "Expired")
                {
                    DataColumn Barcode;
                    Barcode = new DataColumn();
                    Barcode.DataType = System.Type.GetType("System.String");
                    Barcode.AllowDBNull = false;
                    Barcode.ReadOnly = true;
                    Barcode.ColumnName = "Barcode";
                    viewtable2.Columns.Add(Barcode);


                    DataColumn BoughtDate;
                    BoughtDate = new DataColumn();
                    BoughtDate.DataType = System.Type.GetType("System.String");
                    BoughtDate.AllowDBNull = false;
                    BoughtDate.ReadOnly = true;
                    BoughtDate.ColumnName = "BoughtDate";
                    viewtable2.Columns.Add(BoughtDate);

                    DataColumn ExpiryDate;
                    ExpiryDate = new DataColumn();
                    ExpiryDate.DataType = System.Type.GetType("System.String");
                    ExpiryDate.AllowDBNull = false;
                    ExpiryDate.ReadOnly = true;
                    ExpiryDate.ColumnName = "ExpiryDate";
                    viewtable2.Columns.Add(ExpiryDate);
                    
                    DataColumn shop;
                    shop = new DataColumn();
                    shop.DataType = System.Type.GetType("System.String");
                    shop.AllowDBNull = true;
                    shop.ReadOnly = false;
                    shop.ColumnName = "shop";
                    viewtable2.Columns.Add(shop);

                    DataColumn Location;
                    Location = new DataColumn();
                    Location.DataType = System.Type.GetType("System.String");
                    Location.AllowDBNull = true;
                    Location.ReadOnly = false;
                    Location.ColumnName = "Location";
                    viewtable2.Columns.Add(Location);

                    DataColumn Price;
                    Price = new DataColumn();
                    Price.DataType = System.Type.GetType("System.String");
                    Price.AllowDBNull = true;
                    Price.ReadOnly = false;
                    Price.ColumnName = "Price";
                    viewtable2.Columns.Add(Price);
                    dataGridView1.DataSource = viewtable2;

                    foreach(DataRow dr in fulldatabase.fulltable.Rows)
                    {
                        string rowvalue = dr["Status"].ToString();
                        if (rowvalue=="Expired")
                        {
                            string[] row=new string[6];
                            row[0] = dr[0].ToString();
                            row[1] = dr[1].ToString();
                            row[2] = dr[2].ToString();
                            row[3] = dr[3].ToString();
                            row[4] = dr[4].ToString();
                            row[5] = dr[5].ToString();
                            viewtable2.Rows.Add(row);
                        }
                    }
                }
                else if (Form1.viewerstate == "Info")
                {
                    DataColumn Name;
                    Name = new DataColumn();
                    Name.DataType = System.Type.GetType("System.String");
                    Name.AllowDBNull = false;
                    Name.ReadOnly = true;
                    Name.ColumnName = "Name";
                    viewtable3.Columns.Add(Name);


                    DataColumn Barcode;
                    Barcode = new DataColumn();
                    Barcode.DataType = System.Type.GetType("System.String");
                    Barcode.AllowDBNull = false;
                    Barcode.ReadOnly = true;
                    Barcode.ColumnName = "Barcode";
                    viewtable3.Columns.Add(Barcode);


                    DataColumn BoughtDate;
                    BoughtDate = new DataColumn();
                    BoughtDate.DataType = System.Type.GetType("System.String");
                    BoughtDate.AllowDBNull = false;
                    BoughtDate.ReadOnly = true;
                    BoughtDate.ColumnName = "BoughtDate";
                    viewtable3.Columns.Add(BoughtDate);

                    DataColumn ExpiryDate;
                    ExpiryDate = new DataColumn();
                    ExpiryDate.DataType = System.Type.GetType("System.String");
                    ExpiryDate.AllowDBNull = false;
                    ExpiryDate.ReadOnly = true;
                    ExpiryDate.ColumnName = "ExpiryDate";
                    viewtable3.Columns.Add(ExpiryDate);

                    DataColumn Status;
                    Status = new DataColumn();
                    Status.DataType = System.Type.GetType("System.String");
                    Status.AllowDBNull = true;
                    Status.ReadOnly = false;
                    Status.ColumnName = "Status";
                    viewtable3.Columns.Add(Status);

                    DataColumn shop;
                    shop = new DataColumn();
                    shop.DataType = System.Type.GetType("System.String");
                    shop.AllowDBNull = true;
                    shop.ReadOnly = false;
                    shop.ColumnName = "shop";
                    viewtable3.Columns.Add(shop);

                    DataColumn Location;
                    Location = new DataColumn();
                    Location.DataType = System.Type.GetType("System.String");
                    Location.AllowDBNull = true;
                    Location.ReadOnly = false;
                    Location.ColumnName = "Location";
                    viewtable3.Columns.Add(Location);

                    DataColumn Price;
                    Price = new DataColumn();
                    Price.DataType = System.Type.GetType("System.String");
                    Price.AllowDBNull = true;
                    Price.ReadOnly = false;
                    Price.ColumnName = "Price";
                    viewtable3.Columns.Add(Price);
                    dataGridView1.DataSource = viewtable3;
                    textBox1.Enabled = true;
                    button1.Enabled = true;
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text !="")
             {
                 viewtable3.Clear();
                foreach(DataRow dr in productdatabase.producttable.Rows)
                {
                    string a=dr[0].ToString();
                    string b =textBox1.Text;
                    bool x = a.Contains(b);
                    if (x==true)
                    {
                        foreach (DataRow dx in fulldatabase.fulltable.Rows)
                        {
                            string rowvalue = dx["Barcode"].ToString();
                            string rowvalue2 = dr["Barcode"].ToString();
                            if(rowvalue==rowvalue2)
                            {
                                string[]viewproduct = new string[8];
                                viewproduct[0] = a;
                                viewproduct[1] = rowvalue;
                                string boughtdate =dx["BoughtDate"].ToString();
                                string expirydate =dx["ExpiryDate"].ToString();
                                string status =dx["Status"].ToString();
                                string shop =dx["shop"].ToString();
                                string location=dx["Location"].ToString();
                                string price =dx["Price"].ToString();
                                viewproduct[2]=boughtdate;
                                viewproduct[3]=expirydate;
                                viewproduct[4]=status;
                                viewproduct[5]=shop;
                                viewproduct[6]=location;
                                viewproduct[7]=price;
                                viewtable3.Rows.Add(viewproduct);
                            }
                        }
                    }
                }
            }
        }

        private void viewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            viewtable.Reset();
            viewtable2.Reset();
            viewtable3.Reset();
        }
    }
}
