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
    public partial class calender : Form
    {
        DateTime value;
        public calender()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            value = monthCalendar1.SelectionStart;
            value = value.Date;
        }

        public string getvalue()
    {
        return value.ToString();

    }

    }
}
