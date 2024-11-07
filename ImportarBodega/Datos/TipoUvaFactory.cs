using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Datos
{
    public static class TipoUvaFactory
    {
        public static List<Entidades.TipoUva> DatosTipoUva()
        {
            List<Entidades.TipoUva> tipoUva = new List<Entidades.TipoUva>();
            tipoUva.Add(new Entidades.TipoUva("Cabernet Sauvignon", "Una uva negra con gran potencial de envejecimiento."));
            tipoUva.Add(new Entidades.TipoUva("Chardonnay", "Una uva blanca que puede dar vinos secos y frescos."));
            tipoUva.Add(new Entidades.TipoUva("Merlot", "Una uva roja con taninos suaves y sabores afrutados."));

            return tipoUva;
        }
    }
}
