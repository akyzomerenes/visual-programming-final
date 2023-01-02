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
using System.Xml;

namespace Görsel_Prog._Proje_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=Localhost; Database=stoktakip; uid=root; Password=;");
        DataSet daset = new DataSet();
        private void sepetlistele()
        {
            baglanti.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("select * from sepet", baglanti);
            adtr.Fill(daset, "sepet");
            dataGridView1.DataSource = daset.Tables["sepet"];

            //dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[1].Visible = false;
            //dataGridView1.Columns[2].Visible = false;


            baglanti.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmmusteriekle ekle = new frmmusteriekle();
            ekle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMusteriListele listele = new frmMusteriListele();
            listele.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmÜrünEkle ekle = new frmÜrünEkle();

            ekle.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmKategori kategori = new frmKategori();

            kategori.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmMarka marka = new frmMarka();

            marka.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmÜrünListele listele = new frmÜrünListele();
            listele.ShowDialog();
        }

        private void hesapla()
        {
            try
            {
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select sum(toplamfiyati) from sepet", baglanti);
                lblgeneltoplam.Text = komut.ExecuteScalar() + " TL";
                baglanti.Close();
            }
            catch (Exception)
            {

                ;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            sepetlistele();
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        private void txttc_TextChanged(object sender, EventArgs e)
        {
            if(txttc.Text=="")
            {
                txtadsoyad.Text = "";
                txttelefon.Text = "";
            }
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select * from musteri where tc like '" + txttc.Text + "'    ", baglanti);
            MySqlDataReader read = komut.ExecuteReader();

            while(read.Read())
            {
                txtadsoyad.Text = read["adsoyad"].ToString();
                txttelefon.Text = read["telefon"].ToString();
            }
            baglanti.Close();
            
        }

        private void txtbarkodno_TextChanged(object sender, EventArgs e)
        {
            temizle();

            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select * from urun where barkodno like '" + txtbarkodno.Text + "'    ", baglanti);
            MySqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {
                txturunadi.Text = read["urunadi"].ToString();
                txtsatisfiyat.Text = read["satisfiyati"].ToString();
            }
            baglanti.Close();
        }

        private void temizle()
        {
            if (txtbarkodno.Text == "")
            {
                foreach (Control item in groupBox2.Controls)
                {

                    if (item is TextBox)
                    {
                        if (item != txtmiktar)
                        {
                            item.Text = "";
                        }
                    }

                }
            }
        }


       

        private void btnekle_Click(object sender, EventArgs e)
        {
            
            
                baglanti.Open(); 
                MySqlCommand komut = new MySqlCommand("insert into sepet(tc,adsoyad,telefon,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih) values(@tc,@adsoyad,@telefon,@barkodno,@urunadi,@miktari,@satisfiyati,@toplamfiyati,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@tc", txttc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtadsoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txttelefon.Text);
                komut.Parameters.AddWithValue("@barkodno", txtbarkodno.Text);                                           
                komut.Parameters.AddWithValue("@urunadi", txturunadi.Text);
                komut.Parameters.AddWithValue("@miktari", int.Parse(txtmiktar.Text));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(txtsatisfiyat.Text));
                komut.Parameters.AddWithValue("@toplamfiyati", double.Parse(txttoplamfiyat.Text));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
            daset.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();
            temizle();

            
           
            txtmiktar .Text= "1";
           
            foreach (Control item in groupBox2.Controls)
            {

                if (item is TextBox)
                {
                    if (item != txtmiktar)
                    {
                        item.Text = "";
                    }
                }

            }
        }

        private void txtmiktar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txttoplamfiyat.Text = (double.Parse(txtmiktar.Text) * double.Parse(txtsatisfiyat.Text)).ToString();
            }
            catch (Exception)
            {

                ;
            }
        }

        private void txtsatisfiyat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txttoplamfiyat.Text = (double.Parse(txtmiktar.Text) * double.Parse(txtsatisfiyat.Text)).ToString();
            }
            catch (Exception)
            {

                ;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("delete from sepet where barkodno='"+dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString()+"'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();         
            MessageBox.Show("Ürün Sepetten Çıkarıldı");
            daset.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();
        }

        private void btnsatisiptal_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("delete from sepet", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Satış İptal Edildi");
            daset.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSatışListele listele = new frmSatışListele();
            listele.ShowDialog();
        }

        private void btnsatisyap_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("insert into satis(tc,adsoyad,telefon,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih) values(@tc,@adsoyad,@telefon,@barkodno,@urunadi,@miktari,@satisfiyati,@toplamfiyati,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@tc", txttc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtadsoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txttelefon.Text);
                komut.Parameters.AddWithValue("@barkodno",dataGridView1.Rows[i].Cells["barkodno"].Value.ToString()); // kaç tane kayıt varsa barkodno sütununa aktar
                komut.Parameters.AddWithValue("@urunadi", dataGridView1.Rows[i].Cells["urunadi"].Value.ToString());
                komut.Parameters.AddWithValue("@miktari", int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(dataGridView1.Rows[i].Cells["satisfiyati"].Value.ToString()));
                komut.Parameters.AddWithValue("@toplamfiyati", double.Parse(dataGridView1.Rows[i].Cells["toplamfiyati"].Value.ToString()));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();
                MySqlCommand komutiki = new MySqlCommand("update urun set miktari=miktari-'" + int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()) + "' where barkodno='" + dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "' ", baglanti); // satış yaptıktan sonra stoktan ürünleri düşürecek
                komutiki.ExecuteNonQuery();
                baglanti.Close();
              
               
            }
            baglanti.Open();
            MySqlCommand komutuc = new MySqlCommand("delete from sepet", baglanti);   //sepetteki kayıtları sildik
            komutuc.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();
            MessageBox.Show("Satış İşlemi Başarılı");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmXML xmlgetir = new FrmXML();
            xmlgetir.ShowDialog();
           
        }

       
    }
}
