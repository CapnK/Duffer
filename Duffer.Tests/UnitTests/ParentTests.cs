using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Duffer;
using NUnit.Framework;
using Moq;

namespace Duffer.Tests.UnitTests
{
   [TestFixture]
   class ParentTests
   {

      [Test]
      public void should_write_identity_transform_matrix_with_null_name()
      {
         // Create a tempfile so the StreamWriter can be instantiated
         var path = System.IO.Path.GetTempFileName();

         // Create a basic identity matrix
         var p = new Parent();

         // create a mock stream writer
         var mockStream = new Mock<StreamWriter>(path);

         // catch all the calls to the streamwriter
         List<string> lines = new List<string>();

         mockStream.Setup(sw => sw.WriteLine(It.IsAny<string>()))
            .Callback((string s) => lines.Add(s));


         // write out the transform
         p.Export(mockStream.Object);


         // Check the result
         Assert.That(lines.Count, Iz.EqualTo(7));
         //Assert.That(lines[0], Iz.EqualTo("				1.000000 0.000000 0.000000 0.000000"));
         //Assert.That(lines[1], Iz.EqualTo("				0.000000 1.000000 0.000000 0.000000"));
         //Assert.That(lines[2], Iz.EqualTo("				0.000000 0.000000 1.000000 0.000000"));
         //Assert.That(lines[3], Iz.EqualTo("				0.000000 0.000000 0.000000 1.000000"));

         Assert.That(lines[0], Iz.EqualTo("\t\t\tPARENT_NAME \"<NULL>\""));
         Assert.That(lines[1], Iz.EqualTo("\t\t\tPARENT_TM {"));
         Assert.That(lines[2], Iz.EqualTo("\t\t\t\t1.000000 0.000000 0.000000 0.000000"));
         Assert.That(lines[3], Iz.EqualTo("\t\t\t\t0.000000 1.000000 0.000000 0.000000"));
         Assert.That(lines[4], Iz.EqualTo("\t\t\t\t0.000000 0.000000 1.000000 0.000000"));
         Assert.That(lines[5], Iz.EqualTo("\t\t\t\t0.000000 0.000000 0.000000 1.000000"));
         Assert.That(lines[6], Iz.EqualTo("\t\t\t}"));

         // Set callbase to true so we can dispose the underlying object (and release the file)
         mockStream.CallBase = true;
         mockStream.Object.Close();
         mockStream.Object.Dispose();

         //cleanup
         System.IO.File.Delete(path);

      }

      [Test]
      public void should_write_identity_transform_matrix_with_name()
      {
         // Create a tempfile so the StreamWriter can be instantiated
         var path = System.IO.Path.GetTempFileName();

         // Create a basic identity matrix
         var p = new Parent("MyParent");

         // create a mock stream writer
         var mockStream = new Mock<StreamWriter>(path);

         // catch all the calls to the streamwriter
         List<string> lines = new List<string>();

         mockStream.Setup(sw => sw.WriteLine(It.IsAny<string>()))
            .Callback((string s) => lines.Add(s));


         // write out the transform
         p.Export(mockStream.Object);


         // Check the result
         Assert.That(lines.Count, Iz.EqualTo(7));

         Assert.That(lines[0], Iz.EqualTo("\t\t\tPARENT_NAME \"MyParent\""));
         Assert.That(lines[1], Iz.EqualTo("\t\t\tPARENT_TM {"));
         Assert.That(lines[2], Iz.EqualTo("\t\t\t\t1.000000 0.000000 0.000000 0.000000"));
         Assert.That(lines[3], Iz.EqualTo("\t\t\t\t0.000000 1.000000 0.000000 0.000000"));
         Assert.That(lines[4], Iz.EqualTo("\t\t\t\t0.000000 0.000000 1.000000 0.000000"));
         Assert.That(lines[5], Iz.EqualTo("\t\t\t\t0.000000 0.000000 0.000000 1.000000"));
         Assert.That(lines[6], Iz.EqualTo("\t\t\t}"));

         // Set callbase to true so we can dispose the underlying object (and release the file)
         mockStream.CallBase = true;
         mockStream.Object.Close();
         mockStream.Object.Dispose();

         //cleanup
         System.IO.File.Delete(path);

      }
   }
}
