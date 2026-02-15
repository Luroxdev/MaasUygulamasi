using System; // Temel .NET sınıfları
using System.Collections.Generic; // Generic koleksiyonlar
using System.ComponentModel; // Bileşen işlemleri
using System.Data; // Veri işlemleri
using System.Drawing; // Grafik işlemleri
using System.Linq; // LINQ işlemleri
using System.Text; // Metin işlemleri
using System.Threading.Tasks; // Asenkron işlemler
using System.Windows.Forms; // Windows Form kütüphanesi
using System.Data.OleDb; // Access veritabanı bağlantısı

namespace Maaş_Uygulaması // Proje isim alanı
{
    public partial class Form1 : Form // Form sınıfı
    {
        public Form1()
        {
            InitializeComponent(); // Form bileşenlerini başlatır
        }

        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Erdem\\Documents\\MaaşSistemi.mdb"); // Access bağlantısı
        OleDbCommand cmd = new OleDbCommand(); // SQL komut nesnesi
        DataSet ds = new DataSet(); // Verileri tutmak için dataset
        string maas; // Maaş değişkeni

        private void verilerigöster()
        {
            connect.Open(); // Bağlantıyı açar

            ds.Tables.Clear(); // Dataset içini temizler

            OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT * FROM Maaş", connect); // Maaş tablosunu çeker
            adtr.Fill(ds, "Maaş"); // Dataset içine doldurur
            dataGridView1.DataSource = ds.Tables["Maaş"]; // DataGridView’e bağlar

            connect.Close(); // Bağlantıyı kapatır
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verilerigöster(); // Listeleme butonu
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "") // Boş alan kontrolü
            {
                DialogResult result = MessageBox.Show("Boş alan bırakmayınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); // Hata mesajı
                if (result == DialogResult.OK)
                {
                    return; // İşlemi durdurur
                }
            }
            else
            {
                connect.Open(); // Bağlantıyı açar

                if (comboBox1.SelectedIndex == 0) // 1. pozisyon
                {
                    if (comboBox2.SelectedIndex == 0) // 1. deneyim
                    {
                        maas = "20.000"; // Maaş atanır
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        maas = "70.000";
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        maas = "100.000";
                    }
                    else if (comboBox2.SelectedIndex == 3)
                    {
                        maas = "150.000";
                    }
                }

                else if (comboBox1.SelectedIndex == 1) // 2. pozisyon
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        maas = "15.000";
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        maas = "55.000";
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        maas = "80.000";
                    }
                    else if (comboBox2.SelectedIndex == 3)
                    {
                        maas = "110.000";
                    }
                }

                else if (comboBox1.SelectedIndex == 2) // 3. pozisyon
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        maas = "15.000";
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        maas = "60.000";
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        maas = "90.000";
                    }
                    else if (comboBox2.SelectedIndex == 3)
                    {
                        maas = "120.000";
                    }
                }

                else if (comboBox1.SelectedIndex == 3) // 4. pozisyon
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        maas = "20.000";
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        maas = "60.000";
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        maas = "80.000";
                    }
                    else if (comboBox2.SelectedIndex == 3)
                    {
                        maas = "120.000";
                    }
                }

                else if (comboBox1.SelectedIndex == 4) // 5. pozisyon
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        maas = "16.000";
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        maas = "55.000";
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        maas = "65.000";
                    }
                    else if (comboBox2.SelectedIndex == 3)
                    {
                        maas = "100.000";
                    }
                }

                cmd.Connection = connect; // Komutu bağlantıya bağlar

                cmd.CommandText = "INSERT INTO Maaş (Ad, Soyad, Pozisyon, Deneyim, IBAN, Telefon, Ücret) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + maas + "')"; // Yeni kayıt ekler
                cmd.ExecuteNonQuery(); // Komutu çalıştırır
                connect.Close(); // Bağlantıyı kapatır

                textBox1.Clear(); // Alanları temizler
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.SelectedItem = null;
                comboBox2.SelectedItem = null;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "") // Silme için kimlik boş mu kontrol
            {
                DialogResult result = MessageBox.Show("Boş alan Bırakmayınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    return;
                }
            }
            else
            {
                connect.Open(); // Bağlantıyı açar

                cmd.Connection = connect;
                cmd.CommandText = "DELETE FROM Maaş WHERE Kimlik=" + textBox5.Text; // Kimliğe göre silme

                cmd.ExecuteNonQuery(); // Komutu çalıştırır
                connect.Close(); // Bağlantıyı kapatır
                verilerigöster(); // Listeyi yeniler

                textBox5.Clear(); // Alanı temizler
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "") // Güncelleme boş kontrol
            {
                DialogResult result = MessageBox.Show("Boş Alan Bırakmayınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    return;
                }
            }
            else
            {
                connect.Open(); // Bağlantıyı açar

                if (comboBox1.SelectedIndex == 0)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        maas = "20.000";
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        maas = "70.000";
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        maas = "100.000";
                    }
                    else if (comboBox2.SelectedIndex == 3)
                    {
                        maas = "150.000";
                    }
                }

                else if (comboBox1.SelectedIndex == 1)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        maas = "15.000";
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        maas = "55.000";
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        maas = "80.000";
                    }
                    else if (comboBox2.SelectedIndex == 3)
                    {
                        maas = "110.000";
                    }
                }

                else if (comboBox1.SelectedIndex == 2)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        maas = "15.000";
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        maas = "60.000";
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        maas = "90.000";
                    }
                    else if (comboBox2.SelectedIndex == 3)
                    {
                        maas = "120.000";
                    }
                }

                else if (comboBox1.SelectedIndex == 3)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        maas = "20.000";
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        maas = "60.000";
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        maas = "80.000";
                    }
                    else if (comboBox2.SelectedIndex == 3)
                    {
                        maas = "120.000";
                    }
                }

                else if (comboBox1.SelectedIndex == 4)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        maas = "16.000";
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        maas = "55.000";
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        maas = "65.000";
                    }
                    else if (comboBox2.SelectedIndex == 3)
                    {
                        maas = "100.000";
                    }
                }

                cmd.Connection = connect;

                cmd.CommandText = "UPDATE Maaş SET Ad= '" + textBox1.Text + "', Soyad= '" + textBox2.Text + "', Pozisyon= '" + comboBox1.Text + "', Deneyim= '" + comboBox2.Text + "', IBAN= '" + textBox3.Text + "', Telefon= '" + textBox4.Text + "', Ücret= '" + maas + "' " + "WHERE Kimlik= " + textBox5.Text; // Güncelleme sorgusu
                cmd.ExecuteNonQuery(); // Komutu çalıştırır
                connect.Close(); // Bağlantıyı kapatır
                verilerigöster(); // Listeyi yeniler

                textBox1.Clear(); // Alanları temizler
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                comboBox1.SelectedItem = null;
                comboBox2.SelectedItem = null;
            }
        }
    }
}
