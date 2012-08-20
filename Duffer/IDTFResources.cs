using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Duffer
{
   public abstract class ResourceList
   {

      public ResourceListType Type { get; protected set; }

   }


   public class ShaderResources : ResourceList
   {
      public ShaderResources()
      {
         this.Type = ResourceListType.SHADER;
      }
   }

   public class MotionResources : ResourceList
   {
      public MotionResources()
      {
         this.Type = ResourceListType.MOTION;
      }
   }
   public class ModelResources : ResourceList
   {
      public ModelResources()
      {
         this.Type = ResourceListType.MODEL;
      }
   }
   public class ViewResources : ResourceList
   {
      public ViewResources()
      {
         this.Type = ResourceListType.VIEW;
      }
   }
   public class LightResources : ResourceList
   {
      public LightResources()
      {
         this.Type = ResourceListType.LIGHT;
      }
   }
}
