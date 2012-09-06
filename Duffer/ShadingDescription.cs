using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Duffer.Properties;

namespace Duffer
{
   class ShadingDescription
   {


      public int TextureLayerCount { get; set; }

      public int ShaderID { get; set; }

      private List<TextureCoordDimension>  _textureCoordDimList;
      public List<TextureCoordDimension> TextureCoordDimensionList 
      {
         get
         {
            if (_textureCoordDimList == null) { _textureCoordDimList = new List<TextureCoordDimension>(); }
            return _textureCoordDimList;
         }
         set
         {
            _textureCoordDimList = value;
         }
      }




      internal void Export(StreamWriter toStream)
      {
         toStream.WriteLine(String.Format("\t\t\t\t\tTEXTURE_LAYER_COUNT {0}", this.TextureLayerCount));
         if (_textureCoordDimList != null)
         {
            ListExtensions.ExportTextureCoordListToStream(_textureCoordDimList, toStream);
         }
         toStream.WriteLine(String.Format("\t\t\t\t\tSHADER_ID {0}", this.ShaderID));
      }

   }

   class TextureCoordDimension
   {
      public int TextureLayer { get; set; }
      public int Dimension { get; set; }

      internal void Export(StreamWriter toStream)
      {
         toStream.WriteLine(String.Format("\t\t\t\t\t\tTEXTURE_LAYER {0}	DIMENSION: {1}", this.TextureLayer, this.Dimension));
      }
   }
}
