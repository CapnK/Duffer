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

        [Given(@"the metadata for the model named ""(.*)"" has the following entries")]
        public void GivenTheMetadataForHasTheFollowingEntries(string modelName, Table table)
        {
            //ScenarioContext.Current.Pending();

            Model model = ScenarioContext.Current.Get<Model>(modelName);

            //Read the test data out of the table
            for (int i = 0; i < table.Rows.Count; i++)
            {
                TableRow row = table.Rows[i];
                model.MetaData.GenericMetaData.Add(new StringMetaDataItem(row[0], row[1]));
            }


        }

        [Given(@"the metadata for the model named ""(.*)"" has a RHAdobeMeta entry with the following values")]
        public void GivenTheMetadataForHasARHAdobeMetaEntryWithTheFollowingValues(string modelName, Table table)
        {
            //ScenarioContext.Current.Pending();

            Model model = ScenarioContext.Current.Get<Model>(modelName);
            
            //Read the test data out of the table
            for (int i = 0; i < table.Rows.Count; i++)
            {
                TableRow row = table.Rows[i];
                model.MetaData.RHAdobeMetaData.Add(row[0], row[1]);
            }
        }


    }
}
