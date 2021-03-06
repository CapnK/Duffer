﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.269
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
    [NUnit.Framework.DescriptionAttribute("\'Texture\' resources")]
    public partial class TextureResourcesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TextureResources.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "\'Texture\' resources", "In order to create useful IDTF files \r\nI want to be able to write out Texture res" +
                    "ource list definitions", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("scene with four texture resources")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void SceneWithFourTextureResources()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("scene with four texture resources", new string[] {
                        "mytag"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have a new current scene", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("the current scene contains a texture resource named \"Texture0\" with path \"mat1.tg" +
                    "a\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And("the current scene contains a texture resource named \"Texture1\" with path \"mat2.tg" +
                    "a\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("the current scene contains a texture resource named \"Texture2\" with path \"mat3.tg" +
                    "a\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("the current scene contains a texture resource named \"Texture3\" with path \"mat4.tg" +
                    "a\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.When("I export the current scene to a file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 13
 testRunner.Then("the contents of the current file should be", @"FILE_FORMAT ""IDTF""
FORMAT_VERSION 100

RESOURCE_LIST ""TEXTURE"" {
	RESOURCE_COUNT 4
	RESOURCE 0 {
		RESOURCE_NAME ""Texture0""
		TEXTURE_PATH ""mat1.tga""
	}
	RESOURCE 1 {
		RESOURCE_NAME ""Texture1""
		TEXTURE_PATH ""mat2.tga""
	}
	RESOURCE 2 {
		RESOURCE_NAME ""Texture2""
		TEXTURE_PATH ""mat3.tga""
	}
	RESOURCE 3 {
		RESOURCE_NAME ""Texture3""
		TEXTURE_PATH ""mat4.tga""
	}
}
", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("scene with one texture that contains two image formats")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void SceneWithOneTextureThatContainsTwoImageFormats()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("scene with one texture that contains two image formats", new string[] {
                        "mytag"});
#line 41
this.ScenarioSetup(scenarioInfo);
#line 42
 testRunner.Given("I have a new current scene", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 43
 testRunner.And("the current scene contains a texture resource named \"lines\" with path \"lines_alph" +
                    "a.tga\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.And("the texture resource \"lines\" has image type \"RGBA\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("the texture resource \"lines\" contains an image format list: compression type is \"" +
                    "JPEG24\" and bleu, green and red channel is \"true\", \"true\", \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("the texture resource \"lines\" contains a second image format list: compression typ" +
                    "e is \"PNG\" and alpha channel is \"true\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("I export the current scene to a file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 48
 testRunner.Then("the contents of the current file should be", @"FILE_FORMAT ""IDTF""
FORMAT_VERSION 100

RESOURCE_LIST ""TEXTURE"" {
	RESOURCE_COUNT 1
	RESOURCE 0 {
		RESOURCE_NAME ""lines""
		TEXTURE_IMAGE_TYPE ""RGBA""
		TEXTURE_IMAGE_COUNT 2
		IMAGE_FORMAT_LIST {
			IMAGE_FORMAT 0 {
				COMPRESSION_TYPE ""JPEG24""
				BLUE_CHANNEL ""TRUE""
				GREEN_CHANNEL ""TRUE""
				RED_CHANNEL ""TRUE""
			}
			IMAGE_FORMAT 1 {
				COMPRESSION_TYPE ""PNG""
				ALPHA_CHANNEL ""TRUE""
			}
		}
		TEXTURE_PATH ""lines_alpha.tga""
	}
}
", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
