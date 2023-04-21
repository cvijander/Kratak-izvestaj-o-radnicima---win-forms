using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kratak_izvestaj
{
    public partial class Form1 : Form
    {
        private OleDbConnection konekcija = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =C:\Users\Cvijander\source\repos\Relja napredni kurs\Kratak izvestaj\Kratak izvestaj\bin\Debug\baza.mdb");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ukupan broj radnika
            try
            {
                konekcija.Open();
                string tekstKomande = "select COUNT(sfRadnik) from Radnik";
                OleDbCommand komanda = new OleDbCommand(tekstKomande, konekcija);
                textBox1.Text = komanda.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska prilikom prebrojavanja svih radnika" + ex.Message);
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }
            //radnici sa velikom platom

            try
            {
                konekcija.Open();
                string tekstKomande = "select COUNT(sfRadnik) from Radnik where plata > 100000";
                OleDbCommand komanda = new OleDbCommand(tekstKomande, konekcija);
                textBox2.Text = komanda.ExecuteScalar().ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show("Greska prilikom ispisivana radnika sa najvecom platom " + x.Message);
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }

            //radnici sa platom izmedju 50 i 100 000
            try
            {
                konekcija.Open();
                string tekstKomande = "select COUNT(sfRadnik) from Radnik where plata<= 100000 and plata >= 50000";
                OleDbCommand komanda = new OleDbCommand(tekstKomande, konekcija);
                textBox3.Text = komanda.ExecuteScalar().ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show("Greska prilikom prebrojavanja radnika sa platom izmedju 50 i 100 000 " + x.Message);
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }

            // radnici sa platom manjom od 50 000
            try
            {
                konekcija.Open();
                string tekstKomande = "select COUNT(sfRadnik) from Radnik where plata< 50000";
                OleDbCommand komanda = new OleDbCommand(tekstKomande, konekcija);
                textBox4.Text = komanda.ExecuteScalar().ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show("Greska prilikom prikazivanja plate manje od 50 000 " + x.Message);
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }
        }
    }
}