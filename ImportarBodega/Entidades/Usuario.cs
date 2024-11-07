using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Entidades
{
    public class Usuario
    {
        [Key]
        public string id { get; set; }
        private string nombre;
        private int contraseña;
        private bool premium;

        public Usuario(string nombreU, int contraseñaU, bool premiumU)
        {
            nombre = nombreU;
            contraseña = contraseñaU;
            premium = premiumU;
        }

        public Usuario() { }

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public int Contraseña
        {
            get => contraseña;
            set => contraseña = value;
        }

        public bool Premium
        {
            get => premium;
            set => premium = value;
        }

        public string getNombre()
        {
            return this.nombre;
        }
    }
}
