using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Duffer
{
   /// <summary>
   /// The Scene is the root node in the IDTF file, all objects should be aded to the scene, 
   /// and then the scene is exported to a file
   /// </summary>
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


      private Dictionary<string,LightResource>  _lightResources;
      public Dictionary<string,LightResource>  LightResources
      {
         get 
         {
            if (_lightResources == null) { _lightResources = new Dictionary<string, LightResource>(); }
            return _lightResources; 
         }
         set { _lightResources = value; }
      }


      private Dictionary<string, ModelResource> _modelResources;
      public Dictionary<string, ModelResource> ModelResources
      {
         get
         {
            if (_modelResources == null) { _modelResources = new Dictionary<string, ModelResource>(); }
            return _modelResources;
         }
         set { _modelResources = value; }
      }

      private Dictionary<string, ViewResource> _viewResources;
      public Dictionary<string, ViewResource> ViewResources
      {
         get
         {
            if (_viewResources == null) { _viewResources = new Dictionary<string,ViewResource>(); }
            return _viewResources;
         }
         set { _viewResources = value; }
      }

      private Dictionary<string, ShaderResource> _shaderResources;
      public Dictionary<string, ShaderResource> ShaderResources
      {
         get
         {
            if (_shaderResources == null) { _shaderResources = new Dictionary<string, ShaderResource>(); }
            return _shaderResources;
         }
         set { _shaderResources = value; }
      }

      private Dictionary<string, MaterialResource> _materialResources;
      public Dictionary<string, MaterialResource> MaterialResources
      {
          get
          {
              if (_materialResources == null) { _materialResources = new Dictionary<string, MaterialResource>(); }
              return _materialResources;
          }
          set { _materialResources = value; }
      }

      private Dictionary<string, TextureResource> _textureResources;
      public Dictionary<string, TextureResource> TextureResources
      {
          get
          {
              if (_textureResources == null) { _textureResources = new Dictionary<string, TextureResource>(); }
              return _textureResources;
          }
          set { _textureResources = value; }
      }

      private Dictionary<string, MotionResource> _motionResources;
      public Dictionary<string, MotionResource> MotionResources
      {
         get
         {
            if (_motionResources == null) { _motionResources = new Dictionary<string, MotionResource>(); }
            return _motionResources;
         }
         set { _motionResources = value; }
      }

      private List<ShadingModifier> _shadingModifiers;
      public List<ShadingModifier> ShadingModifiers
      {
          get
          {
              if (_shadingModifiers == null) { _shadingModifiers = new List<ShadingModifier>(); }
              return _shadingModifiers;
          }
          set { _shadingModifiers = value; }
      }

      public bool Export(string toFile)
      {
         // The IDTF file contains the following text blocks written in this order
         //<FILE_HEADER>
         //<SCENE_DATA>
         //<FILE_REFERENCE>
         //<NODES>
         //<NODE_RESOURCES>
         //<SHADER_RESOURCES>
         //<MATERIAL_RESOURCES>
         //<TEXTURE_RESOURCES>
         //<MOTION_RESOURCES>
         //<MODIFIERS>

        using (var output = new StreamWriter(toFile))
         {

            //<FILE_HEADER>
            output.WriteLine("FILE_FORMAT \"IDTF\"");
            output.WriteLine("FORMAT_VERSION 100");
            output.WriteLine();

            //<SCENE_DATA>
            //<FILE_REFERENCE>
            // NOT YET IMPLEMENTED

            //<NODES> - groups
            foreach (Group g in this.Groups)
            {
               g.WriteOutput(output);
            }

            //<NODES> - Views
            foreach (View v in this.Views)
            {
               v.WriteOutput(output);
            }

            //<NODES> - Models
            foreach (Model m in this.Models)
            {
               m.WriteOutput(output);
            }


            //<RESOURCE_LISTS> - Light   
            if (this.LightResources.Count() > 0)
            {
                output.WriteLine("RESOURCE_LIST \"LIGHT\" {");
                output.WriteLine("\tRESOURCE_COUNT {0}", this.LightResources.Count().ToString());

                for (int i = 0; i < this.LightResources.Count(); i++)
                {
                    output.WriteLine("\tRESOURCE {0} {{", i.ToString());
                    this.LightResources.ElementAt(i).Value.Export(output);
                    output.WriteLine("\t}");
                }
                output.WriteLine("}");
                output.WriteLine();
            }

            //<RESOURCE_LISTS> - Shader   
            if (this.ShaderResources.Count() > 0)
            {
                output.WriteLine("RESOURCE_LIST \"SHADER\" {");
                output.WriteLine("\tRESOURCE_COUNT {0}", this.ShaderResources.Count().ToString());

                for (int i = 0; i < this.ShaderResources.Count(); i++)
                {
                    output.WriteLine("\tRESOURCE {0} {{", i.ToString());
                    this.ShaderResources.ElementAt(i).Value.Export(output);
                    output.WriteLine("\t}");
                }
                output.WriteLine("}");
                output.WriteLine();
            }

            //<RESOURCE_LISTS> - Material
            if (this.MaterialResources.Count() > 0)
            {
                output.WriteLine("RESOURCE_LIST \"MATERIAL\" {");
                output.WriteLine("\tRESOURCE_COUNT {0}", this.MaterialResources.Count().ToString());

                for (int i = 0; i < this.MaterialResources.Count(); i++)
                {
                    output.WriteLine("\tRESOURCE {0} {{", i.ToString());
                    this.MaterialResources.ElementAt(i).Value.Export(output);
                    output.WriteLine("\t}");
                }
                output.WriteLine("}");
                output.WriteLine();
            }

            //<RESOURCE_LISTS> - Texture
            if (this.TextureResources.Count() > 0)
            {
                output.WriteLine("RESOURCE_LIST \"TEXTURE\" {");
                output.WriteLine("\tRESOURCE_COUNT {0}", this.TextureResources.Count().ToString());

                for (int i = 0; i < this.TextureResources.Count(); i++)
                {
                    output.WriteLine("\tRESOURCE {0} {{", i.ToString());
                    this.TextureResources.ElementAt(i).Value.Export(output);
                    output.WriteLine("\t}");
                }
                output.WriteLine("}");
                output.WriteLine();
            }

            //<RESOURCE_LISTS> - Model   
            if (this.ModelResources.Count() > 0)
            {
                output.WriteLine("RESOURCE_LIST \"MODEL\" {");
                output.WriteLine("\tRESOURCE_COUNT {0}", this.ModelResources.Count().ToString());

                for (int i = 0; i < this.ModelResources.Count(); i++)
                {
                    output.WriteLine("\tRESOURCE {0} {{", i.ToString());
                    this.ModelResources.ElementAt(i).Value.Export(output);
                    output.WriteLine("\t}");
                }
                output.WriteLine("}");
                output.WriteLine();
            }

         

            //<MODIFIER> - Shading
            foreach (ShadingModifier s in this.ShadingModifiers)
            {
                s.Export(output);
            }


            output.Flush();
            output.Close();
         }
         
         return false;
      }

      
   }
}
