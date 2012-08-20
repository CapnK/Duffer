using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duffer.Properties;

namespace Duffer
{
   internal static class ExtensionMethods
   {
      public static string ToIDTFString(this System.Drawing.Color color)
      {
         ///Convert the colors from 0-255 to 0-1.0 and 6 dec places
         ///

         // If the value is 255, then make it 1.0, otherwise divide by 256, and force cast to double
         double r = (color.R == 255) ? 1.0 : (double)color.R / 256;
         double g = (color.G == 255) ? 1.0 : (double)color.G / 256;
         double b = (color.B == 255) ? 1.0 : (double)color.B / 256;
         double a = (color.A == 255) ? 1.0 : (double)color.A / 256;

         

         return String.Format("{0} {1} {2} {3}",
             r.ToString(Resources.SixDecPlFormat),
             g.ToString(Resources.SixDecPlFormat),
             b.ToString(Resources.SixDecPlFormat),
             a.ToString(Resources.SixDecPlFormat));
      }
   }
}
