using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duffer;
using NUnit.Framework;
using System.IO;
using Moq;

namespace Duffer.Tests.UnitTests
{

   [TestFixture]
   class ExtensionMethodTests
   {

      [Test]
      public void should_output_black_in_ITDF_Format()
      {
         string blackString = System.Drawing.Color.Black.ToIDTFString();

         Assert.That(blackString, Iz.EqualTo("0.000000 0.000000 0.000000 1.000000"));
      }

      [Test]
      public void should_output_white_in_ITDF_Format()
      {
         string colorString = System.Drawing.Color.White.ToIDTFString();

         Assert.That(colorString, Iz.EqualTo("1.000000 1.000000 1.000000 1.000000"));
      }

      [Test]
      public void should_output_50percentgrey_in_ITDF_Format()
      {
         string colorString = System.Drawing.Color.Gray.ToIDTFString();

         Assert.That(colorString, Iz.EqualTo("0.500000 0.500000 0.500000 1.000000"));
      }

      [Test]
      public void should_output_red_with_50percentalpha_in_ITDF_Format()
      {
         System.Drawing.Color alphaRed = System.Drawing.Color.FromArgb(128, 255, 0, 0);

         string colorString = alphaRed.ToIDTFString();

         Assert.That(colorString, Iz.EqualTo("1.000000 0.000000 0.000000 0.500000"));
      }

   }
}