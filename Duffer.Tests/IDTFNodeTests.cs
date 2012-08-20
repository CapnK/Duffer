using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duffer;
using NUnit.Framework;

namespace Duffer.Tests
{

   [TestFixture]
   class IDTFNodeTests
   {

      [Test]
      public void should_not_allow_different_resource_type_to_be_assigned()
      {
         Model m = new Model();
         LightResources lr = new LightResources();

         Assert.Throws<InvalidOperationException>(() => m.Resources = lr);

      }

      [Test]
      public void should_not_allow_resource_list_for_group_node()
      {

         Group gn = new Group();
         ShaderResources sr = new ShaderResources();

         Assert.Throws<InvalidOperationException>(() => gn.Resources = sr);

      }

      [Test]
      public void should_all_correct_resources_for_Model_light_and_view_nodes()
      {
         Model m = new Model();
         ModelResources mr = new ModelResources();

         m.Resources = mr;
         Assert.That(m.Resources, Iz.EqualTo(mr));


         Light l = new Light();
         LightResources lr = new LightResources();

         l.Resources = lr;
         Assert.That(l.Resources, Iz.EqualTo(lr));


         View v = new View();
         ViewResources vr = new ViewResources();

         v.Resources = vr;
         Assert.That(v.Resources, Iz.EqualTo(vr));

      }
   }
}
