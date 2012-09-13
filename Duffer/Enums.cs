using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Duffer
{
   public enum NodeType
   {
      MODEL,
      VIEW,
      LIGHT,
      GROUP
   }

   public enum ResourceListType
   {
      MODEL,
      VIEW,
      LIGHT,
      SHADER,
      MOTION
   }

   /// <summary>
   /// Set the model visibility: NOT IMPLEMENTED
   /// </summary>
   public enum ModelVisibility
   {
      NONE,
      FRONT,
      BACK,
      BOTH
   }

   public enum ViewType
   {
      PERSPECTIVE,
      ORTHO
   }

   public enum ViewAttributeScreenUnit
   {
      PIXEL,
      PERCENTAGE
   }

   public enum ModelType
   {
      MESH,
      POINT_SET,
      LINE_SET
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

   public enum TextureLayerBlendFunctionType
   {
       ADD,
       MULTIPLY,
       REPLACE,
       BLEND
   }

   public enum TextureLayerBlendSourceType
   {
       ALPHA,
       CONSTANT
   }
}
