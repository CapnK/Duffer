using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Duffer
{
   public class IDTFScene
   {

      private List<View> _views;
      /// <summary>
      /// A list of the View nodes in the scene
      /// </summary>
      public List<View> Views
      {
         get 
         {
            if (_views == null) { _views = new List<View>(); }
            return _views; 
         }
         set { _views = value; }
      }


      private List<Model> _models;
      /// <summary>
      /// A list of the Model nodes in this scene
      /// </summary>
      public List<Model> Models
      {
         get 
         {
            if (_models == null) { _models = new List<Model>(); }
            return _models; 
         }
         set { _models = value; }
      }

      private List<Group> _groups;
      /// <summary>
      /// A list of the group nodes in this scene
      /// </summary>
      public List<Group> Groups
      {
         get 
         {
            if (_groups == null) { _groups = new List<Group>(); }
            return _groups; 
         }
         set { _groups = value; }
      }

      private List<Light> _lights;
      /// <summary>
      /// A list of lights in this scene
      /// </summary>
      public List<Light> Lights
      {
         get 
         {
            if (_lights == null) { _lights = new List<Light>(); }
            return _lights; 
         }
         set { _lights = value; }
      }
      
      


      public ResourceList ModelResources { get; set; }
      public ResourceList ViewResources { get; set; }
      public ResourceList LightResources { get; set; }
      public ResourceList ShaderResources { get; set; }
      public ResourceList MotionResources { get; set; }



      public bool Export(string toFile)
      {
         // The IDTF file contains the following text blocks written in this order
         //<FILE_HEADER>
         //<SCENE_DATA>
         //<FILE_REFERENCE>
         //<NODES>
         //<NODE_RESOURCES>
         //<SHADER_RESOURCES>
         //<MOTION_RESOURCES>
         //<MODIFIERS>

        using (var output = new StreamWriter(toFile))
         {

            // Header
            output.WriteLine("FILE_FORMAT \"IDTF\"");
            output.WriteLine("FORMAT_VERSION 100");
            output.WriteLine();




            
            output.Flush();
            output.Close();
         }
         
         return false;
      }
   }
}
