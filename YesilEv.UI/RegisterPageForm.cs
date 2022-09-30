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
using YesilEv.DAL.Abstract;
using YesilEv.DAL.Concrete;
using YesilEv.Validation.Concrete;

namespace YesilEv.UI
{
    public partial class RegisterPageForm : Form
    {
        public RegisterPageForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPageForm lp = new LoginPageForm();
            lp.Show();


        }

        private void RegisterPageForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RegisterDTO registerDTO = new RegisterDTO();
            registerDTO.Email = txtEmail.Text;
            registerDTO.Password = txtPass.Text;
            registerDTO.Name = textName.Text;
            registerDTO.Surname = textSurname.Text;
            UserDal userDal = new UserDal();
            RegisterValidator registerValidator = new RegisterValidator(registerDTO);
            string HashedPassword = txtPass.Text.md5sifreleme();
            if (registerValidator.isValid && userDal.Register(textName.Text, textSurname.Text, txtEmail.Text, HashedPassword, textSocialMedia.Text))
            {
                MessageBox.Show("Kayıt gerçekleşti, login ekranına yönlendiriliyorsunuz.");
                LoginPageForm lg = new LoginPageForm();
                lg.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Girilen mail, sistemde daha önceden başkasına ait olabilir veya sosyal medya harici boş bırakılan alanlar olabilir. Tekrar deneyiniz kayıt gerçekleşmedi. Login ekranına yönlendiriliyorsunuz.");
            }



        }
    }
}
