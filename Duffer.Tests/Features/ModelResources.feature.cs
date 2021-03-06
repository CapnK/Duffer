﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.296
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Duffer.Tests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("\'Model\' resources")]
    public partial class ModelResourcesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ModelResources.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "\'Model\' resources", "In order to create useful IDTF files \r\nI want to be able to write out model resou" +
                    "rce list definitions", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("scene with one model resource")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void SceneWithOneModelResource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("scene with one model resource", new string[] {
                        "mytag"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have a new current scene", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("the current scene contains a model resource list with a \"Mesh\" resource named \"Li" +
                    "ghtBoxModel\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("I export the current scene to a file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
 testRunner.Then("the contents of the current file should be", "FILE_FORMAT \"IDTF\"\r\nFORMAT_VERSION 100\r\n\r\nRESOURCE_LIST \"MODEL\" {\r\n\tRESOURCE_COUN" +
                    "T 1\r\n\tRESOURCE 0 {\r\n\t\tRESOURCE_NAME \"LightBoxModel\"\r\n\t\tMODEL_TYPE \"MESH\"\r\n\t}\r\n}\r" +
                    "\n", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("scene with one model resource with empty mesh model")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void SceneWithOneModelResourceWithEmptyMeshModel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("scene with one model resource with empty mesh model", new string[] {
                        "mytag"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("I have a new current scene", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.And("the current scene contains a model resource list with a \"Mesh\" resource named \"My" +
                    "Mesh01\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("the resource \"MyMesh01\" contains an mesh model", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.When("I export the current scene to a file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 31
 testRunner.Then("the contents of the current file should be", @"FILE_FORMAT ""IDTF""
FORMAT_VERSION 100

RESOURCE_LIST ""MODEL"" {
	RESOURCE_COUNT 1
	RESOURCE 0 {
		RESOURCE_NAME ""MyMesh01""
		MODEL_TYPE ""MESH""
		MESH {
			FACE_COUNT 0
			MODEL_POSITION_COUNT 0
			MODEL_NORMAL_COUNT 0
			MODEL_DIFFUSE_COLOR_COUNT 0
			MODEL_SPECULAR_COLOR_COUNT 0
			MODEL_TEXTURE_COORD_COUNT 0
			MODEL_BONE_COUNT 0
			MODEL_SHADING_COUNT 0
		}
	}
}
", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("scene with one model resource with empty line set model")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void SceneWithOneModelResourceWithEmptyLineSetModel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("scene with one model resource with empty line set model", new string[] {
                        "mytag"});
#line 57
this.ScenarioSetup(scenarioInfo);
#line 58
 testRunner.Given("I have a new current scene", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 59
 testRunner.And("the current scene contains a model resource list with a \"Line_Set\" resource named" +
                    " \"MyLineSet\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("the resource \"MyLineSet\" contains a line set model", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.When("I export the current scene to a file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 62
 testRunner.Then("the contents of the current file should be", @"FILE_FORMAT ""IDTF""
FORMAT_VERSION 100

RESOURCE_LIST ""MODEL"" {
	RESOURCE_COUNT 1
	RESOURCE 0 {
		RESOURCE_NAME ""MyLineSet""
		MODEL_TYPE ""LINE_SET""
		LINE_SET {
			LINE_COUNT 0
			MODEL_POSITION_COUNT 0
			MODEL_NORMAL_COUNT 0
			MODEL_DIFFUSE_COLOR_COUNT 0
			MODEL_SPECULAR_COLOR_COUNT 0
			MODEL_TEXTURE_COORD_COUNT 0
			MODEL_SHADING_COUNT 0
		}
	}
}
", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("scene with one model resource with \"Mesh\" with shading descriptions")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void SceneWithOneModelResourceWithMeshWithShadingDescriptions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("scene with one model resource with \"Mesh\" with shading descriptions", new string[] {
                        "mytag"});
#line 87
this.ScenarioSetup(scenarioInfo);
#line 88
 testRunner.Given("I have a new current scene", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 89
 testRunner.And("the current scene contains a model resource list with a \"Mesh\" resource named \"My" +
                    "Mesh01\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And("the resource \"MyMesh01\" contains an mesh model", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And("the resource \"MyMesh01\" contains a shading description with id \"0\" and a texture " +
                    "layer with dimension \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("the resource \"MyMesh01\" contains a shading description with id \"0\" and a texture " +
                    "layer with dimension \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And("the resource \"MyMesh01\" contains a shading description with id \"0\" and a texture " +
                    "layer with dimension \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.When("I export the current scene to a file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 95
 testRunner.Then("the contents of the current file should be", @"FILE_FORMAT ""IDTF""
FORMAT_VERSION 100

RESOURCE_LIST ""MODEL"" {
	RESOURCE_COUNT 1
	RESOURCE 0 {
		RESOURCE_NAME ""MyMesh01""
		MODEL_TYPE ""MESH""
		MESH {
			FACE_COUNT 0
			MODEL_POSITION_COUNT 0
			MODEL_NORMAL_COUNT 0
			MODEL_DIFFUSE_COLOR_COUNT 0
			MODEL_SPECULAR_COLOR_COUNT 0
			MODEL_TEXTURE_COORD_COUNT 0
			MODEL_BONE_COUNT 0
			MODEL_SHADING_COUNT 3
			MODEL_SHADING_DESCRIPTION_LIST {
				SHADING_DESCRIPTION 0 {
					TEXTURE_LAYER_COUNT 1
					TEXTURE_COORD_DIMENSION_LIST {
						TEXTURE_LAYER 0	DIMENSION: 2
					}
					SHADER_ID 0
				}
				SHADING_DESCRIPTION 1 {
					TEXTURE_LAYER_COUNT 1
					TEXTURE_COORD_DIMENSION_LIST {
						TEXTURE_LAYER 0	DIMENSION: 1
					}
					SHADER_ID 0
				}
				SHADING_DESCRIPTION 2 {
					TEXTURE_LAYER_COUNT 1
					TEXTURE_COORD_DIMENSION_LIST {
						TEXTURE_LAYER 0	DIMENSION: 2
					}
					SHADER_ID 0
				}
			}
		}
	}
}
", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("scene with one model resource containing a mesh with some random lists")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void SceneWithOneModelResourceContainingAMeshWithSomeRandomLists()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("scene with one model resource containing a mesh with some random lists", new string[] {
                        "mytag"});
#line 144
this.ScenarioSetup(scenarioInfo);
#line 145
 testRunner.Given("I have a new current scene", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 146
 testRunner.And("the current scene contains a model resource list with a \"Mesh\" resource named \"Li" +
                    "ghtBoxModel\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
 testRunner.And("the resource \"LightBoxModel\" contains an mesh model", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 148
 testRunner.And("the resource \"LightBoxModel\" contains a shading description with id \"0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
 testRunner.And("the resource \"LightBoxModel\" has a mesh face position \"0\", \"2\", \"3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 150
 testRunner.And("the resource \"LightBoxModel\" has a mesh face position \"3\", \"1\", \"0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 151
 testRunner.And("the resource \"LightBoxModel\" has a mesh face position \"4\", \"5\", \"7\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 152
 testRunner.And("the resource \"LightBoxModel\" has a mesh face position \"7\", \"6\", \"4\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
 testRunner.And("the resource \"LightBoxModel\" has a mesh face normal \"0\", \"1\", \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 154
 testRunner.And("the resource \"LightBoxModel\" has a mesh face normal \"3\", \"4\", \"5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 155
 testRunner.And("the resource \"LightBoxModel\" has a mesh face normal \"6\", \"7\", \"8\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 156
 testRunner.And("the resource \"LightBoxModel\" has a mesh face normal \"9\", \"10\", \"11\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 157
 testRunner.And("the resource \"LightBoxModel\" has a mesh face shading \"0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 158
 testRunner.And("the resource \"LightBoxModel\" has a mesh face shading \"0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
 testRunner.And("the resource \"LightBoxModel\" has a mesh face shading \"0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 160
 testRunner.And("the resource \"LightBoxModel\" has a mesh face shading \"0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
 testRunner.And("the resource \"LightBoxModel\" has a mesh position \"-20\", \"-20\", \"0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
 testRunner.And("the resource \"LightBoxModel\" has a mesh position \"20\", \"-20\", \"0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 163
 testRunner.And("the resource \"LightBoxModel\" has a mesh position \"20\", \"-20\", \"40\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 164
 testRunner.And("the resource \"LightBoxModel\" has a mesh position \"-20\", \"20\", \"40\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 165
 testRunner.When("I export the current scene to a file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 166
 testRunner.Then("the contents of the current file should be", @"FILE_FORMAT ""IDTF""
FORMAT_VERSION 100

RESOURCE_LIST ""MODEL"" {
	RESOURCE_COUNT 1
	RESOURCE 0 {
		RESOURCE_NAME ""LightBoxModel""
		MODEL_TYPE ""MESH""
		MESH {
			FACE_COUNT 4
			MODEL_POSITION_COUNT 4
			MODEL_NORMAL_COUNT 0
			MODEL_DIFFUSE_COLOR_COUNT 0
			MODEL_SPECULAR_COLOR_COUNT 0
			MODEL_TEXTURE_COORD_COUNT 0
			MODEL_BONE_COUNT 0
			MODEL_SHADING_COUNT 1
			MODEL_SHADING_DESCRIPTION_LIST {
				SHADING_DESCRIPTION 0 {
					TEXTURE_LAYER_COUNT 0
					SHADER_ID 0
				}
			}
			MESH_FACE_POSITION_LIST {
				0 2 3
				3 1 0
				4 5 7
				7 6 4
			}
			MESH_FACE_NORMAL_LIST {
				0 1 2
				3 4 5
				6 7 8
				9 10 11
			}
			MESH_FACE_SHADING_LIST {
				0
				0
				0
				0
			}
			MODEL_POSITION_LIST {
				-20.000000 -20.000000 0.000000
				20.000000 -20.000000 0.000000
				20.000000 -20.000000 40.000000
				-20.000000 20.000000 40.000000
			}
		}
	}
}
", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("scene with one model resource containing some lines")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void SceneWithOneModelResourceContainingSomeLines()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("scene with one model resource containing some lines", new string[] {
                        "mytag"});
#line 223
this.ScenarioSetup(scenarioInfo);
#line 224
 testRunner.Given("I have a new current scene", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 225
 testRunner.And("the current scene contains a model resource list with a \"Line_Set\" resource named" +
                    " \"Lines\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 226
 testRunner.And("the resource \"Lines\" contains a line set model", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 227
 testRunner.And("the resource \"Lines\" contains a shading description with id \"3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 228
 testRunner.And("the resource called \"Lines\" contains lines", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 229
 testRunner.When("I export the current scene to a file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 230
 testRunner.Then("the contents of the current file should be", "FILE_FORMAT \"IDTF\"\r\nFORMAT_VERSION 100\r\n\r\nRESOURCE_LIST \"MODEL\" {\r\n\tRESOURCE_COUN" +
                    "T 1\r\n\tRESOURCE 0 {\r\n\t\tRESOURCE_NAME \"Lines\"\r\n\t\tMODEL_TYPE \"LINE_SET\"\r\n\t\tLINE_SET" +
                    " {\r\n\t\t\tLINE_COUNT 9\r\n\t\t\tMODEL_POSITION_COUNT 18\r\n\t\t\tMODEL_NORMAL_COUNT 9\r\n\t\t\tMOD" +
                    "EL_DIFFUSE_COLOR_COUNT 0\r\n\t\t\tMODEL_SPECULAR_COLOR_COUNT 0\r\n\t\t\tMODEL_TEXTURE_COOR" +
                    "D_COUNT 0\r\n\t\t\tMODEL_SHADING_COUNT 1\r\n\t\t\tMODEL_SHADING_DESCRIPTION_LIST {\r\n\t\t\t\tSH" +
                    "ADING_DESCRIPTION 0 {\r\n\t\t\t\t\tTEXTURE_LAYER_COUNT 0\r\n\t\t\t\t\tSHADER_ID 3\r\n\t\t\t\t}\r\n\t\t\t}" +
                    "\r\n\t\t\tLINE_POSITION_LIST {\r\n\t\t\t\t0 1\r\n\t\t\t\t2 3\r\n\t\t\t\t4 5\r\n\t\t\t\t6 7\r\n\t\t\t\t8 9\r\n\t\t\t\t10 1" +
                    "1\r\n\t\t\t\t12 13\r\n\t\t\t\t14 15\r\n\t\t\t\t16 17\r\n\t\t\t}\r\n\t\t\tLINE_NORMAL_LIST {\r\n\t\t\t\t0 0\r\n\t\t\t\t1 " +
                    "1\r\n\t\t\t\t2 2\r\n\t\t\t\t3 3\r\n\t\t\t\t3 0\r\n\t\t\t\t3 0\r\n\t\t\t\t3 0\r\n\t\t\t\t3 0\r\n\t\t\t\t3 0\r\n\t\t\t}\r\n\t\t\tLINE_" +
                    "SHADING_LIST {\r\n\t\t\t\t0\r\n\t\t\t\t0\r\n\t\t\t\t0\r\n\t\t\t\t0\r\n\t\t\t\t0\r\n\t\t\t\t0\r\n\t\t\t\t0\r\n\t\t\t\t0\r\n\t\t\t\t0\r\n\t" +
                    "\t\t}\r\n\t\t\tMODEL_POSITION_LIST {\r\n\t\t\t\t0.000000 0.000000 0.000000\r\n\t\t\t\t0.000000 20.0" +
                    "00000 0.000000\r\n\t\t\t\t5.000000 0.000000 0.000000\r\n\t\t\t\t5.000000 20.000000 0.000000\r" +
                    "\n\t\t\t\t10.000000 0.000000 0.000000\r\n\t\t\t\t10.000000 20.000000 0.000000\r\n\t\t\t\t15.00000" +
                    "0 0.000000 0.000000\r\n\t\t\t\t15.000000 20.000000 0.000000\r\n\t\t\t\t20.000000 0.000000 0." +
                    "000000\r\n\t\t\t\t20.000000 20.000000 0.000000\r\n\t\t\t\t-5.000000 5.000000 0.000000\r\n\t\t\t\t2" +
                    "0.000000 5.000000 0.000000\r\n\t\t\t\t-5.000000 10.000000 0.000000\r\n\t\t\t\t20.000000 10.0" +
                    "00000 0.000000\r\n\t\t\t\t-5.000000 15.000000 0.000000\r\n\t\t\t\t20.000000 15.000000 0.0000" +
                    "00\r\n\t\t\t\t-5.000000 20.000000 0.000000\r\n\t\t\t\t20.000000 20.000000 0.000000\r\n\t\t\t}\r\n\t\t" +
                    "\tMODEL_NORMAL_LIST {\r\n\t\t\t\t0.000000 0.500000 0.500000\r\n\t\t\t\t0.000000 0.200000 0.80" +
                    "0000\r\n\t\t\t\t0.000000 0.000000 0.990000\r\n\t\t\t\t0.000000 0.000000 1.000000\r\n\t\t\t\t0.0000" +
                    "00 0.000000 1.000000\r\n\t\t\t\t0.000000 0.000000 1.000000\r\n\t\t\t\t0.000000 0.000000 -1.0" +
                    "00000\r\n\t\t\t\t0.000000 0.000000 -1.000000\r\n\t\t\t\t0.000000 0.000000 -1.000000\r\n\t\t\t}\r\n\t" +
                    "\t}\r\n\t}\r\n}\r\n", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
