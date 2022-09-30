
using GreenHouseEntityy.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesilEv.Common.Helper;
using YesilEv.Core.Context;
using YesilEv.DAL.Concrete;
using YesilEv.UI;
using YesilEv.Validation.Concrete;

namespace YesilEv.UI
{
    public partial class LoginPageForm : Form
    {
        UserDal userDal = new UserDal();
        public LoginPageForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterPageForm r = new RegisterPageForm();
            r.Show();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            txtEmail.Text = "eren.kinay@gmail.com";
            txtPass.Text = "123123";
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

            string HashedPassword = txtPass.Text.md5sifreleme();
            var result = userDal.Login(txtEmail.Text, HashedPassword);
            LoginValidator loginValidator = new LoginValidator(result);
            if (loginValidator.isValid)
            {
                HomePageForm hp = new HomePageForm();
                hp.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Girilen bilgiler yanlış");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RegisterPageForm registerPageForm = new RegisterPageForm();
            registerPageForm.Show();
            this.Hide();
        }
    }
}
