
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
{
    public partial class HomePageForm : Form
    {
        SingletonLoginInformations userInformationSingleton = SingletonLoginInformations.LoginInformationWithSingleton;

        public HomePageForm()
        {
            InitializeComponent();
        }
        private void Secret()
        {
            if (userInformationSingleton.Type == "Normal" || userInformationSingleton.Type == "Premium")
            {
                //editProductsBtn.Visible = false;
                Btn_Approve.Visible = false; //ürünleri onaylama
                MaddeRiskBtn.Visible = false;
                button3.Visible = false;//users
            }

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            Secret();
            ProductDal productDal = new ProductDal();
            int AprrovedWaitedCounted = productDal.GetAllProduct().Where(x => x.IsApproved == false).Count();
            Btn_Approve.Text = "Onay Durumu " + " (" + AprrovedWaitedCounted + ")";

        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            UserPageForm up = new UserPageForm();
            up.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductReport pro = new ProductReport();
            pro.Show();
            this.Hide();
        }



        private void BtnUrünListele_Click(object sender, EventArgs e)
        {
            AllProductsForm allProductsForm = new AllProductsForm();
            allProductsForm.Show();
            allProductsForm.homePageForm = this;
            this.Hide();
        }

        private void Btn_Approve_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllProductsForm allProductsForm = new AllProductsForm();
            allProductsForm.Show();
            allProductsForm.homePageForm = this;
            this.Hide();
        }

      

        private void btnArama_Click_1(object sender, EventArgs e)
        {
            SearchPageForm searchPageForm = new SearchPageForm();
            searchPageForm.homePageForm = this;
            searchPageForm.Show();
            this.Hide();
        }

        private void btnBarkod_Click_2(object sender, EventArgs e)
        {
            BarCodeSearchForm barCodeSearchFrom = new BarCodeSearchForm();
            barCodeSearchFrom.Show();
            this.Hide();
        }

        private void btnAdminUrunEkleDuzenle_Click_2(object sender, EventArgs e)
        {
            AddProducForm addProducForm = new AddProducForm();
            addProducForm.Show();
            this.Hide();
        }

        private void btnAramaGecmisi_Click_1(object sender, EventArgs e)
        {
            AllSearchHistoryForm allSearchHistoryForm = new AllSearchHistoryForm();
            allSearchHistoryForm.homePageForm = this;
            allSearchHistoryForm.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ProductReport form = new ProductReport();
            form.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserTypeForm utf = new UserTypeForm();
            utf.Show();
            this.Close();
        }

        private void Btn_Approve_Click_1(object sender, EventArgs e)
        {
            ProductAprovedForm productAprovedForm = new ProductAprovedForm();
            this.Close();
            productAprovedForm.Show();
        }

        private void btnUserList_Click_2(object sender, EventArgs e)
        {
            UserPageForm userPageForm = new UserPageForm();
            userPageForm.homePageForm = this;
            userPageForm.Show();
            this.Hide();
        }

        private void MaddeRiskBtn_Click(object sender, EventArgs e)
        {
            SubstanceRiskDetectionForm s = new SubstanceRiskDetectionForm();
            s.Show();
            this.Close();
        }
    }
}
