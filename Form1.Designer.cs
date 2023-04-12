namespace FormEtiquetaRX
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBuscar = new Button();
            nmrPedido = new TextBox();
            label1 = new Label();
            dataGridViewEtiqueta = new DataGridView();
            btnImprimir = new Button();
            impressoraComboBox = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEtiqueta).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = SystemColors.MenuHighlight;
            btnBuscar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBuscar.ForeColor = SystemColors.Window;
            btnBuscar.Location = new Point(658, 17);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(130, 39);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // nmrPedido
            // 
            nmrPedido.Location = new Point(12, 70);
            nmrPedido.Name = "nmrPedido";
            nmrPedido.Size = new Size(323, 23);
            nmrPedido.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(151, 30);
            label1.TabIndex = 2;
            label1.Text = "N° do pedido:";
            // 
            // dataGridViewEtiqueta
            // 
            dataGridViewEtiqueta.AllowUserToAddRows = false;
            dataGridViewEtiqueta.AllowUserToDeleteRows = false;
            dataGridViewEtiqueta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEtiqueta.Location = new Point(12, 106);
            dataGridViewEtiqueta.Name = "dataGridViewEtiqueta";
            dataGridViewEtiqueta.ReadOnly = true;
            dataGridViewEtiqueta.RowTemplate.Height = 25;
            dataGridViewEtiqueta.Size = new Size(776, 113);
            dataGridViewEtiqueta.TabIndex = 3;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = SystemColors.MenuHighlight;
            btnImprimir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnImprimir.ForeColor = SystemColors.Window;
            btnImprimir.Location = new Point(658, 61);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(130, 39);
            btnImprimir.TabIndex = 4;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // impressoraComboBox
            // 
            impressoraComboBox.FormattingEnabled = true;
            impressoraComboBox.Location = new Point(341, 70);
            impressoraComboBox.Name = "impressoraComboBox";
            impressoraComboBox.Size = new Size(311, 23);
            impressoraComboBox.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(341, 17);
            label2.Name = "label2";
            label2.Size = new Size(121, 30);
            label2.TabIndex = 6;
            label2.Text = "Impressora";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 250);
            Controls.Add(label2);
            Controls.Add(impressoraComboBox);
            Controls.Add(btnImprimir);
            Controls.Add(dataGridViewEtiqueta);
            Controls.Add(label1);
            Controls.Add(nmrPedido);
            Controls.Add(btnBuscar);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Etiqueta RX";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewEtiqueta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBuscar;
        private TextBox nmrPedido;
        private Label label1;
        private DataGridView dataGridViewEtiqueta;
        private Button btnImprimir;
        private ComboBox impressoraComboBox;
        private Label label2;
    }
}