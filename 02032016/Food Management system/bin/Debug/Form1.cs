//================================================================================
//
//================================================================================

using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FoodManagementsystem;
using System.Collections.Specialized;

namespace FoodManagmentsystem
{
    public partial class MainWindow : Form
    {

        public static DataTable table = new DataTable(); //main table
        public static DataTable consumedtable = new DataTable(); //consumed table
        public static DataTable expiredtable = new DataTable();// expiredtable
        public static DataTable viewrunningouttable = new DataTable();// viewrunningouttable
        public static DataTable viewexpiringtable = new DataTable();// viewexpiringtable
        public static DataTable Searchtable = new DataTable();// searchtable
        public static product newproduct = new product();
        public static DataTable deleteitems = new DataTable();
        public static DataTable favouritestable = new DataTable();
        details detail = new details();
        string filename = "main.csv";
        public static int rows;
        public MainWindow()
        {
            InitializeComponent();
            {
                //decleration of columns
                DataColumn Name;
                Name = new DataColumn();
                Name.DataType = System.Type.GetType("System.String");
                Name.AllowDBNull = false;
                Name.ReadOnly = true;
                Name.ColumnName = "Name";
                table.Columns.Add(Name);

                DataColumn Barcode;
                Barcode = new DataColumn();
                Barcode.DataType = System.Type.GetType("System.String");
                Barcode.AllowDBNull = false;
                Barcode.ReadOnly = true;
                Barcode.ColumnName = "Barcode";
                table.Columns.Add(Barcode);

                DataColumn Quantity;
                Quantity = new DataColumn();
                Quantity.DataType = System.Type.GetType("System.String");
                Quantity.AllowDBNull = false;
                Quantity.ReadOnly = true;
                Quantity.ColumnName = "Quantity";
                table.Columns.Add(Quantity);

                DataColumn Lastprice;
                Lastprice = new DataColumn();
                Lastprice.DataType = System.Type.GetType("System.String");
                Lastprice.AllowDBNull = true;
                Lastprice.ReadOnly = true;
                Lastprice.ColumnName = "Last price";
                table.Columns.Add(Lastprice);

                DataColumn Shoplastboughtat;
                Shoplastboughtat = new DataColumn();
                Shoplastboughtat.DataType = System.Type.GetType("System.String");
                Shoplastboughtat.AllowDBNull = true;
                Shoplastboughtat.ReadOnly = true;
                Shoplastboughtat.ColumnName = "Shop last bought at";
                table.Columns.Add(Shoplastboughtat);

                DataColumn favourite;
                favourite = new DataColumn();
                favourite.DataType = System.Type.GetType("System.String");
                favourite.AllowDBNull = true;
                favourite.ReadOnly = true;
                favourite.ColumnName = "favourite";
                table.Columns.Add(favourite);

                DataColumn consumedName;
                consumedName = new DataColumn();
                consumedName.DataType = System.Type.GetType("System.String");
                consumedName.AllowDBNull = false;
                consumedName.ReadOnly = true;
                consumedName.ColumnName = "Name";
                consumedtable.Columns.Add(consumedName);


                DataColumn consumedQuantity;
                consumedQuantity = new DataColumn();
                consumedQuantity.DataType = System.Type.GetType("System.String");
                consumedQuantity.AllowDBNull = false;
                consumedQuantity.ReadOnly = true;
                consumedQuantity.ColumnName = "Quantity";
                consumedtable.Columns.Add(consumedQuantity);

                DataColumn expiredName;
                expiredName = new DataColumn();
                expiredName.DataType = System.Type.GetType("System.String");
                expiredName.AllowDBNull = false;
                expiredName.ReadOnly = true;
                expiredName.ColumnName = "Name";
                expiredtable.Columns.Add(expiredName);


                DataColumn expiredExpiryDate;
                expiredExpiryDate = new DataColumn();
                expiredExpiryDate.DataType = System.Type.GetType("System.String");
                expiredExpiryDate.AllowDBNull = false;
                expiredExpiryDate.ReadOnly = true;
                expiredExpiryDate.ColumnName = "Expiry Date";
                expiredtable.Columns.Add(expiredExpiryDate);


                DataColumn expiredLocation;
                expiredLocation = new DataColumn();
                expiredLocation.DataType = System.Type.GetType("System.String");
                expiredLocation.AllowDBNull = true;
                expiredLocation.ReadOnly = true;
                expiredLocation.ColumnName = "Location";
                expiredtable.Columns.Add(expiredLocation);

                DataColumn RunoutName;
                RunoutName = new DataColumn();
                RunoutName.DataType = System.Type.GetType("System.String");
                RunoutName.AllowDBNull = false;
                RunoutName.ReadOnly = true;
                RunoutName.ColumnName = "Name";
                viewrunningouttable.Columns.Add(RunoutName);

                DataColumn RunoutQuantity;
                RunoutQuantity = new DataColumn();
                RunoutQuantity.DataType = System.Type.GetType("System.String");
                RunoutQuantity.AllowDBNull = true;
                RunoutQuantity.ReadOnly = true;
                RunoutQuantity.ColumnName = "Quantity";
                viewrunningouttable.Columns.Add(RunoutQuantity);

                DataColumn fullexpiredname;
                fullexpiredname = new DataColumn();
                fullexpiredname.DataType = System.Type.GetType("System.String");
                fullexpiredname.AllowDBNull = false;
                fullexpiredname.ReadOnly = true;
                fullexpiredname.ColumnName = "name";
                viewexpiringtable.Columns.Add(fullexpiredname);

                DataColumn fullexpiredboughtdate;
                fullexpiredboughtdate = new DataColumn();
                fullexpiredboughtdate.DataType = System.Type.GetType("System.String");
                fullexpiredboughtdate.AllowDBNull = false;
                fullexpiredboughtdate.ReadOnly = true;
                fullexpiredboughtdate.ColumnName = "boughtdate";
                viewexpiringtable.Columns.Add(fullexpiredboughtdate);

                DataColumn fullexpiredexpirydate;
                fullexpiredexpirydate = new DataColumn();
                fullexpiredexpirydate.DataType = System.Type.GetType("System.String");
                fullexpiredexpirydate.AllowDBNull = false;
                fullexpiredexpirydate.ReadOnly = true;
                fullexpiredexpirydate.ColumnName = "expirydate";
                viewexpiringtable.Columns.Add(fullexpiredexpirydate);

                DataColumn fullexpiredshop;
                fullexpiredshop = new DataColumn();
                fullexpiredshop.DataType = System.Type.GetType("System.String");
                fullexpiredshop.AllowDBNull = true;
                fullexpiredshop.ReadOnly = true;
                fullexpiredshop.ColumnName = "shop";
                viewexpiringtable.Columns.Add(fullexpiredshop);


                DataColumn fullexpiredPrice;
                fullexpiredPrice = new DataColumn();
                fullexpiredPrice.DataType = System.Type.GetType("System.String");
                fullexpiredPrice.AllowDBNull = true;
                fullexpiredPrice.ReadOnly = true;
                fullexpiredPrice.ColumnName = "Price";
                viewexpiringtable.Columns.Add(fullexpiredPrice);


                DataColumn fullexpiredLocation;
                fullexpiredLocation = new DataColumn();
                fullexpiredLocation.DataType = System.Type.GetType("System.String");
                fullexpiredLocation.AllowDBNull = true;
                fullexpiredLocation.ReadOnly = true;
                fullexpiredLocation.ColumnName = "Location";
                viewexpiringtable.Columns.Add(fullexpiredLocation);


                DataColumn fullexpiredStatus;
                fullexpiredStatus = new DataColumn();
                fullexpiredStatus.DataType = System.Type.GetType("System.String");
                fullexpiredStatus.AllowDBNull = true;
                fullexpiredStatus.ReadOnly = true;
                fullexpiredStatus.ColumnName = "Status";
                viewexpiringtable.Columns.Add(fullexpiredStatus);

                DataColumn SearchName;
                SearchName = new DataColumn();
                SearchName.DataType = System.Type.GetType("System.String");
                SearchName.AllowDBNull = false;
                SearchName.ReadOnly = true;
                SearchName.ColumnName = "Name";
                Searchtable.Columns.Add(SearchName);


                DataColumn SearchBarcode;
                SearchBarcode = new DataColumn();
                SearchBarcode.DataType = System.Type.GetType("System.String");
                SearchBarcode.AllowDBNull = false;
                SearchBarcode.ReadOnly = true;
                SearchBarcode.ColumnName = "Barcode";
                Searchtable.Columns.Add(SearchBarcode);


                DataColumn SearchBoughtDate;
                SearchBoughtDate = new DataColumn();
                SearchBoughtDate.DataType = System.Type.GetType("System.String");
                SearchBoughtDate.AllowDBNull = false;
                SearchBoughtDate.ReadOnly = true;
                SearchBoughtDate.ColumnName = "BoughtDate";
                Searchtable.Columns.Add(SearchBoughtDate);

                DataColumn SearchExpiryDate;
                SearchExpiryDate = new DataColumn();
                SearchExpiryDate.DataType = System.Type.GetType("System.String");
                SearchExpiryDate.AllowDBNull = false;
                SearchExpiryDate.ReadOnly = true;
                SearchExpiryDate.ColumnName = "ExpiryDate";
                Searchtable.Columns.Add(SearchExpiryDate);

                DataColumn SearchStatus;
                SearchStatus = new DataColumn();
                SearchStatus.DataType = System.Type.GetType("System.String");
                SearchStatus.AllowDBNull = true;
                SearchStatus.ReadOnly = true;
                SearchStatus.ColumnName = "Status";
                Searchtable.Columns.Add(SearchStatus);

                DataColumn Searchshop;
                Searchshop = new DataColumn();
                Searchshop.DataType = System.Type.GetType("System.String");
                Searchshop.AllowDBNull = true;
                Searchshop.ReadOnly = true;
                Searchshop.ColumnName = "shop";
                Searchtable.Columns.Add(Searchshop);

                DataColumn SearchLocation;
                SearchLocation = new DataColumn();
                SearchLocation.DataType = System.Type.GetType("System.String");
                SearchLocation.AllowDBNull = true;
                SearchLocation.ReadOnly = true;
                SearchLocation.ColumnName = "Location";
                Searchtable.Columns.Add(SearchLocation);

                DataColumn SearchPrice;
                SearchPrice = new DataColumn();
                SearchPrice.DataType = System.Type.GetType("System.String");
                SearchPrice.AllowDBNull = true;
                SearchPrice.ReadOnly = true;
                SearchPrice.ColumnName = "Price";
                Searchtable.Columns.Add(SearchPrice);
                searchgrid.DataSource = Searchtable;


                DataColumn DeleteName;
                DeleteName = new DataColumn();
                DeleteName.DataType = System.Type.GetType("System.String");
                DeleteName.AllowDBNull = false;
                DeleteName.ReadOnly = true;
                DeleteName.ColumnName = "Name";
                deleteitems.Columns.Add(DeleteName);

                DataColumn DeleteBarcode;
                DeleteBarcode = new DataColumn();
                DeleteBarcode.DataType = System.Type.GetType("System.String");
                DeleteBarcode.AllowDBNull = false;
                DeleteBarcode.ReadOnly = true;
                DeleteBarcode.ColumnName = "Barcode";
                deleteitems.Columns.Add(DeleteBarcode);


                DataColumn DeleteBoughtDate;
                DeleteBoughtDate = new DataColumn();
                DeleteBoughtDate.DataType = System.Type.GetType("System.String");
                DeleteBoughtDate.AllowDBNull = false;
                DeleteBoughtDate.ReadOnly = true;
                DeleteBoughtDate.ColumnName = "BoughtDate";
                deleteitems.Columns.Add(DeleteBoughtDate);

                DataColumn DeleteExpiryDate;
                DeleteExpiryDate = new DataColumn();
                DeleteExpiryDate.DataType = System.Type.GetType("System.String");
                DeleteExpiryDate.AllowDBNull = false;
                DeleteExpiryDate.ReadOnly = true;
                DeleteExpiryDate.ColumnName = "ExpiryDate";
                deleteitems.Columns.Add(DeleteExpiryDate);



                DataColumn Deleteshop;
                Deleteshop = new DataColumn();
                Deleteshop.DataType = System.Type.GetType("System.String");
                Deleteshop.AllowDBNull = true;
                Deleteshop.ReadOnly = true;
                Deleteshop.ColumnName = "shop";
                deleteitems.Columns.Add(Deleteshop);

                DataColumn DeletePrice;
                DeletePrice = new DataColumn();
                DeletePrice.DataType = System.Type.GetType("System.String");
                DeletePrice.AllowDBNull = true;
                DeletePrice.ReadOnly = true;
                DeletePrice.ColumnName = "Price";
                deleteitems.Columns.Add(DeletePrice);

                DataColumn DeleteLocation;
                DeleteLocation = new DataColumn();
                DeleteLocation.DataType = System.Type.GetType("System.String");
                DeleteLocation.AllowDBNull = true;
                DeleteLocation.ReadOnly = true;
                DeleteLocation.ColumnName = "Location";
                deleteitems.Columns.Add(DeleteLocation);


                DataColumn DeleteStatus;
                DeleteStatus = new DataColumn();
                DeleteStatus.DataType = System.Type.GetType("System.String");
                DeleteStatus.AllowDBNull = true;
                DeleteStatus.ReadOnly = true;
                DeleteStatus.ColumnName = "Status";
                deleteitems.Columns.Add(DeleteStatus);

                DataColumn Deleteposition;
                Deleteposition = new DataColumn();
                Deleteposition.DataType = System.Type.GetType("System.String");
                Deleteposition.AllowDBNull = true;
                Deleteposition.ReadOnly = true;
                Deleteposition.ColumnName = "position";
                deleteitems.Columns.Add(Deleteposition);

                DataColumn FavouriteName;
                FavouriteName = new DataColumn();
                FavouriteName.DataType = System.Type.GetType("System.String");
                FavouriteName.AllowDBNull = false;
                FavouriteName.ReadOnly = true;
                FavouriteName.ColumnName = "Name";
                favouritestable.Columns.Add(FavouriteName);

                DataColumn FavouriteBarcode;
                FavouriteBarcode = new DataColumn();
                FavouriteBarcode.DataType = System.Type.GetType("System.String");
                FavouriteBarcode.AllowDBNull = false;
                FavouriteBarcode.ReadOnly = true;
                FavouriteBarcode.ColumnName = "Barcode";
                favouritestable.Columns.Add(FavouriteBarcode);

                DataColumn FavouriteQuantity;
                FavouriteQuantity = new DataColumn();
                FavouriteQuantity.DataType = System.Type.GetType("System.String");
                FavouriteQuantity.AllowDBNull = false;
                FavouriteQuantity.ReadOnly = true;
                FavouriteQuantity.ColumnName = "Quantity";
                favouritestable.Columns.Add(FavouriteQuantity);

                DataColumn FavouriteLastprice;
                FavouriteLastprice = new DataColumn();
                FavouriteLastprice.DataType = System.Type.GetType("System.String");
                FavouriteLastprice.AllowDBNull = true;
                FavouriteLastprice.ReadOnly = true;
                FavouriteLastprice.ColumnName = "Last price";
                favouritestable.Columns.Add(FavouriteLastprice);

                DataColumn FavouriteShoplastboughtat;
                FavouriteShoplastboughtat = new DataColumn();
                FavouriteShoplastboughtat.DataType = System.Type.GetType("System.String");
                FavouriteShoplastboughtat.AllowDBNull = true;
                FavouriteShoplastboughtat.ReadOnly = true;
                FavouriteShoplastboughtat.ColumnName = "Shop last bought at";
                favouritestable.Columns.Add(FavouriteShoplastboughtat);
                favouriteview.DataSource = favouritestable;

                fullexpiredview.DataSource = viewexpiringtable;
                fullrunoutview.DataSource = viewrunningouttable;
                ConsumedItems.DataSource = consumedtable; // sets the datagridview to show table
                RecentlyExpired.DataSource = expiredtable;
                deleteitem.DataSource = deleteitems;
                deleteitem.Columns["position"].Visible = false;


                //data from csv file inserted into table                
                try
                {
                    var lines = File.ReadLines(filename);
                    string[] values = new string[5];
                    foreach (var line in lines)
                    {
                        values = line.Split(',').ToArray();
                        table.Rows.Add(values);
                        rows++;
                    }
                }
                catch (FileNotFoundException ex)
                {
                    File.Create("main.csv");
                }

                dataGridView1.DataSource = table;
                dataGridView1.Columns[5].Visible = false; //hides position column


                productdatabase frm = new productdatabase(); //creates the product database form to house the table

                stockdatabase frm2 = new stockdatabase();//creates the stock database form to house the table
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //user can only select rows not cells
                dataGridView1.AllowUserToDeleteRows = false;//user is unable to delete rows

                //adding products to favourites if the favourites flag is true
                foreach (DataRow dr in table.Rows)
                {
                    if (dr["favourite"].ToString() == "True")
                    {
                        string[] row = new string[5];
                        row[0] = dr[0].ToString();
                        row[1] = dr[1].ToString();
                        row[2] = dr[2].ToString();
                        row[3] = dr[3].ToString();
                        row[4] = dr[4].ToString();
                        favouritestable.Rows.Add(row);
                    }
                }


                statuscheck();


            }
        }

