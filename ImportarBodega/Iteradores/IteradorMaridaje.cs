using ImportarBodega.Entidades;
using ImportarBodega.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Iteradores
{
    class IteradorMaridaje : IIterador<Maridaje>
    {
        private int posicion;
        private List<Maridaje> maridajes;

        public IteradorMaridaje(List<Maridaje> maridajes)
        {
            this.maridajes = maridajes;
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
        public Maridaje actual(List<Object> filtros)
        {
            if (cumpleFiltro(filtros))
            {
                return maridajes[posicion];
            }
            return null;
        }

        // Indica si se ha llegado al final de la colección
        public bool haTerminado()
        {
            return posicion >= maridajes.Count - 1;
        }

        public bool cumpleFiltro(List<Object> filtros)
        {
            return maridajes[posicion].sosMaridaje(filtros[1].ToString());
        }
    }
}