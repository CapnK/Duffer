using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TechTalk.SpecFlow;

namespace Duffer.Tests.Steps
{
    [Binding]
    public class ModelResourceSteps
    {

        [Given(@"the current scene contains a model resource list with a resource named ""(.*)""")]
        public void GivenTheCurrentSceneContainsAModelResourceListWithAResourceNamed(string modelName)
        {
            IDTFScene currentScene = ScenarioContext.Current.Get<IDTFScene>();

            ModelResource m1 = new ModelResource();
            m1.Name = modelName;

            currentScene.ModelResources.Add(modelName, m1);

            ScenarioContext.Current.Set<ModelResource>(m1, modelName);
        }

        [Given(@"the resource ""(.*)"" contains an mesh model")]
        public void GivenTheResourceContainsAnMeshModel(string modelName)
        {
            ModelResource m1 = ScenarioContext.Current.Get<ModelResource>(modelName);
            m1.Mesh = new MeshData();
        }
        [Given(@"the resource ""(.*)"" contains a shading description with id ""(.*)""")]
        public void GivenTheResourceContainsAShadingDescriptionWithId(string modelName, int id)
        {
            ModelResource m1 = ScenarioContext.Current.Get<ModelResource>(modelName);
            ShadingDescription s1 = new ShadingDescription(id);
            
            m1.Mesh.ShadingDescriptionList.Add(s1);

            ScenarioContext.Current.Set<ShadingDescription>(s1);
        }


        [Given(@"the resource ""(.*)"" contains a shading description with id ""(.*)"" and a texture layer with dimension ""(.*)""")]
        public void GivenTheResourceContainsAShadingDescriptionWithIdAndATextureLayerWithDimension(string modelName, int id, int dim)
        {
            ModelResource m1 = ScenarioContext.Current.Get<ModelResource>(modelName);
            ShadingDescription s1 = new ShadingDescription(id);
            s1.TextureCoordDimensionList.Add(dim);
            m1.Mesh.ShadingDescriptionList.Add(s1);

            ScenarioContext.Current.Set<ShadingDescription>(s1);
        }

        [Given(@"the resource ""(.*)"" has a mesh face position ""(.*)"", ""(.*)"", ""(.*)""")]
        public void GivenTheResourceHasAMeshFacePosition(string modelName, int p1, int p2, int p3)
        {
            ModelResource m1 = ScenarioContext.Current.Get<ModelResource>(modelName);
            m1.Mesh.MeshFacePositionList.Add(new Int3(p1, p2, p3));
        }


        [Given(@"the resource ""(.*)"" has a mesh face normal ""(.*)"", ""(.*)"", ""(.*)""")]
        public void GivenTheResourceHasAMeshFaceNormal(string modelName, int p1, int p2, int p3)
        {
            ModelResource m1 = ScenarioContext.Current.Get<ModelResource>(modelName);
            m1.Mesh.MeshFaceNormalList.Add(new Int3(p1, p2, p3));
        }
        [Given(@"the resource ""(.*)"" has a mesh face shading ""(.*)""")]
        public void GivenTheResourceHasAMeshFaceShading(string modelName, int p1)
        {
            ModelResource m1 = ScenarioContext.Current.Get<ModelResource>(modelName);
            m1.Mesh.MeshFaceShadingList.Add(p1);
        }
        [Given(@"the resource ""(.*)"" has a mesh position ""(.*)"", ""(.*)"", ""(.*)""")]
        public void GivenTheResourceHasAMeshPosition(string modelName, float p1, float p2, float p3)
        {
            ModelResource m1 = ScenarioContext.Current.Get<ModelResource>(modelName);
            m1.Mesh.ModelPositionList.Add(new Point3(p1, p2, p3));                
        }



    }
}