        public static void statuscheck()
        {
            consumedtable.Clear();
            viewexpiringtable.Clear();
            viewrunningouttable.Clear();
            expiredtable.Clear();

            if (productdatabase.producttable.Rows.Count != 0)
            {
                foreach (DataRow dr in productdatabase.producttable.Rows)
                {
                    Int32 Quantity;
                    Int32 minvalue;
                    string rowvalue = dr["Quantity"].ToString();
                    Quantity = Int32.Parse(rowvalue);
                    string rowvaluemin = dr["minquantity"].ToString();
                    minvalue = Int32.Parse(rowvaluemin);
                    // check if the remaining quantity is less than the user defined minimum value
                    if (Quantity == 0)
                    {
                        if (minvalue > -1)
                        {
                            dr["Status"] = "Runout";
                        }
                    }
                    else if (Quantity < minvalue)
                    {
                        dr["Status"] = "Running out";
                    }
                    else if (Quantity > minvalue)
                    {
                        dr["Status"] = "";
                    }
                    string rowValue = dr["status"].ToString();
                    // if the status of a row is listed as runout then it is added to the runningout/consumed table
                    if (rowValue == "Runout")
                    {
                        string[] row = new string[2];
                        row[0] = dr["Name"].ToString();
                        row[1] = dr["Quantity"].ToString();
                        viewrunningouttable.Rows.Add(row);
                        consumedtable.Rows.Add(row);
                    }
                    if (rowValue == "Running out")
                    {
                        string[] row = new string[2];
                        row[0] = dr["Name"].ToString();
                        row[1] = dr["Quantity"].ToString();
                        viewrunningouttable.Rows.Add(row);
                    }


                }
                int i = 0;
                foreach (DataRow dr in stockdatabase.stocktable.Rows)
                {
                    dr["position"] = i;
                    string rowValue2 = dr["expirydate"].ToString();
                    DateTime ExpiryValue = DateTime.Parse(rowValue2);
                    string rowValue3 = dr["BoughtDate"].ToString();
                    DateTime BoughtValue = DateTime.Parse(rowValue3);
                    var Boughtdate = BoughtValue.Date.AddDays(7);
                    var dateAndTime = DateTime.Now;
                    var date = dateAndTime.Date;
                    var expirydate = ExpiryValue.Date;
                    i++;
                    if (date > expirydate)//checks that the current date is not past the expiry date of the product
                    {
                        dr["Status"] = "Expired";
                    }
                    else if (date > expirydate.AddDays(-7))//checks if the product expires in 7 days and marks as expiring 
                    {
                        dr["Status"] = "Expiring";
                    }
                    else
                    {
                        dr["Status"] = "";
                    }
                    string rowValue = dr["status"].ToString();
                    string name = "";
                    foreach (DataRow dx in table.Rows)
                    {
                        if (dr["barcode"].ToString() == dx["barcode"].ToString())
                        {
                            name = dx["Name"].ToString();
                            break;
                        }
                    }
                    //if the status is marked as expired adds to the expired and expiringtable 
                    if (rowValue == "Expired")
                    {
                        string one = name;
                        string two = dr["Boughtdate"].ToString();
                        string three = dr["expirydate"].ToString();
                        string four = dr["shop"].ToString();
                        string five = dr["Price"].ToString();
                        string six = dr["Location"].ToString();
                        string seven = dr["Status"].ToString();
                        expiredtable.Rows.Add(one, two, six);
                        viewexpiringtable.Rows.Add(one, two, three, four, five, six, seven);
                    }
                    //if the status is marked as expiring adds to the expiringtable
                    if (rowValue == "Expiring")
                    {
                        string one = name;
                        string two = dr["Boughtdate"].ToString();
                        string three = dr["expirydate"].ToString();
                        string four = dr["shop"].ToString();
                        string five = dr["Price"].ToString();
                        string six = dr["Location"].ToString();
                        string seven = dr["Status"].ToString();
                        viewexpiringtable.Rows.Add(one, two, three, four, five, six, seven);
                    }
                }
                foreach (DataRow dr in table.Rows)
                {
                    favouritestable.Clear();
                    if (dr["favourite"].ToString() == "True")
                    {
                        string[] row = new string[5];
                        row[0] = dr[0].ToString();
                        row[1] = dr[1].ToString();
                        row[2] = dr[2].ToString();
                        row[3] = dr[3].ToString();
                        row[4] = dr[4].ToString();
                        favouritestable.Rows.Add(row);
                    }
                }
                foreach (DataRow dr in productdatabase.producttable.Rows)
                {
                    Int32 Quantity;
                    Int32 minvalue;
                    string rowvalue = dr["Quantity"].ToString();
                    Quantity = Int32.Parse(rowvalue);
                    string rowvaluemin = dr["minquantity"].ToString();
                    minvalue = Int32.Parse(rowvaluemin);
                    if (Quantity == 0)
                    {
                        if (minvalue == -1)
                        {
                                foreach (DataRow dpr in table.Rows)
                                {
                                    if (dr["barcode"] == dpr["barcode"])
                                    {
                                        dpr.Delete();

                                    }
                                if (table.Rows.Count == 0) { break; }
                            }
                                dr.Delete();
                                if (productdatabase.producttable.Rows.Count==0){ break; }

                        }
                    }
                }
            }
        }
        string input;

