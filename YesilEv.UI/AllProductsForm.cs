
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
using YesilEv.DAL.Concrete;
using YesilEv.Entity.Concrete.DTO;

namespace YesilEv.UI
{//--------Güncel
    public partial class AllProductsForm : Form
    {
        public HomePageForm homePageForm;
        List<ProductListDTO> productListDTO;
        string barkod = null;
        ProductDetailDTO ProductDetailDTO;
        ProductDal productDal = new ProductDal();
        public AllProductsForm()
        {
            InitializeComponent();
        }

        private void AllProductsForm_Load(object sender, EventArgs e)
        {
            List();
        }
        private void List()
        {
            ProductDal pd = new ProductDal();
            productListDTO = pd.GetAllProduct().Where(x => x.IsApproved == true && x.isActive == true).ToList();
            dataGridView1.DataSource = productListDTO;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.Show();
            this.Close();
        }
        private void btnUserList_Click(object sender, EventArgs e)
        {
            UserPageForm userPageForm = new UserPageForm();
            userPageForm.Show();
            this.Close();
        }


        private void dataGridView1_ClickedRow(object sender, DataGridViewCellMouseEventArgs e)
        {
            string barcode = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            if (!String.IsNullOrEmpty(barcode))
            {

                var result = productDal.GetAll(x => x.BarkodNo == barcode).SingleOrDefault();
                var productDetailResult = productDal.productDetail(result.BarkodNo);
                ProductPageForm form = new ProductPageForm(productDetailResult);
                form.Show();

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productListDTO.Where(x => x.Name.ToLower().Contains(textBox1.Text.ToLower())).ToList();
        }

        private void Product_Clicked(object sender, MouseEventArgs e)
        {
            barkod = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            if (!(barkod is null))
            {
                ProductDetailDTO = productDal.productDetail(barkod);
            }
            else
            {

                MessageBox.Show("Güncellenecek ürünün satırını seçiniz");
            }
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ProductDetailDTO is null))
            {
                ProductUpdateForm productUpdate = new ProductUpdateForm(ProductDetailDTO);
                productUpdate.Show();
            }
        }

        private void silToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!(ProductDetailDTO is null))
            {
                string message = "Seçili ürünü silmek istediğinizden emin misiniz?";
                string title = "Sil";
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                DialogResult dialogResult = MessageBox.Show(message, title, messageBoxButtons);
                if (dialogResult == DialogResult.Yes)
                {
                    ProductDal productDal = new ProductDal();
                    var resultFromDb = productDal.GetAll(x => x.BarkodNo == ProductDetailDTO.Barkod).FirstOrDefault();
                    if (resultFromDb != null)
                        productDal.ProductSoftDelete(resultFromDb);
                    AllProductsForm allProductsForm = new AllProductsForm();
                    allProductsForm.Show();
                    this.Dispose();
                }
            }
        }
    }
}
