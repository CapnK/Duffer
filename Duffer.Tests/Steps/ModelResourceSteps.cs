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

        [Given(@"the current scene contains a model resource list with a ""(.*)"" resource named ""(.*)""")]
        public void GivenTheCurrentSceneContainsAModelResourceListWithAMeshResourceNamed(ModelType type, string modelName)
        {
            IDTFScene currentScene = ScenarioContext.Current.Get<IDTFScene>();

            ModelResource m1 = null;

            switch (type)
            {
                case ModelType.MESH:
                    m1 = new ModelResource(ModelType.MESH);
                    break;
                case ModelType.LINE_SET:
                    m1 = new ModelResource(ModelType.LINE_SET);
                    break;
            }
            
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

        [Given(@"the resource ""(.*)"" contains a line set model")]
        public void GivenTheResourceContainsALineSetModel(string modelName)
        {
            ModelResource m1 = ScenarioContext.Current.Get<ModelResource>(modelName);
            m1.LineSet = new LineSetData();
        }

        [Given(@"the resource ""(.*)"" contains a shading description with id ""(.*)""")]
        public void GivenTheResourceContainsAShadingDescriptionWithId(string modelName, int id)
        {
            ModelResource m1 = ScenarioContext.Current.Get<ModelResource>(modelName);
            ShadingDescription s1 = new ShadingDescription(id);

            if (m1.Type == ModelType.MESH) m1.Mesh.ShadingDescriptionList.Add(s1);
            if (m1.Type == ModelType.LINE_SET) m1.LineSet.ShadingDescriptionList.Add(s1);

            ScenarioContext.Current.Set<ShadingDescription>(s1);
        }
        
        [Given(@"the resource ""(.*)"" contains a shading description with id ""(.*)"" and a texture layer with dimension ""(.*)""")]
        public void GivenTheResourceContainsAShadingDescriptionWithIdAndATextureLayerWithDimension(string modelName, int id, int dim)
        {
            ModelResource m1 = ScenarioContext.Current.Get<ModelResource>(modelName);
            
            ShadingDescription s1 = new ShadingDescription(id);
            s1.TextureCoordDimensionList.Add(dim);

            if (m1.Mesh != null) m1.Mesh.ShadingDescriptionList.Add(s1);
            else m1.LineSet.ShadingDescriptionList.Add(s1);
            
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

        [Given(@"the resource called ""(.*)"" contains lines")]
        public void GivenTheResourceCalledContainsLines(string modelName)
        {
            ModelResource m1 = ScenarioContext.Current.Get<ModelResource>(modelName);

            m1.LineSet.LinePositionList = new List<Int2>(){
                new Int2(0,1),
                new Int2(2,3),
                new Int2(4,5),
                new Int2(6,7),
                new Int2(8,9),
                new Int2(10,11),
                new Int2(12,13),
                new Int2(14,15),
                new Int2(16,17)
            };
            m1.LineSet.LineNormalList = new List<Int2>()
            {
                new Int2(0,0),
                new Int2(1,1),
                new Int2(2,2),
                new Int2(3,3),
                new Int2(3,0),
                new Int2(3,0),
                new Int2(3,0),
                new Int2(3,0),
                new Int2(3,0)
            };
            m1.LineSet.LineShadingList = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            m1.LineSet.ModelPositionList = new List<Point3>()
            {
                new Point3(0,0,0),
                new Point3(0,20,0),
                new Point3(5,0,0),
                new Point3(5,20,0),
                new Point3(10,0,0),
                new Point3(10,20,0),
                new Point3(15,0,0),
                new Point3(15,20,0),
                new Point3(20,0,0),
                new Point3(20,20,0),
                new Point3(-5,5,0),
                new Point3(20,5,0),
                new Point3(-5,10,0),
                new Point3(20,10,0),
                new Point3(-5,15,0),
                new Point3(20,15,0),
                new Point3(-5,20,0),
                new Point3(20,20,0)
            };
            m1.LineSet.ModelNormalList = new List<Point3>()
            {
                new Point3(0,(float)0.5,(float)0.5),
                new Point3(0,(float)0.2,(float)0.8),
                new Point3(0,0,(float)0.99),
                new Point3(0,0,1),
                new Point3(0,0,1),
                new Point3(0,0,1),
                new Point3(0,0,-1),
                new Point3(0,0,-1),
                new Point3(0,0,-1)
            };
            
        }
    }
}
