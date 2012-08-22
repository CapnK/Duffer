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

      [Given(@"the parent named ""(.*)"" has an translation only transform matrix of ""(\d*)"", ""(\d*), ""(\d*)""")]
      public void GivenTheParentNamedBox_GroupHasAnTranslationOnlyTransformMatrixOfXYZ(string parentName, int xDisp, int yDisp, int zDisp)
      {
         Parent p = ScenarioContext.Current.Get<Parent>(parentName);

         p.Transform = new Transform4x4();

         p.Transform.c3r0 = xDisp;
         p.Transform.c3r1 = yDisp;
         p.Transform.c3r2 = zDisp;
      }


   }
}