        public void oktoscan_Click(object sender, EventArgs e)
        {

            if (nobarcode.Checked == true)// checks if the user has ticked the box to say that product has no barcode
            {
                newproduct.notinoutpan = false;
                if (barcodeinput.Text != "")//check that input box is not empty
                {
                    input = barcodeinput.Text;
                    newproduct.setbarcode(input);
                    newproduct.setname(input);
                    newproduct.setboughtdate(DateTime.Today);
                    newproduct.setstatus("Just Added");
                    barcodeinput.Clear();
                    Editinfo frm = new Editinfo();//open editform
                    frm.ShowDialog();
                }
            }
            else
            {
                if (barcodeinput.Text != "")
                {
                    input = barcodeinput.Text;
                    //As most barcodes follow EAN13 they have 13 digits. This block of code adds heading 0s to the entered barcode to match it to the format on Outpan
                    if (input.Length < 13)
                    {
                        for (int x = input.Length; x < 13; x++)
                        {
                            input = "0" + input;
                        }
                    }
                    string link = "https://api.outpan.com/v2/products/" + input + "?apikey=c96c011b6746445555dd5614d1572114";
                    var request = HttpWebRequest.Create(link);//request sent to Outpan with the barcode
                    string str3 = "";
                    try
                    {
                        var response = request.GetResponse();
                        Stream dataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(dataStream);
                        string responseFromServer = reader.ReadToEnd();
                        //splits up the string to get the name of the product
                        int first = responseFromServer.IndexOf("\"name\": \"") + "\"name\": \"".Length;
                        string str2 = responseFromServer.Substring(first);
                        int last = str2.IndexOf("\",\n");
                        str3 = str2.Substring(0, last);
                        if (str3.StartsWith("tin"))//if the string starts with "tin" this indicates that there is no details in outpans database.
                        {
                            str3 = "";
                            newproduct.setbarcode(input);
                            newproduct.setname(str3);
                            newproduct.setboughtdate(DateTime.Now);
                            newproduct.setstatus("");
                            newproduct.notinoutpan=true;
                            reader.Close();
                            dataStream.Close();
                            response.Close();
                            barcodeinput.Clear();
                            Editinfo frm = new Editinfo();
                            frm.ShowDialog();

                        }

                        else
                        {
                            newproduct.setbarcode(input);
                            newproduct.setname(str3);
                            newproduct.setboughtdate(DateTime.Now);
                            newproduct.setstatus("");
                            newproduct.notinoutpan = false;
                            barcodeinput.Clear();
                            Editinfo frm = new Editinfo();
                            frm.ShowDialog();
                        }


                    }
                    catch (WebException ex)
                    {
                        if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                        {
                            var resp = (HttpWebResponse)ex.Response;
                            if (resp.StatusCode == HttpStatusCode.BadRequest) // HTTP 404
                            {
                                MessageBox.Show("Invalid Barcode!", "Warning");
                                barcodeinput.Clear();
                            }
                        }
                    }
                }
            }
        }

