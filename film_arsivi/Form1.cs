using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;

namespace film_arsivi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=SerhatDemir\SQLEXPRESS;Initial Catalog=FilmArsivim;Integrated Security=True;");
       void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLFilmler ",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFilmler(AD,KATAGORI,LINK) values(@P1,@P2,@P3) ", baglanti);
            komut.Parameters.AddWithValue("@P1", txtFilmAd.Text);
            komut.Parameters.AddWithValue("@P2", txtKatagori.Text);
            komut.Parameters.AddWithValue("@P3", txtLink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Filminiz Başarıyla Eklendi ","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            filmler();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
           webBrowser.Navigate(link);
        }

        private void btnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BU PROJE SERHAT DEMİR TARAFINDAN KODLANMIŞTIR","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Warning);

        }

        private void btnÇıkış_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRenkDeğiştir_Click(object sender, EventArgs e)
        {
           


        }

    }
}
