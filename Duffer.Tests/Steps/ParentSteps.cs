using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Duffer.Tests.Steps
{
   [Binding]
   public class ParentSteps
   {
      [Given(@"the parent named ""(.*)"" has an identity transform matrix")]
      public void GivenTheParentNamedHasAnIdentityTransformMatrix(string parentName)
      {
         Parent p = ScenarioContext.Current.Get<Parent>(parentName);

         p.Transform = new Transform4x4();
      }

   }
}
