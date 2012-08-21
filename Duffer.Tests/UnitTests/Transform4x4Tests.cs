using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Moq;

namespace Duffer.Tests.UnitTests
{
   [TestFixture]
   class Transform4x4Tests
   {

      [Test]
      public void should_write_identity_transform_matrix()
      {
         // Create a basic identity matrix
         var tm = new Transform4x4();

         // create a mock stream writer
         var mockStream = new Mock<StreamWriter>("C:\\temp\\filename.txt");

         // catch all the calls to the streamwriter
         List<string> lines = new List<string>();

         mockStream.Setup(sw => sw.WriteLine(It.IsAny<string>()))
            .Callback((string s) => lines.Add(s));


         // write out the transform
         tm.Export(mockStream.Object);

         
         // Check the result
         Assert.That(lines.Count, Iz.EqualTo(4));
         Assert.That(lines[0], Iz.EqualTo("				1.000000 0.000000 0.000000 0.000000"));
         Assert.That(lines[1], Iz.EqualTo("				0.000000 1.000000 0.000000 0.000000"));
         Assert.That(lines[2], Iz.EqualTo("				0.000000 0.000000 1.000000 0.000000"));
         Assert.That(lines[3], Iz.EqualTo("				0.000000 0.000000 0.000000 1.000000"));


      }

   }
}
