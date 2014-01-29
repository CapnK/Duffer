using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Duffer
{
    public abstract class MetaDataItem
    {

        public MetaDataType Attribute { get; protected set; }
        public string Key { get; set; }
        public abstract void WriteOutput(StreamWriter toStream);

    }

    public class StringMetaDataItem : MetaDataItem
    {
        public StringMetaDataItem()
        {
            this.Attribute = MetaDataType.STRING;
        }

        public StringMetaDataItem(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Value { get; set; }

        public override void WriteOutput(StreamWriter toStream)
        {
            toStream.WriteLine("\t\t\tMETA_DATA_ATTRIBUTE \"STRING\"");
            toStream.WriteLine(String.Format("\t\t\tMETA_DATA_KEY \"{0}\"",Key));
            toStream.WriteLine(String.Format("\t\t\tMETA_DATA_VALUE \"{0}\"",Value));
        }

    }

    public class BinaryMetaDataItem : MetaDataItem
    {
        public BinaryMetaDataItem()
        {
            this.Attribute = MetaDataType.BINARY;
        }

        public BinaryMetaDataItem(string key, byte[] value)
        {
            this.Key = key;
            this.Value = value;
        }

        public byte[] Value { get; set; }

        public override void WriteOutput(StreamWriter toStream)
        {
            throw new NotImplementedException("Binary MetaDataItem not yet supported");
        }

    }
}
