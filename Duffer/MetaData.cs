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
            // The totla metadata count is 1 for each generic entry, plus one combined one for all the RHAdobe entries
            int totalCount = GenericMetaData.Count;
            if (RHAdobeMetaData.Count > 0) 
            {
                totalCount++; 
            }
             
            if (totalCount == 0)
            {
                return;
            }
            else
            {
                
                toStream.WriteLine("\tMETA_DATA {");
                toStream.WriteLine("\t\tMETA_DATA_COUNT {0}", totalCount);

                var metadataIndex = 0;
                if (RHAdobeMetaData.Count > 0)
                {
                    toStream.WriteLine("\t\tMETA_DATA 0 {");
				    toStream.WriteLine("\t\t\tMETA_DATA_ATTRIBUTE \"STRING\"");
                    toStream.WriteLine("\t\t\tMETA_DATA_KEY \"RHAdobeMeta\"");
                    ListExtensions.ExportAdobeMetaDataDictionaryToStream(RHAdobeMetaData, toStream);
                    toStream.WriteLine("\t\t}");
                    metadataIndex++;
                }

                if (GenericMetaData.Count > 0)
                {
                    
                }

                toStream.WriteLine("\t}");  //Close out the meta data block
            }
        }
    }
}
