using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Datos
{
    public static class EnofiloFactory
    {
        public static List<Entidades.Enofilo> DatosEnofilo()
        {
            List<Entidades.Enofilo> enofilos = new List<Entidades.Enofilo>();
            List<Entidades.Usuario> usuarios = UsuarioFactory.DatosUsuario();
            List<Entidades.Siguiendo> siguiendos = SiguiendosFactory.DatosSiguiendo();

            enofilos.Add(new Entidades.Enofilo("Perez", "imagen500.png", "Jose", usuarios[0], new List<Entidades.Siguiendo> { siguiendos[0] }));

            return enofilos;
        }
    }
}