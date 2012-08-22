using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;

using Duffer.Tests;

namespace Duffer.Tests.Steps
{
   [Binding]
   public class FileSteps
   {
      [When(@"I export the current scene to a file")]
      public void WhenIExportTheCurrentSceneToAFile()
      {
         Duffer.IDTFScene aScene = ScenarioContext.Current.Get<Duffer.IDTFScene>();

         string fileName = System.IO.Path.GetTempFileName();
         
         // export to the file
         aScene.Export(fileName);

         ScenarioContext.Current.Add("currentFile", fileName);

      }

      [Then(@"the contents of the current file should be")]
      public void ThenTheContentsOfTheCurrentFileShouldBe(string multilineText)
      {
         var filename = ScenarioContext.Current.Get<string>("currentFile");

         string[] fileContents = File.ReadAllLines(filename);
         string[] splitSpecflowData = multilineText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

         FileHelpers.AssertStringArrarysEqual(fileContents, splitSpecflowData);

      }



      [AfterScenario]
      public void ScenarioCleanup()
      {
         if (ScenarioContext.Current.ContainsKey("currentFile"))
         {
            var filename = ScenarioContext.Current.Get<string>("currentFile");

            Console.WriteLine(String.Format("Deleting: {0}", filename));
            //System.IO.File.Delete(filename);
         }
      }

   }
}
