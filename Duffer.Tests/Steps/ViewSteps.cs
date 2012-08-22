using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Duffer.Tests.Steps
{
   [Binding]
   public class ViewSteps
   {
      [Given(@"the current scene contains a view named ""(.*)""")]
      public void GivenTheCurrentSceneContainsAViewNamed(string viewName)
      {
         IDTFScene currentScene = ScenarioContext.Current.Get<IDTFScene>();

         View v1 = new View();
         v1.Name = viewName;

         currentScene.Views.Add(v1);

         // Also add v1 to the scenario so we can find it
         ScenarioContext.Current.Set<View>(v1, viewName);
      }

      [Given(@"the view named ""(.*)"" has a parent called ""(.*)""")]
      public void GivenTheViewNamedHasAParentCalled(string viewName, string parentName)
      {
         View v1 = ScenarioContext.Current.Get<View>(viewName);

         Parent p1 = new Parent(parentName);

         v1.Parents.Add(p1);

         //also add the parent to the ScenarioContext to get it later
         ScenarioContext.Current.Set<Parent>(p1, parentName);
      }
   }
}
