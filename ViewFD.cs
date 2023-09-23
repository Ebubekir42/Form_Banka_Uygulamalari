using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingApplication
{
    public partial class ViewFD : Form
    {
        public ViewFD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindingList<FD> bi = new BindingList<FD>();
            BankingApplicationEntities db = new BankingApplicationEntities();
            string date_ = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            MessageBox.Show(date_);
            var items = db.FD;
            foreach(var item in items)
            {
                if (item.StartDate.Value.ToString("dd/MM/yyyy").Equals(date_))
                {
                    bi.Add(item);
                }
            }
            dataGridView1.DataSource = bi;
        }
    }
}
