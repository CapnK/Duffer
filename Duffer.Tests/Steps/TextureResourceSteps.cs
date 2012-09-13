using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Duffer.Tests.Steps
{
    [Binding]
    public class TextureResourceSteps
    {
        [Given(@"the current scene contains a texture resource named ""(.*)"" with path ""(.*)""")]
        public void GivenTheCurrentSceneContainsATextureResourceNamedWithPath(string textureName, string path)
        {
            IDTFScene currentScene = ScenarioContext.Current.Get<IDTFScene>();

            TextureResource t1 = new TextureResource();
            t1.Name = textureName;
            t1.TexturePath = path;

            currentScene.TextureResources.Add(textureName, t1);
            ScenarioContext.Current.Set<TextureResource>(t1, textureName);
        }

        [Given(@"the texture resource ""(.*)"" has image type ""(.*)""")]
        public void GivenTheTextureResourceHasImageType(string textureName, string p1)
        {
            TextureResource t1 = ScenarioContext.Current.Get<TextureResource>(textureName);
            t1.ImageType = (TextureImageType)Enum.Parse(typeof(TextureImageType), p1, true);
            t1.ImageType = (TextureImageType)Enum.Parse(typeof(TextureImageType), p1, true);
        }

        [Given(@"the texture resource ""(.*)"" contains an image format list: compression type is ""(.*)"" and bleu, green and red channel is ""(.*)"", ""(.*)"", ""(.*)""")]
        public void GivenTheTextureResourceContainsAnImageFormatListCompressionTypeIsAndBleuGreenAndRedChannelIs(string textureName, string p1, bool p2, bool p3, bool p4)
        {
            TextureResource t1 = ScenarioContext.Current.Get<TextureResource>(textureName);

            TextureImageFormat f1 = new TextureImageFormat();
            f1.Type = (CompressionType)Enum.Parse(typeof(CompressionType), p1, true);
            f1.BlueChannel = p2;
            f1.GreenChannel = p3;
            f1.RedChannel = p4;

            t1.TexureImageFormatList.Add(f1);
            ScenarioContext.Current.Set<TextureImageFormat>(f1);
        }
        [Given(@"the texture resource ""(.*)"" contains a second image format list: compression type is ""(.*)"" and alpha channel is ""(.*)""")]
        public void GivenTheTextureResourceContainsASecondImageFormatListCompressionTypeIsAndAlphaChannelIs(string textureName, string p1, bool p2)
        {
            TextureResource t1 = ScenarioContext.Current.Get<TextureResource>(textureName);

            TextureImageFormat f1 = new TextureImageFormat();
            f1.Type = (CompressionType)Enum.Parse(typeof(CompressionType), p1, true);
            f1.AlphaChannel = p2;

            t1.TexureImageFormatList.Add(f1);
            ScenarioContext.Current.Set<TextureImageFormat>(f1);
        }

    }
}
