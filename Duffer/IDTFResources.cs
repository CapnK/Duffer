using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Duffer.Properties;

namespace Duffer
{
    public abstract class Resource
    {
        public string Name { get; set; }

        public ResourceListType Type {get; protected set;}               

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
      public System.Drawing.Color Color { get; set; }

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
         toStream.WriteLine(String.Format("\t\tLIGHT_COLOR \"{0}\"", this.Color.ToIDTFString()));
         toStream.WriteLine(String.Format("\t\tLIGHT_ATTENUATION \"{0}\"", this.Attenuation.ToString()));
         toStream.WriteLine(String.Format("\t\tLIGHT_SPOT_ANGLE \"{0}\"", this.SpotAngle.ToString(Resources.SixDecPlFormat)));
         toStream.WriteLine(String.Format("\t\tLIGHT_INTENSITY \"{0}\"", this.Intensity.ToString(Resources.SixDecPlFormat)));

      }
   }

   public enum LightType
   {
      /// <summary>
      /// Light provides uniform non-directional light to the scene
      /// </summary>
      AMBIENT,

      /// <summary>
      /// Light provides uniform directional light to the scene
      /// </summary>
      DIRECTIONAL,
      
      /// <summary>
      /// Light is emitted from a specific point in the scene
      /// </summary>
      POINT,

      /// <summary>
      /// Like point light, but constrained to specific directions
      /// </summary>
      SPOT
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
   }

   public class MotionResource
   {

   }
}
