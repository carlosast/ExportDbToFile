using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Speed.Data;

namespace ExportDbToFile
{

    public partial class FrmMain : Form
    {

        int count;
        DateTime date;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panProgress.Visible = false;
            panInput.Enabled = true;

            cboConnections.DisplayMember = "Name";
            cboConnections.Sorted = true;
            cboConnections.DataSource = Settings.Load();

            cboExportType.SelectedIndex = 1;

            Show();

            txtDirectory.Text = @"c:\temp";
#if DEBUG
            txtSelect.Text =
@"select
    C.CHAVE_CTE || '.pdf', 
    A.ARQUIVO_PDF
from
    translogic.cte c inner join cte_arquivo a on a.id_cte = c.id_cte
where
    c.data_cte between to_Date('01/01/2018 00:00:00','dd/mm/yyyy hh24:mi:ss') and to_Date('31/12/2018 23:59:59','dd/mm/yyyy hh24:mi:ss')
    AND C.SITUACAO_ATUAL = 'AUT'
";

            txtDirectory.Text = @"D:\temp\ExportCtes";


            //btnExportar_Click(null, null);
#endif
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Program.RunSafe(this, () =>
            {
                if (cboConnections.SelectedIndex == -1)
                {
                    throw new Exception("Selecione a conexão");
                }
                
                if (txtSelect.Text.Trim() == string.Empty)
                {
                    throw new Exception("Entre o SELECT");
                }
                
                if (txtDirectory.Text.Trim() == string.Empty)
                {
                    throw new Exception("Entre o Diretório");
                }

                if (!Program.Confirm("Confirma a exportação?"))
                {
                    return;
                }
            });

            worker.RunWorkerAsync();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            using (var f = new FrmHelp())
                f.ShowDialog();
        }

        private void btnNewConnection_Click(object sender, EventArgs e)
        {
            Program.RunSafe(this, () =>
            {
                using (var f = new FrmConnections())
                    f.ShowDialog();

                var cur = cboConnections.SelectedItem;
                cboConnections.DataSource = null;
                var connections = Settings.Load();
                cboConnections.DisplayMember = "Name";
                cboConnections.DataSource = connections;
                if (cur != null && connections.Any())
                {
                    cboConnections.SelectedItem = cur;
                }
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            panProgress.Visible = true;
            panInput.Enabled = false;

            var connection = cboConnections.SelectedItem as DbConnection;
            string dir = txtDirectory.Text.Trim();

            if (dir == string.Empty)
                throw new Exception("Entre o diretório");

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string select = txtSelect.Text.Trim();

            var exp = new ExportXml();
            date = DateTime.Now;

            using (var db = Sys.NewDb(connection.GetProviderType(), connection.ConnectionString))
            {
                count = exp.Export(db, worker, dir, select, cboExportType.SelectedIndex == 1, !chkNotExportNulls.Checked, lblMessage, txtExtension.Text, out count);
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panProgress.Visible = false;
            panInput.Enabled = true;

            string msg = "Exportados " + count + " arquivos. Tempo: " + DateTime.Now.Subtract(date);
            Program.ShowInformation(this, msg);
        }
    }

}
