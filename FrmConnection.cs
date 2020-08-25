using Speed.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExportDbToFile
{
    public partial class FrmConnection : Form
    {

        DbConnection Connection;

        public FrmConnection()
        {
            InitializeComponent();
        }

        private void FrmConnection_Load(object sender, EventArgs e)
        {
            //LoadData();
        }

        void LoadData()
        {
            if (Connection == null)
            {
                cboDbType.Items.Clear();
                cboDbType.Items.Add(EnumDbProviderType.Oracle.ToString());
                cboDbType.Items.Add(EnumDbProviderType.SqlServer.ToString());
                cboDbType.Items.Add(EnumDbProviderType.Access.ToString());
                cboDbType.Items.Add(EnumDbProviderType.MySql.ToString());
                cboDbType.Items.Add(EnumDbProviderType.PostgreSQL.ToString());
                cboDbType.Sorted = true;

                Connection = new DbConnection();
                SetValues();
            }
        }

        void SetValues()
        {
            txtName.Text = Connection.Name;
            txtConnectionString.Text = Connection.ConnectionString;

            cboDbType.SelectedIndex = -1;

            if (Connection.ProviderType != null)
            {
                cboDbType.SelectedItem = Connection.ProviderType;
            }
        }

        void GetValues()
        {
            Connection.Name = txtName.Text.Trim();
            Connection.ConnectionString = txtConnectionString.Text.Trim();
            Connection.ProviderType = cboDbType.SelectedItem.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboDbType.SelectedIndex == 0 || string.IsNullOrWhiteSpace(txtName.Text.Trim()) || string.IsNullOrWhiteSpace(txtConnectionString.Text.Trim()))
            {
                Program.ShowError("Todos os campos são obrigatórios");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        public static DialogResult ShowDialog(DbConnection connection)
        {
            using (var f = new FrmConnection())
            {
                f.LoadData();
                f.Connection = connection;
                f.SetValues();

                if (f.ShowDialog() == DialogResult.OK)
                {
                    f.GetValues();
                    f.DialogResult = DialogResult.OK;
                }
                return f.DialogResult;
            }
        }
    }
}
