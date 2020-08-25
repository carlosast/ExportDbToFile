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
    public partial class FrmConnections : Form
    {

        List<DbConnection> connections;

        public FrmConnections()
        {
            InitializeComponent();
        }

        private void FrmConnections_Load(object sender, EventArgs e)
        {
            connections = Settings.Load();
            grid.AutoGenerateColumns = false;
            grid.DataSource = null;
            grid.DataSource = connections;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var connection = new DbConnection { Name = "Nome da conexão" };

            if (FrmConnection.ShowDialog(connection) == DialogResult.OK)
            {
                connections.Add(connection);
                Settings.Save(connections);
                grid.DataSource = null;
                grid.DataSource = connections;
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.CurrentRow == null)
            {
                return;
            }

            if (e.ColumnIndex == colAdd.Index)
            {
                var connection = grid.CurrentRow.DataBoundItem as DbConnection;
                if (connection != null)
                {
                    if (FrmConnection.ShowDialog(connection) == DialogResult.OK)
                    {
                        Settings.Save(connections);
                        grid.DataSource = null;
                        grid.DataSource = connections;
                    }
                }
            }
            else if (e.ColumnIndex == colDelete.Index)
            {
                var connection = grid.CurrentRow.DataBoundItem as DbConnection;
                if (connection != null)
                {
                    if (Program.Confirm("Excluir a conexão '" + connection.Name + "'?"))
                    {
                        grid.DataSource = null;
                        connections.Remove(connection);
                        Settings.Save(connections);
                        grid.DataSource = connections;
                    }
                }
            }
        }
    }
}
