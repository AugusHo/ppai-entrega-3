using ImportarBodega.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Datos
{
    public static class UsuarioFactory
    {
        public static List<Usuario> DatosUsuario()
        {

            List<Usuario> usuarios = new List<Usuario>();

            usuarios.Add(new Entidades.Usuario("JoseVinero", 123456, true));

            return usuarios;



        }
    }
}