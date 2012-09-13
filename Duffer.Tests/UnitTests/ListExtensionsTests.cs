using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duffer;
using NUnit.Framework;
using System.IO;
using Moq;

namespace Duffer.Tests.UnitTests
{
    [TestFixture]
    class ListExtensionsTests
    {
        string _tempFilePath;
        Mock<StreamWriter> _mockStream;
        List<string> _lines = new List<string>();

        [SetUp]
        public void runBeforeAllTests()
        {
            // Create a tempfile so the StreamWriter can be instantiated
            _tempFilePath = System.IO.Path.GetTempFileName();

            // Clear out any previously captured streamwriter output
            _lines.Clear();

            // catch all the calls to the streamwriter
            _mockStream = new Mock<StreamWriter>(_tempFilePath);
            _mockStream.Setup(sw => sw.WriteLine(It.IsAny<string>()))
               .Callback((string s) => _lines.Add(s));
        }

        [TearDown]
        public void runAfterAlltests()
        {
            // Set callbase to true so we can dispose the underlying object (and release the file)
            _mockStream.CallBase = true;
            _mockStream.Object.Close();
            _mockStream.Object.Dispose();

            //cleanup
            System.IO.File.Delete(_tempFilePath);
        }


        [Test]
        public void should_export_a_parent_list_with_one_item()
        {
            

            // Create a simple list of parents
            List<Parent> parentList = new List<Parent>();
            parentList.Add(new Parent());


            // write out the list
            ListExtensions.ExportParentListToStream(parentList, _mockStream.Object);


            // Check the result
            Assert.That(_lines.Count, Iz.EqualTo(12));

            Assert.That(_lines[0], Iz.EqualTo("\tPARENT_LIST {"));
            Assert.That(_lines[1], Iz.EqualTo("\t\tPARENT_COUNT 1"));
            Assert.That(_lines[2], Iz.EqualTo("\t\tPARENT 0 {"));
            Assert.That(_lines[3], Iz.EqualTo("\t\t\tPARENT_NAME \"<NULL>\""));
            Assert.That(_lines[4], Iz.EqualTo("\t\t\tPARENT_TM {"));
            Assert.That(_lines[5], Iz.EqualTo("\t\t\t\t1.000000 0.000000 0.000000 0.000000"));
            Assert.That(_lines[6], Iz.EqualTo("\t\t\t\t0.000000 1.000000 0.000000 0.000000"));
            Assert.That(_lines[7], Iz.EqualTo("\t\t\t\t0.000000 0.000000 1.000000 0.000000"));
            Assert.That(_lines[8], Iz.EqualTo("\t\t\t\t0.000000 0.000000 0.000000 1.000000"));
            Assert.That(_lines[9], Iz.EqualTo("\t\t\t}"));
            Assert.That(_lines[10], Iz.EqualTo("\t\t}"));
            Assert.That(_lines[11], Iz.EqualTo("\t}"));

            
        }

        [Test]
        public void should_export_a_shading_list_with_one_item()
        {


            // Create a simple list of ShadingDescription
            List<ShadingDescription> aList = new List<ShadingDescription>();

            var shadingDesc = new ShadingDescription();
            shadingDesc.ShaderID = 1;
           // shadingDesc.TextureLayerCount = 1;

        //    var textureCoords = new TextureCoordDimension();
          //  textureCoords.TextureLayer = 0;
          //  textureCoords.Dimension = 1;

            shadingDesc.TextureCoordDimensionList.Add(1);
           // shadingDesc.TextureCoordDimensionList.Add(textureCoords);

            aList.Add(shadingDesc);


            // write out the list
            ListExtensions.ExportShadingListToStream(aList, _mockStream.Object);


            // Check the result
            Assert.That(_lines.Count, Iz.EqualTo(9));

            Assert.That(_lines[0], Iz.EqualTo("\t\t\tMODEL_SHADING_DESCRIPTION_LIST {"));
            Assert.That(_lines[1], Iz.EqualTo("\t\t\t\tSHADING_DESCRIPTION 0 {"));
            Assert.That(_lines[2], Iz.EqualTo("\t\t\t\t\tTEXTURE_LAYER_COUNT 1"));
            Assert.That(_lines[3], Iz.EqualTo("\t\t\t\t\tTEXTURE_COORD_DIMENSION_LIST {"));
            Assert.That(_lines[4], Iz.EqualTo("\t\t\t\t\t\tTEXTURE_LAYER 0	DIMENSION: 1"));
            Assert.That(_lines[5], Iz.EqualTo("\t\t\t\t\t}"));
            Assert.That(_lines[6], Iz.EqualTo("\t\t\t\t\tSHADER_ID 1"));
            Assert.That(_lines[7], Iz.EqualTo("\t\t\t\t}"));
            Assert.That(_lines[8], Iz.EqualTo("\t\t\t}"));
            


        }

