using ImportarBodega.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportarBodega.Entidades
{
    public class Vino
    {
        [Key]
        public int id { get; set; }
        private string añada;
        private string imagenEtiqueta;
        private string nombre;
        private int notaDeCataBodega;
        private float precioARS;
        private Bodega bodega;
        private List<Maridaje> maridaje;
        private string fechaActualizacion;
        private List<Varietal> varietal;

        public Vino(string añadaVino, string imagenEtiquetaVino, string nombreVino, int notaDeCataBodegaVino, float precioARSVino, Bodega bodegaVino, List<Maridaje> maridajeVino, string fechaActualizacionVino, List<Varietal> varietalVino)
        {
            añada = añadaVino;
            imagenEtiqueta = imagenEtiquetaVino;
            nombre = nombreVino;
            notaDeCataBodega = notaDeCataBodegaVino;
            precioARS = precioARSVino;
            bodega = bodegaVino;
            maridaje = maridajeVino;
            fechaActualizacion = fechaActualizacionVino;
            varietal = varietalVino;
        }

        public Vino() { }

        public string añadaVino
        {
            get => añada;
            set => añada = value;
        }

        public string imagenEtiquetaVino
        {
            get => imagenEtiqueta;
            set => imagenEtiqueta = value;
        }

        public string nombreVino
        {
            get => nombre;
            set => nombre = value;
        }

        public int notaDeCataBodegaVino
        {
            get => notaDeCataBodega;
            set => notaDeCataBodega = value;
        }

        public float precioARSVino
        {
            get => precioARS;
            set => precioARS = value;
        }

        public Bodega bodegaVino
        {
            get => bodega;
            set => bodega = value;
        }

        public List<Maridaje> maridajeVino
        {
            get => maridaje;
            set => maridaje = value;
        }

        public string fechaActualizacionV
        {
            get => fechaActualizacion;
            set => fechaActualizacion = value;
        }

        public List<Varietal> varietalVino
        {
            get => varietal;
            set => varietal = value;
        }

        public bool sosParaActualizar(string nombreAllVino, string nombreVinoAct)
        {
            if (string.IsNullOrWhiteSpace(nombreAllVino) || string.IsNullOrWhiteSpace(nombreVinoAct))
            {
                return false;
            }

            return nombreAllVino.Trim().Equals(nombreVinoAct.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        public void setPrecio(float precio)
        {
            this.precioARS = precio;
        }

        public void setNotaCata(int notaDeCataBodega)
        {
            this.notaDeCataBodegaVino = notaDeCataBodega;
        }

        public void setImagenEtiqueta(string imagenEtiqueta)
        {
            this.imagenEtiquetaVino = imagenEtiqueta;
        }

        public void setFechaActualizacion(string fechaActual)
        {
            this.fechaActualizacion = fechaActual;
        }

        public Varietal crearVarietal(List<TipoUva> listaNuevoVinoTU, Varietal creadoVarietal)
        {
            for (int i = 0; i < listaNuevoVinoTU.Count; i++)
            {

                if (listaNuevoVinoTU[i].nombreUva == creadoVarietal.tipoUvaVarietal.nombreUva)
                {
                    Varietal nuevoVarietal = new Varietal(creadoVarietal.descripcionVarietal, creadoVarietal.porcentajeTiposUvaVarietal, listaNuevoVinoTU[i]);
                    return nuevoVarietal;
                }

            }
            return null;
        }

        public bool esTuVino(String nombreBodega)
        {
            return bodega.esTuVino(this.bodegaVino.nombreBodega, nombreBodega);
        }
    }
}
