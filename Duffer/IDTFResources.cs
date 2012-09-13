using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using Duffer.Properties;

namespace Duffer
{
   /* Resource lists
    * Possible Resource_List types: View, Light, Model, Shader, Material, Texture, Motion
    * A IDTF file can only have one list of each type and has the following format:
    * RESOURCE_LIST <RESOURCE_TYPE> {
    *   RESOURCE_COUNT <int>
    *   RESOURCE 0 {
    *       RESOURCE_NAME <string>
    *       <RESOURCE_DATA>
    *       <META_DATA>
    *   }
    *       etc.
    * }
    * 
    * This file contains the Resource data for each of the resource list types.
    */

   public abstract class Resource
    {
        public string Name { get; set; }

        public abstract ResourceListType Type {get; }               

        public abstract void Export(StreamWriter toStream);
    }

   public class LightResource
   {
      public LightResource(string name)
      {
         this.Name = name;
      }

      public string Name { get; set; }

      /// <summary>
      /// The Light Type
      /// </summary>
      public LightType Type { get; set; }

      /// <summary>
      /// Light color
      /// </summary>
      public Color Color { get; set; }

      public Vector4 Attenuation { get; set; }

      /// <summary>
      /// Applies to Spot lights only, Radians or Deg? Measured from where?
      /// </summary>
      public float SpotAngle { get; set; }


      public float Intensity { get; set; }

      internal void Export(StreamWriter toStream)
      {
         toStream.WriteLine(String.Format("\t\tRESOURCE_NAME \"{0}\"", this.Name));
         toStream.WriteLine(String.Format("\t\tLIGHT_TYPE \"{0}\"", this.Type.ToString()));
         toStream.WriteLine(String.Format("\t\tLIGHT_COLOR \"{0}\"", this.Color.ToIDTFStringRGBA()));
         toStream.WriteLine(String.Format("\t\tLIGHT_ATTENUATION \"{0}\"", this.Attenuation.ToString()));
         toStream.WriteLine(String.Format("\t\tLIGHT_SPOT_ANGLE \"{0}\"", this.SpotAngle.ToString(Resources.SixDecPlFormat)));
         toStream.WriteLine(String.Format("\t\tLIGHT_INTENSITY \"{0}\"", this.Intensity.ToString(Resources.SixDecPlFormat)));
      }
   } 
   
   public class ModelResource
   {
      public ModelResource(string name)
      {
         this.Name = name;
      }

      public string Name { get; set; }

   }

   public class ViewResource
   {
      public ViewResource(string name)
      {
         this.Name = name;
      }

      public string Name { get; set; }


   }

   public class ShaderResource: Resource
   {
       public string ShaderMaterialName { get; set; }

       private List<TextureLayer> _shaderTextureLayerList;
       public List<TextureLayer> ShaderTextureLayerList 
       {
           get
           {
               if (_shaderTextureLayerList == null) _shaderTextureLayerList = new List<TextureLayer>();
               return _shaderTextureLayerList;
           }
           set
           {
               _shaderTextureLayerList = value;
           }
       }

       public bool? AttributeLightingEnabled { get; set; } //optional
       public bool? AttributeAlphaTestEnabled { get; set; } //optional
       public bool? AttributeUseVertexColor { get; set; } //optional
       public bool? AttributeUseFastSpecular { get; set; } //optional
       public float? ShaderAlphaTestReference { get; set; } //optional       

       public override void Export(StreamWriter toStream)
       {
           toStream.WriteLine(String.Format("\t\tRESOURCE_NAME \"{0}\"", this.Name));           

           if (this.AttributeLightingEnabled != null)
               toStream.WriteLine(String.Format("\t\tATTRIBUTE_LIGHTING_ENABLED \"{0}\"", this.ShaderMaterialName.ToString().ToUpper()));
           if (this.AttributeAlphaTestEnabled != null)
               toStream.WriteLine(String.Format("\t\tATTRIBUTE_ALPHA_TEST_ENABLED \"{0}\"", this.AttributeAlphaTestEnabled.ToString().ToUpper()));
           if (this.AttributeUseVertexColor != null)
               toStream.WriteLine(String.Format("\t\tATTRIBUTE_USE_VERTEX_COLOR \"{0}\"", this.AttributeUseVertexColor.ToString().ToUpper()));
           if (this.AttributeUseFastSpecular != null)
               toStream.WriteLine(String.Format("\t\tATRIBUTE_USE_FAST_SPECULAR \"{0}\"", this.AttributeUseFastSpecular.ToString().ToUpper()));
           if (this.ShaderAlphaTestReference != null)
               toStream.WriteLine(String.Format("\t\tSHADER_ALPHA_TEST_REFERENCE \"{0}\"", this.ShaderAlphaTestReference));

           toStream.WriteLine(String.Format("\t\tSHADER_MATERIAL_NAME \"{0}\"", this.ShaderMaterialName));
           ListExtensions.ExportShaderTextureLayerListToStream(ShaderTextureLayerList, toStream);
       }

