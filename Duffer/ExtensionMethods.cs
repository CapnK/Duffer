using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duffer.Properties;
using System.IO;

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


      // Create an extension method in IList<t> that is constrained to IList<Parent>!
      //http://grabbagoft.blogspot.com.au/2007/07/constrained-generic-extension-methods.html
      /// <summary>
      /// Export a List&lt;Parent&gt; to a stream in IDTF format
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="list"></param>
      /// <param name="toStream"></param>
      public static void Export<T>(this T list, StreamWriter toStream)
         where T : IList<Parent>
      {
         toStream.WriteLine("\tPARENT_LIST {");
         toStream.WriteLine(String.Format("\t\tPARENT_COUNT {0}", list.Count));
         for (int i = 0; i < list.Count; i++)
         {
            //note: double {{ wil output as single { in string.format
            toStream.WriteLine(String.Format("\t\tPARENT {0} {{", i));
            list.ElementAt(i).Export(toStream);
            toStream.WriteLine("\t\t}");
         }

         toStream.WriteLine("\t}");
        
      }
   }
}
