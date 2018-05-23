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

namespace YaizlimYapimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-IC1ASAB\\BARTENDER;Initial Catalog=YzmTasarim;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            verigörüntüle();
        }
        private void verigörüntüle()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From Yzm", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Stories"].ToString());
                ekle.SubItems.Add(oku["NotStarted"].ToString());
                ekle.SubItems.Add(oku["InProgress"].ToString());
                ekle.SubItems.Add(oku["Done"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From Yzm",baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Stories"].ToString());
                ekle.SubItems.Add(oku["NotStarted"].ToString());
                ekle.SubItems.Add(oku["InProgress"].ToString());
                ekle.SubItems.Add(oku["Done"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Yzm (Stories,NotStarted,InProgress,Done) values('"+textBox1.Text.ToString()+ "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "')",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            verigörüntüle();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand sil = new SqlCommand("Delete From Yzm where id=("+id+")",baglan);
            sil.ExecuteNonQuery();
            baglan.Close();
            id = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            verigörüntüle();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand ekle = new SqlCommand("UPDATE Yzm set Stories='"+textBox1.Text.ToString()+ "',NotStarted='" + textBox2.Text.ToString()+"',InProgress='" + textBox3.Text.ToString() + "',Done='" + textBox4.Text.ToString() + "'  WHERE id="+id+" ",baglan);
            ekle.ExecuteNonQuery();
            baglan.Close();
            id = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            verigörüntüle();
        }
    }
}