       public override ResourceListType Type
       {
           get { return ResourceListType.SHADER; }
       }
   }
   public class MaterialResource: Resource
   {
       public bool? AttributeAmbientEnabled { get; set; } //optional
       public bool? AttributeDiffuseEnabled { get; set; } //optional
       public bool? AttributeSpecularEnabled { get; set; } //optional
       public bool? AttributeEmmisiveEnabled { get; set; } //optional
       public bool? AttributeReflectivityEnabled { get; set; } //optional
       public bool? AttributeOpacityEnabled { get; set; } //optional

       public Color MaterialAmbient { get; set; }
       public Color MaterialDiffuse { get; set; }
       public Color MaterialSpecular { get; set; }
       public Color MaterialEmmisive { get; set; }
       public float MaterialReflectivity { get; set; }
       public float MaterialOpacity { get; set; }

       public override void Export(StreamWriter toStream)
       {
           if (this.AttributeAmbientEnabled != null)
               toStream.WriteLine(String.Format("\t\tATTRIBUTE_AMBIENT_ENABLED \"{0}\"", this.AttributeAmbientEnabled.ToString().ToUpper()));
           if (this.AttributeDiffuseEnabled != null)
               toStream.WriteLine(String.Format("\t\tATTRIBUTE_DIFFUSE_ENABLED \"{0}\"", this.AttributeDiffuseEnabled.ToString().ToUpper()));
           if (this.AttributeSpecularEnabled != null)
               toStream.WriteLine(String.Format("\t\tATTRIBUTE_SPECULAR_ENABLED \"{0}\"", this.AttributeSpecularEnabled.ToString().ToUpper()));
           if (this.AttributeEmmisiveEnabled != null)
               toStream.WriteLine(String.Format("\t\tATTRIBUTE_EMISSIVE_ENABLED \"{0}\"", this.AttributeEmmisiveEnabled.ToString().ToUpper()));
           if (this.AttributeReflectivityEnabled != null)
               toStream.WriteLine(String.Format("\t\tATTRIBUTE_REFLECTIVITY_ENABLED \"{0}\"", this.AttributeReflectivityEnabled.ToString().ToUpper()));
           if (this.AttributeOpacityEnabled != null)
               toStream.WriteLine(String.Format("\t\tATTRIBUTE_OPACITY_ENABLED \"{0}\"", this.AttributeOpacityEnabled.ToString().ToUpper()));

           toStream.WriteLine(String.Format("\t\tRESOURCE_NAME \"{0}\"", this.Name));
           toStream.WriteLine(String.Format("\t\tMATERIAL_AMBIENT {0}", this.MaterialAmbient.ToIDTFStringRGB()));
           toStream.WriteLine(String.Format("\t\tMATERIAL_DIFFUSE {0}", this.MaterialDiffuse.ToIDTFStringRGB()));
           toStream.WriteLine(String.Format("\t\tMATERIAL_SPECULAR {0}", this.MaterialSpecular.ToIDTFStringRGB()));
           toStream.WriteLine(String.Format("\t\tMATERIAL_EMISSIVE {0}", this.MaterialEmmisive.ToIDTFStringRGB()));
           toStream.WriteLine(String.Format("\t\tMATERIAL_REFLECTIVITY {0}", this.MaterialReflectivity.ToString(Resources.SixDecPlFormat)));
           toStream.WriteLine(String.Format("\t\tMATERIAL_OPACITY {0}", this.MaterialOpacity.ToString(Resources.SixDecPlFormat)));
       }

       public override ResourceListType Type
       {
           get { return ResourceListType.MATERIAL; }
       }
   }
   public class TextureResource : Resource
   {
       public int? IdtfTextureHeight { get; set; } //optional
       public int? IdtfTextureWidth { get; set; } //optional
       public TextureImageType? ImageType { get; set; } //optional

       private List<TextureImageFormat> _texureImageFormatList; //optional
       public List<TextureImageFormat> TexureImageFormatList
       {
           get
           {
               if (_texureImageFormatList == null) _texureImageFormatList = new List<TextureImageFormat>();
               return _texureImageFormatList;
           }
           set
           {
               _texureImageFormatList = value;
           }
       } //optional

       public string TexturePath { get; set; }

       public override void Export(StreamWriter toStream)
       {
           toStream.WriteLine(String.Format("\t\tRESOURCE_NAME \"{0}\"", this.Name));

           if (this.IdtfTextureHeight != null)
               toStream.WriteLine(String.Format("\t\tIDTF_TEXTURE_HEIGHT \"{0}\"", this.IdtfTextureHeight.ToString()));
           if (this.IdtfTextureWidth != null)
               toStream.WriteLine(String.Format("\t\tIDTF_TEXTURE_WIDTH \"{0}\"", this.IdtfTextureWidth.ToString()));
           if (this.ImageType != null)
               toStream.WriteLine(String.Format("\t\tTEXTURE_IMAGE_TYPE \"{0}\"", this.ImageType.ToString()));

           ListExtensions.ExportTextureImageFormatListToStream(this.TexureImageFormatList, toStream);
           
           toStream.WriteLine(String.Format("\t\tTEXTURE_PATH \"{0}\"", this.TexturePath));
       }

       public override ResourceListType Type
       {
           get { return ResourceListType.TEXTURE; }
       }
   }


   public class MotionResource
   {

   }
}
