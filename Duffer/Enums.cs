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
      MATERIAL,
      TEXTURE,
      MOTION
   }

   public enum ModifierType
   {
       ANIMATION,
       SHADING,
       BONE_WEIGHT,
       CLOD,
       SUBDIV,
       GLYPH
   }

   /// <summary>
   /// Set the model visibility
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

   /* Types for the "MODEL RESOURCE_LIST" */ 
   public enum ModelType
   {
      MESH,
      POINT_SET,
      LINE_SET
   }

   /* Types for the "LIGHT RESOURCE_LIST" */  
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

   /* Types for the "SHADER RESOURCE_LIST" */ 
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

   /* Types for the "TEXTURE RESOURCE_LIST" */
   public enum TextureImageType
   {
       ALPHA,
       RGB,
       RGBA,
       LUMINANCE,
       LUMINANCE_AND_ALPHA
   }
   public enum CompressionType
   {
       JPEG24,
       JPEG8,
       PNG
   }
}
