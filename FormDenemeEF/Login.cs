using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormDenemeEF
{
    public partial class Login : Form
    {
        formdenemeEntities db = new formdenemeEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            foreach (var User in db.Users)
            {
                if (User.UserName == txtUserName.Text && User.Password == txtPassword.Text)
                {
                    Main mainOpen = new Main();
                    mainOpen.Show();
                }
                else
                {
                    MessageBox.Show("Hatalı Ad ya da Şifre");
                }
            }
            

        }
    }
}