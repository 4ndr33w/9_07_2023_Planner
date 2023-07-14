using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_07_2023_Planner.Data
{
    internal static class TextData
    {
        public static readonly string ApplicationTitle = "Planner Application";
        public static readonly string directory =
           Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
           Properties.Resources.SaveDirectory + "\\";
    }
}
