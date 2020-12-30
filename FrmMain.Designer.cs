namespace ExportDbToFile
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSelect = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnNewConnection = new System.Windows.Forms.Button();
            this.chkNotExportNulls = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboConnections = new System.Windows.Forms.ComboBox();
            this.cboExportType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panProgress = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panInput = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.groupBox2.SuspendLayout();
            this.panProgress.SuspendLayout();
            this.panInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtSelect);
            this.groupBox2.Location = new System.Drawing.Point(11, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(854, 181);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select";
            // 
            // txtSelect
            // 
            this.txtSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSelect.Location = new System.Drawing.Point(3, 16);
            this.txtSelect.Multiline = true;
            this.txtSelect.Name = "txtSelect";
            this.txtSelect.Size = new System.Drawing.Size(848, 162);
            this.txtSelect.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Diretório de Exportação";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(145, 258);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(717, 20);
            this.txtDirectory.TabIndex = 3;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Location = new System.Drawing.Point(778, 309);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(84, 23);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnNewConnection
            // 
            this.btnNewConnection.Location = new System.Drawing.Point(694, 10);
            this.btnNewConnection.Name = "btnNewConnection";
            this.btnNewConnection.Size = new System.Drawing.Size(74, 23);
            this.btnNewConnection.TabIndex = 1;
            this.btnNewConnection.Text = "Conexões";
            this.toolTip1.SetToolTip(this.btnNewConnection, "Nova conexão");
            this.btnNewConnection.UseVisualStyleBackColor = true;
            this.btnNewConnection.Click += new System.EventHandler(this.btnNewConnection_Click);
            // 
            // chkNotExportNulls
            // 
            this.chkNotExportNulls.AutoSize = true;
            this.chkNotExportNulls.Checked = true;
            this.chkNotExportNulls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotExportNulls.Location = new System.Drawing.Point(16, 309);
            this.chkNotExportNulls.Name = "chkNotExportNulls";
            this.chkNotExportNulls.Size = new System.Drawing.Size(155, 17);
            this.chkNotExportNulls.TabIndex = 11;
            this.chkNotExportNulls.Text = "Não exportar campos nulos";
            this.toolTip1.SetToolTip(this.chkNotExportNulls, "Nao gerar arquivo quando o valor do campo à ser exportado for nulo");
            this.chkNotExportNulls.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Conexões";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboConnections
            // 
            this.cboConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConnections.FormattingEnabled = true;
            this.cboConnections.Location = new System.Drawing.Point(125, 10);
            this.cboConnections.Name = "cboConnections";
            this.cboConnections.Size = new System.Drawing.Size(563, 21);
            this.cboConnections.TabIndex = 0;
            // 
            // cboExportType
            // 
            this.cboExportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExportType.FormattingEnabled = true;
            this.cboExportType.Items.AddRange(new object[] {
            "Nomes de arquivos gerados dinâmicamente",
            "Nomes de arquivos no SELECT"});
            this.cboExportType.Location = new System.Drawing.Point(125, 37);
            this.cboExportType.Name = "cboExportType";
            this.cboExportType.Size = new System.Drawing.Size(294, 21);
            this.cboExportType.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Modo de Exportação";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panProgress
            // 
            this.panProgress.Controls.Add(this.btnCancel);
            this.panProgress.Controls.Add(this.lblMessage);
            this.panProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panProgress.Location = new System.Drawing.Point(0, 348);
            this.panProgress.Name = "panProgress";
            this.panProgress.Size = new System.Drawing.Size(877, 38);
            this.panProgress.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(778, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.SteelBlue;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(877, 38);
            this.lblMessage.TabIndex = 8;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panInput
            // 
            this.panInput.Controls.Add(this.label4);
            this.panInput.Controls.Add(this.txtExtension);
            this.panInput.Controls.Add(this.label2);
            this.panInput.Controls.Add(this.groupBox2);
            this.panInput.Controls.Add(this.chkNotExportNulls);
            this.panInput.Controls.Add(this.label1);
            this.panInput.Controls.Add(this.picHelp);
            this.panInput.Controls.Add(this.txtDirectory);
            this.panInput.Controls.Add(this.cboExportType);
            this.panInput.Controls.Add(this.btnExportar);
            this.panInput.Controls.Add(this.label3);
            this.panInput.Controls.Add(this.cboConnections);
            this.panInput.Controls.Add(this.btnNewConnection);
            this.panInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panInput.Location = new System.Drawing.Point(0, 0);
            this.panInput.Name = "panInput";
            this.panInput.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panInput.Size = new System.Drawing.Size(877, 386);
            this.panInput.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Extensão";
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(145, 283);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(68, 20);
            this.txtExtension.TabIndex = 13;
            this.txtExtension.Text = "xml";
            // 
            // picHelp
            // 
            this.picHelp.Image = global::ExportDbToFile.Properties.Resources.Help;
            this.picHelp.Location = new System.Drawing.Point(425, 40);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(16, 16);
            this.picHelp.TabIndex = 1;
            this.picHelp.TabStop = false;
            this.picHelp.Click += new System.EventHandler(this.picHelp_Click);
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 386);
            this.Controls.Add(this.panProgress);
            this.Controls.Add(this.panInput);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Db To File";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panProgress.ResumeLayout(false);
            this.panInput.ResumeLayout(false);
            this.panInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboConnections;
        private System.Windows.Forms.Button btnNewConnection;
        private System.Windows.Forms.ComboBox cboExportType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkNotExportNulls;
        private System.Windows.Forms.Panel panProgress;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panInput;
        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExtension;
    }
}

