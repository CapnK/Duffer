using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duffer;
using NUnit.Framework;
using System.IO;
using Moq;

namespace Duffer.Tests
{
    [TestFixture]
    class ListExtensionsTests
    {


        [Test]
        public void should_export_a_parent_list_with_one_item()
        {
            // Create a tempfile so the StreamWriter can be instantiated
            var path = System.IO.Path.GetTempFileName();

            // Create a simple list of parents
            List<Parent> parentList = new List<Parent>();
            parentList.Add(new Parent());

            // create a mock stream writer
            var mockStream = new Mock<StreamWriter>(path);

            // catch all the calls to the streamwriter
            List<string> lines = new List<string>();

            mockStream.Setup(sw => sw.WriteLine(It.IsAny<string>()))
               .Callback((string s) => lines.Add(s));


            // write out the transform
            ListExtensions.ExportParentListToStream(parentList, mockStream.Object);


            // Check the result
            Assert.That(lines.Count, Iz.EqualTo(12));
            //      Assert.That(lines[0], Iz.EqualTo("				1.000000 0.000000 0.000000 0.000000"));
            //      Assert.That(lines[1], Iz.EqualTo("				0.000000 1.000000 0.000000 0.000000"));
            //      Assert.That(lines[2], Iz.EqualTo("				0.000000 0.000000 1.000000 0.000000"));
            //      Assert.That(lines[3], Iz.EqualTo("				0.000000 0.000000 0.000000 1.000000"));

            Assert.That(lines[0], Iz.EqualTo("\tPARENT_LIST {"));
            Assert.That(lines[1], Iz.EqualTo("\t\tPARENT_COUNT 1"));
            Assert.That(lines[2], Iz.EqualTo("\t\tPARENT 0 {"));
            Assert.That(lines[3], Iz.EqualTo("\t\t\tPARENT_NAME \"<NULL>\""));
            Assert.That(lines[4], Iz.EqualTo("\t\t\tPARENT_TM {"));
            Assert.That(lines[5], Iz.EqualTo("\t\t\t\t1.000000 0.000000 0.000000 0.000000"));
            Assert.That(lines[6], Iz.EqualTo("\t\t\t\t0.000000 1.000000 0.000000 0.000000"));
            Assert.That(lines[7], Iz.EqualTo("\t\t\t\t0.000000 0.000000 1.000000 0.000000"));
            Assert.That(lines[8], Iz.EqualTo("\t\t\t\t0.000000 0.000000 0.000000 1.000000"));
            Assert.That(lines[9], Iz.EqualTo("\t\t\t}"));
            Assert.That(lines[10], Iz.EqualTo("\t\t}"));
            Assert.That(lines[11], Iz.EqualTo("\t}"));

            // Set callbase to true so we can dispose the underlying object (and release the file)
            mockStream.CallBase = true;
            mockStream.Object.Close();
            mockStream.Object.Dispose();

            //cleanup
            System.IO.File.Delete(path);
        }

    }
}
