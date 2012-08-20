using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Duffer.Properties;

namespace Duffer
{

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

   }

   public class ViewResource
   {

   }

   public class ShaderResource
   {

   }

   public class MotionResource
   {

   }
}
