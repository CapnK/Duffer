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

        [Test]
        public void should_export_a_mesh_face_texture_coord_list_with_one_item_with_two_texture_layers()
        {
            // Create a simple list of mesh face texture coordinates
            
            var aMeshFace = new FaceTextureCoord();
            aMeshFace.TextureCoordDimensionList = new List<Int3> { new Int3(1, 2, 3), new Int3(4, 5, 6) };
            var aList = new List<FaceTextureCoord> { aMeshFace };

            ListExtensions.ExportMeshFaceTextureCoordListToStream(aList, _mockStream.Object);
            
            // Check the result
            Assert.That(_lines.Count, Iz.EqualTo(6));

            Assert.That(_lines[0], Iz.EqualTo("\t\t\tMESH_FACE_TEXTURE_COORD_LIST {"));
            Assert.That(_lines[1], Iz.EqualTo("\t\t\t\tFACE 0 {"));
            Assert.That(_lines[2], Iz.EqualTo("\t\t\t\t\tTEXTURE_LAYER 0 TEX_COORD: 1 2 3"));
            Assert.That(_lines[3], Iz.EqualTo("\t\t\t\t\tTEXTURE_LAYER 1 TEX_COORD: 4 5 6"));
            Assert.That(_lines[4], Iz.EqualTo("\t\t\t\t}"));
            Assert.That(_lines[5], Iz.EqualTo("\t\t\t}"));
        }
        [Test]
        public void should_export_a_mesh_face_texture_coord_list_with_two_items_with_two_texture_layers()
        {
            // Create a simple list of mesh face texture coordinates            
            var aMeshFace01 = new FaceTextureCoord();
            aMeshFace01.TextureCoordDimensionList = new List<Int3> { new Int3(1, 2, 3), new Int3(4, 5, 6) };
            var aMeshFace02 = new FaceTextureCoord();
            aMeshFace02.TextureCoordDimensionList = new List<Int3> { new Int3(1, 2, 3), new Int3(4, 5, 6) };

            var aList = new List<FaceTextureCoord>{aMeshFace01, aMeshFace02};         

            ListExtensions.ExportMeshFaceTextureCoordListToStream(aList, _mockStream.Object);

            // Check the result
            Assert.That(_lines.Count, Iz.EqualTo(10));

            Assert.That(_lines[0], Iz.EqualTo("\t\t\tMESH_FACE_TEXTURE_COORD_LIST {"));
            Assert.That(_lines[1], Iz.EqualTo("\t\t\t\tFACE 0 {"));
            Assert.That(_lines[2], Iz.EqualTo("\t\t\t\t\tTEXTURE_LAYER 0 TEX_COORD: 1 2 3"));
            Assert.That(_lines[3], Iz.EqualTo("\t\t\t\t\tTEXTURE_LAYER 1 TEX_COORD: 4 5 6"));
            Assert.That(_lines[4], Iz.EqualTo("\t\t\t\t}"));
            Assert.That(_lines[5], Iz.EqualTo("\t\t\t\tFACE 1 {"));
            Assert.That(_lines[6], Iz.EqualTo("\t\t\t\t\tTEXTURE_LAYER 0 TEX_COORD: 1 2 3"));
            Assert.That(_lines[7], Iz.EqualTo("\t\t\t\t\tTEXTURE_LAYER 1 TEX_COORD: 4 5 6"));
            Assert.That(_lines[8], Iz.EqualTo("\t\t\t\t}"));
            Assert.That(_lines[9], Iz.EqualTo("\t\t\t}"));
        }

        [Test]
        public void should_export_a_int3_list_with_three_items()
        {
            // Create a simple list of mesh face texture coordinates            
            var firstInt3 = new Int3(3, 5, 7);
            var secondInt3 = new Int3(8, 9, 10);
            var thirdInt3 = new Int3(2, 2, 7);
            
            var aList = new List<Int3> { firstInt3, secondInt3, thirdInt3 };

            ListExtensions.ExportInt3ListToStream(aList, _mockStream.Object, "MESH_FACE_DIFFUSE_COLOR_LIST");

            // Check the result
            Assert.That(_lines.Count, Iz.EqualTo(5));

            Assert.That(_lines[0], Iz.EqualTo("\t\t\tMESH_FACE_DIFFUSE_COLOR_LIST {"));
            Assert.That(_lines[1], Iz.EqualTo("\t\t\t\t3 5 7"));
            Assert.That(_lines[2], Iz.EqualTo("\t\t\t\t8 9 10"));
            Assert.That(_lines[3], Iz.EqualTo("\t\t\t\t2 2 7"));
            Assert.That(_lines[4], Iz.EqualTo("\t\t\t}"));
        }

        [Test]
        public void should_export_a_int_list_with_three_items()
        {
            // Create a simple list of integers
            var aList = new List<int> { 1, 3, 5 };
            ListExtensions.ExportIntListToStream(aList, _mockStream.Object, "MESH_BASE_POSITION_LIST");

            // Check the result
            Assert.That(_lines.Count, Iz.EqualTo(5));

            Assert.That(_lines[0], Iz.EqualTo("\t\t\tMESH_BASE_POSITION_LIST {"));
            Assert.That(_lines[1], Iz.EqualTo("\t\t\t\t1"));
            Assert.That(_lines[2], Iz.EqualTo("\t\t\t\t3"));
            Assert.That(_lines[3], Iz.EqualTo("\t\t\t\t5"));
            Assert.That(_lines[4], Iz.EqualTo("\t\t\t}"));
        }

        [Test]
        public void should_export_a_point3_list_with_three_items()
        {
            // Create a simple list of integers
            var firstPoint3 = new Point3(3, 5.01f, 7);
            var secondPoint3 = new Point3(8, -9.005f, 10);
            var thirdPoint3 = new Point3(2, 2, 7);

            var aList = new List<Point3> { firstPoint3, secondPoint3, thirdPoint3 };
            ListExtensions.ExportPoint3ListToStream(aList, _mockStream.Object, "MODEL_POSITION_LIST");

            // Check the result
            Assert.That(_lines.Count, Iz.EqualTo(5));

            Assert.That(_lines[0], Iz.EqualTo("\t\t\tMODEL_POSITION_LIST {"));
            Assert.That(_lines[1], Iz.EqualTo("\t\t\t\t3.000000 5.010000 7.000000"));
            Assert.That(_lines[2], Iz.EqualTo("\t\t\t\t8.000000 -9.005000 10.000000"));
            Assert.That(_lines[3], Iz.EqualTo("\t\t\t\t2.000000 2.000000 7.000000"));
            Assert.That(_lines[4], Iz.EqualTo("\t\t\t}"));
        }

        [Test]
        public void should_export_a_vector4_list_with_one_item()
        {
            // Create a simple list of vector4 objects
            var aList = new List<Vector4> { new Vector4(1.01f, -5.9f, 9, 9) };
            ListExtensions.ExportVector4ListToStream(aList, _mockStream.Object, "MODEL_TEXTURE_COORD_LIST");

            // Check the result
            Assert.That(_lines.Count, Iz.EqualTo(3));

            Assert.That(_lines[0], Iz.EqualTo("\t\t\tMODEL_TEXTURE_COORD_LIST {"));
            Assert.That(_lines[1], Iz.EqualTo("\t\t\t\t1.010000 -5.900000 9.000000 9.000000"));
            Assert.That(_lines[2], Iz.EqualTo("\t\t\t}"));
        }

        [Test]
        public void should_export_a_color_list_with_three_items()
        {
            // Create a simple list of colors
            System.Drawing.Color black = System.Drawing.Color.Black;
            System.Drawing.Color white = System.Drawing.Color.White;
            System.Drawing.Color gray = System.Drawing.Color.Gray;

            var aList = new List<System.Drawing.Color> { black, white, gray };
            ListExtensions.ExportColor4ListToStream(aList, _mockStream.Object, "MODEL_SPECULAR_COLOR_LIST");

            // Check the result
            Assert.That(_lines.Count, Iz.EqualTo(5));

            Assert.That(_lines[0], Iz.EqualTo("\t\t\tMODEL_SPECULAR_COLOR_LIST {"));
            Assert.That(_lines[1], Iz.EqualTo("\t\t\t\t0.000000 0.000000 0.000000 1.000000"));
            Assert.That(_lines[2], Iz.EqualTo("\t\t\t\t1.000000 1.000000 1.000000 1.000000"));
            Assert.That(_lines[3], Iz.EqualTo("\t\t\t\t0.500000 0.500000 0.500000 1.000000"));  
            Assert.That(_lines[4], Iz.EqualTo("\t\t\t}"));
        }

        [Test]
        public void should_export_a_shader_list_with_two_shader_lists()
        {
            // Create a simple list of colors
            Shader s1 = new Shader() { ShaderNameList = new List<string> { "ModelShader1", "ModelShader2", "ModelShader3" } };
            Shader s2 = new Shader() { ShaderNameList = new List<string> { "AnotherShader"} };

            var aList = new List<Shader> { s1, s2 };
            ListExtensions.ExportShaderListToStream(aList, _mockStream.Object);

            // Check the result
            Assert.That(_lines.Count, Iz.EqualTo(17));

            Assert.That(_lines[0], Iz.EqualTo("\t\tSHADER_LIST_COUNT 2"));
            Assert.That(_lines[1], Iz.EqualTo("\t\tSHADING_GROUP {"));
            Assert.That(_lines[2], Iz.EqualTo("\t\t\tSHADER_LIST 0 {"));
            Assert.That(_lines[3], Iz.EqualTo("\t\t\t\tSHADER_COUNT 3"));
            Assert.That(_lines[4], Iz.EqualTo("\t\t\t\tSHADER_NAME_LIST {"));
            Assert.That(_lines[5], Iz.EqualTo("\t\t\t\t\tSHADER 0 NAME: \"ModelShader1\""));
            Assert.That(_lines[6], Iz.EqualTo("\t\t\t\t\tSHADER 1 NAME: \"ModelShader2\""));
            Assert.That(_lines[7], Iz.EqualTo("\t\t\t\t\tSHADER 2 NAME: \"ModelShader3\""));
            Assert.That(_lines[8], Iz.EqualTo("\t\t\t\t}"));
            Assert.That(_lines[9], Iz.EqualTo("\t\t\t}"));
            Assert.That(_lines[10], Iz.EqualTo("\t\t\tSHADER_LIST 1 {"));
            Assert.That(_lines[11], Iz.EqualTo("\t\t\t\tSHADER_COUNT 1"));
            Assert.That(_lines[12], Iz.EqualTo("\t\t\t\tSHADER_NAME_LIST {"));
            Assert.That(_lines[13], Iz.EqualTo("\t\t\t\t\tSHADER 0 NAME: \"AnotherShader\""));
            Assert.That(_lines[14], Iz.EqualTo("\t\t\t\t}"));
            Assert.That(_lines[15], Iz.EqualTo("\t\t\t}"));
            Assert.That(_lines[16], Iz.EqualTo("\t\t}"));
        }
    }
}
