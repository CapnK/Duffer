
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duffer;
using NUnit.Framework;

namespace Duffer.Tests.UnitTests
{
   [TestFixture]
   class BasicTypesTests
   {
      [Test]
      public void should_print_vector_to_string()
      {
         Vector4 v = new Vector4(1, 2, 3, 4);

         Assert.That(v.ToString(), Iz.EqualTo("1.000000 2.000000 3.000000 4.000000"));
      }
      [Test]
      public void should_print_point3_to_string()
      {
         Point3 p = new Point3(1, 2, 3);

         Assert.That(p.ToString(), Iz.EqualTo("1.000000 2.000000 3.000000"));
      }
       [Test]
      public void should_print_int3_to_string()
      {
          Int3 p = new Int3(1, 2, 3);

          Assert.That(p.ToString(), Iz.EqualTo("1 2 3"));
      }
       [Test]
       public void should_print_int2_to_string()
       {
           Int2 p = new Int2(1, 3);

           Assert.That(p.ToString(), Iz.EqualTo("1 3"));
       }

   }
}
