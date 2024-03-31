using mpp_project.domain;
using mpp_project.repository;
using mpp_project.service;
using System.Diagnostics;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace mpp_project
{
    internal static class Program
    {

        private static AngajatRepository angajatRepository;
        private static ClientRepository clientRepository;
        private static AeroportRepository aeroportRepository;
        private static ZborRepository zborRepository;
        private static RezervareRepository rezervareRepository;
        private static BiletRepository biletRepository;
        private static AngajatService angajatService;
        private static ZborService zborService;
        private static RezervareService rezervareService;
        private static BiletService biletService;
        private static ClientService clientService;


        static void test()
        {
            Angajat angajat = new Angajat("angajat2", "parola2");
            AngajatRepository angajatRepository = new AngajatRepository("Data Source=C:\\Users\\serba\\source\\repos\\mpp-project\\mpp-project\\agentie.db");
            angajatRepository.Save(angajat);
          
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()

        {
            test();
            angajatRepository = new AngajatRepository("Data Source=C:\\Users\\serba\\source\\repos\\mpp-project\\mpp-project\\agentie.db");
            clientRepository = new ClientRepository("Data Source=C:\\Users\\serba\\source\\repos\\mpp-project\\mpp-project\\agentie.db");
            aeroportRepository = new AeroportRepository("Data Source=C:\\Users\\serba\\source\\repos\\mpp-project\\mpp-project\\agentie.db");
            zborRepository = new ZborRepository("Data Source=C:\\Users\\serba\\source\\repos\\mpp-project\\mpp-project\\agentie.db", aeroportRepository);
            rezervareRepository = new RezervareRepository("Data Source=C:\\Users\\serba\\source\\repos\\mpp-project\\mpp-project\\agentie.db", zborRepository, clientRepository);
            biletRepository = new BiletRepository("Data Source=C:\\Users\\serba\\source\\repos\\mpp-project\\mpp-project\\agentie.db", rezervareRepository, clientRepository);
            angajatService = new AngajatService(angajatRepository);
            zborService = new ZborService(zborRepository);
            rezervareService = new RezervareService(rezervareRepository);
            biletService = new BiletService(biletRepository);
            clientService = new ClientService(clientRepository);


            

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Form1 loginForm = new Form1();
            loginForm.setService(angajatService, zborService, rezervareService, biletService, clientService);

            Application.Run(loginForm);
        }
    }
}