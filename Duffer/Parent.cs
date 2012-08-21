using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Duffer
{

   public class Parent
   {
      public Parent()
      {
         Transform = new Transform4x4();
      }

      public Parent(string name) : this()
      {
         this.Name = name;
      }

      public string Name { get; set; }
      public Transform4x4 Transform { get; set; }

      internal void Export(StreamWriter toStream)
      {
         var tempName = (String.IsNullOrWhiteSpace(this.Name)) ? "<NULL>" : this.Name;

         toStream.WriteLine(String.Format("\t\t\tPARENT_NAME \"{0}\"", tempName));
         toStream.WriteLine("\t\t\tPARENT_TM {");
         this.Transform.Export(toStream);
         toStream.WriteLine("\t\t\t}");
      }
   }
}
