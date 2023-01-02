using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Görsel_Prog._Proje_Final
{
    public partial class frmSatışListele : Form
    {
        public frmSatışListele()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=Localhost; Database=stoktakip; uid=root; Password=;");
        DataSet daset = new DataSet();

        private void satışlistele()
        {
            baglanti.Open();   // Bağlantıyı Açtık
            MySqlDataAdapter adtr = new MySqlDataAdapter("select * from satis", baglanti); // Gerekli olan query i yazdım
            adtr.Fill(daset, "satis");// daset isminde oluşturduğum geçici tabloya verilerimi ekledim
            dataGridView1.DataSource = daset.Tables["satis"]; // datagridview e geçici tablo olan daset içindeki verileri birleştirdim
            
            baglanti.Close();//Bağlantıyı Kapattım
        }

        private void frmSatışListele_Load(object sender, EventArgs e)
        {
            satışlistele();  // Satış Listele adlı methodumu çağırdım.
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