        public static void updatetable()
        {
            string price;
            if (newproduct.notinoutpan == true)
            {
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    values["name"] = "name";
                    values["value"] = newproduct.Name;
                    var response = client.UploadValues("https://api.outpan.com/v2/products/" + newproduct.barcode + "/attribute?apikey=c96c011b6746445555dd5614d1572114", values);
                    var responseString = Encoding.Default.GetString(response);
                    values["name"] = newproduct.Name;
                    var response2 = client.UploadValues("https://api.outpan.com/v2/products/"+newproduct.barcode+"/name?apikey=c96c011b6746445555dd5614d1572114", values);
                    var responseString2 = Encoding.Default.GetString(response);
                }
            }
            if (newproduct.price == "£0")
            {
                price = "";
            }
            else
            {
                price = newproduct.price;
            }
           string bought = newproduct.Boughtdate;
            string expired = newproduct.Expirydate;
            int number =1;
            //adds up stock to get quantity
            foreach (DataRow dr in stockdatabase.stocktable.Rows)
            {
                string rowValue = dr["Barcode"].ToString();
                if (newproduct.barcode == rowValue)
                {
                    number++;
                }
            }
            // if number is one it is a new product and adds details to the system in the main, product and stock database
            if (number == 1)
            {
                stockdatabase.stocktable.Rows.Add(newproduct.barcode, bought, expired, "", newproduct.shop, newproduct.location, price, 1);
                productdatabase.producttable.Rows.Add(newproduct.Name, newproduct.barcode, number, newproduct.minvalue, "");
                table.Rows.Add(newproduct.Name, newproduct.barcode, number, price, newproduct.shop, newproduct.favourite);
                if (newproduct.favourite == true)
                {
                    favouritestable.Rows.Add(newproduct.Name, newproduct.barcode, number, price, newproduct.shop);
                }
            }
                //otherwise the details on the system are updated to match the new user details
            else
            {
                stockdatabase.stocktable.Rows.Add(newproduct.barcode, bought, expired, "", newproduct.shop, newproduct.location, price, 1);
                foreach (DataRow dr in productdatabase.producttable.Rows)
                {
                    string rowValue = dr["Barcode"].ToString();
                    if (newproduct.barcode == rowValue)
                    {
                        productdatabase.producttable.Columns["quantity"].ReadOnly = false;
                        dr["quantity"] = number;
                        dr["Name"] = newproduct.Name;
                        dr["minquantity"] = newproduct.minvalue;
                    }

                }

                foreach (DataRow dr in table.Rows)
                {
                    string rowValue = dr["Barcode"].ToString();
                    if (newproduct.barcode == rowValue)
                    {
                        table.Columns["Name"].ReadOnly = false;
                        table.Columns["quantity"].ReadOnly = false;
                        table.Columns["Last Price"].ReadOnly = false;
                        table.Columns["Shop last bought at"].ReadOnly = false;
                        table.Columns["favourite"].ReadOnly = false;
                        dr["Name"] = newproduct.Name;
                        dr["quantity"] = number;
                        dr["Last Price"] = price;
                        dr["Shop last bought at"] = newproduct.shop;
                        dr["favourite"] = newproduct.favourite;
                        table.Columns["Name"].ReadOnly = true;
                        table.Columns["quantity"].ReadOnly = true;
                        table.Columns["Last Price"].ReadOnly = true;
                        table.Columns["Shop last bought at"].ReadOnly = true;
                        table.Columns["favourite"].ReadOnly = true;


                    }
                }

                foreach (DataRow dr in favouritestable.Rows)
                {
                    string rowValue = dr["Barcode"].ToString();
                    if (newproduct.barcode == rowValue)
                    {
                        favouritestable.Columns["Name"].ReadOnly = false;
                        favouritestable.Columns["quantity"].ReadOnly = false;
                        favouritestable.Columns["Last Price"].ReadOnly = false;
                        favouritestable.Columns["Shop last bought at"].ReadOnly = false;
                        dr["Name"] = newproduct.Name;
                        dr["quantity"] = number;
                        dr["Last Price"] = price;
                        dr["Shop last bought at"] = newproduct.shop;
                        favouritestable.Columns["Name"].ReadOnly = true;
                        favouritestable.Columns["quantity"].ReadOnly = true;
                        favouritestable.Columns["Last Price"].ReadOnly = true;
                        favouritestable.Columns["Shop last bought at"].ReadOnly = true;

                    }

                }
            }
            
