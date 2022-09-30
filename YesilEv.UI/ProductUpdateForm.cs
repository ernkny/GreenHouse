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
using YesilEv.Entity.Concrete.DTO;
using YesilEv.Validation.Concrete;

namespace YesilEv.UI
{
    public partial class ProductUpdateForm : Form
    {//--------GÜNCEL
        ProductDetailDTO ProductDetailDTO { get; set; }
        Product product = null;
        int categoryID;
        int CompanyID;
        public ProductUpdateForm()
        {
            InitializeComponent();
        }
        public ProductUpdateForm(ProductDetailDTO _ProductDetailDTO) : this()
        {
            ProductDetailDTO = _ProductDetailDTO;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(ProductDetailDTO.CategoryName);
        }

        private void ProductUpdateForm_Load(object sender, EventArgs e)
        {
            LoadUpdateınformations();
            textBox1.Enabled = false;

        }
        private void LoadUpdateınformations()
        {
            CompanyDal companyDal = new CompanyDal();
            CommonHelper commonHelper = new CommonHelper();
            ProductDal productDal = new ProductDal();
            var CompaniesResult = companyDal.GetAll();
            foreach (var item in commonHelper.menuLists.Items)
            {
                comboBox2.Items.Add(item.Text);
                int lastIndexOfNegatif = item.Text.LastIndexOf("-") + 1;
                string categoryName = item.Text.Substring(lastIndexOfNegatif);
                if (categoryName == ProductDetailDTO.CategoryName)
                {
                    comboBox2.SelectedIndex = comboBox2.Items.IndexOf(item.Text);
                }

            }
            foreach (var item in CompaniesResult)
            {
                comboBox1.Items.Add(item.Name);
                if (item.Name == ProductDetailDTO.CompanyName)
                {
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(item.Name);
                }
            }
            textBox1.Text = ProductDetailDTO.Barkod;
            textBox4.Text = ProductDetailDTO.ProductName;
            StringBuilder stringBuilder = new StringBuilder();
            string updateSubstances = null;
            foreach (var item in ProductDetailDTO.Substances)
            {
                updateSubstances = stringBuilder.Append(item.Name + ",").ToString();
            }

            richTextBox1.Text = updateSubstances;
            product = productDal.GetAll(x => x.BarkodNo == textBox1.Text).FirstOrDefault();


        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Title = "Select a Image";
            openFileDialog2.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                button3.Text = openFileDialog2.SafeFileName;
            }
            else
            {
                openFileDialog2.Dispose();

            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select a Image";
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button4.Text = openFileDialog1.SafeFileName;
            }
            else
            {
                openFileDialog1.Dispose();

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            #region Clean Code ProductUpdated
            try
            {
                var _descriptionsSplit = richTextBox1.Text.Split(',').ToList();
                PictureUpdateProcess pictureUpdateProcess = new PictureUpdateProcess();
                ProductDTO _productDTO = new ProductDTO();
                ProductDal productDal = new ProductDal();
                _productDTO.Name = textBox4.Text;
                _productDTO.CategoryId = categoryID;
                _productDTO.CompanyId = CompanyID;
                //todo ModifiedUser Ekle
                //Product için gelen verileri Kontrol ediyorum
                ProductValidator _productValidator = new ProductValidator(_productDTO, _descriptionsSplit);
                if (_productValidator.isValid)
                {
                    product.Name = textBox4.Text;
                    product.CategoryId = categoryID;
                    product.CompanyId = CompanyID;
                    List<OpenFileDialog> openFileDialogs = new List<OpenFileDialog>();
                    openFileDialogs.Add(openFileDialog1);
                    openFileDialogs.Add(openFileDialog2);
                    var pictureResultsForUpdate = pictureUpdateProcess.UpdatePictureProcess(openFileDialogs, product.Pictures.ToList());
                    product = productDal.productUpdate(product, _productValidator.SubstancesCleared, pictureResultsForUpdate);
                    var message = product is null ? "Ürün Güncellenirken Hata Oluştu!!" : "Ürün Güncelledi";
                    MessageBox.Show(message);
                    AllProductsForm allProductsForm = new AllProductsForm();
                    allProductsForm.Show();
                    this.Dispose();

                }
                else MessageBox.Show("Bilgileri eksiksiz doldurunuz!!");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu");
            }
            #endregion


        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox selecteditem = sender as ComboBox;
            CompanyDal CompanyDal = new CompanyDal();
            CompanyID = CompanyDal.GetAll(x => x.Name == selecteditem.Text).SingleOrDefault().Id;
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox selecteditem = sender as ComboBox;
            CategoryDal categoryDal = new CategoryDal();
            int lastindex = selecteditem.Text.LastIndexOf('-') + 1;
            categoryID = categoryDal.GetAll(x => x.Name == selecteditem.Text.Substring(lastindex)).SingleOrDefault().Id;
        }
    }
}
