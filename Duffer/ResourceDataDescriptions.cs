using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Duffer.Properties;
using System.Drawing;

namespace Duffer
{
    /* This file contains data descriptions for the resource_lists. */

    internal interface IResourceData
    {
        void Export(StreamWriter toStream);
    }

    /* Resource data for the "MODEL RESOURCE_LIST" */

    public class ShadingDescription
    {
        public ShadingDescription(int id = 0)
        {
            this.ShaderID = id;
        }

        public int ShaderID { get; set; }

        private List<int> _textureCoordDimList;
        public List<int> TextureCoordDimensionList
        {
            get
            {
                if (_textureCoordDimList == null) { _textureCoordDimList = new List<int>(); }
                return _textureCoordDimList;
            }
            set
            {
                _textureCoordDimList = value;
            }
        }

        internal void Export(StreamWriter toStream)
        {
            toStream.WriteLine(String.Format("\t\t\t\t\tTEXTURE_LAYER_COUNT {0}", this.TextureCoordDimensionList.Count()));
            if (_textureCoordDimList != null)
            {
                ListExtensions.ExportTextureCoordListToStream(_textureCoordDimList, toStream);
            }
            toStream.WriteLine(String.Format("\t\t\t\t\tSHADER_ID {0}", this.ShaderID));
        }

    }

    public class FaceTextureCoord
    {        

        private List<Int3> _textureCoordDimList;
        public List<Int3> TextureCoordDimensionList
        {
            get
            {
                if (_textureCoordDimList == null) { _textureCoordDimList = new List<Int3>(); }
                return _textureCoordDimList;
            }
            set
            {
                _textureCoordDimList = value;
            }
        }

        internal void Export(StreamWriter toStream)
        {          
            if (_textureCoordDimList != null)
            {
                ListExtensions.ExportMeshFaceTextureCoordListToStream(_textureCoordDimList, toStream);
            }
        }

    }
    
    public class MeshData
    {
        private List<ShadingDescription> _shadingDescriptionList;
        private List<Int3> _meshFacePositionList;
        private List<Int3> _meshFaceNormalList;
        private List<int> _meshFaceShadingList;
        private List<FaceTextureCoord> _meshFaceTextureCoordinateList;
        private List<Int3> _meshFaceDiffuseColorList;
        private List<Int3> _meshFaceSpecularColorList;
        private List<Point3> _modelPositionList;
        private List<Point3> _modelNormalList;
        private List<Color> _modelDiffuseColorList;
        private List<Color> _modelSpecularColorList;
        private List<Vector4> _modelTextureCoordList;
        private List<int> _meshBasePositionList;


        public List<ShadingDescription> ShadingDescriptionList
        {
            get
            {
                if (this._shadingDescriptionList == null) this._shadingDescriptionList = new List<ShadingDescription>();
                return this._shadingDescriptionList;
            }
            set { this._shadingDescriptionList = value; }
        }
        public List<Int3> MeshFacePositionList 
        {
            get
            {
                if (this._meshFacePositionList == null) this._meshFacePositionList = new List<Int3>();
                return this._meshFacePositionList;
            }
            set { this._meshFacePositionList = value; }
        }                
        public List<Int3> MeshFaceNormalList
        {
            get
            {
                if (this._meshFaceNormalList == null) this._meshFaceNormalList = new List<Int3>();
                return this._meshFaceNormalList;
            }
            set { this._meshFaceNormalList = value; }
        }
        public List<int> MeshFaceShadingList
        {
            get
            {
                if (this._meshFaceShadingList == null) this._meshFaceShadingList = new List<int>();
                return this._meshFaceShadingList;
            }
            set { this._meshFaceShadingList = value; }
        }
        public List<FaceTextureCoord> MeshFaceTextureCoordinateList
        {
            get
            {
                if (this._meshFaceTextureCoordinateList == null) this._meshFaceTextureCoordinateList = new List<FaceTextureCoord>();
                return this._meshFaceTextureCoordinateList;
            }
            set { this._meshFaceTextureCoordinateList = value; }
        }
        public List<Int3> MeshFaceDiffuseColorList
        {
            get
            {
                if (this._meshFaceDiffuseColorList == null) this._meshFaceDiffuseColorList = new List<Int3>();
                return this._meshFaceDiffuseColorList;
            }
            set { this._meshFaceDiffuseColorList = value; }
        }
        public List<Int3> MeshFaceSpecularColorList
        {
            get
            {
                if (this._meshFaceSpecularColorList == null) this._meshFaceSpecularColorList = new List<Int3>();
                return this._meshFaceSpecularColorList;
            }
            set { this._meshFaceSpecularColorList = value; }
        }
        public List<Point3> ModelPositionList
        {
            get
            {
                if (this._modelPositionList == null) this._modelPositionList = new List<Point3>();
                return this._modelPositionList;
            }
            set { this._modelPositionList = value; }
        }
        public List<Point3> ModelNormalList
        {
            get
            {
                if (this._modelNormalList == null) this._modelNormalList = new List<Point3>();
                return this._modelNormalList;
            }
            set { this._modelNormalList = value; }
        }
        public List<Color> ModelDiffuseColorList
        {
            get
            {
                if (this._modelDiffuseColorList == null) this._modelDiffuseColorList = new List<Color>();
                return this._modelDiffuseColorList;
            }
            set { this._modelDiffuseColorList = value; }
        }
        public List<Color> ModelSpecularColorList
        {
            get
            {
                if (this._modelSpecularColorList == null) this._modelSpecularColorList = new List<Color>();
                return this._modelSpecularColorList;
            }
            set { this._modelSpecularColorList = value; }
        }
        public List<Vector4> ModelTextureCoordList
        {
            get
            {
                if (this._modelTextureCoordList == null) this._modelTextureCoordList = new List<Vector4>();
                return this._modelTextureCoordList;
            }
            set { this._modelTextureCoordList = value; }
        }
        public List<int> MeshBasePositionList
        {
            get
            {
                if (this._meshBasePositionList == null) this._meshBasePositionList = new List<int>();
                return this._meshBasePositionList;
            }
            set { this._meshBasePositionList = value; }
        }

