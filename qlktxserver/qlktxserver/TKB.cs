using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qlktxserver;

namespace qLKTX.Control_UI
{
    public partial class TKB : UserControl
    {
        public TKB()
        {
            InitializeComponent();
            LoadMatrix();
        }
        public List<List<Button>> Matrix;


        private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        private void First_Load(object sender, EventArgs e)
        {

        }
        int DayofMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if ((date.Year % 400 == 0) || (date.Year % 4 == 0 && date.Year % 100 != 0))
                        return 29;
                    else
                        return 28;
                default:
                    return 30;
            }
        }

        void LoadMatrix()
        {
            Matrix = new List<List<Button>>();
            Button Btn = new Button() { Height = 0, Width = 0, Location = new Point(-62, 0) };
            for (int i = 0; i < 6; i++)
            {
                // Matrix.Add(new List<Button>());
                Matrix.Add(new List<Button>());
                for (int j = 0; j < 7; j++)
                {
                    Button BtnNew = new Button() { Width = 62, Height = 30, Location = new Point(Btn.Location.X + 62, Btn.Location.Y) };
                    BtnNew.Click += BtnNew_Click;
                    BtnNew.BackColor = Color.Blue;
                    BtnNew.ForeColor = Color.Black;

                    panel1.Controls.Add(BtnNew);
                    Matrix[i].Add(BtnNew);
                    Btn = BtnNew;

                }
                Btn = new Button() { Height = 0, Width = 0, Location = new Point(-62, Btn.Location.Y + 30) };
            }

            SetDefaultDate();
            //  AddNumberintoMatrixbyDate(dateTimePicker1.Value);

        }

        void BtnNew_Click(object Sender, EventArgs e)
        {
            //   minh daily = new minh(new DateTime(dateTimePicker1.Value.Year,dateTimePicker1.Value.Month,Convert.ToInt32((Sender as Button).Text)),Job);
            //  panel3.Controls.Add(daily);
            //  daily.Show();
            Form2 m = new Form2(dateTimePicker1.Value);
            m.Show();
            //   daily.Show();
            //  panel3.Controls.Add(m);
            // panel3.Show();
            // MessageBox.Show("sdf");
        }

        void AddNumberintoMatrixbyDate(DateTime date)
        {
            ClearMatrix();
            DateTime useDate = new DateTime(date.Year, date.Month, 1);


            int Line = 0;
            for (int i = 1; i <= DayofMonth(date); i++)
            {
                int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
                Button BtnNew = Matrix[Line][column];
                BtnNew.Text = i.ToString();
                if (isEqualDate(useDate, DateTime.Now))
                {
                    BtnNew.BackColor = Color.Red;
                }
                if (isEqualDate(date, useDate))
                {
                    BtnNew.BackColor = Color.Yellow;
                }
                if (column >= 6)
                    Line++;

                useDate = useDate.AddDays(1);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            AddNumberintoMatrixbyDate((sender as DateTimePicker).Value);
        }
        void ClearMatrix()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    Button btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.Blue;
                    // btn.BackColor = Color.WhiteSmoke;
                }
            }
        }
        void SetDefaultDate()
        {
            dateTimePicker1.Value = DateTime.Now;
        }
        bool isEqualDate(DateTime dateA, DateTime dateB)
        {
            return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        }
        private void TKB_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
