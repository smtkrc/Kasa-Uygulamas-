using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SqlBaglantı;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Windows.Forms.VisualStyles;
using System.Media;
using System.Windows.Forms.DataVisualization.Charting;

namespace BaküKasa
{



public partial class Anasayfa : MaterialForm
{

    int secilenıdgelirgun;
    int secilenıdgidergun;
    int secilenpergun;
    int secilengiderturgun;
    int secilenparabirimidgun;
    int secilenkullanıcı;
    //Combobox Veri listeleme Bölümü
    public void ComboboxGider()
    {
        try
        {
            Class1.baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("exec personellistetamamı", Class1.baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbgiderper.DataSource = dt;
            cmbgiderper.DisplayMember = "PERSONELADSOYAD";
            cmbgiderper.ValueMember = "PERSONELID";
            Class1.baglan.Close();
            Class1.baglan.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("exec parabirimilistetamamı", Class1.baglan);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cmbgiderparabirim.DataSource = dt2;
            cmbgiderparabirim.DisplayMember = "PARABIRIMAD";
            cmbgiderparabirim.ValueMember = "PARAID";
            Class1.baglan.Close();
            Class1.baglan.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("exec harcamatürütamlist", Class1.baglan);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            cmbgiderhtürü.DataSource = dt3;
            cmbgiderhtürü.DisplayMember = "HKATEGORIAD";
            cmbgiderhtürü.ValueMember = "HKATEGORIID";
            cmbgidergunharcamaturu.DataSource = dt3;
            cmbgidergunharcamaturu.DisplayMember = "HKATEGORIAD";
            cmbgidergunharcamaturu.ValueMember = "HKATEGORIID";
            Class1.baglan.Close();
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hata oluştu lütfen programı tekrar başlatınız");
        }
    }
    public void comboboxgelirekle()
    {
        try
        {
            Class1.baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("exec personellistetamamı", Class1.baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "PERSONELADSOYAD";
            comboBox1.ValueMember = "PERSONELID";
            cmbgelirgüncelleperad.DataSource = dt;
            cmbgelirgüncelleperad.DisplayMember = "PERSONELADSOYAD";
            cmbgelirgüncelleperad.ValueMember = "PERSONELID";
            cmbgidergunperlist.DataSource = dt;
            cmbgidergunperlist.DisplayMember = "PERSONELADSOYAD";
            cmbgidergunperlist.ValueMember = "PERSONELID";
            Class1.baglan.Close();
            Class1.baglan.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("exec parabirimilistetamamı", Class1.baglan);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "PARABIRIMAD";
            comboBox2.ValueMember = "PARAID";
            cmbgelirguncelleparabirim.DataSource = dt2;
            cmbgelirguncelleparabirim.DisplayMember = "PARABIRIMAD";
            cmbgelirguncelleparabirim.ValueMember = "PARAID";
            cmbgidergunparabirim.DataSource = dt2;
            cmbgidergunparabirim.DisplayMember = "PARABIRIMAD";
            cmbgidergunparabirim.ValueMember = "PARAID";
            Class1.baglan.Close();
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hata oluştu lütfen tekrar deneyiniz.");
        }
    }

    //Gelirler Bölümü(List,İnsert,Update,Delete)
    public void Gelirliste()
    {
        try
        {
            Class1.baglan.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec paragirisiliste", Class1.baglan);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView7.DataSource = dt;
            Class1.baglan.Close();
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hata oluştu tekrar deneyiniz");
        }
    }
    public void gelirekle()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("Gelirekle", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", comboBox1.SelectedValue);
            komut.Parameters.AddWithValue("@P2", txttutar.Text);
            komut.Parameters.AddWithValue("@P3", comboBox2.SelectedValue);
            komut.Parameters.AddWithValue("@P4", txtaciklama.Text);
            komut.Parameters.AddWithValue("@P5", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@P6", "True");
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            MessageBox.Show("Başarıyla kaydedildi");
            Gelirliste();
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hatalı giriş yaptınız tüm alanları doldurunuz");
        }
    }
    public void GelirGuncelle()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("gelirguncelle", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", cmbgelirgüncelleperad.SelectedValue);
            komut.Parameters.AddWithValue("@P2", txtgelirguncelletutar.Text);
            komut.Parameters.AddWithValue("@P3", cmbgelirguncelleparabirim.SelectedValue);
            komut.Parameters.AddWithValue("@P4", txtgelirguncelleaciklama.Text);
            komut.Parameters.AddWithValue("@P5", dtpgelirguncelletarih.Text);
            komut.Parameters.AddWithValue("@P6", secilenıdgelirgun);
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            Gelirliste();
            MessageBox.Show("Güncelleme başarıyla kaydedildi.");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz..");
        }
    }
    public void GelirSil()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("GelirSil", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", secilenıdgelirgun);
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            Gelirliste();
            MessageBox.Show("Silme işlemi başarıyla gerçekleşti");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Silme İşlemi başarısız oldu, bilgileri kontrol ederek tekrar deneyiniz.");
        }

    }

