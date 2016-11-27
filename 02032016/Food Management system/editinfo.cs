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
    public partial class Editinfo : Form
    {
        public Editinfo()
        {
            InitializeComponent();
            //fills in edit form if there is pre-existing data on the product
            BarcodeEditBox.Text = MainWindow.newproduct.barcode;
            NameEditBox.Text = MainWindow.newproduct.Name;
            linkLabel1.Text = DateTime.Today.ToString();

            foreach (DataRow dr in productdatabase.producttable.Rows)
            {
                string rowValue = dr["Barcode"].ToString();
                if (MainWindow.newproduct.barcode == rowValue)
                {
                    NameEditBox.Text = dr["Name"].ToString();
                    string minvalue = dr["MinQuantity"].ToString();
                    int minvalueval = Int32.Parse(minvalue);
                    minimumstockedit.Value = minvalueval;
                    string quantity = dr["Quantity"].ToString();
                    label6.Text = quantity;
                }
            }

            foreach (DataRow dr in stockdatabase.stocktable.Rows)
            {
                string rowValue = dr["Barcode"].ToString();
                if (MainWindow.newproduct.barcode == rowValue)
                {
                    comboBox1.Text = dr["Shop"].ToString();
                    comboBox2.Text = dr["Location"].ToString();
                    string price = dr["Price"].ToString();
                    string price2 = price.Remove(0, 1);
                    decimal priceval = decimal.Parse(price2);
                    priceeditbox.Value = priceval;
                }
            }

            foreach (DataRow dr in MainWindow.favouritestable.Rows)
            {
                string rowValue = dr["Barcode"].ToString();
                if (MainWindow.newproduct.barcode == rowValue)
                {
                    checkBox1.Checked = true;
                }
            }
        }
        //removes commas
        public string commaremover(string commastring)
        {
            commastring = commastring.Replace(",", " ");
            return commastring;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string expirystring = linkLabel2.Text;
            if (Noexpiry.Checked == false)
            {
                if (NameEditBox.Text == "")
                {
                    MessageBox.Show("There is no name entered!", "Warning");
                }

                else if (linkLabel2.Text == "choose date" || linkLabel2.Text == "01/01/0001 00:00:00")
                {
                    MessageBox.Show("There is an invalid expiry date entered!", "Warning");
                }
                else if (linkLabel1.Text == "01/01/0001 00:00:00")
                {
                    MessageBox.Show("There is an invalid bought date entered!", "Warning");
                }
                else
                {
                    DateTime dt = Convert.ToDateTime(expirystring);
                    if (dt < DateTime.Now)
                    {
                        DialogResult result = MessageBox.Show("Item has already expired! still add it?", "Warning", MessageBoxButtons.YesNo);
                        if (result == System.Windows.Forms.DialogResult.No)
                        {
                            Close();
                        }
                        else
                        {
                            AutoClosingMessageBox.Show("Product has been added", "Added Product", 1000);
                            MainWindow.newproduct.setbarcode(commaremover(BarcodeEditBox.Text));
                            MainWindow.newproduct.setname(commaremover(NameEditBox.Text));
                            MainWindow.newproduct.setboughtdate(Convert.ToDateTime(linkLabel1.Text));
                            MainWindow.newproduct.setexpirydate(Convert.ToDateTime(linkLabel2.Text));
                            MainWindow.newproduct.setindex(MainWindow.rows);
                            MainWindow.newproduct.setminvalue(Convert.ToInt32(minimumstockedit.Value));
                            MainWindow.newproduct.setprice(Convert.ToDouble(priceeditbox.Text));
                            MainWindow.newproduct.setlocation(comboBox2.Text);
                            MainWindow.newproduct.setshop(comboBox1.Text);
                            if (checkBox1.Checked == true)
                            {
                                MainWindow.newproduct.favourite = true;
                            }
                            else
                            {
                                MainWindow.newproduct.favourite = false;
                            }
                            MainWindow.updatetable();
                            Close();
                        }
                    }
                    else
                    {
                        AutoClosingMessageBox.Show("Product has been added", "Added Product", 1000);
                        MainWindow.newproduct.setbarcode(commaremover(BarcodeEditBox.Text));
                        MainWindow.newproduct.setname(commaremover(NameEditBox.Text));
                        MainWindow.newproduct.setboughtdate(Convert.ToDateTime(linkLabel1.Text));
                        MainWindow.newproduct.setexpirydate(Convert.ToDateTime(linkLabel2.Text));
                        MainWindow.newproduct.setindex(MainWindow.rows);
                        MainWindow.newproduct.setminvalue(Convert.ToInt32(minimumstockedit.Value));
                        MainWindow.newproduct.setprice(Convert.ToDouble(priceeditbox.Value));
                        MainWindow.newproduct.setlocation(comboBox2.Text);
                        MainWindow.newproduct.setshop(comboBox1.Text);
                        if (checkBox1.Checked == true)
                        {
                            MainWindow.newproduct.favourite = true;
                        }
                        else
                        {
                            MainWindow.newproduct.favourite = false;
                        }
                        MainWindow.updatetable();
                        MainWindow.statuscheck();
                        Close();
                    }
                }
            }
            else
            {
                if (NameEditBox.Text == "")
                {
                    MessageBox.Show("There is no name entered!", "Warning");
                }
                else if (linkLabel1.Text == "01/01/0001 00:00:00")
                {
                    MessageBox.Show("There is an invalid bought date entered!", "Warning");
                }
                else
                {
                    AutoClosingMessageBox.Show("Product has been added", "Added Product", 1000);
                    MainWindow.newproduct.setbarcode(commaremover(BarcodeEditBox.Text));
                    MainWindow.newproduct.setname(commaremover(NameEditBox.Text));
                    MainWindow.newproduct.setboughtdate(Convert.ToDateTime(linkLabel1.Text));
                    MainWindow.newproduct.setexpirydate(DateTime.Now.AddYears(1000));
                    MainWindow.newproduct.setindex(MainWindow.rows);
                    MainWindow.newproduct.setminvalue(Convert.ToInt32(minimumstockedit.Value));
                    MainWindow.newproduct.setprice(Convert.ToDouble(priceeditbox.Value));
                    MainWindow.newproduct.setlocation(comboBox2.Text);
                    MainWindow.newproduct.setshop(comboBox1.Text);
                    if (checkBox1.Checked == true)
                    {
                        MainWindow.newproduct.favourite = true;
                    }
                    else
                    {
                        MainWindow.newproduct.favourite = false;
                    }
                    MainWindow.updatetable();
                    MainWindow.statuscheck();
                    Close();
                }
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            calender calenderform = new calender();
            calenderform.ShowDialog();
                linkLabel1.Text = calenderform.getvalue();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            calender calenderform = new calender();
            calenderform.ShowDialog();
                linkLabel2.Text = calenderform.getvalue();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Noexpiry_CheckedChanged(object sender, EventArgs e)
        {
            if(Noexpiry.Checked==true)
            {
                linkLabel2.Enabled = false;
            }
            else
            {
                linkLabel2.Enabled = true;
            }
        }
    }
}