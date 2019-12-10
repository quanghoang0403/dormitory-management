using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlktxserver
{
    public class Phong
    {
        public Phong(int iD, string status)
        {
            this.ID = iD;
            this.Status = status;
        }

        public Phong(DataRow row)
        {
            this.ID = (int)row["MAPHG"];
            this.Status = row["TINHTRANG"].ToString();
        }
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
            }
        }
    }
}
