using FoodManagementsystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodManagmentsystem
{
    public partial class Deleteinfo : Form
    {
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private DataGridView deleteitem;
        private Button button2;
        public static DataTable deleteitems = new DataTable();
        public Deleteinfo()
        {
            InitializeComponent();
            deleteitem.DataSource = deleteitems;
            deleteitem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        
        private void oktodelete_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.deleteitem = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.deleteitem)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(370, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Barcode";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(585, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "display";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteitem
            // 
            this.deleteitem.AllowUserToAddRows = false;
            this.deleteitem.AllowUserToDeleteRows = false;
            this.deleteitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deleteitem.Location = new System.Drawing.Point(43, 90);
            this.deleteitem.MultiSelect = false;
            this.deleteitem.Name = "deleteitem";
            this.deleteitem.ReadOnly = true;
            this.deleteitem.Size = new System.Drawing.Size(889, 346);
            this.deleteitem.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(445, 488);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Delete";
            this.button2.UseMnemonic = false;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Deleteinfo
            // 
            this.ClientSize = new System.Drawing.Size(979, 653);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.deleteitem);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Deleteinfo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Deleteinfo_FormClosing);
            this.Load += new System.EventHandler(this.Deleteinfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deleteitem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in fulldatabase.fulltable.Rows)
            {
                string rowValue = dr["Barcode"].ToString();

                if (rowValue == textBox1.Text)
                {
                    string[] fullarray = new string[9];
                    foreach (DataRow dx in productdatabase.producttable.Rows)
                    {
                        string rowValue2 = dx["Barcode"].ToString();
                        if (rowValue2 == textBox1.Text)
                        {

                            fullarray[0] = dx["Name"].ToString();
                            break;
                        }
                    }
                    fullarray[1] = textBox1.Text;
                    fullarray[2] = dr["BoughtDate"].ToString();
                    fullarray[3] = dr["ExpiryDate"].ToString();
                    fullarray[4] = dr["shop"].ToString();
                    fullarray[5] = dr["Price"].ToString();
                    fullarray[6] = dr["Location"].ToString();
                    fullarray[7] = dr["Status"].ToString();
                    fullarray[8] = dr["position"].ToString();
                    deleteitems.Rows.Add(fullarray);
                }
            }
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string index = deleteitem.SelectedRows[0].Cells["position"].Value.ToString();
            int indexnum = Int32.Parse(index);
            string barcode = deleteitem.SelectedRows[0].Cells["Barcode"].Value.ToString();
            int value;
            foreach (DataRow dr in Form1.table.Rows)
            {
                if (barcode == dr["Barcode"].ToString())
                {
                    value = Convert.ToInt32(dr["Quantity"]);
                    value -= 1;
                    fulldatabase.fulltable.Rows.RemoveAt(indexnum);
                    Form1.table.Columns["Quantity"].ReadOnly = false;
                    dr["Quantity"] = value;
                    foreach (DataRow dx in productdatabase.producttable.Rows)
                    {
                        if (barcode == dx["Barcode"].ToString())
                        {
                            dr["Quantity"] = value;
                        }
                    }
                    Form1.table.Columns["Quantity"].ReadOnly = true;
                    Form1.statuscheck();
                    Close();
                    break;
                }
            }
        }

        private void Deleteinfo_Load(object sender, EventArgs e)
        {
            DataColumn Name;
            Name = new DataColumn();
            Name.DataType = System.Type.GetType("System.String");
            Name.AllowDBNull = false;
            Name.ReadOnly = true;
            Name.ColumnName = "Name";
            deleteitems.Columns.Add(Name);

            DataColumn Barcode;
            Barcode = new DataColumn();
            Barcode.DataType = System.Type.GetType("System.String");
            Barcode.AllowDBNull = false;
            Barcode.ReadOnly = true;
            Barcode.ColumnName = "Barcode";
            deleteitems.Columns.Add(Barcode);

            DataColumn BoughtDate;
            BoughtDate = new DataColumn();
            BoughtDate.DataType = System.Type.GetType("System.String");
            BoughtDate.AllowDBNull = false;
            BoughtDate.ReadOnly = true;
            BoughtDate.ColumnName = "BoughtDate";
            deleteitems.Columns.Add(BoughtDate);

            DataColumn ExpiryDate;
            ExpiryDate = new DataColumn();
            ExpiryDate.DataType = System.Type.GetType("System.String");
            ExpiryDate.AllowDBNull = false;
            ExpiryDate.ReadOnly = true;
            ExpiryDate.ColumnName = "ExpiryDate";
            deleteitems.Columns.Add(ExpiryDate);

            DataColumn Shop;
            Shop = new DataColumn();
            Shop.DataType = System.Type.GetType("System.String");
            Shop.AllowDBNull = false;
            Shop.ReadOnly = true;
            Shop.ColumnName = "Shop";
            deleteitems.Columns.Add(Shop);
           
            DataColumn Price;
            Price = new DataColumn();
            Price.DataType = System.Type.GetType("System.String");
            Price.AllowDBNull = false;
            Price.ReadOnly = true;
            Price.ColumnName = "Price";
            deleteitems.Columns.Add(Price);
            
            DataColumn Location;
            Location = new DataColumn();
            Location.DataType = System.Type.GetType("System.String");
            Location.AllowDBNull = false;
            Location.ReadOnly = true;
            Location.ColumnName = "Location";
            deleteitems.Columns.Add(Location);


            DataColumn Status;
            Status = new DataColumn();
            Status.DataType = System.Type.GetType("System.String");
            Status.AllowDBNull = false;
            Status.ReadOnly = false;
            Status.ColumnName = "Status";
            deleteitems.Columns.Add(Status);

            DataColumn position;
            position = new DataColumn();
            position.DataType = System.Type.GetType("System.String");
            position.AllowDBNull = false;
            position.ReadOnly = false;
            position.ColumnName = "position";
            deleteitems.Columns.Add(position);

            deleteitem.DataSource = deleteitems;



        }

        private void Deleteinfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            deleteitems.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button2_Click(sender, e);
            }
        }
            }
        }

