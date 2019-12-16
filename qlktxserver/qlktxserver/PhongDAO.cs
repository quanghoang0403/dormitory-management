using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlktxserver
{
    public class PhongDAO
    {
        private static PhongDAO instance;

        public static PhongDAO Instance 
        {
            get { if (instance == null) instance = new PhongDAO(); return PhongDAO.instance;}
            private set { PhongDAO.instance = value; } 
        }

        public static int PhongWidth = 140;
        public static int PhongHeight = 140;
        private PhongDAO() { }

        public List<Phong> LoadPhongList()
        {
            List<Phong> phongList = new List<Phong>();
            DataTable data = DataProvider.Instance.ExecuteQuery("DBO.USP_PhongList");
            foreach (DataRow item in data.Rows)
            {
                Phong phong = new Phong(item);
                phongList.Add(phong);
            }
            return phongList;
        }
    }
}
