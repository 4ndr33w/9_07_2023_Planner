using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9_07_2023_Planner.Languages;

namespace _9_07_2023_Planner.Data
{
    internal static class TextData
    {
        public static readonly string ApplicationTitle = Lang.ApplicationTitle;
        public static readonly string directory =
           Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
           Properties.Resources.SaveDirectory + "\\";

        public static readonly string AddGroupButton = Lang.AddGroupButton;
        public static readonly string Info = Lang.Info;
        public static readonly string Menu= Lang.Menu;
        public static readonly string Cancel = Lang.Cancel;
        public static readonly string Default = Lang.Default;
        public static readonly string AddGroupWindowText_ChooseColor = Lang.AddGroupWindowText_ChooseColor;
        public static readonly string AddGroupWindowText_EnterGroupName = Lang.AddGroupWindowText_EnterGroupName;
    }
}
