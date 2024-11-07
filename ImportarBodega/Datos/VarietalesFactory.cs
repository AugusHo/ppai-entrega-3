using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Datos
{
    public static class VarietalFactory
    {
        public static List<Entidades.Varietal> DatosVarietal()
        {
            List<Entidades.TipoUva> tipoUvas = TipoUvaFactory.DatosTipoUva();
            List<Entidades.Varietal> varietales = new List<Entidades.Varietal>();

            varietales.Add(new Entidades.Varietal("Un vino blanco fresco y afrutado.", "88", tipoUvas[0]));
            varietales.Add(new Entidades.Varietal("Un vino tinto robusto y complejo.", "12", tipoUvas[1]));
            varietales.Add(new Entidades.Varietal("Un vino tinto suave y aterciopelado.", "93", tipoUvas[2]));
            varietales.Add(new Entidades.Varietal("Un vino espumoso, elegante y seco.", "7", tipoUvas[0]));
            varietales.Add(new Entidades.Varietal("Un vino blanco dulce y aromático.", "81", tipoUvas[1]));
            varietales.Add(new Entidades.Varietal("Un vino rosado suave y con aroma a leña.", "19", tipoUvas[2]));
            varietales.Add(new Entidades.Varietal("Un vino oscuro suave y con aroma otoñal.", "100", tipoUvas[1]));

            return varietales;
        }
    }
}
