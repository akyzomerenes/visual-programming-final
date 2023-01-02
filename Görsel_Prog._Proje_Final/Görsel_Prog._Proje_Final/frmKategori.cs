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
    public partial class frmKategori : Form
    {
        public frmKategori()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=Localhost; Database=stoktakip; uid=root; Password=;");


        private void frmKategori_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open(); //Bağlantıyı Açtım
            MySqlCommand komut = new MySqlCommand("insert into kategoribilgileri(kategori) values('"+textBox1.Text+"')",baglanti); // Gerekli queryi yazdım
            komut.ExecuteNonQuery(); // queryi çalıştırdım
            baglanti.Close(); //Bağlantıyı Kapattım
            textBox1.Text = ""; // Texbox ın içini temizledim
            MessageBox.Show("Kategori Eklendi"); // Ekrana Mesaj Yazdırdım
        }
    }
}
