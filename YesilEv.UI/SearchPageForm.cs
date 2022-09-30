
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
    public partial class SearchPageForm : Form
    {
        SingletonLoginInformations userInformationSingleton = SingletonLoginInformations.LoginInformationWithSingleton;
        public UserPageForm userPageForm;
        public HomePageForm homePageForm;
        public SearchPageForm()
        {
            InitializeComponent();
        }
        private void SearchPage_Load(object sender, EventArgs e)
        {
           
        }

        private void btnLogin_Click(object sender, EventArgs e) //search butonu
        {
            ProductDal product = new ProductDal();
            var searchedValuelist = product.Search(textBox1.Text);
            dataGridView1.DataSource = searchedValuelist;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            product.sendSearchedValue(searchedValuelist, userInformationSingleton.Id);
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            UserPageForm userPageForm = new UserPageForm();
            userPageForm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            homePageForm.Visible = true;
            this.Close();
          
        }
    }
}
