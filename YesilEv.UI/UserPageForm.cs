using YesilEv.DAL.Concrete;
using GreenHouseEntityy.Concrete.DTO;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesilEv.Entity.Concrete.DTO;
using YesilEv.Common.Helper;

namespace YesilEv.UI
{
    public partial class UserPageForm : Form
    {
        SingletonLoginInformations userInformationSingleton = SingletonLoginInformations.LoginInformationWithSingleton;
        UserDal userDal = new UserDal();
        public HomePageForm homePageForm;
        public UserPageForm()
        {
            InitializeComponent();
        }

        private void UserPage_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            label3.Visible = false;
            GetUserType();
            GetUserUIInfo();
            ProductDal pd = new ProductDal();
            button6.Text = "Eklediği Ürün Sayısı : " + pd.HowManyProductsDidTheUserAdd();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }
        private void GetUserType()
        {
            if (userInformationSingleton.Type == "Admin")
            {
                btnMakePre.Visible = false;
                label3.Visible = true;
            }
            else if (userInformationSingleton.Type == "Premium")
            {
                btnMakePre.Visible = false;
                groupBox1.Visible = true;
            }

        }

        private void GetUserUIInfo()
        {
            label1.Text = userInformationSingleton.Name;
            label2.Text = userInformationSingleton.KayıtTarihi;
        }
        private void btnArama_Click_1(object sender, EventArgs e)  // email değiştirme
        {
            string newMail = Interaction.InputBox("Değiştirmek istenilen mail adresi", "Mail Box", "");
            if (newMail != "" && userInformationSingleton.Email != newMail && userDal.UpdateMail(newMail))
            {
                    MessageBox.Show("Email adresiniz değişti.");
            }
            else
            {
                MessageBox.Show("Email adresinizde değişiklik yapılamadı, aynı email adresini girmeyiniz ya da email kımını boş bırakmayınız veya tahmin edilemeyen bir hata gerçekleşti, tekrar deneyiniz.");
            }

        }

        private void btnAdminUrunEkleDuzenle_Click_1(object sender, EventArgs e) //password degistirme butonu
        {
            string newPass = Interaction.InputBox("Değiştirmek istenilen şifre", "New Password", "");
            string HashedPassword = newPass.md5sifreleme();
            if (newPass != "" && userInformationSingleton.Password != newPass && userDal.UpdatePassword(HashedPassword))
            {
                
                    MessageBox.Show("Şifreniz değişti.");
            }
            else
            {
                MessageBox.Show("Aynı şifre girimi, şifre kısmı boş geçimi veya tahmin edilemeyen hata tespiti dolayısıyla şifre güncelleme başarısız. Tekrar deneyiniz.");
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomePageForm home = new HomePageForm();
            home.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userDal.cleanerForSearchHistory(userInformationSingleton.Id);
            MessageBox.Show("Temizlendi");

        }

        private void btnAramaGecmisi_Click(object sender, EventArgs e) //profil bilgileri güncelleme
        {

            DialogResult dialogResult = MessageBox.Show("İsim Değiştirme", "İsminizi değiştirmek istermisiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string newName = Interaction.InputBox("Değiştirmek istenilen isim", "New Name", "");
                if (newName != "" && userInformationSingleton.Name != newName && userDal.UpdateNameAndSurname("Name", newName))
                {
                        MessageBox.Show("Güncelleme işlemi başarılı.");
                        userInformationSingleton.Name = newName;   
                }
                else
                {
                    MessageBox.Show("Aynı isim girişi, isim kutusnun boş bırakılması veya tahmin edilemeyen hata tespiti sonucu güncelleme işlemi başarısız tekrar deneyiniz.");
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                DialogResult dialogResult2 = MessageBox.Show("Soyisim Değiştirme", "Soyisminizi değiştirmek istermisiniz?", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    string newSurname = Interaction.InputBox("Değiştirmek istenilen soyisim", "New Surname", "");
                    if (newSurname != null && userInformationSingleton.Surname != newSurname && userDal.UpdateNameAndSurname("Surname", newSurname))
                    {
                            MessageBox.Show("Güncelleme işlemi başarılı.");
                            userInformationSingleton.Surname = newSurname;
                    }
                    else
                    {
                        MessageBox.Show("Aynı soyisim girişi, soyisim kutusnun boş bırakılması veya tahmin edilemeyen hata tespiti sonucu güncelleme işlemi başarısız tekrar deneyiniz.");
                    }

                }
            }
            UserPageForm u = new UserPageForm();
            u.Show();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FavoriteAndBlockListForm favoriteAndBlockListForm = new FavoriteAndBlockListForm("Favorite");
            favoriteAndBlockListForm.pageForm = this;
            favoriteAndBlockListForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FavoriteAndBlockListForm favoriteAndBlockListForm = new FavoriteAndBlockListForm("Block");
            favoriteAndBlockListForm.pageForm = this;
            favoriteAndBlockListForm.Show();
            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginPageForm l = new LoginPageForm();
            l.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
