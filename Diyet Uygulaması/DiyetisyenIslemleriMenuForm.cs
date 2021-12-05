using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiyetisyenUygulama
{
    public partial class DiyetisyenIslemleriMenuForm : Form
    {
        public DiyetisyenIslemleriMenuForm()
        {
            InitializeComponent();
        }

        private void btnHastaKayit_Click(object sender, EventArgs e)
        {
            //Hasta Kayit Formu acilir
            HastaKayitFormu hastaKayitFormu = new HastaKayitFormu();
            hastaKayitFormu.Show();
        }

        private void formuKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formuKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            //Rapor Formu acilir
            RaporFormu raporFormu = new RaporFormu();
            raporFormu.Show();
        }
    }
}
