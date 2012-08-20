using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Duffer.Tests.Steps
{
   [Binding]
   public class SceneSteps
   {

      [Given(@"I have a new current scene")]
      public void GivenIHaveANewScene()
      {
         Duffer.IDTFScene aScene = new IDTFScene();
         ScenarioContext.Current.Set <Duffer.IDTFScene>(aScene);

      }


   }
}
