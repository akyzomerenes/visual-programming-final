using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Görsel_Prog._Proje_Final
{
    public partial class baslangıc : Form
    {
        public baslangıc()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {

            int sifre = int.Parse(txtadmin_password.Text);

            int kullaniciadi = int.Parse(txtadmin_name.Text);


            try
            {
                if (kullaniciadi==1071 && sifre==1453)
                {
                    Form1 acform = new Form1();

                    acform.ShowDialog();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adınız Veya Parolanız Hatalıdır.Hangisinin Hatalı Olduğunu Söylemem :)");
                }
            }
            catch (Exception)
            {

                ;
            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmGirisBilgileri giris = new FrmGirisBilgileri();
            giris.ShowDialog();
           
        }
    }
}
