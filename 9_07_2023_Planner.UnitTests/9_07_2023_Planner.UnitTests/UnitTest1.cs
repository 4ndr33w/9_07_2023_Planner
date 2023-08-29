using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _9_07_2023_Planner;
using _9_07_2023_Planner.ViewModels;

namespace _9_07_2023_Planner.UnitTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        _9_07_2023_Planner.ViewModels.MainWindowViewModel mainVM = new _9_07_2023_Planner.ViewModels.MainWindowViewModel();
        [TestMethod]
        public void ShowExpiredTasksButtonTitle_CheckFillingTitle_ExpiredTasksTitle()
        {
            //mainVM.InformativeButtonTitles();

            Assert.AreEqual("Expired Tasks:", mainVM.ShowExpiredTasksButton.Title);
        }

        [TestMethod]
        public void ShowCompletedTasksButtonTitle_CheckFillingTitle_CompletedTasksTitle()
        {
            Assert.AreEqual("Completed Tasks:", mainVM.ShowCompletedTasksButton.Title);
        }

        [TestMethod]
        public void FullTaskList_CheckFillingDefaultTaskList_HeaderOfLastTask()
        {
            Assert.AreEqual("Sample Header 5", mainVM.FullTaskList[mainVM.FullTaskList.Count - 1].Header);
        }
        [TestMethod]
        public void FullTaskList_CheckIsNullOrNot_IsNotNull()
        {
            Assert.IsNotNull(mainVM.FullTaskList);
        }
    }
}
