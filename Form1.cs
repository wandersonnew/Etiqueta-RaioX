using System.Data;
using System.Windows.Forms;

namespace FormEtiquetaRX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dado = new Dictionary<string, object>();
            EtiquetarxController etiquetarxController = new EtiquetarxController();
            dado = etiquetarxController.BuscarDados(nmrPedido.Text);

            DataTable table = new DataTable();
            foreach (KeyValuePair<string, object> item in dado)
                table.Columns.Add(item.Key);

            object[] values = new object[dado.Count];
            int i = 0;
            foreach (KeyValuePair<string, object> item in dado)
                values[i++] = item.Value;

            table.Rows.Add(values);
            dataGridViewEtiqueta.DataSource = table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            impressoraComboBox.Items.Clear();

            foreach (var printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                impressoraComboBox.Items.Add(printer);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(impressoraComboBox.SelectedItem.ToString());
            // MessageBox.Show(impressoraComboBox.SelectedItem.ToString());
            // MessageBox.Show((string)dataGridViewEtiqueta.Rows[0].Cells[0].Value);
            List<string> dadosetiqueta = new List<string>()
            {
                (string)dataGridViewEtiqueta.Rows[0].Cells[0].Value + " " + (string)dataGridViewEtiqueta.Rows[0].Cells[1].Value,
                (string)dataGridViewEtiqueta.Rows[0].Cells[2].Value + " " + (string)dataGridViewEtiqueta.Rows[0].Cells[3].Value,
                (string)dataGridViewEtiqueta.Rows[0].Cells[4].Value,
                (string)dataGridViewEtiqueta.Rows[0].Cells[6].Value + " " + (string)dataGridViewEtiqueta.Rows[0].Cells[7].Value,
                (string)dataGridViewEtiqueta.Rows[0].Cells[5].Value,
                (string)dataGridViewEtiqueta.Rows[0].Cells[8].Value,
                (string)dataGridViewEtiqueta.Rows[0].Cells[9].Value,
                (string)dataGridViewEtiqueta.Rows[0].Cells[10].Value + " " + (string)dataGridViewEtiqueta.Rows[0].Cells[11].Value,
            };
            EtiquetarxController etiqueta = new EtiquetarxController();
            etiqueta.ImprimirDados(dadosetiqueta, impressoraComboBox.SelectedItem.ToString());
        }
    }
}