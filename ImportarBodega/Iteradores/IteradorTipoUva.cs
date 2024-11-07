using ImportarBodega.Entidades;
using ImportarBodega.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Iteradores
{
    class IteradorTipoUva : IIterador<TipoUva>
    {
        private int posicion;
        private List<TipoUva> tiposUva;

        public IteradorTipoUva(List<TipoUva> tiposUva)
        {
            this.tiposUva = tiposUva;
            this.posicion = 0; // Inicia la posición en 0
        }

        // Posiciona la posición en el primer elemento
        public void primero()
        {
            posicion = 0;
        }

        // Avanza al siguiente elemento
        public void siguiente()
        {
            posicion++;
        }

        // Devuelve el elemento actual
        public TipoUva actual(List<Object> filtros)
        {
            if (cumpleFiltro(filtros))
            {
                return tiposUva[posicion];
            }
            return null;

        }

        // Indica si se ha llegado al final de la colección
        public bool haTerminado()
        {
            return posicion > tiposUva.Count - 1;
        }

        public bool cumpleFiltro(List<Object> filtros)
        {
            return tiposUva[posicion].sosTipoUva(filtros[1].ToString());
        }
    }
}