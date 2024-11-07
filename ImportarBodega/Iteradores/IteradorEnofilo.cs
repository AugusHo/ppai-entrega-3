using ImportarBodega.Entidades;
using ImportarBodega.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Iteradores
{
    class IteradorEnofilo : IIterador<Enofilo>
    {
        private int posicion;
        private List<Enofilo> enofilos;

        public IteradorEnofilo(List<Enofilo> enofilos)
        {
            this.enofilos = enofilos;
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
        public Enofilo actual(List<Object> filtros)
        {
            if (cumpleFiltro(filtros))
            {
                return enofilos[posicion];
            }
            return null;
        }

        // Indica si se ha llegado al final de la colección
        public bool haTerminado()
        {
            return posicion > enofilos.Count - 1;
        }

        public bool cumpleFiltro(List<Object> filtros)
        {
            return enofilos[posicion].esSeguidor(filtros[1].ToString());
        }
    }
}