        public void Export(StreamWriter toStream) 
        {
            toStream.WriteLine(String.Format("\t\tMESH {{"));
            toStream.WriteLine(String.Format("\t\t\tFACE_COUNT {0}", this.MeshFacePositionList.Count().ToString()));
            toStream.WriteLine(String.Format("\t\t\tMODEL_POSITION_COUNT {0}", this.ModelPositionList.Count().ToString()));
            // toStream.WriteLine(String.Format("\t\t\tMODEL_BASE_POSITION_COUNT {0} {{", this.MeshBasePositionList.Count().ToString())); 
            toStream.WriteLine(String.Format("\t\t\tMODEL_NORMAL_COUNT {0}", this.ModelNormalList.Count().ToString()));
            toStream.WriteLine(String.Format("\t\t\tMODEL_DIFFUSE_COLOR_COUNT {0}", this.ModelDiffuseColorList.Count().ToString()));
            toStream.WriteLine(String.Format("\t\t\tMODEL_SPECULAR_COLOR_COUNT {0}", this.ModelSpecularColorList.Count().ToString()));
            toStream.WriteLine(String.Format("\t\t\tMODEL_TEXTURE_COORD_COUNT {0}", this.ModelTextureCoordList.Count().ToString()));
            toStream.WriteLine(String.Format("\t\t\tMODEL_BONE_COUNT {0}", 0)); //What does this count???
            toStream.WriteLine(String.Format("\t\t\tMODEL_SHADING_COUNT {0}", this.ShadingDescriptionList.Count().ToString()));

            ListExtensions.ExportShadingListToStream(this.ShadingDescriptionList, toStream);
            ListExtensions.ExportInt3ListToStream(this.MeshFacePositionList, toStream, "MESH_FACE_POSITION_LIST");
            ListExtensions.ExportInt3ListToStream(this.MeshFaceNormalList, toStream, "MESH_FACE_NORMAL_LIST");
            ListExtensions.ExportIntListToStream(this.MeshFaceShadingList, toStream, "MESH_FACE_SHADING_LIST");
            ListExtensions.ExportMeshFaceTextureCoordListToStream(this.MeshFaceTextureCoordinateList, toStream);
            ListExtensions.ExportInt3ListToStream(this.MeshFaceDiffuseColorList, toStream, "MESH_FACE_DIFFUSE_COLOR_LIST");
            ListExtensions.ExportInt3ListToStream(this.MeshFaceSpecularColorList, toStream, "MESH_FACE_SPECULAR_COLOR_LIST");
            ListExtensions.ExportPoint3ListToStream(this.ModelPositionList, toStream, "MODEL_POSITION_LIST");
            ListExtensions.ExportPoint3ListToStream(this.ModelNormalList, toStream, "MODEL_NORMAL_LIST");
            ListExtensions.ExportColorListToStream(this.ModelDiffuseColorList, toStream, "MODEL_NORMAL_LIST");
            ListExtensions.ExportColorListToStream(this.ModelSpecularColorList, toStream, "MODEL_NORMAL_LIST");
            ListExtensions.ExportVector4ListToStream(this.ModelTextureCoordList, toStream, "MODEL_TEXURE_COORD_LIST");
            ListExtensions.ExportIntListToStream(this.MeshBasePositionList, toStream, "MESH_BASE_POSITION_LIST");


            toStream.WriteLine(String.Format("\t\t}}"));
        }
    }

    public class LineSetData
    {
        public void Export(StreamWriter toStream) { }
    }

    public class PointSetData
    {
        public void Export(StreamWriter toStream) { }
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
