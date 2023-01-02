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
    public partial class frmmusteriekle : Form
    {
        public frmmusteriekle()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=Localhost; Database=stoktakip; uid=root; Password=;");

        private void frmmusteriekle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open(); //Bağlantımızı gerçekleştirdik
            MySqlCommand komut = new MySqlCommand("insert into musteri(tc,adsoyad,telefon,adres,email) values(@tc,@adsoyad,@telefon,@adres,@email)", baglanti); //Mysql sorgumuzu yazdık

            komut.Parameters.AddWithValue("@tc", txtTC.Text);
            komut.Parameters.AddWithValue("@adsoyad", txtADSOYAD.Text);
            komut.Parameters.AddWithValue("@telefon", txtTELEFON.Text);
            komut.Parameters.AddWithValue("@adres", txtADRES.Text);
            komut.Parameters.AddWithValue("@email", txtEMAİL.Text);

            komut.ExecuteNonQuery(); // Sorgumuzu çalıştırdık

            baglanti.Close();// Bağlantıyı Kapatıık

            MessageBox.Show("Müşteri Kaydı Eklendi"); // Mesaj box ile ekrana mesaj gösterdik


            foreach (Control item in this.Controls) // foreach döngüsü formdaki elemanları teker teker kontrol ettik ve eğer texbox varsa içini temizlemesini söyledik.
            {
                if (item is TextBox)
                {
                    item.Text = "";     
                }
            }

        }
    }
}
