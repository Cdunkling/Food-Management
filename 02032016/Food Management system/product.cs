using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagmentsystem
{
    public class product
    {
        public string barcode;
        public string Name;
        public string Status;
        public string Boughtdate;
        public string Expirydate;
        public DateTime dtBoughtdate;
        public DateTime dtExpirydate;
        public string Index;
        public string minvalue;
        public string location;
        public string shop;
        public string price;
        public bool favourite;
        public bool notinoutpan;

        public void setbarcode(string sbarcode)
        {
            barcode=sbarcode;   
        }

        public void setname(string sname)
        {
            Name = sname;
        }

        public void setboughtdate(DateTime sboughtdate)
        {
            dtBoughtdate = sboughtdate.Date;
            Boughtdate = dtBoughtdate.ToString("d");
        }

        public void setexpirydate(DateTime sexpirydate)
        {
            dtExpirydate = sexpirydate.Date;
            Expirydate = dtExpirydate.ToString("d");
        }
        
        public void setstatus(string sstatus)
        {
            Status = sstatus;
        }
        public void setindex(int sindex)
        {
            Index = sindex.ToString();
        }
        
        public void setminvalue(int sminvalue)
        {
            minvalue = sminvalue.ToString();
        }

        public void setshop(string sshop)
        {
            shop = sshop;
        }
       
        public void setlocation(string slocation)
        {
            location = slocation;
        }
       
        public void setprice(double sprice)
        {
            price = "£"+sprice.ToString();
        }


    }
}
