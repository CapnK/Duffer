using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Duffer
{
    /* Modifiers
    * Possible modifier types: Animation, Shading, Bone weight, Clod, Subdiv, Glyph
    * A IDTF file can only have multiple blocks of each type and a block has the following format:
    * MODIFIER <MODIFIER_TYPE> {
    *   MODIFIER_NAME <string>
    *   MODIFIER_CHAIN_TYPE <string>
    *   <MODIFIER_DATA>
    *   <META_DATA>  
    * }
    * 
    * This file contains the modifier blocks for each of the modifiers types.
    */
    public abstract class Modifier
    {
        public string Name { get; set; }
        public abstract ModifierType ResourceType { get; }
        public abstract void Export(StreamWriter toStream);
    }

    public class ShadingModifier : Modifier
    {
        private List<Shader> _shaderList;
        public List<Shader> ShaderList
        {
            get
            {
                if (this._shaderList == null) this._shaderList = new List<Shader>();
                return this._shaderList;
            }
            set { this._shaderList = value; }
        }

        public override ModifierType ResourceType
        {
            get { return ModifierType.SHADING; }
        }

        public override void Export(StreamWriter toStream)
        {
            toStream.WriteLine(String.Format("MODIFIER \"SHADING\" {{" ));
            toStream.WriteLine(String.Format("\tMODIFIER_NAME \"{0}\"", this.Name));
            toStream.WriteLine(String.Format("\tPARAMETERS {{"));
            ListExtensions.ExportShaderListToStream(this.ShaderList, toStream);
            toStream.WriteLine(String.Format("\t}}"));
            toStream.WriteLine(String.Format("}}"));
            toStream.WriteLine();
        }
    }
}
