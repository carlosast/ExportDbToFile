using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Speed.Common;
using Speed.Data;
using Translogic.Modules.Core.Spd;
using Translogic.Modules.Core.Spd.BLL;
using Translogic.Modules.Core.Spd.Data;

namespace ExportarCteXml
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = progressBar.Visible = false;

            Show();

            Sis.Inicializar(Translogic.Modules.Core.Spd.Data.Enums.EnumSistema.Indefinido, "ExportarCteXml", false);

#if DEBUG
            txtSelect.Text =
@"select id_cte from translogic.cte c where
c.data_cte between to_Date('01/08/2019 00:00:00','dd/mm/yyyy hh24:mi:ss')
and to_Date('31/07/2020 23:59:59','dd/mm/yyyy hh24:mi:ss')
and c.sigla_uf_ferrovia in ('MT','MS','SP')
AND C.SITUACAO_ATUAL = 'AUT'";

            txtDirectory.Text = @"D:\temp\ExportCtes";

            //btnExportar_Click(null, null);
#endif
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = txtDirectory.Text.Trim();

                if (dir == string.Empty)
                    throw new Exception("Entre o diretório");

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string chaves = txtChaves.Text.Trim();
                string select = txtSelect.Text.Trim();

                if (chaves == string.Empty && select == string.Empty)
                    throw new Exception("Entre a lista de chaves ou o select");

                if (chaves != string.Empty && select != string.Empty)
                    throw new Exception("Entre as chaves ou o select. Não ambos ao mesmo tempo");

                var exp = new ExportXml();
                DateTime date = DateTime.Now;

                lblMessage.Visible = progressBar.Visible = true;
                int count = exp.Export(dir, chaves, select, progressBar, lblMessage);

                string msg = "Exportados " + count + " arquivos. Tempo: " + DateTime.Now.Subtract(date);
                MessageBox.Show(msg, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblMessage.Visible = progressBar.Visible = false;
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            string msg =
@"
Entre um select com o campo que deseja exportar.
    ex: select coluna_com_arquivo from minha_tabela where .... order by ....
Se deseja ao exportar ter controle sobre o nome do arquivo, retorne na primeira coluna o nome do arquivo e na segunda coluna o campo à ser exportado
    ex: select 'XML_' || coluna_com_id, coluna_com_arquivo from minha_tabela where .... order by ....
";
        }
    }

}
