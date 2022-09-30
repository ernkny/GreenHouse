using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesilEv.DAL.Concrete;

namespace YesilEv.UI
{
    public partial class UserTypeForm : Form
    {
        string username = "";
        int roleType = 0;
        UserDal ud = new UserDal();
        public UserTypeForm()
        {
            InitializeComponent();
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            UserPageForm u = new UserPageForm();
            u.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HomePageForm h = new HomePageForm();
            h.Show();
            this.Close();
        }

        private void UserTypeForm_Load(object sender, EventArgs e)
        {
            premiumOrNormalUserComboBox.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            RolcomboBox1.Visible = false;
        }

        private void PremiumradioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (PremiumradioButton1.Checked == true)
            {
                foreach (var i in ud.getNormalAndPremiumUser("Premium User"))
                {
                    premiumOrNormalUserComboBox.Items.Add(i);
                }
                RolcomboBox1.Visible = true;
                premiumOrNormalUserComboBox.Visible = true;
                RolcomboBox1.Items.Add("Admin");
                RolcomboBox1.Items.Add("Normal User");
                label1.Visible = true;
                label2.Visible = true;
            }
            else
            {
                premiumOrNormalUserComboBox.Items.Clear();
                RolcomboBox1.Items.Clear();
            }

        }

        private void NormalradioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (NormalradioButton2.Checked == true)
            {
                foreach (var i in ud.getNormalAndPremiumUser("Normal User"))
                {
                    premiumOrNormalUserComboBox.Items.Add(i);
                }
                premiumOrNormalUserComboBox.Visible = true;
                RolcomboBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                RolcomboBox1.Items.Add("Admin");
                RolcomboBox1.Items.Add("Premium User");
            }
            else
            {
                premiumOrNormalUserComboBox.Items.Clear();
                label2.Visible = true;
                RolcomboBox1.Items.Clear();
            }
        }

        private void premiumOrNormalUserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selectedItem = sender as ComboBox;
            username = selectedItem.Text;
        }

        private void RolcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selectedItem = sender as ComboBox;
            if (selectedItem.Text == "Admin")
                roleType = 1;
            else if (selectedItem.Text == "Premium User")
                roleType = 3;
            else if (selectedItem.Text == "Normal User")
                roleType = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username != "" && roleType != 0)
            {
                if (ud.updateUserRole(username, roleType))
                {
                    MessageBox.Show("Ana sayfaya yönlendiriliyorsunuz. User güncellemesi gerçekleşti.");
                 
                }
                else
                {
                    MessageBox.Show("Ana sayfaya yönlendiriliyorsunuz. Bir hata gerçekleşti. Tekrar deneyiniz.");
                }
                HomePageForm h = new HomePageForm();
                h.Show();
                this.Close();
            }
            else
                MessageBox.Show("Bilgiler eksik tekrar deneyiniz.");
            
          
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                foreach (var i in ud.getNormalAndPremiumUser("Admin"))
                {
                    premiumOrNormalUserComboBox.Items.Add(i);
                }
                premiumOrNormalUserComboBox.Visible = true;
                RolcomboBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                RolcomboBox1.Items.Add("Normal User");
                RolcomboBox1.Items.Add("Premium User");
            }
            else
            {
                premiumOrNormalUserComboBox.Items.Clear();
                label2.Visible = true;
                RolcomboBox1.Items.Clear();
            }
        }
    }
}
