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
    public partial class frmÜrünEkle : Form
    {
        public frmÜrünEkle()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=Localhost; Database=stoktakip; uid=root; Password=;");
        private void kategorigetir()
        {
            baglanti.Open();

            MySqlCommand komut = new MySqlCommand("select * from kategoribilgileri", baglanti);
            MySqlDataReader read = komut.ExecuteReader(); // SATIR OKUYOR

            while (read.Read())
            {
                comboKategori.Items.Add(read["kategori"].ToString());
            }
            baglanti.Close();
        }
        private void frmÜrünEkle_Load(object sender, EventArgs e)
        {
            kategorigetir();
        }

        private void comboKategori_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboMarka.Items.Clear();
            comboMarka.Text = "";

            baglanti.Open();

            MySqlCommand komut = new MySqlCommand("select * from markabilgileri where kategori='"+comboKategori.SelectedItem+"'", baglanti);
            MySqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {
                comboMarka.Items.Add(read["marka"].ToString());
            }
            baglanti.Close();
        }

        private void btnyeniekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            MySqlCommand komut = new MySqlCommand("insert into urun(barkodno,kategori,marka,urunadi,miktari,alisfiyati,satisfiyati,tarih) values(@barkodno,@kategori,@marka,@urunadi,@miktari,@alisfiyati,@satisfiyati,@tarih)", baglanti);
            komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
            komut.Parameters.AddWithValue("@kategori", comboKategori.Text);
            komut.Parameters.AddWithValue("@marka",comboMarka.Text);
            komut.Parameters.AddWithValue("@urunadi", txtÜrünAdi.Text);
            komut.Parameters.AddWithValue("@miktari", int.Parse (txtMiktari.Text));
            komut.Parameters.AddWithValue("@alisfiyati",double.Parse( txtAlışFiyatı.Text));
            komut.Parameters.AddWithValue("@satisfiyati",double.Parse( txtSatışFiyatı.Text));
            komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());

            komut.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Ürün Eklendi");
            comboMarka.Items.Clear();

            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
               }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }

        }

        private void BarkodNotxt_TextChanged(object sender, EventArgs e)
        {
            if (BarkodNotxt.Text=="")  // eğer barkod numarası boşsa kutuların içini dolaş (foreach) ve sil + labeli sil
            {
                lblMiktari.Text = "";
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }

            baglanti.Open();

            MySqlCommand komut = new MySqlCommand("select * from urun where barkodno like '"+BarkodNotxt.Text+"'", baglanti);

            MySqlDataReader read = komut.ExecuteReader();

            while (read.Read()) //Kayıtlar okunduğu sürece
            {
                Kategoritxt.Text = read["kategori"].ToString();
                Markatxt.Text = read["marka"].ToString();
                ÜrünAdıtxt.Text = read["urunadi"].ToString();
                lblMiktari.Text = read["miktari"].ToString();
                AlışFiyatıtxt.Text = read["alisfiyati"].ToString();
                SatışFiyatıtxt.Text = read["satisfiyati"].ToString();

            }
            baglanti.Close();
        }

        private void btnmevcutaekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            MySqlCommand komut = new MySqlCommand("update urun set miktari=miktari+'"+int.Parse(Miktarıtxt.Text)+"' where barkodno='"+BarkodNotxt.Text+"' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            MessageBox.Show("Var olan ürüne ekleme yapıldı");
        }
    }
}
