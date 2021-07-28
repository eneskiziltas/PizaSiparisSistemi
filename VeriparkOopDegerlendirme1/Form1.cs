using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        List<Pizza> pizzaList = new List<Pizza>();
        string[] ebatlar = { "Küçük", "Orta", "Büyük", "Maxi" };
        string[] kenarSecim = { "Kalin", "Ince" };
        string[] malzemeler = { "Dana Jambon", "Sosis", "Mısır", "Anguez", "Zeytin", "Salam", "Sucuk", "Mantar", "Ton Balığı", "Peynir" };
        string secilenMalzemeler;
        double toplamTutar = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            CmbEbatlarDoldur();
            PizzalariDoldur();
            RadioButtonDoldur();
            CbDoldur();

        }

        public void CmbEbatlarDoldur()
        {
            for (int i = 0; i < ebatlar.Length; i++)
            {

                cmbEbatlar.Items.Add(ebatlar[i]);
            }
        }

        public void RadioButtonDoldur()
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



        public void CbDoldur()
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

        public void CbKontrol()
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

        public void PizzalariDoldur()
        {
            Pizza klasikpizza = new Pizza("KLASIK", 14);
            pizzaList.Add(klasikpizza);
            Pizza karisikpizza = new Pizza("KARISIK", 17);
            pizzaList.Add(karisikpizza);
            Pizza extravaganzapizza = new Pizza("EXRAVAGANZA", 21);
            pizzaList.Add(klasikpizza);
            Pizza italianopizza = new Pizza("ITALIANO", 20);
            pizzaList.Add(italianopizza);
            Pizza turkishpizza = new Pizza("TURKISH", 23);
            pizzaList.Add(turkishpizza);
            Pizza tunapizza = new Pizza("TUNA", 18);
            pizzaList.Add(tunapizza);
            Pizza seafeedpizza = new Pizza("SEAFEED", 19);
            pizzaList.Add(seafeedpizza);
            Pizza kastamonupizza = new Pizza("KASTAMONU", 20);
            pizzaList.Add(kastamonupizza);
            Pizza calypsopizza = new Pizza("CALYPSO", 24);
            pizzaList.Add(calypsopizza);
            Pizza akdenizpizza = new Pizza("AKDENİZ", 21);
            pizzaList.Add(akdenizpizza);
            Pizza karadenizpizza = new Pizza("KARADENİZ", 21);
            pizzaList.Add(karadenizpizza);



            foreach (Pizza item in pizzaList)
            {

                ListViewItem li = new ListViewItem();
                li.Tag = item;
                li.Text = item.PizzaTuru;
                listPizzalar2.Items.Add(li);
            }
        }


        ListView.SelectedListViewItemCollection secilenElemanlar;
        List<Pizza> secilenUrunler = new List<Pizza>();

        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            secilenMalzemeler = "";
            secilenElemanlar = listPizzalar2.SelectedItems;

            CbKontrol();


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
                    Pizza secilenUrun = (Pizza)item.Tag;
                    //secilenUrun.Ebat = cmbEbatlar.SelectedItem.ToString();
                    secilenUrunler.Add(secilenUrun);
                    //Sipariş spr = new Sipariş(secilenUrun, cmbEbatlar.SelectedItem.ToString(), rdbbtn.Text, int.Parse(txtAdet.Text),secilenMalzemeler);

                    if (Util.SayiMi(txtAdet.Text))
                    {
                        MessageBox.Show("Geçersiz Adet Sayisi Girdiniz!");
                    }
                    else
                    {
                        PizzaSiparis spr1 = new PizzaSiparis(secilenUrun, cmbEbatlar.SelectedItem.ToString(), rdbbtn.Text, int.Parse(txtAdet.Text));

                        toplamTutar += spr1.ToplamTutarHesapla(spr1.Adet);
                        spr1.SiparisTutari = spr1.ToplamTutarHesapla(spr1.Adet);
                        lblToplamTutar.Text = toplamTutar.ToString();
                        listSepet.Items.Add(spr1.ToString());
                    }


                }


            }

        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            double araToplam = 0;

            ListView.SelectedListViewItemCollection secilenUrunAraToplam;
            List<Pizza> secilenUrunlerAraToplam = new List<Pizza>();

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
                    Pizza secilenUrun = (Pizza)secilenEleman.Tag;
                    secilenUrunler.Add(secilenUrun);



                    if (Util.SayiMi(txtAdet.Text))
                    {
                        MessageBox.Show("Geçersiz Adet Sayisi Girdiniz!");
                    }
                    else
                    {

                        PizzaSiparis spr1 = new PizzaSiparis(secilenUrun, cmbEbatlar.SelectedItem.ToString(), rdbbtn.Text, Convert.ToInt32(txtAdet.Text));
                        araToplam += spr1.TutarHesapla() * spr1.Adet;

                        txtAraToplam.Text = araToplam.ToString();
                    }

                }

            }

        }

        private void btnSpiarisOnayla_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Toplam " + secilenUrunler.Count + " adet siparişiniz " + toplamTutar.ToString() + "TL tutarındadır");


        }




    }
}
