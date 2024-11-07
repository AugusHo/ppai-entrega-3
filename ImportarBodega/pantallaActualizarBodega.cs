using ImportarBodega.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportarBodega
{
    public partial class pantallaActualizarBodega : Form
    {
        private GestorImportadorBodega gestor;

        public pantallaActualizarBodega(object dbContext)
        {
            InitializeComponent();
            clbBodegas.Enabled = false;
            btnSeleccionar.Enabled = false;
            dgBodega.Enabled = false;
            lblNombreBodega.Enabled = false;
            label1.Enabled = false;
            gestor = new GestorImportadorBodega(this);
        }

        private void opcionImportarActualizacionVino_Click(object sender, EventArgs e)
        {
            habilitarPantalla();
            if (gestor.OpcionImportarActualizacionVinos().Count == 0)
            {
                MessageBox.Show("No hay bodegas para actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                gestor.OpcionImportarActualizacionVinos().Clear();
                clbBodegas.DataSource = gestor.OpcionImportarActualizacionVinos();
            }



        }

        public void habilitarPantalla()
        {
            clbBodegas.Enabled = true;
            btnSeleccionar.Enabled = true;
            dgBodega.Enabled = true;
            label1.Enabled = true;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //gestor.tomarSeleccionBodega(clbBodegas.SelectedItem.ToString());
            if (dgBodega.Rows.Count > 0)
            {
                dgBodega.DataSource = null;  // Esto limpiará el DataGridView
            }


            List<string> bodegasSeleccionadas = clbBodegas.CheckedItems.Cast<string>().ToList();


            gestor.tomarSeleccionBodega(bodegasSeleccionadas);



        }


        public void mostarResumen(List<Vino> vinos, string nombreBodega)
        {
            List<VinoTabla> vinosTabla = this.Transformar(vinos);
            var existingData = dgBodega.DataSource as List<VinoTabla>;

            if (existingData != null)
            {
                vinosTabla.AddRange(existingData);
            }
            dgBodega.DataSource = null;
            dgBodega.DataSource = vinosTabla;
            lblNombreBodega.Enabled = true;
            lblNombreBodega.Text = ("Nombre de la bodega: " + nombreBodega);
        }

        public List<VinoTabla> Transformar(List<Vino> vinos)
        {
            return vinos.Select(v => new VinoTabla
            {
                Añada = v.añadaVino,
                ImagenEtiqueta = v.imagenEtiquetaVino,
                Nombre = v.nombreVino,
                NotaDeCataBodega = v.notaDeCataBodegaVino,
                PrecioARS = v.precioARSVino,
                NombreBodega = v.bodegaVino?.nombreBodega ?? "Sin nombre de bodega",
                DatosMaridaje = v.maridajeVino != null
                    ? string.Join(" // ", v.maridajeVino
                                    .Where(m => m != null)
                                    .Select(m => $"{m.nombreMaridaje}: {m.descripcionMaridaje}"))
                    : "Sin datos de maridaje",
                FechaActualizacion = v.fechaActualizacionV,
                DatosVarietal = v.varietalVino != null
                    ? string.Join(" // ", v.varietalVino
                                    .Where(varietal => varietal != null && varietal.tipoUvaVarietal != null)
                                    .Select(varietal => $"{varietal.porcentajeTiposUvaVarietal}% de {varietal.tipoUvaVarietal.nombreUva}: {varietal.descripcionVarietal}"))
                    : "Sin datos de varietal"
            }).ToList();

        }

        private void pantallaActualizarBodega_Load(object sender, EventArgs e)
        {

        }
    }
}

