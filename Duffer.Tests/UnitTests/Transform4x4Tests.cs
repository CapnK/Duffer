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
         // Create a tempfile so the StreamWriter can be instantiated
         var path = System.IO.Path.GetTempFileName();

         // Create a basic identity matrix
         var tm = new Transform4x4();

         // create a mock stream writer
        var mockStream = new Mock<StreamWriter>(path);
        
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

         // Set callbase to true so we can dispose the underlying object (and release the file)
         mockStream.CallBase = true;
         mockStream.Object.Close();
         mockStream.Object.Dispose();  

         //cleanup
         System.IO.File.Delete(path);

      }

      [Test]
      public void should_write_column0_equal_1_transform_matrix()
      {
         // Create a tempfile so the StreamWriter can be instantiated
         var path = System.IO.Path.GetTempFileName();

         // Create a basic matrix, with 1.0 in all column 1 values
         var tm = new Transform4x4();

         //blank out the identity matrix
         tm.c1r1 = 0;
         tm.c2r2 = 0;
         tm.c3r3 = 0;

         //setup column 0
         tm.c0r0 = 1;
         tm.c0r1 = 1;
         tm.c0r2 = 1;
         tm.c0r3 = 1;



         // create a mock stream writer
         var mockStream = new Mock<StreamWriter>(path);

         // catch all the calls to the streamwriter
         List<string> lines = new List<string>();

         mockStream.Setup(sw => sw.WriteLine(It.IsAny<string>()))
            .Callback((string s) => lines.Add(s));


         // write out the transform
         tm.Export(mockStream.Object);


         // Check the result
         Assert.That(lines.Count, Iz.EqualTo(4));
         Assert.That(lines[0], Iz.EqualTo("				1.000000 1.000000 1.000000 1.000000"));
         Assert.That(lines[1], Iz.EqualTo("				0.000000 0.000000 0.000000 0.000000"));
         Assert.That(lines[2], Iz.EqualTo("				0.000000 0.000000 0.000000 0.000000"));
         Assert.That(lines[3], Iz.EqualTo("				0.000000 0.000000 0.000000 0.000000"));

         // Set callbase to true so we can dispose the underlying object (and release the file)
         mockStream.CallBase = true;
         mockStream.Object.Close();
         mockStream.Object.Dispose();

         //cleanup
         System.IO.File.Delete(path);

      }

      [Test]
      public void should_write_column1_equal_2point5_transform_matrix()
      {
         // Create a tempfile so the StreamWriter can be instantiated
         var path = System.IO.Path.GetTempFileName();

         // Create a basic matrix, with 1.0 in all column 1 values
         var tm = new Transform4x4();

         //blank out the identity matrix
         tm.c0r0 = 0;
         tm.c1r1 = 0;
         tm.c2r2 = 0;
         tm.c3r3 = 0;

         //setup column 1
         tm.c1r0 = 2.5;
         tm.c1r1 = 2.5;
         tm.c1r2 = 2.5;
         tm.c1r3 = 2.5;



         // create a mock stream writer
         var mockStream = new Mock<StreamWriter>(path);

         // catch all the calls to the streamwriter
         List<string> lines = new List<string>();

         mockStream.Setup(sw => sw.WriteLine(It.IsAny<string>()))
            .Callback((string s) => lines.Add(s));


         // write out the transform
         tm.Export(mockStream.Object);


         // Check the result
         Assert.That(lines.Count, Iz.EqualTo(4));
         Assert.That(lines[0], Iz.EqualTo("				0.000000 0.000000 0.000000 0.000000"));
         Assert.That(lines[1], Iz.EqualTo("				2.500000 2.500000 2.500000 2.500000"));
         Assert.That(lines[2], Iz.EqualTo("				0.000000 0.000000 0.000000 0.000000"));
         Assert.That(lines[3], Iz.EqualTo("				0.000000 0.000000 0.000000 0.000000"));

         // Set callbase to true so we can dispose the underlying object (and release the file)
         mockStream.CallBase = true;
         mockStream.Object.Close();
         mockStream.Object.Dispose();

         //cleanup
         System.IO.File.Delete(path);

      }

      [Test]
      public void should_write_row3_equal_minus2point5_transform_matrix()
      {
         // Create a tempfile so the StreamWriter can be instantiated
         var path = System.IO.Path.GetTempFileName();

         // Create a basic matrix, with 1.0 in all column 1 values
         var tm = new Transform4x4();

         //blank out the identity matrix
         tm.c0r0 = 0;
         tm.c1r1 = 0;
         tm.c2r2 = 0;
         tm.c3r3 = 0;

         //setup row 3
         tm.c0r3 = -2.5;
         tm.c1r3 = -2.5;
         tm.c2r3 = -2.5;
         tm.c3r3 = -2.5;



         // create a mock stream writer
         var mockStream = new Mock<StreamWriter>(path);

         // catch all the calls to the streamwriter
         List<string> lines = new List<string>();

         mockStream.Setup(sw => sw.WriteLine(It.IsAny<string>()))
            .Callback((string s) => lines.Add(s));


         // write out the transform
         tm.Export(mockStream.Object);


         // Check the result
         Assert.That(lines.Count, Iz.EqualTo(4));
         Assert.That(lines[0], Iz.EqualTo("				0.000000 0.000000 0.000000 -2.500000"));
         Assert.That(lines[1], Iz.EqualTo("				0.000000 0.000000 0.000000 -2.500000"));
         Assert.That(lines[2], Iz.EqualTo("				0.000000 0.000000 0.000000 -2.500000"));
         Assert.That(lines[3], Iz.EqualTo("				0.000000 0.000000 0.000000 -2.500000"));

         // Set callbase to true so we can dispose the underlying object (and release the file)
         mockStream.CallBase = true;
         mockStream.Object.Close();
         mockStream.Object.Dispose();

         //cleanup
         System.IO.File.Delete(path);

      }

   }
}
