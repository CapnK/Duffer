using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Duffer.Properties;

namespace Duffer
{
    /* This file contains data descriptions for the resource_lists. */

    internal interface IResourceData
    {
        void Export(StreamWriter toStream);
    }

    /* Resource data for the "MODEL RESOURCE_LIST" */

    class ShadingDescription
    {


        public int TextureLayerCount { get; set; }

        public int ShaderID { get; set; }

        private List<TextureCoordDimension> _textureCoordDimList;
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

    /* Resource data for the "SHADER RESOURCE_LIST" */

    public class TextureLayer:IResourceData
    {
        public string TextureName { get; set; }

        public float? TextureLayerIntensity { get; set; } //optional
        public TextureLayerBlendFunctionType? TextureLayerBlendFunction { get; set; } //optional
        public TextureLayerBlendSourceType? TextureLayerBlendSource { get; set; } //optional
        public float? TextureLayerBlendConstant { get; set; } //optional
        public string TextureLayerMode { get; set; } //optional
        public bool? TextureLayerAlphaEnabled { get; set; } //optional        

        public void Export(StreamWriter toStream)
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

    /* Resource data for the "TEXTURE RESOURCE_LIST" */

    public class TextureImageFormat: IResourceData
    {
        public CompressionType? Type { get; set; }
        public bool? AlphaChannel { get; set; }
        public bool? BlueChannel { get; set; }
        public bool? GreenChannel { get; set; }
        public bool? RedChannel { get; set; }
        public bool? Luminance { get; set; }
        public bool? ExternalReference { get; set; }

        private List<Url> _urlList; //optional
        public List<Url> UrltList
        {
            get
            {
                if (_urlList == null) _urlList = new List<Url>();
                return _urlList;
            }
            set
            {
                _urlList = value;
            }
        } //optional

        public void Export(StreamWriter toStream)
        {
            if (this.Type != null)
                toStream.WriteLine(String.Format("\t\t\t\tCOMPRESSION_TYPE \"{0}\"", this.Type.ToString()));
            if (this.AlphaChannel != null)
                toStream.WriteLine(String.Format("\t\t\t\tALPHA_CHANNEL \"{0}\"", this.AlphaChannel.ToString().ToUpper()));
            if (this.BlueChannel != null)
                toStream.WriteLine(String.Format("\t\t\t\tBLUE_CHANNEL \"{0}\"", this.BlueChannel.ToString().ToUpper()));
            if (this.GreenChannel != null)
                toStream.WriteLine(String.Format("\t\t\t\tGREEN_CHANNEL \"{0}\"", this.GreenChannel.ToString().ToUpper()));
            if (this.RedChannel != null)
                toStream.WriteLine(String.Format("\t\t\t\tRED_CHANNEL \"{0}\"", this.RedChannel.ToString().ToUpper()));
            if (this.Luminance != null)
                toStream.WriteLine(String.Format("\t\t\t\tLUMINANCE \"{0}\"", this.Luminance.ToString().ToUpper()));
            if (this.ExternalReference != null)
                toStream.WriteLine(String.Format("\t\t\t\tEXERNAL_REFERENCE \"{0}\"", this.ExternalReference.ToString().ToUpper()));

            ListExtensions.ExportUrlListToStream(this.UrltList, toStream);
        }
    }
    public class Url : IResourceData
    {
        public string UrlPath { get; set; }

        public void Export(StreamWriter toStream)
        {
        }
    }
}
