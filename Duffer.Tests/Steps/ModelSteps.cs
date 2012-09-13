using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Duffer.Tests.Steps
{
   [Binding]
   public class ModelSteps
   {
      [Given(@"the current scene contains a model named ""(.*)""")]
      public void GivenTheCurrentSceneContainsAModelNamedBox01(string modelName)
      {
         IDTFScene currentScene = ScenarioContext.Current.Get<IDTFScene>();

         Model m1 = new Model();
         m1.Name = modelName;

         currentScene.Models.Add(m1);

         // Also add v1 to the scenario so we can find it
         ScenarioContext.Current.Set<Model>(m1, modelName);
      }


      [Given(@"the model named ""(.*)"" has a parent called ""(.*)""")]
      public void GivenTheModelNamedXHasAParentCalledY(string modelName, string parentName)
      {
         Model v1 = ScenarioContext.Current.Get<Model>(modelName);

         Parent p1 = new Parent(parentName);

         v1.Parents.Add(p1);

         //also add the parent to the ScenarioContext to get it later
         ScenarioContext.Current.Set<Parent>(p1, parentName);
      }

      [Given(@"the model named ""(.*)"" has a resource called ""(.*)""")]
      public void GivenTheModelNamedBox01HasAResourceCalledBoxModel(string modelName, string resourceName)
      {
         Model m1 = ScenarioContext.Current.Get<Model>(modelName);

         ModelResource r1 = new ModelResource();
         r1.Name = resourceName;

         m1.Resource = r1;

         //also add the ModelResource to the ScenarioContext to get it later
         ScenarioContext.Current.Set<ModelResource>(r1, resourceName);  
      }


   }
}
