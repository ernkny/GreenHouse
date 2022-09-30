using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesilEv.Core.Context;
using YesilEv.DAL.Concrete;
using YesilEv.Entity.Concrete.DTO;

namespace YesilEv.UI
{
    public partial class BarCodeSearchForm : Form
    {
        public BarCodeSearchForm()
        {
            InitializeComponent();
        }
        private void BarCodeSearchFrom_Load(object sender, EventArgs e)
        {
            txtBarCode.Text = "4e053cb3-eebb-4340-90cd-9b2f454ddab0fasdafasd";
        }
        private void btnBarkod_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBarCode.Text))
            {
                ProductDal productDal = new ProductDal();
                var result = productDal.GetAll(x => x.BarkodNo == txtBarCode.Text).SingleOrDefault();
                
                if (result is null)
                {
                    AddProducForm form = new AddProducForm(txtBarCode.Text);
                    form.Show();
                    this.Hide();
                }
                else
                {
                    var productDetailResult=productDal.productDetail(txtBarCode.Text);
                    ProductPageForm form = new ProductPageForm(productDetailResult);
                    form.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Barkod Numarası Giriniz");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.Visible = true;
            this.Hide();
;        }
    }
}
