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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtoldpass.Text == String.Empty || txtnewpass.Text == String.Empty || txtretypepass.Text == String.Empty || txtname.Text == String.Empty)
            {
                MessageBox.Show("Please enter the areas");
            }
            else
            {
                BankingApplicationEntities db = new BankingApplicationEntities();
                var user = db.AdminTable.FirstOrDefault(a => a.UserName.Equals(txtname.Text));
                if(user != null)
                {
                    if (user.Password.Equals(txtoldpass.Text))
                    {
                        user.Password = txtnewpass.Text;
                        db.SaveChanges();
                        MessageBox.Show("Password Change Successfuly");
                    }
                    else
                    {
                        MessageBox.Show("Password Incorrect");
                    }
                }
            }
        }
    }
}
