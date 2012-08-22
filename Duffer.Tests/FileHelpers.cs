using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace Duffer.Tests
{
   class FileHelpers
   {

      /// <summary>
      /// Check wether two files are equal by comparing all bytes
      /// Note: Text files may appear different if one of them is missing the Byte Order Mark
      /// </summary>
      /// <param name="path1"></param>
      /// <param name="path2"></param>
      /// <returns></returns>
      internal static bool AreFileEquals(string path1, string path2)
      {
         byte[] file1 = File.ReadAllBytes(path1);
         byte[] file2 = File.ReadAllBytes(path2);
         if (file1.Length == file2.Length)
         {
            for (int i = 0; i < file1.Length; i++)
            {
               if (file1[i] != file2[i])
               {
                  return false;
               }
            }
            return true;
         }
         return false;
      }

      /// <summary>
      /// Compare wether two files are equal, using text comparisions
      /// </summary>
      /// <param name="path1"></param>
      /// <param name="path2"></param>
      /// <returns></returns>
      internal static bool AreTextFilesEquals(string path1, string path2)
      {

         string[] file1 = File.ReadAllLines(path1);
         string[] file2 = File.ReadAllLines(path2);
         return AreStringArrarysEqual(file1, file2);
      }

      internal static bool AreStringArrarysEqual(string[] strings1, string[] strings2)
      {
         if (strings1.Length == strings2.Length)
         {
            for (int i = 0; i < strings1.Length; i++)
            {
               if (strings1[i] != strings2[i])
               {
                  return false;
               }
            }
            return true;
         }
         return false;
      }

      /// <summary>
      /// Compare a file and a specflow example string.
      /// Ignores newline differences!
      /// </summary>
      internal static bool IsTextFileEqualToSpecFlowMultilineString(string filepath, string specflowData)
      {
         string[] fileContents = File.ReadAllLines(filepath);
         string[] splitSpecflowData = specflowData.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
         return AreStringArrarysEqual(fileContents, splitSpecflowData);
      }

      internal static void AssertTextFileIsEqualToSpecFlowMultilineString(string filepath, string specflowData)
      {
         string[] fileContents = File.ReadAllLines(filepath);
         string[] splitSpecflowData = specflowData.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
         AssertStringArrarysEqual(fileContents, splitSpecflowData);
      }

      internal static void AssertStringArrarysEqual(string[] strings1, string[] strings2)
      {
         Assert.That(strings1.Length, Iz.EqualTo(strings2.Length), "The number of strings in the array don't match");

         for (int i = 0; i < strings1.Length; i++)
         {
            Assert.That(strings1[i], Iz.EqualTo(strings2[i]));
         }
            
      }
   }
}
