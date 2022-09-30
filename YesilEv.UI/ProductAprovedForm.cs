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
using YesilEv.Entity.Concrete.DTO;

namespace YesilEv.UI
{
    public partial class ProductAprovedForm : Form
    {
        public HomePageForm homePageForm = new HomePageForm();
        List<ProductListDTO> productDetailDTO = null;
        ProductDal productDal = new ProductDal();
        string barkod = null;
        public ProductAprovedForm()
        {
            InitializeComponent();
        }

        private void UserAprovedForm_Load(object sender, EventArgs e)
        {
           
            LoadProducts();

        }
        private void LoadProducts()
        {
            productDetailDTO = productDal.GetAllProduct();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (var item in productDetailDTO.Where(x => x.IsApproved == false).ToList())
            {
                listBox1.Items.Add(item.ToString());
            }
            foreach (var item in productDetailDTO.Where(x => x.IsApproved == true).ToList())
            {
                listBox2.Items.Add(item.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomePageForm h = new HomePageForm();
            h.Show();
            this.Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            ListBox item = sender as ListBox;
            var result = productDal.GetAll(x => x.BarkodNo == item.Text).SingleOrDefault();
            if (!(result is null))
            {
                var productDetailResult = productDal.productDetail(item.Text);
                ProductPageForm form = new ProductPageForm(productDetailResult);
                form.Show();
          
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox item = sender as ListBox;
            barkod = item.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (barkod==null)
            {
                MessageBox.Show("Lütfen Ürün Seçiniz");
            }
            else
            {
                productDal.UpdateProductAprroved(barkod);
                barkod = null;
                LoadProducts();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox item = sender as ListBox;
            barkod = item.Text;
        }

        private void listbox2_DoubleClick(object sender, EventArgs e)
        {
            ListBox item = sender as ListBox;
            var result = productDal.GetAll(x => x.BarkodNo == item.Text).SingleOrDefault();
            if (!(result is null))
            {
                var productDetailResult = productDal.productDetail(item.Text);
                ProductPageForm form = new ProductPageForm(productDetailResult);
                form.Show();
            }
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            UserPageForm form = new UserPageForm();
            this.Close();
            form.Show();

        }
    }
}
