//#define COSMOSDEBUG
using System;
using System.IO;
using Cosmos.System;
using Cosmos.IL2CPU.API.Attribs;

namespace Cosmos.System_Plugs.System.IO
{
    // TODO A lot of these methods should be implemented using StreamReader / StreamWriter
    [Plug(Target = typeof(File))]
    public static class FileImpl
    {
        /*
         * Plug needed for the usual issue that Array can not be converted in IEnumerable... it is starting
         * to become annoying :-(
         */
        public static void WriteAllLines(string aFile, string[] contents)
        {
            if (aFile == null)
            {
                throw new ArgumentNullException("path");
            }
            if (contents == null)
            {
                throw new ArgumentNullException("contents");
            }
            if (aFile.Length == 0)
            {
                throw new ArgumentException("Empty", "aFile");
            }

            Global.mFileSystemDebugger.SendInternal("Writing contents");

            using (var xSW = new StreamWriter(aFile))
            {
                foreach (var current in contents)
                    xSW.WriteLine(current);
            }
        }
    }
}
