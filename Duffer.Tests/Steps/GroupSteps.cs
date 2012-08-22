using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Duffer.Tests.Steps
{
   [Binding]
   public class GroupSteps
   {
      [Given(@"the current scene contains a group named ""(\w*)""")]
      public void GivenTheCurrentSceneContainsASingleGroupNamedGroup1(string groupName)
      {
         IDTFScene currentScene = ScenarioContext.Current.Get<IDTFScene>();

         Group g1 = new Group();
         g1.Name = groupName;

         currentScene.Groups.Add(g1);

         // Also add v1 to the scenario so we can find it
         ScenarioContext.Current.Set<Group>(g1, groupName);
      }

      [Given(@"the group named ""(\w*)"" has a parent called ""(\w*)""")]
      public void GivenTheGroupNamedGroup1HasOneParentCalledParent1(string groupName, string parentName)
      {
         Group g1 = ScenarioContext.Current.Get<Group>(groupName);

         Parent p1 = new Parent(parentName);

         g1.Parents.Add(p1);

         //also add the parent to the ScenarioContext to get it later
         ScenarioContext.Current.Set<Parent>(p1, parentName);
      }




   }
}
