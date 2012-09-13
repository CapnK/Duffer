using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

using Duffer.Properties;
using System.IO;


namespace Duffer
{

   public class Point3
   {
      public Point3(float x, float y, float z)
      {
         this.X = x;
         this.Y = y;
         this.Z = z;

      }

      public float X { get; set; }
      public float Y { get; set; }
      public float Z { get; set; }

      public override string ToString()
      {
         return String.Format("{0} {1} {2}", 
             this.X.ToString(Resources.SixDecPlFormat),
             this.Y.ToString(Resources.SixDecPlFormat),
             this.Z.ToString(Resources.SixDecPlFormat));
      }
   }

   public class Vector4 : Point3
   {

      public Vector4(float x, float y, float z, float w) : base(x,y,z)
      {
         this.W = w;
      }

      public float W { get; set; }

      public override string ToString()
      {
         return String.Format("{0} {1} {2} {3}",
             this.X.ToString(Resources.SixDecPlFormat),
             this.Y.ToString(Resources.SixDecPlFormat),
             this.Z.ToString(Resources.SixDecPlFormat),
             this.W.ToString(Resources.SixDecPlFormat));
      }
   }

   public class Int3
   {       
       public Int3(int i0, int i1, int i2)
       {
           IntArray = new int[3];
           IntArray[0] = i0;
           IntArray[1] = i1;
           IntArray[2] = i2;
       }

       public int[] IntArray { get; private set; }

       public override string ToString()
       {
           return String.Format("{0} {1} {2}",
               this.IntArray[0].ToString(),
               this.IntArray[1].ToString(),
               this.IntArray[2].ToString());
       }
   }
}
