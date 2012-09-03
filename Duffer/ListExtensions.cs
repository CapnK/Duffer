using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Duffer
{
    static class ListExtensions
    {
        // These are hard to do as extension methods, because the compiler starts complaining
        // And I wanted them to be indepedently unit-testable, so this code is not just
        // dropped into the location where this method gets called

        internal static void ExportParentListToStream(IList<Parent> list, StreamWriter toStream)
        {
            toStream.WriteLine("\tPARENT_LIST {");
            toStream.WriteLine(String.Format("\t\tPARENT_COUNT {0}", list.Count));
            for (int i = 0; i < list.Count; i++)
            {
                //note: double {{ wil output as single { in string.format
                toStream.WriteLine(String.Format("\t\tPARENT {0} {{", i));
                list.ElementAt(i).Export(toStream);
                toStream.WriteLine("\t\t}");
            }

            toStream.WriteLine("\t}");
        }


        internal static void ExportShadingListToStream(IList<ShadingDescription> list, StreamWriter toStream)
        {
            toStream.WriteLine("\t\t\tMODEL_SHADING_DESCRIPTION_LIST {");
            for (int i = 0; i < list.Count; i++)
            {
                //note: double {{ wil output as single { in string.format
                toStream.WriteLine(String.Format("\t\t\t\tSHADING_DESCRIPTION {0} {{", i));
                list.ElementAt(i).Export(toStream);
                toStream.WriteLine("\t\t\t\t}");
            }

            toStream.WriteLine("\t\t\t}");
        }


        internal static void ExportTextureCoordListToStream(IList<TextureCoordDimension> list, StreamWriter toStream)
        {

            toStream.WriteLine("\t\t\t\t\tTEXTURE_COORD_DIMENSION_LIST {");
            for (int i = 0; i < list.Count; i++)
            {
                list.ElementAt(i).Export(toStream);
            }

            toStream.WriteLine("\t\t\t\t\t}");
        }
    }
}
