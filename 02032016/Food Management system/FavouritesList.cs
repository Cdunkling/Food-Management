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
    public partial class FavouritesList : Form
    {
        public static DataTable favouritestable = new DataTable();
        public FavouritesList()
        {
            InitializeComponent();
            
            DataColumn Name;
            Name = new DataColumn();
            Name.DataType = System.Type.GetType("System.String");
            Name.AllowDBNull = false;
            Name.ReadOnly = false;
            Name.ColumnName = "Name";
            favouritestable.Columns.Add(Name);

            DataColumn Barcode;
            Barcode = new DataColumn();
            Barcode.DataType = System.Type.GetType("System.String");
            Barcode.AllowDBNull = false;
            Barcode.ReadOnly = true;
            Barcode.ColumnName = "Barcode";
            favouritestable.Columns.Add(Barcode);

            DataColumn Quantity;
            Quantity = new DataColumn();
            Quantity.DataType = System.Type.GetType("System.String");
            Quantity.AllowDBNull = false;
            Quantity.ReadOnly = false;
            Quantity.ColumnName = "Quantity";
            favouritestable.Columns.Add(Quantity);

            DataColumn Lastprice;
            Lastprice = new DataColumn();
            Lastprice.DataType = System.Type.GetType("System.String");
            Lastprice.AllowDBNull = false;
            Lastprice.ReadOnly = false;
            Lastprice.ColumnName = "Last price";
            favouritestable.Columns.Add(Lastprice);

            DataColumn Shoplastboughtat;
            Shoplastboughtat = new DataColumn();
            Shoplastboughtat.DataType = System.Type.GetType("System.String");
            Shoplastboughtat.AllowDBNull = false;
            Shoplastboughtat.ReadOnly = false;
            Shoplastboughtat.ColumnName = "Shop last bought at";
            favouritestable.Columns.Add(Shoplastboughtat);
            favouriteback.DataSource = favouritestable;
        }

        private void deleteitem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
