using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentDemo.WrapTextTest
{
    class FileUtils
    {
        public static string readFileDataAndReplaceSpecialChars(string filePath)
        {
            var input = readFileData(@filePath);
            return input.Replace("\\r", "").Replace("\\t", "").Replace("\\n", "").Replace("\\f", "");
        }

        public static string readFileData(string filePath)
        {
            return System.IO.File.ReadAllText(@filePath);
        }
    }
}
