using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Duffer
{
    public class Shader
    {
        private List<string> _shaderNameList;
        public List<string> ShaderNameList
        {
            get
            {
                if (this._shaderNameList == null) this._shaderNameList = new List<string>();
                return this._shaderNameList;
            }
            set { this._shaderNameList = value; }

        }
    }
}
