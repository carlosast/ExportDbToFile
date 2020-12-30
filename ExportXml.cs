using Speed.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Speed.Common;
using System.Text;
using System.ComponentModel;

namespace ExportDbToFile
{
    public class ExportXml
    {
        StreamWriter writerOk;
        StreamWriter writerError;
        public int Export(Database db, BackgroundWorker worker, string dir, string select, bool columnFileNames, bool exportNulls, Label lblMessage, string extension, out int count)
        {
            count = 0;
            extension = extension.Replace(".", "");

            using (writerOk = new StreamWriter(Path.Combine(dir, "_Export_OK.txt"), false))
            {
                using (writerError = new StreamWriter(Path.Combine(dir, "_Export_Error.txt"), false))
                {
                    lblMessage.Text = "Consultando ...";
                    lblMessage.Update();

                    select = select.Trim();
                    if (select.EndsWith(";"))
                        select = select.Substring(0, select.Length - 1);

                    using (var reader = db.ExecuteReader(select, 0))
                    {
                        while (reader.Read())
                        {
                            if (worker.CancellationPending)
                            {
                                return count;
                            }

                            count++;

                            try
                            {
                                if (count % 10 == 0)
                                {
                                    lblMessage.Text = string.Format("Processados {0} registros", count);
                                    lblMessage.Update();
                                }

                                string fileName = null;
                                object value = null;

                                for (int i = 0; i < reader.FieldCount; i += (columnFileNames ? 2 : 1))
                                {
                                    if (columnFileNames)
                                    {
                                        fileName = reader.GetValue(i) as string;
                                        if (fileName == null)
                                            fileName = reader.GetName(i) + "_" + count;
                                        value = reader.GetValue(i + 1);
                                    }
                                    else
                                    {
                                        fileName = reader.GetName(i) + "_" + count;
                                        value = reader.GetValue(i);
                                    }

                                    if (!exportNulls && (value == DBNull.Value || value == null))
                                    {
                                        continue;
                                    }

                                    fileName = Path.Combine(dir, Speed.IO.FileTools.ToValidPath(fileName));

                                    if (!string.IsNullOrWhiteSpace(extension) && Path.GetExtension(fileName).Replace(".", "").ToLower() != extension)
                                    {
                                        fileName += "." + extension;
                                    }

                                    if (value is byte[])
                                    {
                                        File.WriteAllBytes(fileName, (byte[])value);
                                    }
                                    else
                                    {
                                        File.WriteAllText(fileName, value.ToString(), UTF8Encoding.UTF8);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                LogError(ex.Message + "\r\n" + ex.StackTrace);
                            }
                        }

                        lblMessage.Text = string.Format("Processados {0} registros", count);
                        lblMessage.Update();
                    }
                }
            }

            return count;
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
