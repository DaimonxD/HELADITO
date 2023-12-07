using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HELADITO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        HELADITOS oHeladito = new HELADITOS();

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarGustos();
            CargarSucursales();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
         

        }

        private void CargarSucursales()
        {
            DataTable sucursales = oHeladito.sucursales();

            CbSucursal.DisplayMember = "nombre";
            CbSucursal.ValueMember = "sucursal_id";
            CbSucursal.DataSource = sucursales;
        }

        private void CargarGustos()
        {
            DataTable gustos = oHeladito.gustos();

            CbGusto.DisplayMember = "nombre";
            CbGusto.ValueMember = "gusto_id";
            CbGusto.DataSource = gustos;
        }

        private void BtnVer_Click(object sender, EventArgs e)
        {
            int gustoId = Convert.ToInt32(CbTipo.SelectedValue);

            DataTable tabla = oHeladito.GetVentasPorGusto(gustoId);

            Grilla.DataSource = tabla;
        }
    }
}
