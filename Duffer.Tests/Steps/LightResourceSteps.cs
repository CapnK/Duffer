using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Duffer.Tests.Steps
{
    [Binding]
    public class LightResourceSteps
    {
        [Given(@"the current scene contains a light resource list with a resource named ""(.*)""")]
        public void GivenTheCurrentSceneContainsALightResourceListWithAResourceNamed(string lightName)
        {
            IDTFScene currentScene = ScenarioContext.Current.Get<IDTFScene>();

            LightResource l1 = new LightResource();
            l1.Name = lightName;

            currentScene.LightResources.Add(lightName, l1);

            ScenarioContext.Current.Set<LightResource>(l1, lightName);
        }

        [Given(@"the ""(.*)"" resource is of type ""(.*)"" and has an intensity of ""(.*)""")]
        public void GivenTheResourceIsOfTypeAndHasAnIntensityOf(string lightName, string p1, float p2)
        {
            LightResource s1 = ScenarioContext.Current.Get<LightResource>(lightName);
            s1.Type = (LightType)Enum.Parse(typeof(LightType), p1, true);
            s1.Intensity = p2;
        }

        [Given(@"the ""(.*)"" resource has a light color of ""(.*)"", ""(.*)"", ""(.*)"" and attenuaion of ""(.*)"", ""(.*)"", ""(.*)""")]
        public void GivenTheResourceHasALightColorOfAndAttenuaionOf(string lightName, double p1, double p2, double p3, float p4, float p5, float p6)
        {
            LightResource s1 = ScenarioContext.Current.Get<LightResource>(lightName);
            
            int r = (p1 == 1.0) ? 255 : (int)(p1 * 256);
            int g = (p2 == 1.0) ? 255 : (int)(p2 * 256);
            int b = (p3 == 1.0) ? 255 : (int)(p3 * 256);

            s1.Color = System.Drawing.Color.FromArgb(r, g, b);
            s1.Attenuation = new Point3(p4, p5, p6);      
        }

    }
}
