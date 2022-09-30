using YesilEv.DAL.Concrete;
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
using YesilEv.Entity.Concrete.DTO;
using YesilEv.Common.Helper;

namespace YesilEv.UI
{
    public partial class FavoriteAndBlockListForm : Form
    {
        SingletonLoginInformations userInformationSingleton = SingletonLoginInformations.LoginInformationWithSingleton;
        UserDal userDal = new UserDal();
        public UserPageForm pageForm;
        string _request;
        string barkode = null;
        public FavoriteAndBlockListForm()
        {
            InitializeComponent();
        }
        public FavoriteAndBlockListForm(string request) : this()
        {
            _request = request;
        }
  

        private void FavoriteAndBlockListForm_Load(object sender, EventArgs e)
        {
            List();
        }
        private void List()
        {

            if (_request == "Block")
            {
                dataGridView1.DataSource = userDal.ListBlockOrFavorited((int)CommonHelper.BlokFavType.blok);
            }
            else if (_request == "Favorite")
            {
                dataGridView1.DataSource = userDal.ListBlockOrFavorited((int)CommonHelper.BlokFavType.favori);
            }
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            pageForm.Visible = true;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomePageForm h = new HomePageForm();
            h.Show();
            this.Close();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserProcessDal userProcessDal = new UserProcessDal();
            ProductDal productDal= new ProductDal();
            var product=productDal.GetAll(x => x.BarkodNo == barkode).FirstOrDefault();
            if (!(barkode is null) && !(product is null))
            {
                var result = userProcessDal.GetAll(x => x.UserId == userInformationSingleton.Id && x.ProductId == product.Id).FirstOrDefault();
                if (!(result is null))
                {
                    MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                    string message = "Bu( " + product.Name + " " + product.BarkodNo + " )" + " Ürünü çıkarmak istediğinizden emin misiniz?";
                    string title = "Uyarı";
                    DialogResult dialogResult = MessageBox.Show(message, title, messageBoxButtons);
                    if (dialogResult==DialogResult.Yes)
                    {
                        userProcessDal.Delete(result);
                        userProcessDal.MyChanges();
                        List();
                    }
                   
                }
                else
                {
                    MessageBox.Show("Ürün Bulunamadı!!");
                }

            }
            else
            {
                MessageBox.Show("Lütfen çıkarılacak ürünü seçiniz!");
            }
            
        }

        private void SelectedItem_Click(object sender, MouseEventArgs e)
        {
            string barcode = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            barkode= barcode;
        }
    }
}
