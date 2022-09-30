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
using YesilEv.DAL.Abstract;
using YesilEv.DAL.Concrete;
using YesilEv.Entity.Concrete.DTO;

namespace YesilEv.UI
{
    public partial class ProductPageForm : Form
    {
        UserDal u = new UserDal();
        ProductDetailDTO _productDetail;
        SingletonLoginInformations userInformationSingleton = SingletonLoginInformations.LoginInformationWithSingleton;
        public ProductPageForm()
        {
            InitializeComponent();
            
        }
        public ProductPageForm(ProductDetailDTO productDetail):this()
        {
            _productDetail= productDetail;
           
        }
        private void ProductPage_Load(object sender, EventArgs e)
        {
            ProductDal pd = new ProductDal();
            if (!(_productDetail.Substances is null))
            {
                foreach (var item in _productDetail.Substances)
                {
                    comboBox1.Items.Add(item.Name);

                }
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            if (_productDetail.Pictures.Count()==2)
            {
                pictureBox1.Image = Image.FromFile(_productDetail.Pictures[0].PicturePath);
                pictureBox2.Image = Image.FromFile(_productDetail.Pictures[1].PicturePath);
            }
            label1.Text = _productDetail.ProductName;
            label2.Text = _productDetail.CompanyName;
            label13.Text = pd.HowManyHighRiskOrLowRiskOrMediumRiskSubstancesDoesTheProductHave("Düşük", _productDetail.Id).ToString();
            label12.Text = pd.HowManyHighRiskOrLowRiskOrMediumRiskSubstancesDoesTheProductHave("Orta", _productDetail.Id).ToString();
            label11.Text = pd.HowManyHighRiskOrLowRiskOrMediumRiskSubstancesDoesTheProductHave("Yüksek", _productDetail.Id).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePageForm h = new HomePageForm();
            h.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string message = "Favoriye eklemek istediğinizden emin misiniz?";
            string title = "Favori Onay";
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
            DialogResult dialogResult = MessageBox.Show(message, title, messageBoxButtons);
            if (dialogResult == DialogResult.Yes && u.addProductFavoriteorBlockList(_productDetail.Id, 2))
                MessageBox.Show("Ürün Favorilerinize eklendi");
            else
                MessageBox.Show("Hata tespit edildi, tekrar deneyiniz.");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string message = "Bloklamak istediğinizden emin misiniz?";
            string title = "Blok Onay";
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
            DialogResult dialogResult = MessageBox.Show(message, title, messageBoxButtons);
            if (dialogResult == DialogResult.Yes && u.addProductFavoriteorBlockList(_productDetail.Id, 1))
                MessageBox.Show("Ürün Bloklandı");
            else
                MessageBox.Show("Hata tespit edildi, tekrar deneyiniz.");
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            UserPageForm userPageForm = new UserPageForm();
            userPageForm.Show();
            this.Close();
        }

    }
}
