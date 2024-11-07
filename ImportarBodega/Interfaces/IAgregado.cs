using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Interfaces
{
    public interface IAgregado<T>
    {
        IIterador<T> crearIterador(List<T> coleccion); // Método para crear un iterador para la colección especificada
    }

}
