using ImportarBodega.Entidades;
using ImportarBodega.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Iteradores
{
    class IteradorVino : IIterador<Vino>
    {
        private int posicion;
        private List<Vino> vinos;

        public IteradorVino(List<Vino> vinos)
        {
            this.vinos = vinos;
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
        public Vino actual(List<Object> filtros)
        {
            if (cumpleFiltro(filtros))
            {
                return vinos[posicion];
            }
            return null;

        }

        // Indica si se ha llegado al final de la colección
        public bool haTerminado()
        {
            return posicion > vinos.Count - 1;
        }

        public bool cumpleFiltro(List<Object> filtros)
        {
            if (Convert.ToInt32(filtros[0]) == 1)
            {
                return vinos[posicion].esTuVino(filtros[1].ToString());
            }
            if (Convert.ToInt32(filtros[0]) == 2)
            {
                return (vinos[posicion].sosParaActualizar(vinos[posicion].nombreVino, filtros[1].ToString()) &&
                    vinos[posicion].añadaVino == filtros[2].ToString() &&
                    vinos[posicion].bodegaVino.nombreBodega == filtros[3].ToString());
            }
            return false;

        }
    }
}