using DevExpress.Utils.CodedUISupport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace malzemekayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();


        }
        SqlConnection baglanti = new SqlConnection("Data Source=SEYMA\\SQLEXPRESS; Initial Catalog=Stok3; Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {// BUASI EKLE BUTONU KARISTIRMA

            String t1 = textBox1.Text;// mazemekod
            String t2 = textBox2.Text;//malzeme ad
            String t3 = textBox3.Text;//yıllık satis
            String t4 = textBox4.Text;//birim fiyat
                String t5 = textBox6.Text;//minstok
                String t6= textBox7.Text;//tedarik süre
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Malzemeler (Malzemekodu, MalzemeAdi, YillikSatis, BirimFiyat, Minstok, TSuresi)VALUES('"+ t1 +"','"+ t2 +"','"+ t3 +"','"+ t4 +"','"+ t5 +"','"+ t6 +"')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();













        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {




            listele();
        }
        private void listele()// veri tabanımızdaki kayıtları görmek icin metot en güncel

        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Malzemeler", baglanti); ;
            DataTable tablo= new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource= tablo;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)//silme
        {
String t1= textBox1.Text;// secilen satırımımnın malzeme kodunu alıyo ki koda göre sileyim
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Malzemeler WHERE MalzemeKodu=('" + t1 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }

     

        private void button3_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text;// mazemekod
            String t2 = textBox2.Text;//malzeme ad
            String t3 = textBox3.Text;//yıllık satis
            String t4 = textBox4.Text;//birim fiyat
            String t5 = textBox6.Text;//minstok
            String t6 = textBox7.Text;//tedarik süre
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Malzemeler SET MalzemeKodu='"+t1+"', MalzemeAdi='"+t2+"' ,YillikSatis='"+t3+"',BirimFiyat='"+t4+"',MinStok='"+t5+"',TSuresi='"+t6+"' WHERE MalzemeKodu='"+t1+"' ",baglanti);
            komut.ExecuteNonQuery ();
            baglanti.Close();
            listele ();

        }
    }
}
