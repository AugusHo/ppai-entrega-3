using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Datos
{
    public static class BodegaFactory
    {
        public static List<Entidades.Bodega> DatosBodegas()
        {
            List<Entidades.Bodega> bodegas = new List<Entidades.Bodega>();

            // Hardcodea las instancias de Bodega aquí
            bodegas.Add(new Entidades.Bodega("Esta es una bodega", "Bodega 0", "Los Santos", true, 151515, "24-04-2024"));
            bodegas.Add(new Entidades.Bodega("Esta es otra bodega", "Bodega 1", "Aimar Vinos", true, 151115, "24-04-2024"));
            bodegas.Add(new Entidades.Bodega("Y este es un Bodegon", "Bodega 2", "Norton", true, 151565, "24-04-2024"));
            bodegas.Add(new Entidades.Bodega("VLLC", "Bodega 3", "Zuccardi", false, 2151565, "18-06-2024"));
            bodegas.Add(new Entidades.Bodega("PPQGS", "Bodega 4", "Andeluna", false, 2151565, "22-07-2024"));
            bodegas.Add(new Entidades.Bodega("OA", "Bodega 5", "Rutini", false, 2151565, "14-08-2024"));
            bodegas.Add(new Entidades.Bodega("AJKDJAS", "Bodega 6", "Colomé", true, 2151565, "24-04-2024"));
            bodegas.Add(new Entidades.Bodega("EA", "Bodega 7", "Luigi Bosca", true, 2151565, "24-04-2024"));

            return bodegas;
        }
        public static List<Entidades.Bodega> DatosBodegasFalsa()
        {
            List<Entidades.Bodega> bodegas = new List<Entidades.Bodega>();

            // Hardcodea las instancias de Bodega aquí
            bodegas.Add(new Entidades.Bodega("Esta es una bodega", "Bodega 0", "Los Santos", false, 151515, "24-04-2024"));
            bodegas.Add(new Entidades.Bodega("Esta es otra bodega", "Bodega 1", "Aimar Vinos", false, 151115, "24-04-2024"));
            bodegas.Add(new Entidades.Bodega("Y este es un Bodegon", "Bodega 2", "Norton", false, 151565, "24-04-2024"));
            bodegas.Add(new Entidades.Bodega("VLLC", "Bodega 3", "Zuccardi", false, 2151565, "18-06-2024"));
            bodegas.Add(new Entidades.Bodega("PPQGS", "Bodega 4", "Andeluna", false, 2151565, "22-07-2024"));
            bodegas.Add(new Entidades.Bodega("OA", "Bodega 5", "Rutini", false, 2151565, "14-08-2024"));
            bodegas.Add(new Entidades.Bodega("AJKDJAS", "Bodega 6", "Colomé", false, 2151565, "24-04-2024"));
            bodegas.Add(new Entidades.Bodega("EA", "Bodega 7", "Luigi Bosca", false, 2151565, "24-04-2024"));

            return bodegas;
        }
    }
}
