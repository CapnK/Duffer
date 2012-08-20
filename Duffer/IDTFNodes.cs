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

      public ModelResource Resource { get; set; }

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

      public LightResource Resource { get; set; }

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

      public ViewResource Resource { get; set; }

      public void WriteOutput(StreamWriter toStream)
      {
         base.WriteCommonOutputWithoutMetaData(toStream);

         //TODO - Add View data

         base.WriteMetaData(toStream);
      }

   }
}
