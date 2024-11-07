using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Datos
{
    public class SiguiendosFactory
    {
        public static List<Entidades.Siguiendo> DatosSiguiendo()
        {
            List<Entidades.Siguiendo> siguiendos = new List<Entidades.Siguiendo>();
            List<Entidades.Bodega> bodegas = BodegaFactory.DatosBodegas();

            siguiendos.Add(new Entidades.Siguiendo("", "20-5-2022", bodegas[0], null));



            return siguiendos;
        }
    }
}
