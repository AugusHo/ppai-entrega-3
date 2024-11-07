using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Entidades
{
    public class TipoUva
    {
        [Key]
        public int id { get; set; }
        private string nombre;
        private string descripcion;

        public TipoUva(string nombreUva, string descripcionUva)
        {
            nombre = nombreUva;
            descripcion = descripcionUva;
        }

        public TipoUva() { }

        public string nombreUva
        {
            get => nombre;
            set => nombre = value;
        }

        public string descripcionUva
        {
            get => descripcion;
            set => descripcion = value;
        }

        public bool sosTipoUva(string nombreTU)
        {
            if (this.nombre == nombreTU) { return true; }
            return false;
        }

    }
}