using ImportarBodega.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Entidades
{
    public class Siguiendo
    {
        [Key]
        public int id { get; set; }
        private string fechaFin;
        private string fechaInicio;
        private Bodega bodega;
        private Enofilo amigo;

        public Siguiendo(string fechaFinSiguiendo, string fechaInicioSiguiendo, Bodega bodegaSiguiendo, Enofilo amigoE)
        {
            fechaFin = fechaFinSiguiendo;
            fechaInicio = fechaInicioSiguiendo;
            bodega = bodegaSiguiendo;
            amigo = amigoE;
        }

        public Siguiendo() { }

        public string fechaFinSiguiendo
        {
            get => fechaFin;
            set => fechaFin = value;
        }

        public string fechaInicioSiguiendo
        {
            get => fechaInicio;
            set => fechaInicio = value;
        }

        public Bodega bodegaSiguiendo
        {
            get => bodega;
            set => bodega = value;
        }

        public Enofilo amigoE
        {
            get => amigo;
            set => amigo = value;
        }

        public bool sosDeBodega(string nombreBodega)
        {
            if (bodega.nombreBodega == nombreBodega) { return true; }
            return false;
        }
    }
}
