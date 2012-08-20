﻿using System;
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
