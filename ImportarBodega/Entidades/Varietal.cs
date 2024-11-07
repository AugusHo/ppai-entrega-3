using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Entidades
{
    public class Varietal
    {
        [Key]
        public string id { get; set; }
        private string descripcion;
        private string porcentajeTiposUva;
        private TipoUva tipoUva;

        public Varietal(string descripcionP, string porcentajeTiposUvaP, TipoUva tipoUvaP)
        {
            descripcion = descripcionP;
            porcentajeTiposUva = porcentajeTiposUvaP;
            tipoUva = tipoUvaP;
        }

        public Varietal() { }

        public string descripcionVarietal
        {
            get => descripcion;
            set => descripcion = value;
        }

        public string porcentajeTiposUvaVarietal
        {
            get => porcentajeTiposUva;
            set => porcentajeTiposUva = value;
        }

        public TipoUva tipoUvaVarietal
        {
            get => tipoUva;
            set => tipoUva = value;
        }

    }
}
