using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploSubUnformeClase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.CochesVendidos' Puede moverla o quitarla según sea necesario.
            this.cochesVendidosTableAdapter.Fill(this.dataSet1.CochesVendidos);

            this.reportViewer1.RefreshReport();

            this.reportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            //Guardo la idVendedor
            var codeID = int.Parse(e.Parameters["idCliente"].Values.First());
            //Creo un dataset y lo relleno
            DataSet1.CochesVendidosDataTable prueba = new DataSet1.CochesVendidosDataTable();
            this.cochesVendidosTableAdapter.FillBy(prueba, codeID.ToString());

            e.DataSources.Add(new ReportDataSource("DataSet1", (DataTable)prueba));
        }
    }
}
