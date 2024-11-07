using ImportarBodega.Entidades;
using ImportarBodega.Interfaces;
using ImportarBodega.Iteradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ImportarBodega.Entidades
{
    class GestorImportadorBodega : IAgregado<Bodega>
    {
        //para ver que onda
        private Bodega objeto;
        private string nombreObjeto;
        private List<string> nombresBodegasConActualizacion = new List<string>();
        private IIterador<Bodega> iteradorBodega;

        private Enofilo enofiloObjeto;
        private string nombreEnofilo;
        private IIterador<Enofilo> iteradorEnofilo;

        private Maridaje maridajeObjeto;
        private IIterador<Maridaje> iteradorMaridaje;

        private TipoUva tipoUvaObjeto;
        private IIterador<TipoUva> iteradorTipoUva;


        private List<object> filtros;

        private Vino vinoObjeto;
        private List<string> nombresVinosConActualizacion = new List<string>();
        private IIterador<Vino> iteradorVino;

        //****************
        private pantallaActualizarBodega pantalla;
        private InterfazNotificacionPush interfazNotificacion;
        private List<Bodega> bodegas;
        private List<Bodega> bodegasConActualizacion;
        private Bodega bodegaSeleccionada;
        private List<Vino> vinos;
        private List<Maridaje> maridajes;
        private List<TipoUva> tiposUva;
        private List<Enofilo> enofilos;

        private List<Vino> vinosConActualizacion;
        private List<Vino> listaVinosAActualizar;
        private List<Vino> listaFinalVinos;
        private List<Vino> listaNuevosVinos;
        private List<Maridaje> listaNuevoVinoMaridaje;
        private List<TipoUva> listaNuevoVinoTU;
        private List<string> listaNombreEnofilosSuscriptos;


        public GestorImportadorBodega(pantallaActualizarBodega pantalla)//InterfazNotificacionPush interfazNotificacion
        {
            Random random = new Random();
            int randomValue = random.Next(5);
            Console.WriteLine(randomValue);
            if (randomValue == 0)
            {
                Console.WriteLine(randomValue);
                bodegas = Datos.BodegaFactory.DatosBodegasFalsa();
            }
            else
            {
                Console.WriteLine(randomValue);
                bodegas = Datos.BodegaFactory.DatosBodegas();
            }

            this.pantalla = pantalla;

            //Llama a todos los vinos de la "base de datos"
            vinos = Datos.VinoFactoy.DatosVinos();

            //LLama a todos los maridajes de la "base de datos"
            maridajes = Datos.MaridajeFactory.DatosMaridajes();

            //Llama a todas las tiposUva de la "base de datos"
            tiposUva = Datos.TipoUvaFactory.DatosTipoUva();

            //Llama a todos los enofilos
            enofilos = Datos.EnofiloFactory.DatosEnofilo();

            bodegasConActualizacion = new List<Bodega>();

            //Lista de todos vinos que nos vienen de la API
            vinosConActualizacion = new List<Vino>();

            //Lista de los vinos que tenemos que actualizar
            listaVinosAActualizar = new List<Vino>();

            //Lista de solo los vinos actualizados
            listaFinalVinos = new List<Vino>();

            //Lista de vinos nuevos
            listaNuevosVinos = new List<Vino>();

            listaNuevoVinoMaridaje = new List<Maridaje>();

            listaNuevoVinoTU = new List<TipoUva>();

            listaNombreEnofilosSuscriptos = new List<string>();



        }


        public List<string> OpcionImportarActualizacionVinos()
        {
            return buscarBodegasConActualizacionesPendientes();
        }

        public List<string> buscarBodegasConActualizacionesPendientes()
        {
            /*
            bodegasConActualizacion = bodegas.Where(x => x.estaParaActualizarNovedadesVino()).ToList();
            return bodegasConActualizacion.Select(x => x.nombreBodega).ToList();
            */
            iteradorBodega = crearIterador(bodegas);
            iteradorBodega.primero();
            while (!iteradorBodega.haTerminado())
            {
                iteradorBodega.haTerminado();
                objeto = iteradorBodega.actual(filtros);
                if (objeto != null)
                {
                    bodegasConActualizacion.Add(objeto);
                    nombreObjeto = objeto.nombreBodega;
                    nombresBodegasConActualizacion.Add(nombreObjeto);
                }
                iteradorBodega.siguiente();
            }
            return nombresBodegasConActualizacion;
        }

        public void tomarSeleccionBodega(string seleccionBodega)
        {
            bodegaSeleccionada = bodegasConActualizacion.FirstOrDefault(x => x.nombreBodega == seleccionBodega);

            obtenerActualizaciones();
            buscarVinosAActualizar();
            actualizarOCrearVinos(listaVinosAActualizar, listaNuevosVinos);
            setFechaUltimaActualizacion(getFechaActual(), bodegaSeleccionada);
            pantalla.mostarResumen(listaFinalVinos, bodegaSeleccionada.nombreBodega);
            enviarNotificacion(enofilos);
            //finCasoUso();
        }

        //poner debajo de tomarSeleccionBodega()
        public void obtenerActualizaciones()
        {
            vinosConActualizacion = Datos.InterfazAPIBodega.ObtenerActualizaciones();
        }

        public void buscarVinosAActualizar()
        {
            /*
            listaVinosAActualizar.Clear();
            for (int i = 0; i < vinosConActualizacion.Count; i++)
            {
                bool validar = bodegaSeleccionada.esTuVino(vinosConActualizacion[i].bodegaVino.nombreBodega, bodegaSeleccionada.nombreBodega);
                if (validar)
                {
                    listaVinosAActualizar.Add(vinosConActualizacion[i]);
                 
                }
                
            }
            Console.WriteLine(listaVinosAActualizar);
            */
            listaVinosAActualizar.Clear();
            object variable = 1;
            var filtros = new List<object> { variable, bodegaSeleccionada.nombreBodega };
            iteradorVino = crearIterador(vinosConActualizacion);
            iteradorVino.primero();
            while (!iteradorVino.haTerminado())
            {
                iteradorVino.haTerminado();
                vinoObjeto = iteradorVino.actual(filtros);
                if (vinoObjeto != null)
                {
                    listaVinosAActualizar.Add(vinoObjeto);
                }
                iteradorVino.siguiente();
            }
        }

        public string getFechaActual()
        {
            DateTime fechaActual = DateTime.Now;
            string fechaActualString = fechaActual.ToString("dd-MM-yyyy");
            return fechaActualString;

        }

        public void actualizarOCrearVinos(List<Vino> listaVinosAActualizar, List<Vino> listaNuevosVinos)
        {
            //Parte de Actualizar
            actualizarVino(listaVinosAActualizar);
            //Parte de Crear (solo se ejecuta si hay vinos nuevos sin crear)
            Console.WriteLine(listaNuevosVinos);
            if (listaNuevosVinos.Count != 0)
            {
                crearVino(listaNuevosVinos);
            }
            Console.WriteLine(listaNuevosVinos);
        }

        public void actualizarVino(List<Vino> listaVinosAActualizar)
        {
            //Console.WriteLine(listaVinosAActualizar);
            listaFinalVinos.Clear();
            listaNuevosVinos.Clear();
            for (int i = 0; i < listaVinosAActualizar.Count; i++)
            {
                bodegaSeleccionada.actualizarDatosDeVino(listaVinosAActualizar[i], vinos, getFechaActual(), listaFinalVinos, listaNuevosVinos);
            }
        }

        public void crearVino(List<Vino> creados)
        {
            //por cada uno de los vinos nuevos que no existen en la base de datos de la bodega: nuevos
            for (int i = 0; i < creados.Count; i++)
            {
                for (int j = 0; j < creados[i].maridajeVino.Count; j++)
                {
                    buscarMaridaje(creados[i].maridajeVino[j].nombreMaridaje, listaNuevoVinoMaridaje);
                }

                for (int k = 0; k < creados[i].varietalVino.Count; k++)
                {
                    buscarTipoUva(creados[i].varietalVino[k].tipoUvaVarietal.nombreUva, listaNuevoVinoTU);
                }

                crearNuevoVino(creados[i], listaNuevoVinoMaridaje, listaNuevoVinoTU);
                listaNuevoVinoMaridaje.Clear();
                listaNuevoVinoTU.Clear();
            }
        }


        public void buscarMaridaje(string nombreMaridaje, List<Maridaje> listaNuevoVinoM)
        {
            /*
            for (int i = 0; i < maridajes.Count; i++)
            {
                if (maridajes[i].sosMaridaje(nombreMaridaje, maridajes[i].nombreMaridaje))
                {
                    listaNuevoVinoM.Add(maridajes[i]);
                    Console.WriteLine(listaNuevoVinoM);
                };

            }
            */
            object variable = 1;
            var filtros = new List<object> { variable, nombreMaridaje };
            iteradorMaridaje = crearIterador(maridajes);
            iteradorMaridaje.primero();
            while (!iteradorMaridaje.haTerminado())
            {
                iteradorMaridaje.haTerminado();
                maridajeObjeto = iteradorMaridaje.actual(filtros);
                if (maridajeObjeto != null)
                {
                    listaNuevoVinoM.Add(maridajeObjeto);
                }
                iteradorMaridaje.siguiente();
            }

        }

        public void buscarTipoUva(string nombreTipoUva, List<TipoUva> listaNuevoVinoTU)
        {
            /*
            for (int i = 0; i < tiposUva.Count; i++)
            {
                if (tiposUva[i].sosTipoUva(nombreTipoUva, tiposUva[i].nombreUva))
                {
                    listaNuevoVinoTU.Add(tiposUva[i]);
                    Console.WriteLine(listaNuevoVinoTU);
                }
            }
            */
            object variable = 1;
            var filtros = new List<object> { variable, nombreTipoUva };
            iteradorTipoUva = crearIterador(tiposUva);
            iteradorTipoUva.primero();
            while (!iteradorTipoUva.haTerminado())
            {
                iteradorTipoUva.haTerminado();
                tipoUvaObjeto = iteradorTipoUva.actual(filtros);
                if (tipoUvaObjeto != null)
                {
                    listaNuevoVinoTU.Add(tipoUvaObjeto);
                }
                iteradorTipoUva.siguiente();
            }
        }

        public void crearNuevoVino(Vino creado, List<Maridaje> listaNuevoVinoMaridaje, List<TipoUva> listaNuevoVinoTU)
        {
            // Crear una nueva lista de maridajes basada en la lista proporcionada
            var nuevaListaMaridaje = new List<Maridaje>(listaNuevoVinoMaridaje);

            // Crear una nueva lista de varietales basada en la lista del vino creado
            //var nuevaListaVarietales = new List<Varietal>(creado.varietalVino);

            var nuevaListaVarietales = new List<Varietal>();
            for (int i = 0; i < creado.varietalVino.Count; i++)
            {
                Varietal nuevoVarietal = creado.crearVarietal(listaNuevoVinoTU, creado.varietalVino[i]);
                nuevaListaVarietales.Add(nuevoVarietal);
                Console.WriteLine(nuevaListaVarietales);
                Console.WriteLine(creado);
            }

            // Crear el nuevo vino con las nuevas listas
            Vino nuevoVino = new Vino(
                creado.añadaVino,
                creado.imagenEtiquetaVino,
                creado.nombreVino,
                creado.notaDeCataBodegaVino,
                creado.precioARSVino,
                creado.bodegaVino,
                nuevaListaMaridaje,
                getFechaActual(),
                nuevaListaVarietales
            );

            vinos.Add(nuevoVino);
            listaFinalVinos.Add(nuevoVino);
            Console.WriteLine(nuevoVino);
        }

        public void setFechaUltimaActualizacion(string fechaActual, Bodega bodegaSeleccionada)
        {
            bodegaSeleccionada.setFechaUltimaActualizacion(fechaActual);
        }

        public void enviarNotificacion(List<Enofilo> enofilos)
        {
            /*
            InterfazNotificacionPush interfazNotificacion = new InterfazNotificacionPush();

            for (int i = 0; i < enofilos.Count; i++)
            {
                if (enofilos[i].esSeguidor(bodegaSeleccionada.nombreBodega))
                {
                    string nombreEnofilo = enofilos[i].getNombreUsuario();
                    Console.WriteLine(nombreEnofilo);
                    listaNombreEnofilosSuscriptos.Add(nombreEnofilo);
                    Console.WriteLine(listaNombreEnofilosSuscriptos);
                };
            }

            for (int j = 0; j < enofilos.Count; j++)
            {
                interfazNotificacion.enviarNotificacionPush();
            }
            */
            InterfazNotificacionPush interfazNotificacion = new InterfazNotificacionPush();
            object variable = 1;
            var filtros = new List<object> { variable, bodegaSeleccionada.nombreBodega };
            iteradorEnofilo = crearIterador(enofilos);
            iteradorEnofilo.primero();
            while (!iteradorEnofilo.haTerminado())
            {
                iteradorEnofilo.haTerminado();
                enofiloObjeto = iteradorEnofilo.actual(filtros);
                if (enofiloObjeto != null)
                {
                    listaNombreEnofilosSuscriptos.Add(enofiloObjeto.getNombreUsuario());
                }
                iteradorEnofilo.siguiente();
            }
            for (int j = 0; j < enofilos.Count; j++)
            {
                interfazNotificacion.enviarNotificacionPush();
            }
        }

        public void finCasoUso()
        {
            Application.Exit();
        }

        public IIterador<Bodega> crearIterador(List<Bodega> bodegas)
        {
            IteradorBodega iteradorBodega = new IteradorBodega(bodegas);

            return iteradorBodega;
        }

        public IIterador<Vino> crearIterador(List<Vino> vinosConActualizacion)
        {
            IteradorVino iteradorVino = new IteradorVino(vinosConActualizacion);

            return iteradorVino;
        }

        public IIterador<Maridaje> crearIterador(List<Maridaje> maridajes)
        {
            IteradorMaridaje iteradorMaridaje = new IteradorMaridaje(maridajes);

            return iteradorMaridaje;
        }

        public IIterador<TipoUva> crearIterador(List<TipoUva> tiposUva)
        {
            IteradorTipoUva iteradorTipoUva = new IteradorTipoUva(tiposUva);

            return iteradorTipoUva;
        }

        public IIterador<Enofilo> crearIterador(List<Enofilo> enofilos)
        {
            IteradorEnofilo iteradorEnofilo = new IteradorEnofilo(enofilos);

            return iteradorEnofilo;
        }
    }
}