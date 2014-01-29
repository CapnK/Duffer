using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Duffer
{
    public class MetaData
    {
        public Dictionary<string, string> RHAdobeMetaData { get; private set; }
        public List<MetaDataItem> GenericMetaData { get; private set; }

        public MetaData()
        {
            this.GenericMetaData = new List<MetaDataItem>();
            this.RHAdobeMetaData = new Dictionary<string, string>();
        }

        public void WriteOutput(StreamWriter toStream)
        {
            if ((GenericMetaData.Count == 0) && (RHAdobeMetaData.Count == 0))
            {
                return;
            }
        }
    }
}
