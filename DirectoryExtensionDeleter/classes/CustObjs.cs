using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectoryExtensionDeleter.classes.CustObjs
{

    public class BgPassObject_GetFileExtensions
    {
        public string path { get; set; }
    }

    public class BgResultObject_GetFileExtensions
    {
        public List<string> lstFileExtensions { get; set; }
        public string msg { get; set; }
    }

    public class BgPassObject_DeleteFiles
    {
        public string path { get; set; }
        public List<string> lstCheckedExts { get; set; }
        public bool deleteEmptyDirs { get; set; }
    }

    public class BgResultObject_DeleteFiles
    {
        public List<string> lstFilesBeingDeleted { get; set; }
        public List<string> lstDirsBeingDeleted { get; set; }
        public List<string> lstCheckedExts { get; set; }
        public string msg { get; set; }
    }

}
