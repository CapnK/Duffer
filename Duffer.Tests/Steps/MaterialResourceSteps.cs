using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TechTalk.SpecFlow;

namespace Duffer.Tests.Steps
{
    [Binding]
    public class MaterialResourceSteps
    {
        [Given(@"the current scene contains a material resource list with a resource named ""(.*)""")]
        public void GivenTheCurrentSceneContainsAMaterialResourceListWithAResourceNamed(string materialName)
        {
            IDTFScene currentScene = ScenarioContext.Current.Get<IDTFScene>();

            MaterialResource m1 = new MaterialResource();
            m1.Name = materialName;

            currentScene.MaterialResources.Add(materialName, m1);

            ScenarioContext.Current.Set<MaterialResource>(m1, materialName);
        }

        [Given(@"the ""(.*)"" resource properties for ambient material are ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void GivenTheResourcePropertiesForAmbientMaterialAreAnd(string materialName, double p1, double p2, double p3)
        {           
            int r = (p1 == 1.0) ? 255 : (int) (p1 * 256);
            int g = (p1 == 1.0) ? 255 : (int)(p1 * 256);
            int b = (p1 == 1.0) ? 255 : (int)(p1 * 256);

            MaterialResource m1 = ScenarioContext.Current.Get<MaterialResource>(materialName);
            m1.MaterialAmbient = Color.FromArgb(r, g, b);
        }

        [Given(@"the ""(.*)"" resource properties for diffuse material are ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void GivenTheResourcePropertiesForDiffuseMaterialAreAnd(string materialName, double p1, double p2, double p3)
        {
            int r = (p1 == 1.0) ? 255 : (int)(p1 * 256);
            int g = (p1 == 1.0) ? 255 : (int)(p1 * 256);
            int b = (p1 == 1.0) ? 255 : (int)(p1 * 256);

            MaterialResource m1 = ScenarioContext.Current.Get<MaterialResource>(materialName);
            m1.MaterialDiffuse = Color.FromArgb(r, g, b);
        }


        [Given(@"the ""(.*)"" resource properties for specular material are ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void GivenTheResourcePropertiesForSpecularMaterialAreAnd(string materialName, double p1, double p2, double p3)
        {
            int r = (p1 == 1.0) ? 255 : (int)(p1 * 256);
            int g = (p1 == 1.0) ? 255 : (int)(p1 * 256);
            int b = (p1 == 1.0) ? 255 : (int)(p1 * 256);

            MaterialResource m1 = ScenarioContext.Current.Get<MaterialResource>(materialName);
            m1.MaterialSpecular = Color.FromArgb(r, g, b);
        }

        [Given(@"the ""(.*)"" resource properties for emissive material are ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void GivenTheResourcePropertiesForEmissiveMaterialAreAnd(string materialName, double p1, double p2, double p3)
        {
            int r = (p1 == 1.0) ? 255 : (int)(p1 * 256);
            int g = (p1 == 1.0) ? 255 : (int)(p1 * 256);
            int b = (p1 == 1.0) ? 255 : (int)(p1 * 256);

            MaterialResource m1 = ScenarioContext.Current.Get<MaterialResource>(materialName);
            m1.MaterialEmmisive = Color.FromArgb(r, g, b);
        }
      
        [Given(@"the ""(.*)"" resource property for material reflectivity is ""(.*)""")]
        public void GivenTheResourcePropertyForMaterialReflectivityIs(string materialName, float p1)
        {
            MaterialResource m1 = ScenarioContext.Current.Get<MaterialResource>(materialName);
            m1.MaterialReflectivity = p1;
        }
        


        [Given(@"the ""(.*)"" resource property for material opacity is ""(.*)""")]
        public void GivenTheResourcePropertyForMaterialOpacityIs(string materialName, float p1)
        {
            MaterialResource m1 = ScenarioContext.Current.Get<MaterialResource>(materialName);
            m1.MaterialOpacity = p1;
        }
    }
}
