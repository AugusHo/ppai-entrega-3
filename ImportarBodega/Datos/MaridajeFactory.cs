using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Datos
{
    public static class MaridajeFactory
    {
        public static List<Entidades.Maridaje> DatosMaridajes()
        {
            List<Entidades.Maridaje> maridajes = new List<Entidades.Maridaje>();
            maridajes.Add(new Entidades.Maridaje("Queso Azul", "Perfecto con vinos tintos robustos"));
            maridajes.Add(new Entidades.Maridaje("Carne Asada", "Ideal para acompañar con vinos tintos"));
            maridajes.Add(new Entidades.Maridaje("Salmón Ahumado", "Combina bien con vinos blancos secos"));
            maridajes.Add(new Entidades.Maridaje("Pasta Alfredo", "Se complementa con vinos blancos cremosos"));
            maridajes.Add(new Entidades.Maridaje("Ensalada César", "Marida con vinos blancos ligeros"));
            maridajes.Add(new Entidades.Maridaje("Chocolate Amargo", "Va bien con vinos tintos dulces"));
            maridajes.Add(new Entidades.Maridaje("Sushi", "Excelente con vinos blancos o espumosos"));
            maridajes.Add(new Entidades.Maridaje("Pizza Margarita", "Acompaña bien con vinos tintos frutales"));
            maridajes.Add(new Entidades.Maridaje("Cordero", "Perfecto con vinos tintos robustos"));
            maridajes.Add(new Entidades.Maridaje("Tarta de Manzana", "Ideal con vinos dulces o de postre"));
            return maridajes;
        }
    }
}
