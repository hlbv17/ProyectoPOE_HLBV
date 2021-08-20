
namespace Visual
{
    partial class FrmListarCitasHLBV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_odontologo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_consultorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCitas
            // 
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_paciente,
            this.col_fecha,
            this.col_hora,
            this.col_odontologo,
            this.col_consultorio});
            this.dgvCitas.Location = new System.Drawing.Point(33, 48);
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.Size = new System.Drawing.Size(643, 315);
            this.dgvCitas.TabIndex = 0;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            // 
            // col_paciente
            // 
            this.col_paciente.HeaderText = "Paciente";
            this.col_paciente.Name = "col_paciente";
            // 
            // col_fecha
            // 
            this.col_fecha.HeaderText = "Fecha";
            this.col_fecha.Name = "col_fecha";
            // 
            // col_hora
            // 
            this.col_hora.HeaderText = "Hora";
            this.col_hora.Name = "col_hora";
            // 
            // col_odontologo
            // 
            this.col_odontologo.HeaderText = "Odontólogo";
            this.col_odontologo.Name = "col_odontologo";
            // 
            // col_consultorio
            // 
            this.col_consultorio.HeaderText = "Consultorio";
            this.col_consultorio.Name = "col_consultorio";
            // 
            // FrmListarCitasHLBV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 450);
            this.Controls.Add(this.dgvCitas);
            this.Name = "FrmListarCitasHLBV";
            this.Text = "FrmListarCitasHLBV";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_odontologo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_consultorio;
    }
}