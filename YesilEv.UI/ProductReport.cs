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
    public partial class ProductReport : Form
    {
        ReportDal reportDal = new ReportDal();
        public ProductReport()
        {
            InitializeComponent();
        }

        private void ProductReport_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
     
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
        
        }

        private void button6_Click(object sender, EventArgs e)
        {
       
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
    
        }

        private void button7_Click(object sender, EventArgs e)
        {
    
        }

        private void button8_Click(object sender, EventArgs e)
        {
          
        }

        private void button9_Click(object sender, EventArgs e)
        {
       
        }

        private void button10_Click(object sender, EventArgs e)
        {
          
        }

        private void button11_Click(object sender, EventArgs e)
        {
    
        }

        private void button12_Click(object sender, EventArgs e)
        {
         
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
           
        }

        private void button15_Click(object sender, EventArgs e)
        {
  
        }

        private void button16_Click(object sender, EventArgs e)
        {
        
        }

        private void btnUserList_Click_1(object sender, EventArgs e)
        {
            UserPageForm userPageForm = new UserPageForm();
            userPageForm.Show();
            this.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.mostAllergenicProducts();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.WhoHasHowManyFavoriteBlockItems();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.ListofProductsThatHaveEthanol();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.mostAllergenicProducts();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.BlacklistAndFavoritedProductsThisMonth();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.MostFavoriteProducts();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.EthanolFavoriteOrBlock();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.HowManySubstanceDoesEachProductHave();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.NumberOfProductsNotApprovedByAdminThisMonth();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.HowManyTimesHastheProductContainingEthanol_BeenAddedToTheFavoriteList_SameForBlock();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.MostFavoriteProductsTOP3();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.Top5UsersWithTheMostProductEntries();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.ProductsWithTheMostItemsBySubstanceCount_Last10Product();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.WhoHasHowManyBlacklistedProductsAndHowManyFavoriteProducts();
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reportDal.HowManyUsersDoIHaveHowManySystemAdminsOrOthers();
        }
    }
}