    //Giderler Bölümü (List,İnsert,Update,Delete)
    public void Harcamaliste()
    {
        try
        {
            Class1.baglan.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec harcamalistesi", Class1.baglan);
            da.Fill(dt);
            dataGridView8.DataSource = dt;
            dataGridView2.DataSource = dt;
            Class1.baglan.Close();
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hata oluştu tekrar deneyiniz");
        }
    }
    public void GiderGuncelle()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("harcamaguncelle", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", secilenıdgidergun);
            komut.Parameters.AddWithValue("@P2", cmbgidergunharcamaturu.SelectedValue);
            komut.Parameters.AddWithValue("@P3", txtgidergunaciklama.Text);
            komut.Parameters.AddWithValue("@P4", txtgiderguntutar.Text);
            komut.Parameters.AddWithValue("@P5", cmbgidergunparabirim.SelectedValue);
            komut.Parameters.AddWithValue("@P6", dtpgiderguntarih.Text);
            komut.Parameters.AddWithValue("@P7", cmbgidergunperlist.SelectedValue);
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            MessageBox.Show("Güncelleme başarıyla kaydedildi.");
            Harcamaliste();
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hata oluştu lütfen bilgileri kontrol ederek tekrar deneyiniz");
        }
    }
    public void GiderSil()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("GiderSil", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", secilenıdgidergun);
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            Harcamaliste();
            MessageBox.Show("Silme işlemi başarıyla gerçekleşti");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Silme İşlemi başarısız oldu, bilgileri kontrol ederek tekrar deneyiniz.");
        }

    }
    public void giderekle()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("harcamaekle", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", cmbgiderhtürü.SelectedValue);
            komut.Parameters.AddWithValue("@P2", txtacıklamagider.Text);
            komut.Parameters.AddWithValue("@P3", txttutargider.Text);
            komut.Parameters.AddWithValue("@P4", cmbgiderparabirim.SelectedValue);
            komut.Parameters.AddWithValue("@P5", dtpgider.Text);
            komut.Parameters.AddWithValue("@P6", cmbgiderper.SelectedValue);
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            Harcamaliste();
            MessageBox.Show("Başarıyla kaydedildi");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hatalı giriş lütfen bilgileri kontrol ediniz.");
        }
    }

    //Personel Bölümü(List,İnsert,Update,Delete) (List,İnsert,Update,Delete)
    public void Personelliste()
    {
        try
        {
            Class1.baglan.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec personeliliste", Class1.baglan);
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            dataGridView9.DataSource = dt;
            Class1.baglan.Close();
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hata oluştu tekrar deneyiniz");
        }
    }
    public void personelekle()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("personelekle", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", txtperadsoyadperlist.Text);
            komut.Parameters.AddWithValue("@P2", "True");
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            Personelliste();
            MessageBox.Show("Başarıyla kaydedildi.");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Lütfen bilgileri kontrol ederek tekrar deneyiniz.");
        }
    }
    public void PersonelGuncelle()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("PersonelGuncelle", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", secilenpergun);
            komut.Parameters.AddWithValue("@P2", txtpergunperad.Text);
            komut.Parameters.AddWithValue("@P3", "True");
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            Personelliste();
            MessageBox.Show("Güncelleme işlemi başarıyla gerçekleştirildi.");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hata oluştu lütfen bilgileri kontrol ederek tekrar deneyiniz");
        }
    }
    public void PersonelSil()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("PersonelSil", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", secilenpergun);
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            Personelliste();
            MessageBox.Show("Silme işlemi başarıyla gerçekleşti");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Silme İşlemi başarısız oldu, bilgileri kontrol ederek tekrar deneyiniz.");
        }

    }

    //Para birimi bölümü (List,İnsert,Update,Delete)
    public void ParaBirimiliste()
    {
        try
        {
            Class1.baglan.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec parabirimiliste", Class1.baglan);
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            dataGridView11.DataSource = dt;
            Class1.baglan.Close();
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hata oluştu tekrar deneyiniz");
        }
    }
    public void parabirimiekle()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("parabirimekle", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", txtyeniparabirim.Text);
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            ParaBirimiliste();
            MessageBox.Show("Başarıyla kaydedildi.");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hatalı giriş yaptınız bilgileri kontrol ediniz.");
        }
    }
    public void ParaBirimGuncelle()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("ParaBirimGuncelle", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", secilenparabirimidgun);
            komut.Parameters.AddWithValue("@P2", txtparabirimgunad.Text);
            komut.Parameters.AddWithValue("@P3", "True");
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            ParaBirimiliste();
            MessageBox.Show("Güncelleme başarıyla kaydedildi.");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("hatalı giriş yaptınız bilgileri kontrol ederek tekrar deneyiniz.");
        }
    }
    public void ParaBirimiSil()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("ParaBirimiSil", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", secilenparabirimidgun);
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            ParaBirimiliste();
            MessageBox.Show("Silme işlemi başarıyla gerçekleşti");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Silme İşlemi başarısız oldu, bilgileri kontrol ederek tekrar deneyiniz.");
        }
    }
    //Harcama Türü bölümü (List,İnsert,Update,Delete)
    public void Harcamatürliste()
    {
        try
        {
            Class1.baglan.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec kategoriliste", Class1.baglan);
            da.Fill(dt);
            dataGridView5.DataSource = dt;
            dataGridView10.DataSource = dt;
            Class1.baglan.Close();
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hata oluştu tekrar deneyiniz");
        }
    }
    public void harcamatürüekle()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("harcamatürekle", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", txtyeniharcamatür.Text);
            komut.Parameters.AddWithValue("@P2", txtyeniharcamaaciklama.Text);
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            Harcamatürliste();
            MessageBox.Show("Başarıyla kaydedildi");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hatalı giriş bilgileri kontrol ediniz");
        }
    }
    public void HarcamaTurGuncelle()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("HarcamaTurGuncelle", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", secilengiderturgun);
            komut.Parameters.AddWithValue("@P2", txtgidergunturad.Text);
            komut.Parameters.AddWithValue("@P3", txtgidergunturacık.Text);
            komut.Parameters.AddWithValue("@P4", "True");
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            Harcamatürliste();
            MessageBox.Show("Harcama türü başarıyla güncellendi");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hata oluştu lütfen bilgileri kontrol ederek tekrar deneyiniz");
        }
    }
    public void HarcamaTurSil()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("HarcamaTurSil", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", secilengiderturgun);
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            Harcamatürliste();
            MessageBox.Show("Silme işlemi başarıyla gerçekleşti");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Silme İşlemi başarısız oldu, bilgileri kontrol ederek tekrar deneyiniz.");
        }
    }

    //Kullanıcı Bilgileri Bölümü (List,İnsert,Update,Delete)
    public void KullaniciListesi()
    {
        try
        {
            Class1.baglan.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec kullanicilistesi", Class1.baglan);
            da.Fill(dt);
            dataGridView6.DataSource = dt;
            dataGridView12.DataSource = dt;
            Class1.baglan.Close();
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hata oluştu lütfen tekrar deneyiniz.");
        }
    }
    public void kullaniciekle()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("kullanicieklee", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", txtyenikullaniciad.Text);
            komut.Parameters.AddWithValue("@P2", Convert.ToInt32(txtyenikullanicisifre.Text));
            komut.Parameters.AddWithValue("@P3", "True");
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            KullaniciListesi();
            MessageBox.Show("Başarıyla kaydedildi.");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hatalı giriş yaptınız lütfen bilgileri kontrol ediniz");
        }

    }
    public void KullaniciGuncelle()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("KullanıcıGuncelle", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", secilenkullanıcı);
            komut.Parameters.AddWithValue("@P2", txtkullanicigunad.Text);
            komut.Parameters.AddWithValue("@P3", txtkullanicigunsifre.Text);
            komut.Parameters.AddWithValue("@P4", "True");
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            KullaniciListesi();
            MessageBox.Show("Güncelleme başarıyla kaydedildi.");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Hatalı giriş yaptınız lütfen bilgilerinizi kontrol edip tekrar deneyiniz.");
        }
    }
    public void KullaniciSil()
    {
        try
        {
            Class1.baglan.Open();
            SqlCommand komut = new SqlCommand("KullaniciSil", Class1.baglan);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@P1", secilenkullanıcı);
            komut.ExecuteNonQuery();
            Class1.baglan.Close();
            KullaniciListesi();
            MessageBox.Show("Silme işlemi başarıyla gerçekleşti");
        }
        catch (Exception)
        {
            Class1.baglan.Close();
            MessageBox.Show("Silme İşlemi başarısız oldu, bilgileri kontrol ederek tekrar deneyiniz.");
        }
    }
    //DataGridView de bulunan verileri ToolBox lara atama
    private void dataGridView9_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            secilenpergun = int.Parse(dataGridView9.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtpergunperad.Text = dataGridView9.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        catch (Exception)
        {
            MessageBox.Show("Lütfen dolu bir satır seçiniz.");
        }
    }
    private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            secilenıdgelirgun = int.Parse(dataGridView7.Rows[e.RowIndex].Cells[0].Value.ToString());
            cmbgelirgüncelleperad.Text = dataGridView7.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtgelirguncelletutar.Text = dataGridView7.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtgelirguncelleaciklama.Text = dataGridView7.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbgelirguncelleparabirim.Text = dataGridView7.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtpgelirguncelletarih.Text = dataGridView7.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
        catch (Exception)
        {
            MessageBox.Show("Lütfen dolu bir satır seçiniz..");
        }
    }
    private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            secilenıdgidergun = int.Parse(dataGridView8.Rows[e.RowIndex].Cells[0].Value.ToString());
            cmbgidergunharcamaturu.Text = dataGridView8.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtgidergunaciklama.Text = dataGridView8.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtgiderguntutar.Text = dataGridView8.Rows[e.RowIndex].Cells[3].Value.ToString();
            cmbgidergunparabirim.Text = dataGridView8.Rows[e.RowIndex].Cells[4].Value.ToString();
            dtpgiderguntarih.Text = dataGridView8.Rows[e.RowIndex].Cells[5].Value.ToString();
            cmbgidergunperlist.Text = dataGridView8.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
        catch (Exception)
        {
            MessageBox.Show("Lütfen dolu bir satır seçiniz");
        }
    }
    private void dataGridView10_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            secilengiderturgun = int.Parse(dataGridView10.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtgidergunturad.Text = dataGridView10.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtgidergunturacık.Text = dataGridView10.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        catch (Exception)
        {
            MessageBox.Show("Lütfen dolu bir satır seçiniz.");
        }
    }
    private void dataGridView11_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            secilenparabirimidgun = int.Parse(dataGridView11.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtparabirimgunad.Text = dataGridView11.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        catch (Exception)
        {
            MessageBox.Show("Lütfen dolu bir satır seçiniz");
        }
    }
    private void dataGridView12_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            secilenkullanıcı = int.Parse(dataGridView12.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtkullanicigunad.Text = dataGridView12.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtkullanicigunsifre.Text = dataGridView12.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        catch (Exception)
        {
            MessageBox.Show("Lütfen dolu bir satır seçiniz");
        }
    }

    //Kasa ve İstatistikler bölümü
    //Label istatistik verileri
    public void KasaVeİstatistikler()
    {
        Class1.baglan.Open();
        SqlCommand komut1 = new SqlCommand("ToplamGelirler", Class1.baglan);
        komut1.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataReader oku = komut1.ExecuteReader();
        while (oku.Read())
        {
            int deger1 = Convert.ToInt32(oku[0]);
            label59.Text = deger1.ToString();
        }
        Class1.baglan.Close();
        Class1.baglan.Open();
        SqlCommand komut2 = new SqlCommand("ToplamHarcamalar", Class1.baglan);
        komut2.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataReader oku2 = komut2.ExecuteReader();
        while (oku2.Read())
        {
            int deger2 = Convert.ToInt32(oku2[0]);
            label60.Text = deger2.ToString();
        }
        Class1.baglan.Close();
        int Gelir, Gider;
        Gelir = Convert.ToInt32(label59.Text);
        Gider = Convert.ToInt32(label60.Text);
        label58.Text = (Gelir - Gider).ToString();
        Class1.baglan.Open();
        SqlCommand komut3 = new SqlCommand("SonAyGelirToplam", Class1.baglan);
        komut3.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataReader oku3 = komut3.ExecuteReader();
        while (oku3.Read())
        {
            int deger3 = Convert.ToInt32(oku3[1]);
            label61.Text = deger3.ToString();
        }
        Class1.baglan.Close();
        Class1.baglan.Open();
        SqlCommand komut4 = new SqlCommand("SonAyharcamalarToplam", Class1.baglan);
        komut4.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataReader oku4 = komut4.ExecuteReader();
        while (oku4.Read())
        {
            int deger4 = Convert.ToInt32(oku4[1]);
            label62.Text = deger4.ToString();
        }
        Class1.baglan.Close();
        Class1.baglan.Open();
        SqlCommand komut5 = new SqlCommand("GunlukOrtalamaHarcama", Class1.baglan);
        komut5.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataReader oku5 = komut5.ExecuteReader();
        while (oku5.Read())
        {
            int deger5 = Convert.ToInt32(oku5[0]);
            label63.Text = deger5.ToString();
        }
        Class1.baglan.Close();
        Class1.baglan.Open();
        SqlCommand komut6 = new SqlCommand("EnCokHarcamaYapilanTur", Class1.baglan);
        komut6.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataReader oku6 = komut6.ExecuteReader();
        while (oku6.Read())
        {
            string deger6 = (oku6[0]).ToString();
            label64.Text = deger6;
        }
        Class1.baglan.Close();
        Class1.baglan.Open();
        SqlCommand komut7 = new SqlCommand("ToplamPersonelAdet", Class1.baglan);
        komut7.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataReader oku7 = komut7.ExecuteReader();
        while (oku7.Read())
        {
            int deger7 = Convert.ToInt32(oku7[0]);
            label65.Text = deger7.ToString();
        }
        Class1.baglan.Close();
    }
    //Chart Grafik verileri
    public void GrafikVerileri()
    {
        foreach (var item in chart1.Series)
        {
            item.Points.Clear();
        }
        SqlCommand komut = new SqlCommand("AylıkHarcamalar", Class1.baglan);
        komut.CommandType = System.Data.CommandType.StoredProcedure;
        Class1.baglan.Open();
        SqlDataReader dr = komut.ExecuteReader();
        int sayac = 0;
        while (dr.Read())
        {
            chart1.Series["Harcamalar"].Points.Add(Convert.ToInt32(dr[1]));
            chart1.Series["Harcamalar"].Points[sayac].AxisLabel = dr[0].ToString();
            sayac = sayac + 1;
        }
        Class1.baglan.Close();
        SqlCommand komut2 = new SqlCommand("AylıkGelirler", Class1.baglan);
        komut2.CommandType = System.Data.CommandType.StoredProcedure;
        Class1.baglan.Open();
        SqlDataReader dr2 = komut2.ExecuteReader();
        int sayac2 = 0;
        while (dr2.Read())
        {
            chart1.Series["Gelirler"].Points.Add(Convert.ToInt32(dr2[1]));
            chart1.Series["Gelirler"].Points[sayac2].AxisLabel = dr2[0].ToString();
            sayac2 = sayac2 + 1;
        }
        Class1.baglan.Close();
    }

    //Form Ilk Yükleme
    public Anasayfa()
    {
        InitializeComponent();
    }
    private void txtyenikullanicisifre_MouseClick(object sender, MouseEventArgs e)
    {
        label24.Visible = true;
    }
    private void txtyenikullaniciad_MouseClick(object sender, MouseEventArgs e)
    {
        label47.Visible = true;
    }
    private void textBox2_MouseClick(object sender, MouseEventArgs e)
    {
        label46.Visible = true;
    }

    private void textBox1_MouseClick(object sender, MouseEventArgs e)
    {
        label42.Visible = true;
    }
    private void Form1_Load(object sender, EventArgs e)
    {

        Gelirliste();
        Harcamaliste();
        Personelliste();
        ParaBirimiliste();
        Harcamatürliste();
        comboboxgelirekle();
        KullaniciListesi();
        ComboboxGider();
        KasaVeİstatistikler();
        GrafikVerileri();
    }

    //admin giriş paneli açılış butonu
    private void materialFlatButton1_Click(object sender, EventArgs e)
    {
        AdminPanel adm = new AdminPanel();
        adm.Show();
        this.Close();
    }

    //Ekleme butonları
    private void button8_Click_1(object sender, EventArgs e)
    {
        harcamatürüekle();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        gelirekle();
    }
    private void btnkaydetgider_Click(object sender, EventArgs e)
    {
        giderekle();
    }
    private void btnpersonelkaydet_Click(object sender, EventArgs e)
    {
        personelekle();
    }
    private void button7_Click_1(object sender, EventArgs e)
    {
        parabirimiekle();
    }
    private void button9_Click_1(object sender, EventArgs e)
    {
        kullaniciekle();
    }

    //Güncelleme Butonları
    private void button10_Click(object sender, EventArgs e)
    {
        GelirGuncelle();
    }

    private void button2_Click_1(object sender, EventArgs e)
    {
        GiderGuncelle();
    }

    private void button3_Click_1(object sender, EventArgs e)
    {
        PersonelGuncelle();
    }
    private void button4_Click_1(object sender, EventArgs e)
    {
        HarcamaTurGuncelle();
    }
    private void button5_Click(object sender, EventArgs e)
    {
        ParaBirimGuncelle();
    }
    private void button6_Click(object sender, EventArgs e)
    {
        KullaniciGuncelle();
    }

    //Silme butonları
    private void button11_Click(object sender, EventArgs e)
    {
        GelirSil();
    }
    private void button12_Click(object sender, EventArgs e)
    {
        GiderSil();
    }
    private void button13_Click(object sender, EventArgs e)
    {
        PersonelSil();
    }
    private void button15_Click(object sender, EventArgs e)
    {
        ParaBirimiSil();
    }
    private void button14_Click(object sender, EventArgs e)
    {
        HarcamaTurSil();
    }
    private void button16_Click(object sender, EventArgs e)
    {
        KullaniciSil();
    }
}
}
