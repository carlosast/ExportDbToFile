using Speed.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Translogic.Modules.Core.Spd;
using Translogic.Modules.Core.Spd.BLL;
using Translogic.Modules.Core.Spd.Data;
using Speed.Common;

namespace ExportarCteXml
{
    public class ExportXml
    {
        StreamWriter writerOk;
        StreamWriter writerError;
        public int Export(string dir, string chaves, string select, ProgressBar progressBar, Label lblMessage)
        {
            int count = 0;

            using (writerOk = new StreamWriter(Path.Combine(dir, "_Export_OK.txt"), false))
            {
                using (writerError = new StreamWriter(Path.Combine(dir, "_Export_Error.txt"), false))
                {
                    using (var db = Dbs.NewDb(Db.Translogic))
                    {
                        var _chaves = ParseChaves(chaves);
                        foreach (var chave in _chaves)
                        {
                            var cte = BL_Cte.SelectSingle(db, new Cte { ChaveCte = chave });
                            if (cte != null)
                            {
                                count++;
                                ExportCte(db, dir, cte);
                            }
                        }

                        lblMessage.Text = "Consultando ...";
                        lblMessage.Update();

                        var ids = GetSelect(select);

                        if (ids.Any())
                        {
                            progressBar.Minimum = 0;
                            progressBar.Maximum = ids.Count;

                            foreach (var id in ids)
                            {
                                var cte = BL_Cte.SelectByPk(db, id);
                                if (cte != null)
                                {
                                    progressBar.Value = count;
                                    progressBar.Update();

                                    count++;

                                    lblMessage.Text = string.Format("Processando {0} de {1}", count, ids.Count);
                                    lblMessage.Update();

                                    ExportCte(db, dir, cte);
                                }
                            }
                        }
                    }
                }
            }
            return count;
        }

        void ExportCte(Database db, string dir, Cte cte)
        {
            var sql = "SELECT ARQUIVO_XML FROM CTE_ARQUIVO WHERE ID_CTE = " + cte.IdCte;
            string xml = db.ExecuteScalar(sql) as string;

            if (string.IsNullOrWhiteSpace(xml))
            {
                LogError(cte.ChaveCte);
            }
            else
            {
                File.WriteAllText(Path.Combine(dir, cte.ChaveCte + ".xml"), xml, System.Text.UTF32Encoding.UTF8);
                LogOk(cte.ChaveCte);
            }
        }

        List<string> ParseChaves(string chaves)
        {
            if (chaves == null || chaves == string.Empty)
                return new List<string>();

            return chaves.Split(new char[] { '\r', '\n', ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim()).Distinct(p => p).ToList();
        }

        List<decimal> GetSelect(string select)
        {
            if (select == null || select == string.Empty)
                return new List<decimal>();

            if (select.EndsWith(";"))
                select = select.Substring(0, select.Length - 1);

            return Dbs.Execute(Db.Translogic, (db) => db.ExecuteArray1D<decimal>(select)).ToList();
        }

        void LogOk(string message)
        {
            writerOk.WriteLine(message);
        }
        void LogError(string message)
        {
            writerError.WriteLine(message);
        }

    }

}
