using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Interfaces
{
    public interface IIterador<T>
    {
        void primero();        // Posiciona la posición en 0
        void siguiente();      // Avanza al siguiente elemento
        T actual(List<Object> filtro);            // Devuelve el elemento actual
        bool haTerminado();    // Indica si se ha llegado al final de la colección
        bool cumpleFiltro(List<Object> filtro);
    }
}