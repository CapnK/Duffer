using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Duffer.Tests.Steps
{
    [Binding]
    public class MetaDataSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"the metadata for ""(.*)"" has the following entries")]
        public void GivenTheMetadataForHasTheFollowingEntries(string p0, Table table)
        {
            ScenarioContext.Current.Pending();

        }

        [Given(@"the metadata for ""(.*)"" has a RHAdobeMeta entry with the following values")]
        public void GivenTheMetadataForHasARHAdobeMetaEntryWithTheFollowingValues(string p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }


    }
}
