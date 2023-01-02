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
    public partial class frmMarka : Form
    {
        public frmMarka()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=Localhost; Database=stoktakip; uid=root; Password=;");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();       //Bağlantıyı Açtım
            MySqlCommand komut = new MySqlCommand("insert into markabilgileri(kategori,marka) values('"+comboBox1.Text+"','" + textBox1.Text + "')", baglanti); // Gerekli Olan Queryi Yazdım
            komut.ExecuteNonQuery(); //Komutu Çalıştırdım
            baglanti.Close();        //Bağlantıyı Kapattım
            textBox1.Text = "";     // Texbox içinde ki verileri temizledim
            comboBox1.Text = "";     // Combo box içinde ki verileri temizledim
            MessageBox.Show("Marka Eklendi"); // Kullanıcıya Mesaj Vermesini Sağladım
        }

        private void frmMarka_Load(object sender, EventArgs e)
        {
            kategorigetir(); // frm marka isminde oluşturduğum form yüklenince kategoriyi getirmesi için methodumu çağırdım.
        }

        private void kategorigetir()
        {
            baglanti.Open();   //Bağlantıyı Açtım

            MySqlCommand komut = new MySqlCommand("select * from kategoribilgileri", baglanti); // Gerekli Olan Queryi Yazdım
            MySqlDataReader read = komut.ExecuteReader(); // Queryi okumasını sağladım

            while (read.Read())      //Veritabanında ki verileri alacağım için ve kaç tane veri olduğunu bilmediğim için while döngüsü ile okumaya devam ettiği sürece demek istedim
            {
                comboBox1.Items.Add(read["kategori"].ToString());  // combobox a veritabanında ki kategori isimli veriyi al dedim
            }
            baglanti.Close(); // Bağlantıyı Kapatmasını Sağladım
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
