using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Duffer
{
   /// <summary>
   /// A geometric transform, in column/row format
   /// </summary>
   public class Transform4x4
   {
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
   }
}