        [Test]
        public void should_export_a_texture_coord_list_list_with_one_item()
        {


            // Create a simple list of ShadingDescription
            //List<TextureCoordDimension> aList = new List<TextureCoordDimension>();

            //var textureCoord = new TextureCoordDimension();
            //textureCoord.TextureLayer = 0;
            //textureCoord.Dimension = 1;
            List<int> aList = new List<int>();
            aList.Add(1);


            // write out the list
            ListExtensions.ExportTextureCoordListToStream(aList, _mockStream.Object);


            // Check the result
            Assert.That(_lines.Count, Iz.EqualTo(3));

            Assert.That(_lines[0], Iz.EqualTo("\t\t\t\t\tTEXTURE_COORD_DIMENSION_LIST {"));
            Assert.That(_lines[1], Iz.EqualTo("\t\t\t\t\t\tTEXTURE_LAYER 0	DIMENSION: 1"));
            Assert.That(_lines[2], Iz.EqualTo("\t\t\t\t\t}"));
           


        }

        [Test]
        public void should_export_a_texture_coord_list_list_with_two_items()
        {


            // Create a simple list of ShadingDescription
            //List<TextureCoordDimension> aList = new List<TextureCoordDimension>();

            //var textureCoord = new TextureCoordDimension();
            //textureCoord.TextureLayer = 0;
            //textureCoord.Dimension = 1;

            //aList.Add(textureCoord);

            //textureCoord = new TextureCoordDimension();
            //textureCoord.TextureLayer = 1;
            //textureCoord.Dimension = 3;

            //aList.Add(textureCoord);


            var aList = new List<int>();
            aList.Add(1);
            aList.Add(3);

            // write out the list
            ListExtensions.ExportTextureCoordListToStream(aList, _mockStream.Object);


            // Check the result
            Assert.That(_lines.Count, Iz.EqualTo(4));

            Assert.That(_lines[0], Iz.EqualTo("\t\t\t\t\tTEXTURE_COORD_DIMENSION_LIST {"));
            Assert.That(_lines[1], Iz.EqualTo("\t\t\t\t\t\tTEXTURE_LAYER 0	DIMENSION: 1"));
            Assert.That(_lines[2], Iz.EqualTo("\t\t\t\t\t\tTEXTURE_LAYER 1	DIMENSION: 3"));
            Assert.That(_lines[3], Iz.EqualTo("\t\t\t\t\t}"));



        }

        [Test]
        public void should_export_a_texture_coord_list_list_with_two_items_without_checking_indentation()
        {


            // Create a simple list of ShadingDescription
            //List<TextureCoordDimension> aList = new List<TextureCoordDimension>();

            //var textureCoord = new TextureCoordDimension();
            //textureCoord.TextureLayer = 0;
            //textureCoord.Dimension = 1;

            //aList.Add(textureCoord);

            //textureCoord = new TextureCoordDimension();
            //textureCoord.TextureLayer = 1;
            //textureCoord.Dimension = 3;
            //aList.Add(textureCoord);

            var aList = new List<int>();
            aList.Add(1);
            aList.Add(3);     

            // write out the list
            ListExtensions.ExportTextureCoordListToStream(aList, _mockStream.Object);


            // Check the result
            Assert.That(_lines.Count, Iz.EqualTo(4));

            Assert.That(_lines[0].Trim(), Iz.EqualTo("TEXTURE_COORD_DIMENSION_LIST {"));
            Assert.That(_lines[1].Trim(), Iz.EqualTo("TEXTURE_LAYER 0	DIMENSION: 1"));
            Assert.That(_lines[2].Trim(), Iz.EqualTo("TEXTURE_LAYER 1	DIMENSION: 3"));
            Assert.That(_lines[3].Trim(), Iz.EqualTo("}"));



        }
    }
}
