using mpp_project.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mpp_project.domain;
using System.Diagnostics;
using mpp_project.observer;

namespace mpp_project
{
    public partial class AfterLogin : Form, Observer<ZborChangeEvent>
    {
        ZborService ZborService;
        Angajat angajat;
        RezervareService rezervareService;
        BiletService biletService;
        ClientService clientService;
        public AfterLogin()
        {
            InitializeComponent();
        }

        public void update(ZborChangeEvent zborChangeEvent)
        {

            string destinatie = textBox1.Text;
            DateTime data = dateTimePicker1.Value;
            if(destinatie == "")
            {
                FindAllInitView();
            }
            else
            {
                initView();
            }
        }

        public void setService(ZborService ZborService, Angajat angajat, RezervareService rezervareService, BiletService biletService, ClientService clientService)
        {
            this.ZborService = ZborService;
            this.angajat = angajat;
            this.rezervareService = rezervareService;
            this.biletService = biletService;
            this.clientService = clientService;
            FindAllInitView();
            ZborService.addObserver(this);
        }

        public void FindAllInitView()
        {
            listView1.Items.Clear();
            IEnumerable<Zbor> zboruri = ZborService.FindAll();
            foreach (Zbor zbor in zboruri)
            {
                string[] arr = new string[5];
                ListViewItem itm;
                arr[0] = zbor.GetId().ToString();
                arr[1] = zbor.GetDestinatie();
                arr[2] = zbor.GetData().ToString();
                arr[3] = zbor.getAeroport().GetNume();
                arr[4] = zbor.GetNrLocuri().ToString();
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
        }


        public void initView()
        {
            listView1.Items.Clear();
            // Cautare zboruri dupa destinatie si data
            string destinatie = textBox1.Text;
            DateTime data = dateTimePicker1.Value;
            IEnumerable<Zbor> zboruri = ZborService.FindZboruriByDestinatieAndData(destinatie, data);
            // debug print zboruri
            Debug.WriteLine("Cautare Zboruri!");
            // using a list view to show the list of zboruri horizontally

            foreach (Zbor zbor in zboruri)
            {
                string[] arr = new string[5];
                ListViewItem itm;
                arr[0] = zbor.GetId().ToString();
                arr[1] = zbor.GetDestinatie();
                arr[2] = zbor.GetData().ToString();
                arr[3] = zbor.getAeroport().GetNume();
                arr[4] = zbor.GetNrLocuri().ToString();
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            initView();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // get the selected zbor from listview1 and add a reservation
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selectati un zbor!");
                return;
            }

            // limit the numericupdown to nrlocuri
            numericUpDown1.Maximum = Int32.Parse(listView1.SelectedItems[0].SubItems[4].Text);

            // get id from selected item
            int id = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            Debug.WriteLine(id);
            Zbor zbor = ZborService.FindOne(id);

            // get client name from textbox
            string nume = textBox2.Text;
            string adresa = textBox3.Text;
            Client client = new Client(nume);
            clientService.Save(client);
            Client newClient = clientService.FindLastClient();

            // get nr locuri from numericupdown
            int nrLocuri = (int)numericUpDown1.Value;

            Rezervare rezervare = new Rezervare(zbor, newClient, adresa, nrLocuri);
            rezervareService.Save(rezervare);
            Rezervare newRezervare = rezervareService.FindLastRezervare();

            // get tourists name from textbox splitted by comma and create Bilet for every tourist
            string[] turisti = textBox4.Text.Split(',');
            foreach (string turist in turisti)
            {
                Bilet bilet = new Bilet(newRezervare, newClient);
                biletService.Save(bilet);
            }

            ZborService.cumparaBilete(zbor, turisti.Length);
            MessageBox.Show("Rezervare efectuata cu succes!");
            // clear listview items
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // exit window
            this.Close();
        }
    }
}
