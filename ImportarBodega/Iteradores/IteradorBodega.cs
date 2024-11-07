using ImportarBodega.Entidades;
using ImportarBodega.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Iteradores
{
    class IteradorBodega : IIterador<Bodega>
    {
        private int posicion;
        private List<Bodega> bodegas;

        public IteradorBodega(List<Bodega> bodegas)
        {
            this.bodegas = bodegas;
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
        public Bodega actual(List<Object> filtros)
        {
            if (cumpleFiltro(filtros))
            {
                return bodegas[posicion];
            }
            return null;
        }

        // Indica si se ha llegado al final de la colección
        public bool haTerminado()
        {
            return posicion > bodegas.Count - 1;
        }

        public bool cumpleFiltro(List<Object> filtros)
        {

            return bodegas[posicion].estaParaActualizarNovedadesVino();

        }
    }
}