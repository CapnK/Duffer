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
         m00 = 1;
         m11 = 1;
         m22 = 1;
         m33 = 1;
      }

      /// <summary>
      /// Column 0, Row 0
      /// </summary>
      public double m00 { get; set; }
      /// <summary>
      /// Column 1, Row 0
      /// </summary>
      public double m10 { get; set; }
      /// <summary>
      /// Column 2, Row 0
      /// </summary>
      public double m20 { get; set; }
      /// <summary>
      /// Column 3, Row 0
      /// </summary>
      public double m30 { get; set; }

      public double m01 { get; set; }
      public double m11 { get; set; }
      public double m21 { get; set; }
      public double m31 { get; set; }

      public double m02 { get; set; }
      public double m12 { get; set; }
      public double m22 { get; set; }
      public double m32 { get; set; }

      public double m03 { get; set; }
      public double m13 { get; set; }
      public double m23 { get; set; }
      public double m33 { get; set; }


      internal void Export(StreamWriter toStream)
      {
         toStream.WriteLine(String.Format("\t\t\t\t{0} {1} {2} {3}", 
            this.m00.ToString(Resources.SixDecPlFormat),
            this.m01.ToString(Resources.SixDecPlFormat),
            this.m02.ToString(Resources.SixDecPlFormat),
            this.m03.ToString(Resources.SixDecPlFormat)
            ));

         toStream.WriteLine(String.Format("\t\t\t\t{0} {1} {2} {3}", 
            this.m10.ToString(Resources.SixDecPlFormat),
            this.m11.ToString(Resources.SixDecPlFormat),
            this.m12.ToString(Resources.SixDecPlFormat),
            this.m13.ToString(Resources.SixDecPlFormat)
            ));

         toStream.WriteLine(String.Format("\t\t\t\t{0} {1} {2} {3}", 
            this.m20.ToString(Resources.SixDecPlFormat),
            this.m21.ToString(Resources.SixDecPlFormat),
            this.m22.ToString(Resources.SixDecPlFormat),
            this.m23.ToString(Resources.SixDecPlFormat)
            ));

         toStream.WriteLine(String.Format("\t\t\t\t{0} {1} {2} {3}", 
            this.m30.ToString(Resources.SixDecPlFormat),
            this.m31.ToString(Resources.SixDecPlFormat),
            this.m32.ToString(Resources.SixDecPlFormat),
            this.m33.ToString(Resources.SixDecPlFormat)
            ));
      }
   }
}
