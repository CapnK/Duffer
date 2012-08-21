using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Duffer.Properties;

namespace Duffer
{
   /// <summary>
   /// A geometric transform, in column/row format
   /// </summary>
   public class Transform4x4
   {

      /// <summary>
      /// Create a new Transform, this will be an identity matrix
      /// </summary>
      public Transform4x4()
      {
         c0r0 = 1;
         c1r1 = 1;
         c2r2 = 1;
         c3r3 = 1;
      }

      /// <summary>
      /// Column 0, Row 0
      /// </summary>
      public double c0r0 { get; set; }
      /// <summary>
      /// Column 1, Row 0
      /// </summary>
      public double c1r0 { get; set; }
      /// <summary>
      /// Column 2, Row 0
      /// </summary>
      public double c2r0 { get; set; }
      /// <summary>
      /// Column 3, Row 0
      /// </summary>
      public double c3r0 { get; set; }

      public double c0r1 { get; set; }
      public double c1r1 { get; set; }
      public double c2r1 { get; set; }
      public double c3r1 { get; set; }

      public double c0r2 { get; set; }
      public double c1r2 { get; set; }
      public double c2r2 { get; set; }
      public double c3r2 { get; set; }

      public double c0r3 { get; set; }
      public double c1r3 { get; set; }
      public double c2r3 { get; set; }
      public double c3r3 { get; set; }


      internal void Export(StreamWriter toStream)
      {
         toStream.WriteLine(String.Format("\t\t\t\t{0} {1} {2} {3}", 
            this.c0r0.ToString(Resources.SixDecPlFormat),
            this.c0r1.ToString(Resources.SixDecPlFormat),
            this.c0r2.ToString(Resources.SixDecPlFormat),
            this.c0r3.ToString(Resources.SixDecPlFormat)
            ));

         toStream.WriteLine(String.Format("\t\t\t\t{0} {1} {2} {3}", 
            this.c1r0.ToString(Resources.SixDecPlFormat),
            this.c1r1.ToString(Resources.SixDecPlFormat),
            this.c1r2.ToString(Resources.SixDecPlFormat),
            this.c1r3.ToString(Resources.SixDecPlFormat)
            ));

         toStream.WriteLine(String.Format("\t\t\t\t{0} {1} {2} {3}", 
            this.c2r0.ToString(Resources.SixDecPlFormat),
            this.c2r1.ToString(Resources.SixDecPlFormat),
            this.c2r2.ToString(Resources.SixDecPlFormat),
            this.c2r3.ToString(Resources.SixDecPlFormat)
            ));

         toStream.WriteLine(String.Format("\t\t\t\t{0} {1} {2} {3}", 
            this.c3r0.ToString(Resources.SixDecPlFormat),
            this.c3r1.ToString(Resources.SixDecPlFormat),
            this.c3r2.ToString(Resources.SixDecPlFormat),
            this.c3r3.ToString(Resources.SixDecPlFormat)
            ));
      }
   }
}
