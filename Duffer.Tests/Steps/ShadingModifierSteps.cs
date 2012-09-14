using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Duffer.Tests.Steps
{
    [Binding]
    public class ShadingModifierSteps
    {
        [Given(@"I add a shading modifier called ""(.*)"" with one shader list with a item ""(.*)"" in the shader name list")]
        public void GivenIAddAShadingModifierCalledWithOneShaderListWithAItemInTheShaderNameList(string shadingName, string name)
        {

            IDTFScene currentScene = ScenarioContext.Current.Get<IDTFScene>();

            ShadingModifier s = new ShadingModifier()
            {
                ShaderList = new List<Shader> { new Shader() { ShaderNameList = new List<string>() { name } } },
                Name = shadingName
            };

            currentScene.ShadingModifiers.Add(s);

            ScenarioContext.Current.Set<ShadingModifier>(s);
        }

        [Given(@"I add a shading modifier called ""(.*)"" with one shader list with a shader ""(.*)"" and a shader ""(.*)""")]
        public void GivenIAddAShadingModifierCalledWithOneShaderListWithAShaderAndAShader(string shadingName, string p1, string p2)
        {

            IDTFScene currentScene = ScenarioContext.Current.Get<IDTFScene>();

            ShadingModifier s = new ShadingModifier()
            {
                ShaderList = new List<Shader> { 
                    new Shader() { ShaderNameList = new List<string>() { p1 } }, 
                    new Shader() { ShaderNameList = new List<string>() { p2 } } 
                },
                Name = shadingName
            };

            currentScene.ShadingModifiers.Add(s);

            ScenarioContext.Current.Set<ShadingModifier>(s);
        }

    }
}
