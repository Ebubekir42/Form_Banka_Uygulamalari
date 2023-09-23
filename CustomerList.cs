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
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();
            getAllCustomer();
        }
        private void getAllCustomer()
        {
            dataGridView1.AutoGenerateColumns = false;
            BankingApplicationEntities db = new BankingApplicationEntities();
            var item = db.UserAccount.ToList();
            dataGridView1.DataSource = item;

        }
    }
}
