using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExportDbToFile
{

    public static class Settings
    {

        static string FileName = "./Connections.json";

        public static List<DbConnection> Load()
        {
            try
            {
                if (File.Exists(FileName))
                {
                    return JsonConvert.DeserializeObject<List<DbConnection>>(File.ReadAllText(FileName));
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex, "Erro ao carregar o arquivo Connections.json");
            }

            return new List<DbConnection>();
        }

        public static void Save(List<DbConnection> list)
        {
            try
            {
                File.WriteAllText(FileName, JsonConvert.SerializeObject(list));
            }
            catch (Exception ex)
            {
                Program.ShowError(ex, "Erro ao salvar o arquivo Connections.json");
            }
        }

    }
}
