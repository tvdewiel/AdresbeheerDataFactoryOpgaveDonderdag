using AdresbeheerDataLayerProvider;
using AdresbeheerDomain.Model;
using AdresbeheerEFlayer.Model;
using System.Configuration;

namespace ConsoleAppTestFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string dataLayer = ConfigurationManager.AppSettings["DataLayer"];
            string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

            AdresbeheerRepositories repos=null;
            switch(dataLayer)
            {
                case "EFCore": repos = AdresbeheerDataLayerFactory.GeefRepositories(connectionString, RepositoryType.EFCore);
                    break;
                case "ADO":
                    repos = AdresbeheerDataLayerFactory.GeefRepositories(connectionString, RepositoryType.ADO);
                    break;
            }
            //Gemeente gemeente = new Gemeente(20000, "Zele");
            //repos.GemeenteRepository.VoegGemeenteToe(gemeente);
            //gemeente = new Gemeente(20001, "Hamme");
            //repos.GemeenteRepository.VoegGemeenteToe(gemeente);
            var g = repos.GemeenteRepository.GeefGemeente(30001);
            //g.ZetGemeentenaam("Hamme-ZoggeX");
            //repos.GemeenteRepository.UpdateGemeente(g);
            //g.ZetGemeentenaam("Dendermonde");
            //repos.GemeenteRepository.UpdateGemeente(g);
            //Console.WriteLine(g);
            //foreach(var g in  repos.GemeenteRepository.GeefGemeenten()) { Console.WriteLine(g); }
            //repos.GemeenteRepository.VerwijderGemeente(20000);
            //var gemeente = new Gemeente(30004, "Lommel");
            Straat s = new Straat("winkelstraat", g);
            repos.StraatRepository.VoegStraatToe(s);
            Console.WriteLine(s);
        }
    }
}