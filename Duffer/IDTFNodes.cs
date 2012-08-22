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

      private List<Parent> _parents;
      public List<Parent> Parents 
      { 
         get
         {
            if (_parents == null) { _parents = new List<Parent>(); }
            return _parents;
         }

         set
         {
            _parents = value;
         }
      }

      protected void WriteCommonOutputWithoutMetaData(StreamWriter toStream)
      {
         toStream.WriteLine(String.Format("\tNODE_NAME \"{0}\"", this.Name));
         if (_parents != null)
         {
            _parents.Export(toStream);
         }
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
         toStream.WriteLine("NODE \"GROUP\" {");
         base.WriteCommonOutputWithoutMetaData(toStream);

         //Group nodes have no other content 

         base.WriteMetaData(toStream);

         toStream.WriteLine("}");
      }

   }

   public class Model : Node
   {
      public Model()
      {
         this.Type = NodeType.MODEL;

      }

      public ModelResource Resource { get; set; }

      // Not implemented yet, no examples in the standard u3d samples
      //public ModelVisibility? Visibility { get; set; }

      public void WriteOutput(StreamWriter toStream)
      {
         toStream.WriteLine("NODE \"MODEL\" {");
         base.WriteCommonOutputWithoutMetaData(toStream);

         //TODO - Add Model data

         if (this.Resource != null)
         {
            toStream.WriteLine(String.Format("\tRESOURCE_NAME \"{0}\"", this.Resource.Name));
         }

         // Not implemented yet, no examples in the standard u3d samples
         //if (this.Visibility.HasValue)
         //{
         //   toStream.WriteLine(String.Format("\tMODEL_VISIBILITY \"{0}\"", this.Visibility.Value.ToString()));
         //}

         base.WriteMetaData(toStream);

         toStream.WriteLine("}");
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
         toStream.WriteLine("NODE \"LIGHT\" {");
         base.WriteCommonOutputWithoutMetaData(toStream);

         //TODO - Add Light data

         if (this.Resource != null)
         {
            toStream.WriteLine(String.Format("\tRESOURCE_NAME \"{0}\"", this.Resource.Name));
         }
         
         base.WriteMetaData(toStream);

         toStream.WriteLine("}");
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
         toStream.WriteLine("NODE \"VIEW\" {");
         base.WriteCommonOutputWithoutMetaData(toStream);

         //TODO - Add View data
         if (this.Resource != null)
         {
            toStream.WriteLine(String.Format("\tRESOURCE_NAME \"{0}\"", this.Resource.Name));
         }

         base.WriteMetaData(toStream);
         toStream.WriteLine("}");
      }

   }
}
