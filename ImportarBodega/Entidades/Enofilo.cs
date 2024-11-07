using ImportarBodega.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Entidades
{
    public class Enofilo
    {
        [Key]
        public string id { get; set; }
        private string apellido;
        private string imagenPerfil;
        private string nombre;
        private Usuario usuario;
        private List<Siguiendo> siguiendos;

        public Enofilo(string apellidoE, string imagenPerfilE, string nombreE, Usuario usuarioE, List<Siguiendo> siguiendoE)
        {
            apellido = apellidoE;
            imagenPerfil = imagenPerfilE;
            nombre = nombreE;
            usuario = usuarioE;
            siguiendos = siguiendoE;
        }

        public Enofilo() { }

        public string apellidoE
        {
            get => apellido;
            set => apellido = value;
        }

        public string imagenPerfilE
        {
            get => imagenPerfil;
            set => imagenPerfil = value;
        }

        public string nombreE
        {
            get => nombre;
            set => nombre = value;
        }

        public Usuario usuarioE
        {
            get => usuario;
            set => usuario = value;
        }

        public List<Siguiendo> siguiendoE
        {
            get => siguiendos;
            set => siguiendos = value;
        }

        public bool esSeguidor(string bodegaSeleccioda)
        {
            for (int i = 0; i < siguiendos.Count; i++)
            {
                if (siguiendos[i].sosDeBodega(bodegaSeleccioda))
                {
                    return true;
                }
            }
            return false;
        }

        public string getNombreUsuario()
        {
            return this.usuario.getNombre();
        }
    }

}
