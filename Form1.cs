using mpp_project.service;
using mpp_project.repository;
using mpp_project.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace mpp_project
{
    public partial class Form1 : Form
    {
        private AngajatService angajatService;
        private ZborService zborService;
        private RezervareService rezervareService;
        private BiletService biletService;
        private ClientService clientService;
        public Form1()
        {
            InitializeComponent();
        }

        public void setService(AngajatService angajatService, ZborService zborService, RezervareService rezervareService, BiletService biletService, ClientService clientService)
        {
            this.angajatService = angajatService;
            this.zborService = zborService;
            this.rezervareService = rezervareService;
            this.biletService = biletService;
            this.clientService = clientService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            Angajat angajat = angajatService.FindAngajatByUsernameAndPassword(username, password);
            if (angajat != null)
            {
                MessageBox.Show("Logare cu succes!");
                AfterLogin afterLogin = new AfterLogin();
                afterLogin.setService(zborService, angajat, rezervareService, biletService, clientService);
                afterLogin.Show();
            }
            else
            {
                MessageBox.Show("Logare esuata!");
            }

        }
    }
}
