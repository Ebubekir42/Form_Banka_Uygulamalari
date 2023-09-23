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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BankingApplicationEntities db = new BankingApplicationEntities();
            
            if(textBox_userName.Text != string.Empty && textBox_password.Text != string.Empty)
            {
                var user = db.AdminTable.FirstOrDefault(a => a.UserName.Equals(textBox_userName.Text));
                if(user != null)
                {
                    if (user.Password.Equals(textBox_password.Text))
                    {
                        Menu menu = new Menu();
                        menu.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username And Password");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Username And Password");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Username And Password");
            }
        }
    }
}
