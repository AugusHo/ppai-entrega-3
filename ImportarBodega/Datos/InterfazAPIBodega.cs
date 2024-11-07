using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Datos
{
    public static class InterfazAPIBodega
    {
        public static List<Entidades.Vino> ObtenerActualizaciones()
        {
            List<Entidades.Bodega> bodegas = BodegaFactory.DatosBodegas();
            List<Entidades.Maridaje> maridajes = MaridajeFactory.DatosMaridajes();
            List<Entidades.Vino> vinosConActualizacion = new List<Entidades.Vino>();
            List<Entidades.Varietal> varietales = VarietalFactory.DatosVarietal();
            //hace falta crearlo bien:
            List<Entidades.Varietal> varietalesNuevos = new List<Entidades.Varietal>();
            List<Entidades.TipoUva> tiposUvaNuevos = TipoUvaFactory.DatosTipoUva();

            //Nuevos varietales:
            //Primer Vino
            varietalesNuevos.Add(new Entidades.Varietal("Un vino tinto robusto y complejo.", "91", tiposUvaNuevos[0]));
            varietalesNuevos.Add(new Entidades.Varietal("Un vino blanco fresco y afrutado.", "9", tiposUvaNuevos[1]));
            //Segundo Vino
            varietalesNuevos.Add(new Entidades.Varietal("Un vino tinto suave y aterciopelado.", "90", tiposUvaNuevos[2]));
            varietalesNuevos.Add(new Entidades.Varietal("Un vino espumoso elegante y seco.", "10", tiposUvaNuevos[0]));


            //Vinos para Actualizar
            vinosConActualizacion.Add(new Entidades.Vino("2018", "imagen100.jpg", "Vino Tinto Reserva", 4, 1234.5f, bodegas[0], new List<Entidades.Maridaje> { null }, "no se actualizo", new List<Entidades.Varietal> { varietales[0], varietales[1] }));
            vinosConActualizacion.Add(new Entidades.Vino("2017", "imagen300.jpg", "Vino Rosado", 5, 9101.25f, bodegas[2], new List<Entidades.Maridaje> { maridajes[4], maridajes[5] }, "no se actualizo", new List<Entidades.Varietal> { varietales[4], varietales[5] }));
            vinosConActualizacion.Add(new Entidades.Vino("2021", "imagen400.jpg", "Vino Blanco Sauvignon", 4, 5496.98f, bodegas[2], new List<Entidades.Maridaje> { maridajes[0], maridajes[1] }, "2023, 5, 23", new List<Entidades.Varietal> { varietales[4], varietales[5] }));
            //Vinos para crear
            vinosConActualizacion.Add(new Entidades.Vino("2009", "imagen200.jpg", "Vino Blanco Vladimmir", 3, 5678.9f, bodegas[0], new List<Entidades.Maridaje> { maridajes[2], maridajes[3] }, "no se actualizo", new List<Entidades.Varietal> { varietalesNuevos[0], varietalesNuevos[1] }));
            vinosConActualizacion.Add(new Entidades.Vino("2001", "imagen400.jpg", "Vino Negro Asabache", 2, 3456.70f, bodegas[2], new List<Entidades.Maridaje> { maridajes[0], maridajes[1] }, "no se actualizo", new List<Entidades.Varietal> { varietalesNuevos[2], varietalesNuevos[3] }));

            return getActualizacion(vinosConActualizacion);
        }

        public static List<Entidades.Vino> getActualizacion(List<Entidades.Vino> vinos)
        {
            //List<Entidades.Vino> actualizaciones = ObtenerActualizaciones();
            return vinos;
        }

    }
}