using Speed.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExportDbToFile
{
    
    public class DbConnection
    {
        public string Name { get; set; }
        public string ProviderType { get; set; }
        public string ConnectionString { get; set; }

        public EnumDbProviderType GetProviderType()
        {
            return (EnumDbProviderType)Enum.Parse(typeof(EnumDbProviderType), ProviderType);
        }

        public override string ToString()
        {
            return string.Format("{0} - ({1})", Name, ProviderType);
        }
    }
}
