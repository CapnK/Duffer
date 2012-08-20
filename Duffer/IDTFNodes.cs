using System;
using System.Collections.Generic;
using System.IO;  
using System.Linq;
using System.Text;

namespace Duffer
{
   // References:
// http://jmol.svn.sourceforge.net/viewvc/jmol/trunk/Jmol/src/org/jmol/export/_IdtfExporter.java?revision=HEAD&view=markup
// http://www2.iaas.msu.ru/tmp/u3d/

   public abstract class Node
   {

      public string Name { get; set; }

      public NodeType Type { get; protected set; }


      // FIXME - Check that the ResourceList.Type is appropriate for this Node.Type
      private ResourceList _resourceList;
      public ResourceList Resources 
      { 
         get
         {
            return _resourceList;  
         }
         set
         {
            
            if ((value.Type == ResourceListType.MOTION) || (value.Type == ResourceListType.SHADER))
            {
               throw new InvalidOperationException("Motions and Shader resource lists are not valid Resources for a Model, View or Light");
            }
            else if (this.Type==NodeType.GROUP)
            {
               throw new InvalidOperationException("Resource lists are not valid for Group nodes");
            }
            else
            {

               if ((value.Type==ResourceListType.MODEL) && (this.Type==NodeType.MODEL))
               {
                  _resourceList = value;
               }
               else if ((value.Type==ResourceListType.VIEW) && (this.Type==NodeType.VIEW))
               {
                  _resourceList = value;
               }
               else if ((value.Type == ResourceListType.LIGHT) && (this.Type == NodeType.LIGHT))
               {
                  _resourceList = value;
               }
               else
               {
                  throw new InvalidOperationException("You are attempting to assign the wrong Resource list type to this Node");
               }


            }
         }

      }

      public Dictionary<string, Transform4x4> ParentList { get; set; }

      protected void WriteCommonOutputWithoutMetaData(StreamWriter toStream)
      {

      }

      protected void WriteMetaData(StreamWriter toStream)
      {

      }

   }


   public class Group : Node
   {
      public Group() 
      {
         this.Type = NodeType.GROUP;
      
      }

      public void WriteOutput(StreamWriter toStream)
      {
         base.WriteCommonOutputWithoutMetaData(toStream);

         //Group nodes have no other content 

         base.WriteMetaData(toStream);
      }

   }

   public class Model : Node
   {
      public Model()
      {
         this.Type = NodeType.MODEL;

      }

      public void WriteOutput(StreamWriter toStream)
      {
         base.WriteCommonOutputWithoutMetaData(toStream);

         //TODO - Add Model data

         base.WriteMetaData(toStream);
      }

   }

   public class Light : Node
   {
      public Light()
      {
         this.Type = NodeType.LIGHT;

      }

      public void WriteOutput(StreamWriter toStream)
      {
         base.WriteCommonOutputWithoutMetaData(toStream);

         //TODO - Add Light data
         
         base.WriteMetaData(toStream);
      }

   }

   public class View : Node
   {
      public View()
      {
         this.Type = NodeType.VIEW;

      }


      public void WriteOutput(StreamWriter toStream)
      {
         base.WriteCommonOutputWithoutMetaData(toStream);

         //TODO - Add View data

         base.WriteMetaData(toStream);
      }

   }
}
