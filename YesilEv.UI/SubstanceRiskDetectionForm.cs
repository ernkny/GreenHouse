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
    public partial class SubstanceRiskDetectionForm : Form
    {
        HomePageForm h = new HomePageForm();
        string substanceName = "";
        ProductDal pd = new ProductDal();
        public SubstanceRiskDetectionForm()
        {
            InitializeComponent();
        }

        private void SubstanceRiskDetectionForm_Load(object sender, EventArgs e)
        {
            getProductSubstancesForWhichRiskTypeHasNotBeenDetermined();
        }
        private void getProductSubstancesForWhichRiskTypeHasNotBeenDetermined()
        {
            foreach (var i in pd.productSubstancesForWhichRiskTypeHasNotBeenDetermined())
            {
                comboBox1.Items.Add(i);
            }

        }

        private void btnAramaGecmisi_Click(object sender, EventArgs e)
        {

            string riskType = "";
            if (substanceName == "" || (düsükRadioButton.Checked == false && ortaRadioButton.Checked == false && yüksekRadioButton.Checked == false))
            {
                MessageBox.Show("Eksik bilgiler mevcut. Tekrar deneyiniz.");
            }
            else
            {
                if (düsükRadioButton.Checked == true)
                    riskType = "Düşük";
                else if (ortaRadioButton.Checked == true)
                    riskType = "Orta";
                else
                    riskType = "Yüksek";

                if(pd.UpdateRiskOfSubstanceWhoseRiskTypeIsNull(substanceName, riskType))
                {
                    MessageBox.Show("Güncelleme başarılı. Ana sayfaya yönlendiriliyorsunuz.");
                }
                else
                {
                    MessageBox.Show("Güncelleme başarısız. Hata gerçekleşti, ana sayfaya yönlendiriliyorsunuz.");
                }
                h.Show();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            h.Show();
            this.Close();
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            UserPageForm u = new UserPageForm();
            u.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selectedItem = sender as ComboBox;
            substanceName = selectedItem.Text;

        }
    }
}
