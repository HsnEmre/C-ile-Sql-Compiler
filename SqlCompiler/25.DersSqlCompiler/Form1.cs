using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _25.DersSqlCompiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;

        void DBBaglantisi()
        {
            baglanti = new SqlConnection(@"Data Source=DESKTOP-972PD8E\SQLEXPRESS;Initial Catalog=Master;Integrated Security=True");
            baglanti.Open();
            komut = new SqlCommand("select name from sys.databases", baglanti);
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                CmbDb.Items.Add(dr[0].ToString());
            }
            baglanti.Close();
        }
        void DBDeğiştir()
        {
            baglanti = new SqlConnection(@"Data Source=DESKTOP-972PD8E\SQLEXPRESS;Initial Catalog="+CmbDb.Text+";Integrated Security=True");
            baglanti.Open();
            komut = new SqlCommand("select name from sys.databases", baglanti);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbDb.Items.Add(dr[0].ToString());
            }
            baglanti.Close();
        }
        void TabloListele()
        {
            baglanti = new SqlConnection(@"Data Source=DESKTOP-972PD8E\SQLEXPRESS;Initial Catalog=" + CmbDb.Text + ";Integrated Security=True");
            baglanti.Open();
            komut = new SqlCommand("select name from sys.Tables", baglanti);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbtablo.Items.Add(dr[0].ToString());
            }
            baglanti.Close();
        }
        void sorguYaz()
        {
            baglanti = new SqlConnection(@"Data Source=DESKTOP-972PD8E\SQLEXPRESS;Initial Catalog=" + CmbDb.Text + ";Integrated Security=True");
            baglanti.Open();
            komut = new SqlCommand(richTextBox1.Text, baglanti);
            komut.ExecuteNonQuery();
            string sorgu = richTextBox1.Text;
            da = new SqlDataAdapter(sorgu, baglanti);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBBaglantisi();
            MessageBox.Show("db açıldı");
        }

        private void CmbDb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBDeğiştir();
            TabloListele();
            MessageBox.Show("db değişti ve tablolar Yüklendi");
            
        }

        private void btnSorgu_Click(object sender, EventArgs e)
        {
            sorguYaz();
        }
    }
}
