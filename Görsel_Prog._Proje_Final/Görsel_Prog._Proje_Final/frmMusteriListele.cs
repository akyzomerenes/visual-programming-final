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
    public partial class frmMusteriListele : Form
    {
        public frmMusteriListele()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=Localhost; Database=stoktakip; uid=root; Password=;");

        DataSet daset = new DataSet(); // bilgilerimizi geçici olarak (yani köprü gibi düşünebiliriz) daset adlı tabloya aktarmak için dataset oluşturduk 

        private void frmMusteriListele_Load(object sender, EventArgs e)
        {
            Kayıt_Göster(); // Kayıt Göster adlı methodumuzu çağırdık
        }

        private void Kayıt_Göster() // Kayıt Göster adında bir methot oluşturduk
        {
            baglanti.Open(); //Bağlantıyı açtık

            MySqlDataAdapter adtr = new MySqlDataAdapter("select * from musteri", baglanti); // veritabanındaki bilgileri çekiyoruz ve datasete aktarmak için data adapter kullanıyoruz
            adtr.Fill(daset, "musteri"); //dataset daset in içini dolduruyoruz
            dataGridView1.DataSource = daset.Tables["musteri"]; // verilerimizi datagridviev ile birleştirdik
            baglanti.Close(); // Bağlantıyı Kapatık
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) // DATAGRİDVİEV DEKİ VERİLERİN ÜSTÜNE ÇİFT TIKLANDIĞINDA GÜNCELLEME EKRANINDAKİ TEXBOX LARA TIKLANAN KİŞİLERİN BİLGİLERİ GELSİN
        {
            txtTC.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            txtADSOYAD.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
            txtTELEFON.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            txtEMAİL.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
            txtADRES.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open(); // Bağlantıyı açtık

            MySqlCommand komut = new MySqlCommand("update musteri set adsoyad=@adsoyad,telefon=@telefon,adres=@adres,email=@email where tc=@tc", baglanti); // query mizi yazdık

            komut.Parameters.AddWithValue("@tc", txtTC.Text); 

            komut.Parameters.AddWithValue("@adsoyad", txtADSOYAD.Text);
            komut.Parameters.AddWithValue("@telefon", txtTELEFON.Text);
            komut.Parameters.AddWithValue("@adres", txtADRES.Text);
            komut.Parameters.AddWithValue("@email", txtEMAİL.Text);

            komut.ExecuteNonQuery(); //komutumuzu çalıştırdık

            baglanti.Close(); //bağlantıyı kapattık

            daset.Tables["musteri"].Clear(); // geçici olarak oluşturduğumuz tablonun içindeki verileri temizledik

            Kayıt_Göster(); //Daset adlı tablomuzun içindeki verileri sildik , verileri update ettik ve sonra en son halini (güncel)  kayıt göster adlı methodumuz ile gösterdik


            MessageBox.Show("Müşteri Kaydı Güncellendi"); // ekrana mesaj ilettik


            foreach (Control item in this.Controls) // foreach döngüsü ile formun içindeki elemanları kontrol ediyoruz.
            {
                if (item is TextBox) // eğer formun içindeki elemanlardan texbox bulursan içini temizle diyoruz
                {
                    item.Text = "";
                }
            }
        }

        private void btnSİL_Click(object sender, EventArgs e)
        {
            baglanti.Open(); //BAĞLANTIYI AÇTIK

            MySqlCommand komut = new MySqlCommand("delete from musteri where tc= '"+dataGridView1.CurrentRow.Cells["tc"].Value.ToString()+"'  ",baglanti); //QUERY MİZİ YAZDIK
            komut.ExecuteNonQuery(); //QUERY Yİ ÇALIŞTIRDIK
            baglanti.Close();


            daset.Tables["musteri"].Clear(); //DATAGRİDVİEVE VERİ AKTARAN TABLOMUZUN İÇİNİ TEMİZLEDİK

            Kayıt_Göster(); // DELETE YAPISINI KULLANDIĞIMIZ İÇİN KAYIT GÖSTERİN İÇİNDE SEÇİLİ OLANIN HAKKINDA BİR BİLGİ BULAMIYOR(SİLDİĞİMİZ İÇİN) VE KAYITLARI SİLMİŞ OLUYOR

            MessageBox.Show("Kayıt Silindi"); // EKRANA MESAJ İLETTİK

        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();   // geçici olarak bir tablo oluşturduk

            baglanti.Open(); // bağlantıyı açtık

            MySqlDataAdapter adtr = new MySqlDataAdapter("select * from musteri where tc like '%" + txtTcAra.Text + "%'", baglanti); //oluşturduğumuz geçici tablonun içine verilerimizi almak için query yazık

            adtr.Fill(tablo); // tablo adlı değişkenimizin içini doldurduk

            dataGridView1.DataSource = tablo; // data grid vievin içini geçici olarak oluşturduğumuz tablo nun içindeki verileri birleştirdik

            baglanti.Close(); // bağlantıyı kapattık

        }

        private void txtTcAra_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtTC_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
