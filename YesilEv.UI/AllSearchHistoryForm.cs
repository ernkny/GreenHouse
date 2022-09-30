
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
    public partial class AllSearchHistoryForm : Form
    {
        SingletonLoginInformations userInformationSingleton = SingletonLoginInformations.LoginInformationWithSingleton;
        public HomePageForm homePageForm;
        UserDal userDAL = new UserDal();
        public AllSearchHistoryForm()
        {
            InitializeComponent();
        }

        private void AllSearchHistoryForm_Load(object sender, EventArgs e)
        {
            getList();
        }
        private void getList()
        {
            var list = userDAL.ListSearchHistory(userInformationSingleton.Id);
            dataGridView1.DataSource = list;
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
