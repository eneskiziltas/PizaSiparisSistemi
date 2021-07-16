using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriparkOopDegerlendirme1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Pizzalar> pizzaList = new List<Pizzalar>();
        string[] ebatlar = { "Küçük", "Orta", "Büyük", "Maxi" };
        string[] kenarSecim = { "Kalin", "Ince" };
        string[] malzemeler = { "Dana Jambon","Sosis","Mısır","Anguez","Zeytin","Salam","Sucuk","Mantar","Ton Balığı","Peynir"};
        string secilenMalzemeler;
        double toplamTutar = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbEbatlarDoldur();
            pizzalariDoldur();
            radioButtonDoldur();
            cbDoldur();

        }

        public void cmbEbatlarDoldur()
        {
            for (int i = 0; i < ebatlar.Length; i++)
            {

                cmbEbatlar.Items.Add(ebatlar[i]);
            }
        }

        public void radioButtonDoldur()
        {
            for (int i = 0; i < kenarSecim.Length; i++)
            {
                foreach (var cont in this.Controls)
                {
                    if (cont is RadioButton)
                    {
                        RadioButton rb = (RadioButton)cont;
                        if (rb.Text == "" || rb.Text == null)
                        {
                            rb.Text = kenarSecim[i];
                            break;
                        }

                    }
                }
            }
        }

        
        
        public void cbDoldur()
        {
            for (int i = 0; i < malzemeler.Length; i++)
            {
                foreach (var cont in this.Controls)
                {
                    if (cont is CheckBox)
                    {
                        CheckBox cb = (CheckBox)cont;
                        if (cb.Text == "" || cb.Text == null)
                        {

                            cb.Text = malzemeler[i];
                            break;
                        }

                    }
                }
            }
        }

        public void cbKontrol()
        {

            
                foreach (var cont in this.Controls)
                {
                    if (cont is CheckBox)
                    {
                        CheckBox cb = (CheckBox)cont;
                        if (cb.Checked)
                        {
                            secilenMalzemeler = secilenMalzemeler + cb.Text + ", ";     
                        }

                    }
                }
            
        }

        public void pizzalariDoldur()
        {
            Pizzalar klasikpizza = new Pizzalar("KLASIK", 14);
            pizzaList.Add(klasikpizza);
            Pizzalar karisikpizza = new Pizzalar("KARISIK", 17);
            pizzaList.Add(karisikpizza);
            Pizzalar extravaganzapizza = new Pizzalar("EXRAVAGANZA", 21);
            pizzaList.Add(klasikpizza);
            Pizzalar italianopizza = new Pizzalar("ITALIANO", 20);
            pizzaList.Add(italianopizza);
            Pizzalar turkishpizza = new Pizzalar("TURKISH", 23);
            pizzaList.Add(turkishpizza);


            foreach (Pizzalar item in pizzaList)
            {

                ListViewItem li = new ListViewItem();
                li.Tag = item;
                li.Text = item.PizzaTuru;
                listPizzalar2.Items.Add(li);
            }
        }


        ListView.SelectedListViewItemCollection secilenElemanlar;
        List<Pizzalar> secilenUrunler = new List<Pizzalar>();

        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            secilenMalzemeler = "";
            secilenElemanlar = listPizzalar2.SelectedItems;

            cbKontrol();


            int check = 0;
            RadioButton rdbbtn = new RadioButton();
            foreach (Control item in this.Controls)
            {
                if (item is RadioButton)
                {
                    rdbbtn = (RadioButton)item;
                    if (rdbbtn.Checked == true)
                    {
                        check++;
                        break;
                    }
                }
            }

            if ((check == 0) || (secilenUrunler == null))
            {
                MessageBox.Show("lutfen kenar seciniz");
            }
            else
            {

                foreach (ListViewItem item in secilenElemanlar)
                {
                    Pizzalar secilenUrun = (Pizzalar)item.Tag;
                    secilenUrunler.Add(secilenUrun);
                    Sipariş spr = new Sipariş(secilenUrun, cmbEbatlar.SelectedItem.ToString(), rdbbtn.Text, int.Parse(txtAdet.Text),secilenMalzemeler);

                    toplamTutar += spr.toplamTutarHesapla();
                    spr.SiparisTutari = spr.toplamTutarHesapla();
                    lblToplamTutar.Text = toplamTutar.ToString();
                    listSepet.Items.Add(spr.ToString());
                }


            }

        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            double araToplam = 0;

            ListView.SelectedListViewItemCollection secilenUrunAraToplam;
            List<Pizzalar> secilenUrunlerAraToplam = new List<Pizzalar>();

            secilenUrunAraToplam = listPizzalar2.SelectedItems;

            int check = 0;
            RadioButton rdbbtn = new RadioButton();
            foreach (Control item in this.Controls)
            {
                if (item is RadioButton)
                {
                    rdbbtn = (RadioButton)item;
                    if (rdbbtn.Checked == true)
                    {
                        check++;
                        break;
                    }
                }

            }

            if ((check == 0) || (secilenUrunAraToplam == null))
            {
                MessageBox.Show("lutfen kenar seciniz");
            }
            else
            {


                foreach (ListViewItem secilenEleman in secilenUrunAraToplam)
                {
                    Pizzalar secilenUrun = (Pizzalar)secilenEleman.Tag;
                    secilenUrunler.Add(secilenUrun);
                    Sipariş spr = new Sipariş(secilenUrun, cmbEbatlar.SelectedItem.ToString(), rdbbtn.Text, int.Parse(txtAdet.Text),secilenMalzemeler);

                    araToplam += spr.tutarHesapla()*spr.Adet;
                    txtAraToplam.Text = araToplam.ToString();

                }

            }

        }

        private void btnSpiarisOnayla_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Toplam " + secilenUrunler.Count + " adet siparişiniz " + toplamTutar.ToString() + "TL tutarındadır");
            
        }

        
    }
}
