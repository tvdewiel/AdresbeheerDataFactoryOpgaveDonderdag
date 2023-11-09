using AdresbeheerEFlayer;

namespace ConsoleAppTestModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string conn = "Data Source=NB21-6CDPYD3\\SQLEXPRESS;Initial Catalog=AdresbeheerTest;Integrated Security=True;TrustServerCertificate=true";
            AdresbeheerContext ctx = new AdresbeheerContext(conn);
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
        }
    }
}