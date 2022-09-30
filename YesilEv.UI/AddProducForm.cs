using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesilEv.Common.Helper;
using YesilEv.Core.Context;
using YesilEv.DAL.Abstract;
using YesilEv.DAL.Concrete;
using YesilEv.Entity.Concrete.DTO;
using YesilEv.Log.Concrete;
using YesilEv.Validation.Concrete;

namespace YesilEv.UI
{
    public partial class AddProducForm : Form
    {
        SingletonLoginInformations s = SingletonLoginInformations.LoginInformationWithSingleton;
        string _barcode;
        int CompanyID;
        int categoryID;

        /// <summary>
        /// 
        /// </summary>
        public AddProducForm()
        {
            InitializeComponent();
        }
        public AddProducForm(string Barcode) : this()
        {
            _barcode = Barcode;
        }

        private void AddProducForm_Load(object sender, EventArgs e)
        {
            if (!(_barcode is null))
            {
                textBox1.Text = _barcode;
            }
            else
            {
                textBox1.Text = Guid.NewGuid().ToString();
            }
            textBox1.Enabled = false;
            CommonHelper commonHelper = new CommonHelper();
            CompanyDal companyDal = new CompanyDal();
            var CompaniesResult = companyDal.GetAll();
            foreach (var item in commonHelper.menuLists.Items)
            {
                comboBox2.Items.Add(item.Text);
                
            }
            foreach (var item in CompaniesResult)
            {
                comboBox1.Items.Add(item.Name);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            #region Clean Code Added
            try
            {
                var _descriptionsSplit = richTextBox1.Text.Split(',').ToList();
                Upload upload = new Upload();
                ProductDTO _productDTO = new ProductDTO();
                _productDTO.Guid = textBox1.Text;
                _productDTO.Name = textBox4.Text;
                _productDTO.CategoryId = categoryID;
                _productDTO.CompanyId = CompanyID;
                _productDTO.CreatedUserId = 1;
                List<OpenFileDialog> openFileDialogs = new List<OpenFileDialog>();
                openFileDialogs.Add(openFileDialog1);
                openFileDialogs.Add(openFileDialog2);
                //Product için gelen verileri Kontrol ediyorum
                ProductValidator _productValidator = new ProductValidator(_productDTO, _descriptionsSplit);
                if (_productValidator.isValid && openFileDialog1.FileName!= "openFileDialog1" && openFileDialog2.FileName != "openFileDialog2" &&
                    !String.IsNullOrEmpty(openFileDialog1.FileName) && !String.IsNullOrEmpty(openFileDialog2.FileName))
                {
                    var pictureResult = upload.UploadPicture(openFileDialogs);
                    if (pictureResult.Count >= 2)
                    {
                        List<Picture> PicturePaths = new List<Picture>();
                        PicturePaths.AddRange(pictureResult);
                        //Son aşama olarak bütün processleri Product Tablosuna eklenmesi için Gönderiyorum
                        ProductDal productDal = new ProductDal();
                        Product productResult = productDal.ProductAdd(_productDTO, _productValidator.SubstancesCleared, PicturePaths);
                        var message = productResult is null ? "Ürün Kayıt Edilemedi" : "Ürün Kayıt Edildi";
                        MessageBox.Show(message);
                        LoggerFactory<Product> log = new LoggerFactory<Product>();
                        log.FactoryMethod(LoggerFactory<Product>.LoggerType.FileLogger, productResult);
                        AddProducForm NewForm = new AddProducForm();
                        NewForm.Show();
                        this.Dispose(false);
                    }
                }
                else MessageBox.Show("Bilgileri eksiksiz doldurunuz!!");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu");
            }
            #endregion


        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selecteditem = sender as ComboBox;
            CategoryDal categoryDal = new CategoryDal();
            int lastindex = selecteditem.Text.LastIndexOf('-') + 1;
            categoryID = categoryDal.GetAll(x => x.Name == selecteditem.Text.Substring(lastindex)).SingleOrDefault().Id;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selecteditem = sender as ComboBox;
            CompanyDal CompanyDal = new CompanyDal();
            CompanyID = CompanyDal.GetAll(x => x.Name == selecteditem.Text).SingleOrDefault().Id;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.Visible = true;
            this.Hide();
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            UserPageForm userPageForm = new UserPageForm();
            userPageForm.Show();
            this.Close();
        }
    }
}
