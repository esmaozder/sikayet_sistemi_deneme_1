using System;
using System.Data.SqlClient;

namespace sikayet_sistemi_deneme_1
{
    public partial class kayit_sayfasi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnKayitOl_Click(object sender, EventArgs e)
        {
            // 1. Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtMail.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                lblMesaj.ForeColor = System.Drawing.Color.Red;
                lblMesaj.Text = "Lütfen tüm alanları doldurunuz.";
                return;
            }

            // 2. Senin veritabanı bağlantı adresin
            string baglantiAdresi = @"Data Source=.;Initial Catalog=sikayetTalepSistemi;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                try
                {
                    baglanti.Open();

                    // Aynı e-posta ile daha önce kayıt olunmuş mu kontrolü
                    string mailKontrolSorgusu = "SELECT COUNT(*) FROM kullanici WHERE kullanici_mail = @mail";
                    using (SqlCommand kontrolKomutu = new SqlCommand(mailKontrolSorgusu, baglanti))
                    {
                        kontrolKomutu.Parameters.AddWithValue("@mail", txtMail.Text.Trim());
                        int kayitSayisi = (int)kontrolKomutu.ExecuteScalar();

                        if (kayitSayisi > 0)
                        {
                            lblMesaj.ForeColor = System.Drawing.Color.Red;
                            lblMesaj.Text = "Bu e-posta adresi zaten sistemde kayıtlı.";
                            return;
                        }
                    }

                    // Yeni kullanıcıyı veritabanına ekleme
                    string sorgu = "INSERT INTO kullanici (kullanici_ad, kullanici_soyad, kullanici_mail, kullanici_sifre) VALUES (@ad, @soyad, @mail, @sifre)";

                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@ad", txtAd.Text.Trim());
                        komut.Parameters.AddWithValue("@soyad", txtSoyad.Text.Trim());
                        komut.Parameters.AddWithValue("@mail", txtMail.Text.Trim());
                        komut.Parameters.AddWithValue("@sifre", txtSifre.Text.Trim());

                        komut.ExecuteNonQuery();
                    }

                    lblMesaj.ForeColor = System.Drawing.Color.Green;
                    lblMesaj.Text = "Kayıt başarıyla tamamlandı! Artık giriş yapabilirsiniz.";

                    // Form kutularını temizle
                    txtAd.Text = "";
                    txtSoyad.Text = "";
                    txtMail.Text = "";
                }
                catch (Exception ex)
                {
                    lblMesaj.ForeColor = System.Drawing.Color.Red;
                    lblMesaj.Text = "Bir hata oluştu: " + ex.Message;
                }
            }
        }
    }
}