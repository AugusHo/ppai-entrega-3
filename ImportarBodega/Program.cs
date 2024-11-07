using System.Windows.Forms;

namespace ImportarBodega
{
    internal static class Program
    {
        private static object dbContext;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Instanciar el contexto de base de datos
            /*using (var dbContext = new ApplicationDbContext())
            {
                // Asegurarse de que la base de datos esté creada
                dbContext.Database.EnsureCreated();

            }*/

            //Application.Run(new pantallaActualizarBodega(dbContext));
        }
    }
}