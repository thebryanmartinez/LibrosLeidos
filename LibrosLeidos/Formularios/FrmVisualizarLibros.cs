﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using LibrosLeidos.Domain;

namespace LibrosLeidos
{
    public partial class FrmVisualizarLibros : KryptonForm
    {
        ClsVisualizarDatos datos = new ClsVisualizarDatos();
        private BusinessLogicLayer _businessLogicLayer = new BusinessLogicLayer();

        public FrmVisualizarLibros()
        {
            InitializeComponent();
        }

        private void FrmVisualizarLibros_Load(object sender, EventArgs e)
        {
            CargarLibros();
        }

        private void CargarLibros()
        {
            List<ClsIngresoDatos> libros = _businessLogicLayer.ObtenerLibros();
            dgvLibrosLeidos.DataSource = libros;
        }

        private void btnIngresarLibro_Click(object sender, EventArgs e)
        {
            this.Hide();
            datos.AbrirFrmIngresoLibros();
            this.Close();
        }

        private void dgvLibrosLeidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewLinkCell cell = (DataGridViewLinkCell)dgvLibrosLeidos.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if(cell.Value.ToString() == "Editar")
            {
                FrmIngresoLibros ingreso = new FrmIngresoLibros();
                ingreso.CargarLibros(new ClsIngresoDatos {
                    id = int.Parse(dgvLibrosLeidos.Rows[e.RowIndex].Cells[0].Value.ToString()),
                    numero_id_ano = int.Parse(dgvLibrosLeidos.Rows[e.RowIndex].Cells[1].Value.ToString()),
                    nombre_libro = dgvLibrosLeidos.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    nombre_autor = dgvLibrosLeidos.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    saga_serie_trilogia = dgvLibrosLeidos.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    numero_saga = double.Parse(dgvLibrosLeidos.Rows[e.RowIndex].Cells[5].Value.ToString()),
                    ano_leido = int.Parse(dgvLibrosLeidos.Rows[e.RowIndex].Cells[6].Value.ToString()),
                });
                this.Hide();
                ingreso.ShowDialog(this);
                this.Close();
            }
            else if(cell.Value.ToString() == "Eliminar")
            {
                EliminarLibro(int.Parse(dgvLibrosLeidos.Rows[e.RowIndex].Cells[0].Value.ToString()));
                CargarLibros();
            }
        }

        private void EliminarLibro(int id)
        {
            _businessLogicLayer.EliminarLibro(id);

        }
    }
}
