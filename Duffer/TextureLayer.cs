using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Duffer.Properties;

namespace Duffer
{
    public class TextureLayer
    {
        public string TextureName { get; set; }

        public float? TextureLayerIntensity { get; set; } //optional
        public TextureLayerBlendFunctionType? TextureLayerBlendFunction { get; set; } //optional
        public TextureLayerBlendSourceType? TextureLayerBlendSource { get; set; } //optional
        public float? TextureLayerBlendConstant { get; set; } //optional
        public string TextureLayerMode { get; set; } //optional
        public bool? TextureLayerAlphaEnabled { get; set; } //optional        

        internal void Export(StreamWriter toStream)
        {
            if (TextureLayerIntensity != null)
                toStream.WriteLine(String.Format("\t\t\t\tTEXTURE_LAYER_INTENSITY {0}", ((float)TextureLayerIntensity).ToString(Resources.SixDecPlFormat)));
            if (TextureLayerBlendFunction != null)
                toStream.WriteLine(String.Format("\t\t\t\tTEXTURE_LAYER_BLEND_FUNCTION \"{0}\"", TextureLayerBlendFunction.ToString()));
            if (TextureLayerBlendSource != null)
                toStream.WriteLine(String.Format("\t\t\t\tTEXTURE_LAYER_BLEND_SOURCE \"{0}\"", TextureLayerBlendSource.ToString()));
            if (TextureLayerBlendConstant != null)
                toStream.WriteLine(String.Format("\t\t\t\tTEXTURE_LAYER_BLEND_CONSTANT {0}", ((float)TextureLayerBlendConstant).ToString(Resources.SixDecPlFormat)));
            if (TextureLayerMode != null)
                toStream.WriteLine(String.Format("\t\t\t\tTEXTURE_LAYER_MODE {0}", TextureLayerMode));
            if (TextureLayerAlphaEnabled != null)
                toStream.WriteLine(String.Format("\t\t\t\tTEXTURE_LAYER_ALPHA_ENABLED \"{0}\"", TextureLayerAlphaEnabled.ToString().ToUpper()));

            toStream.WriteLine(String.Format("\t\t\t\tTEXTURE_NAME \"{0}\"", TextureName));
        }
    }
}
