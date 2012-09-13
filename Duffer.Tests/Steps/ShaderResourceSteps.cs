using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Duffer.Tests.Steps
{
    [Binding]
    public class ShaderResourceSteps
    {
        [Given(@"the current scene contains a shader resource list with a resource named ""(.*)""")]
        public void GivenTheCurrentSceneContainsAShaderResourceList(string shaderName)
        {
            IDTFScene currentScene = ScenarioContext.Current.Get<IDTFScene>();

            ShaderResource s1 = new ShaderResource();
            s1.Name = shaderName;

            currentScene.ShaderResources.Add(shaderName, s1);

            ScenarioContext.Current.Set<ShaderResource>(s1, shaderName);
        }
        [Given(@"the ""(.*)"" resource property for vertex colors is ""(.*)"" and the material name is ""(.*)""")]
        public void GivenTheResourcePropertyForVertexColorsIsAndTheMaterialNameIs(string shaderName, bool b, string materialName)
        {
            ShaderResource s1 = ScenarioContext.Current.Get<ShaderResource>(shaderName);
            s1.AttributeUseVertexColor = b;
            s1.ShaderMaterialName = materialName;
        }


        [Given(@"the ""(.*)"" resource has a texture layer called ""(.*)""")]
        public void GivenTheResourceHasATextureLayerCalled(string shaderName, string textureName)
        {
            ShaderResource s1 = ScenarioContext.Current.Get<ShaderResource>(shaderName);
            TextureLayer t1 = new TextureLayer();
            t1.TextureName = textureName;

            s1.ShaderTextureLayerList.Add(t1);

            ScenarioContext.Current.Set<TextureLayer>(t1, textureName);
        }

        [Given(@"the ""(.*)"" resource has two texture layers called ""(.*)"" and ""(.*)""")]
        public void GivenTheResourceHasTwoTextureLayersCalled(string shaderName, string textureName1, string textureName2)
        {
            ShaderResource s1 = ScenarioContext.Current.Get<ShaderResource>(shaderName);
            TextureLayer t1 = new TextureLayer();
            t1.TextureName = textureName1;
            TextureLayer t2 = new TextureLayer();
            t2.TextureName = textureName2;


            s1.ShaderTextureLayerList.Add(t1);
            s1.ShaderTextureLayerList.Add(t2);

            ScenarioContext.Current.Set<TextureLayer>(t1, textureName1);
            ScenarioContext.Current.Set<TextureLayer>(t2, textureName2);
        }

        [Given(@"the current scene contains a shader resource list with the following resources ""(.*)"", ""(.*)"", ""(.*)""")]
        public void GivenTheCurrentSceneContainsAShaderResourceListWithTheFollowingResources(string shaderName01, string shaderName02, string shaderName03)
        {
            IDTFScene currentScene = ScenarioContext.Current.Get<IDTFScene>();

            ShaderResource s1 = new ShaderResource();
            s1.Name = shaderName01;
            currentScene.ShaderResources.Add(shaderName01, s1);
            ScenarioContext.Current.Set<ShaderResource>(s1, shaderName01);

            ShaderResource s2 = new ShaderResource();
            s2.Name = shaderName02;
            currentScene.ShaderResources.Add(shaderName02, s2);
            ScenarioContext.Current.Set<ShaderResource>(s2, shaderName02);

            ShaderResource s3 = new ShaderResource();
            s3.Name = shaderName03;
            currentScene.ShaderResources.Add(shaderName03, s3);
            ScenarioContext.Current.Set<ShaderResource>(s3, shaderName03);
        }

        [Given(@"""(.*)"" has the following properties: material name is ""(.*)""")]
        public void GivenHasTheFollowingPropertiesMaterialNameIs(string shaderName, string materialName)
        {
            ShaderResource s1 = ScenarioContext.Current.Get<ShaderResource>(shaderName);
            s1.ShaderMaterialName = materialName;
        }

        [Given(@"the texture layer ""(.*)"" has the following properties: ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void GivenTheTextureLayerHasTheFollowingPropertiesCONSTANTTrue(string p0, int p1, string p2, string p3, float p4, bool p5)
        {
            TextureLayer t1 = ScenarioContext.Current.Get<TextureLayer>(p0);
            t1.TextureLayerIntensity = p1;
            t1.TextureLayerBlendFunction = (TextureLayerBlendFunctionType)Enum.Parse(typeof(TextureLayerBlendFunctionType), p2, true);
            t1.TextureLayerBlendSource = (TextureLayerBlendSourceType)Enum.Parse(typeof(TextureLayerBlendSourceType), p3, true);
            t1.TextureLayerBlendConstant = p4;
            t1.TextureLayerAlphaEnabled = p5;

        }
       



    }
}
