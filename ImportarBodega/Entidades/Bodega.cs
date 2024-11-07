using ImportarBodega.Entidades;
using ImportarBodega.Interfaces;
using ImportarBodega.Iteradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Entidades
{
    public class Bodega : IAgregado<Vino>
    {

        [Key]
        public int id { get; set; }
        private List<Object> filtros;
        private Vino vinoObjeto;
        private string nombreVino;
        private List<string> nombresVinosConActualizacion = new List<string>();
        private IIterador<Vino> iteradorVino;


        private string descripcion;
        private string historia;
        private string nombre;
        private bool periodoActualizacion;
        private int coordenadasUbicacion;
        private string fechaUltimaActualizacion;


        public Bodega(string descripcionBodega, string historiaBodega, string nombreBodega, bool periodoActualizacionBodega, int coordenadasUbicacionBodega, string fechaUltimaActualizacionBodega)
        {
            descripcion = descripcionBodega;
            historia = historiaBodega;
            nombre = nombreBodega;
            periodoActualizacion = periodoActualizacionBodega;
            coordenadasUbicacion = coordenadasUbicacionBodega;
            fechaUltimaActualizacion = fechaUltimaActualizacionBodega;
        }

        public Bodega() { }

        public string descripcionBodega
        {
            get => descripcion;
            set => descripcion = value;
        }

        public string historiaBodega
        {
            get => historia;
            set => historia = value;
        }

        public string nombreBodega
        {
            get => nombre;
            set => nombre = value;
        }

        public bool periodoActualizacionBodega
        {
            get => periodoActualizacion;
            set => periodoActualizacion = value;
        }

        public int coordenadasUbicacionBodega
        {
            get => coordenadasUbicacion;
            set => coordenadasUbicacion = value;
        }

        public List<Bodega> bodegas { get; set; }

        //Metodos

        public bool estaParaActualizarNovedadesVino()
        {
            return periodoActualizacion;
        }

        public bool esTuVino(string nombreBodegaVino, string nombreBodega)
        {
            if (nombreBodegaVino == nombreBodega)
            {
                return true;
            };
            return false;
        }

        public void actualizarDatosDeVino(Vino vinoAActualizar, List<Vino> vinos, string fechaActual, List<Vino> listaFinalAct, List<Vino> listaCreados)
        {
           
            bool vinoEncontrado = false;
            Object variable = 2;
            var filtros = new List<object> { variable, vinoAActualizar.nombreVino, vinoAActualizar.añadaVino, vinoAActualizar.bodegaVino.nombre };
            iteradorVino = crearIterador(vinos);
            iteradorVino.primero();
            while (!iteradorVino.haTerminado())
            {
                iteradorVino.haTerminado();
                vinoObjeto = iteradorVino.actual(filtros);
                if (vinoObjeto != null)
                {
                    vinoObjeto.setPrecio(vinoAActualizar.precioARSVino);
                    vinoObjeto.setNotaCata(vinoAActualizar.notaDeCataBodegaVino);
                    vinoObjeto.setImagenEtiqueta(vinoAActualizar.imagenEtiquetaVino);
                    vinoObjeto.setFechaActualizacion(fechaActual);
                    vinoEncontrado = true;
                    listaFinalAct.Add(vinoObjeto);
                    break;
                }
               
                iteradorVino.siguiente();
            }

            if (!vinoEncontrado)
            {
                listaCreados.Add(vinoAActualizar);
                Console.WriteLine(listaCreados);
            }

        }

        public void setFechaUltimaActualizacion(string fechaActual)
        {
            this.fechaUltimaActualizacion = fechaActual;
            Console.WriteLine(this.fechaUltimaActualizacion);
        }

        public IIterador<Vino> crearIterador(List<Vino> coleccion)
        {
            IteradorVino iteradorVino = new IteradorVino(coleccion);

            return iteradorVino;
        }

    }
}
