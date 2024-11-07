using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Entidades
{
    public class Maridaje
    {
        [Key]
        public int id { get; set; }
        private string nombre;
        private string descripcion;


        public Maridaje(string nombreMaridaje, string descripcionMaridaje)
        {
            descripcion = descripcionMaridaje;
            nombre = nombreMaridaje;
        }

        public Maridaje() { }

        public string descripcionMaridaje
        {
            get => descripcion;
            set => descripcion = value;
        }

        public string nombreMaridaje
        {
            get => nombre;
            set => nombre = value;
        }

        public bool sosMaridaje(string nombreM)
        {
            if (this.nombre == nombreM)
            { return true; }
            return false;
        }
    }
}