            statuscheck();
        }

        // this writes all the data from the tables to CSV files
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var csv = new StringBuilder();
            var csv2 = new StringBuilder();
            var csv3 = new StringBuilder();

            foreach (DataRow dr in table.Rows)
            {
                var first = dr[0];
                var second = dr[1];
                var third = dr[2];
                var four = dr[3];
                var five = dr[4];
                var six = dr[5];
                var newLine = string.Format("{0},{1},{2},{3},{4},{5}", first, second, third, four, five, six);
                csv.AppendLine(newLine);
            }
            File.WriteAllText(filename, csv.ToString());

            foreach (DataRow dr in stockdatabase.stocktable.Rows)
            {
                var first = dr[0];
                var second = dr[1];
                var third = dr[2];
                var four = dr[3];
                var five = dr[4];
                var six = dr[5];
                var seven = dr[6];
                var eight = dr[7];
                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", first, second, third, four, five, six, seven, eight);
                csv2.AppendLine(newLine);
            }
            File.WriteAllText("stock.csv", csv2.ToString());

            foreach (DataRow dr in productdatabase.producttable.Rows)
            {
                var first = dr[0];
                var second = dr[1];
                var third = dr[2];
                var four = dr[3];
                var five = dr[4];
                var newLine = string.Format("{0},{1},{2},{3},{4}", first, second, third, four, five);
                csv3.AppendLine(newLine);
            }
            File.WriteAllText("product.csv", csv3.ToString());
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width + 5, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void printbutton_Click(object sender, EventArgs e)
        {


            if (tabcollection.SelectedIndex == 0)
            {
                printDocument2.Print();
                printDocument3.Print();
            }

            if (tabcollection.SelectedIndex == 1)
            {
                printDocument1.Print();
            }

            // these tabs have no tables or in the case of the delete tab there is no reason to print that table
            if (tabcollection.SelectedIndex == 2)
            {
                MessageBox.Show("There is nothing too print", "Warning");
            }

            if (tabcollection.SelectedIndex == 3)
            {
                MessageBox.Show("There is nothing too print", "Warning");
            }

            if (tabcollection.SelectedIndex == 4)
            {
                printDocument4.Print();
            }

            if (tabcollection.SelectedIndex == 5)
            {
                printDocument5.Print();
            }
            if (tabcollection.SelectedIndex == 6)
            {
                printDocument6.Print();
            }

        }
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.ConsumedItems.Width, this.ConsumedItems.Height);
            ConsumedItems.DrawToBitmap(bm, new Rectangle(0, 0, this.ConsumedItems.Width + 5, this.ConsumedItems.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.RecentlyExpired.Width, this.RecentlyExpired.Height);
            RecentlyExpired.DrawToBitmap(bm, new Rectangle(0, 0, this.RecentlyExpired.Width + 5, this.RecentlyExpired.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void barcodeinput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                oktoscan_Click(sender, e);
            }
        }
        // find products that matches the barcode and adds to delete table
        private void button4_Click(object sender, EventArgs e)
        {
            deleteitems.Clear();
            input = textBox1.Text;
            if (input.Length < 13)
            {
                for (int x = input.Length; x < 13; x++)
                {
                    input = "0" + input;
                }
            }

            foreach (DataRow dr in stockdatabase.stocktable.Rows)
            {
                string rowValue = dr["Barcode"].ToString();

                if (rowValue == input)
                {
                    string[] fullarray = new string[9];
                    foreach (DataRow dx in productdatabase.producttable.Rows)
                    {
                        string rowValue2 = dx["Barcode"].ToString();
                        if (rowValue2 == input)
                        {

                            fullarray[0] = dx["Name"].ToString();
                            break;
                        }
                    }
                    fullarray[1] = textBox1.Text;
                    fullarray[2] = dr["BoughtDate"].ToString();
                    fullarray[3] = dr["expirydate"].ToString();
                    fullarray[4] = dr["shop"].ToString();
                    fullarray[5] = dr["Price"].ToString();
                    fullarray[6] = dr["Location"].ToString();
                    fullarray[7] = dr["Status"].ToString();
                    fullarray[8] = dr["position"].ToString();
                    deleteitems.Rows.Add(fullarray);
                }
            }
            if (deleteitems.Rows.Count == 0)
            {
                MessageBox.Show("The barcode returned no results.");
            }
            else
            {
                deletebutton.Enabled = true;
                cancelbutton.Enabled = true;
            }
        }
        // uses details from selected row to decrease the quantity
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for(int i=0;i<deleteitem.SelectedRows.Count;i++)
                {
                    string index = deleteitem.SelectedRows[i].Cells["position"].Value.ToString();
                    int indexnum = Int32.Parse(index);
                    string barcode = deleteitem.SelectedRows[i].Cells["Barcode"].Value.ToString();
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
                            deleteitems.Clear();
                            textBox1.Clear();
                            break;
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("select a row");
            }
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button4_Click(sender, e);
            }
        }
        //uses search term to see if it is in each of the names of the items and returns suggestions
        private void button5_Click(object sender, EventArgs e)
        {
            if (searchbox.Text != "")
            {
                Searchtable.Clear();
                foreach (DataRow dr in productdatabase.producttable.Rows)
                {
                    string a = dr[0].ToString().ToLower();
                    string b = searchbox.Text.ToLower();
                    bool x = a.Contains(b);
                    if (x == true)
                    {
                        foreach (DataRow dx in stockdatabase.stocktable.Rows)
                        {
                            string rowvalue = dx["Barcode"].ToString();
                            string rowvalue2 = dr["Barcode"].ToString();
                            if (rowvalue == rowvalue2)
                            {
                                string[] viewproduct = new string[8];
                                viewproduct[0] = a;
                                viewproduct[1] = rowvalue;
                                string boughtdate = dx["BoughtDate"].ToString();
                                string expirydate = dx["ExpiryDate"].ToString();
                                string status = dx["Status"].ToString();
                                string shop = dx["shop"].ToString();
                                string location = dx["Location"].ToString();
                                string price = dx["Price"].ToString();
                                viewproduct[2] = boughtdate;
                                viewproduct[3] = expirydate;
                                viewproduct[4] = status;
                                viewproduct[5] = shop;
                                viewproduct[6] = location;
                                viewproduct[7] = price;
                                Searchtable.Rows.Add(viewproduct);
                            }



                        }
                    }
                }
            }
            if (Searchtable.Rows.Count == 0)
            {
                MessageBox.Show("The search returned no results.");
            }
            else
            {
            }
        }

        private void printDocument4_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.fullexpiredview.Width, this.fullexpiredview.Height);
            fullexpiredview.DrawToBitmap(bm, new Rectangle(0, 0, this.fullexpiredview.Width + 5, this.fullexpiredview.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void printDocument5_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.fullrunoutview.Width, this.fullrunoutview.Height);
            fullrunoutview.DrawToBitmap(bm, new Rectangle(0, 0, this.fullrunoutview.Width + 5, this.fullrunoutview.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void printDocument6_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.searchgrid.Width, this.searchgrid.Height);
            searchgrid.DrawToBitmap(bm, new Rectangle(0, 0, this.searchgrid.Width + 5, this.searchgrid.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            deleteitems.Clear();
            deletebutton.Enabled = false;
        }

        //when space is pressed all instances of that item is displayed in a details window
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                detail.Show();
                string barcode = dataGridView1.SelectedRows[0].Cells["Barcode"].Value.ToString();
                string rowValue2;
                foreach (DataRow dr in stockdatabase.stocktable.Rows)
                {
                    string rowValue = dr["Barcode"].ToString();

                    if (rowValue == barcode)
                    {
                        string[] fullarray = new string[9];
                        foreach (DataRow dx in productdatabase.producttable.Rows)
                        {
                            rowValue2 = dx["Barcode"].ToString();
                            if (rowValue2 == rowValue)
                            {

                                fullarray[0] = dx["Name"].ToString();
                                break;
                            }
                        }
                        fullarray[1] = rowValue;
                        fullarray[2] = dr["BoughtDate"].ToString();
                        fullarray[3] = dr["expirydate"].ToString();
                        fullarray[4] = dr["shop"].ToString();
                        fullarray[5] = dr["Price"].ToString();
                        fullarray[6] = dr["Location"].ToString();
                        fullarray[7] = dr["Status"].ToString();
                        fullarray[8] = dr["position"].ToString();
                        details.detailstable.Rows.Add(fullarray);
                    }
                }
            }
        }
}
}