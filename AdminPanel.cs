using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlBaglantı;
using System.Data.SqlClient;


namespace BaküKasa
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }
        string kullanici = "";
        int sifre = 0;

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            txtsifre.UseSystemPasswordChar = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("admingiris", Class1.baglan);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.Add("@kullaniciad", SqlDbType.Text).Value = txtkullaniciadi.Text.ToString();
                komut.Parameters.Add("@sifre", SqlDbType.Int).Value = Convert.ToInt32(txtsifre.Text);
                Class1.baglan.Open();
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    kullanici = oku[1].ToString();
                    sifre = Convert.ToInt32(oku[2]);
                }
                if (txtkullaniciadi.Text == kullanici && txtsifre.Text == Convert.ToString(sifre))
                {
                    Class1.baglan.Close();
                    Anasayfa frm = new Anasayfa();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    Class1.baglan.Close();
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("hatalı giriş tekrar deneyiniz..");
            }
        }
        private void materialFlatButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                txtsifre.UseSystemPasswordChar = false;
            else
                txtsifre.UseSystemPasswordChar = true;
        }
    }
}
