using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.ComponentModel;
using System;
using RevitAddin.Core.DI;
using RevitAddin.UI.Windows;
using RevitAddin.Core.DI.Interfaces;
using RevitAddin.Core.ViewModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows;

namespace RevitAddin
{
    /// <summary>
    /// Class MainCommand.
    /// Implements the <see cref="RevitAddin.StartUp" />
    /// Implements the <see cref="Autodesk.Revit.UI.IExternalCommand" />
    /// </summary>
    /// <seealso cref="RevitAddin.StartUp" />
    /// <seealso cref="Autodesk.Revit.UI.IExternalCommand" />
    [Transaction(TransactionMode.Manual)]
    public class MainCommand : StartUp, IExternalCommand
    {
        /// <summary>
        /// Excutes the external command within Revit.
        /// </summary>
        /// <param name="commandData">An ExternalCommandData object which contains reference to Application and View
        /// needed by external command.</param>
        /// <param name="message">Error message can be returned by external command. This will be displayed only if the command status
        /// was "Failed".  There is a limit of 1023 characters for this message; strings longer than this will be truncated.</param>
        /// <param name="elements">Element set indicating problem elements to display in the failure dialog.  This will be used
        /// only if the command status was "Failed".</param>
        /// <returns>The result indicates if the execution fails, succeeds, or was canceled by user. If it does not
        /// succeed, Revit will undo any changes made by the external command.</returns>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            ConfigureServices();

            //通过依赖注入容器解析类 `MainWindow`，并调用方法
            var mainWindow = IoC.Default.GetService<IMainWindow>();

            var revitHander = commandData.Application.MainWindowHandle;
            new System.Windows.Interop.WindowInteropHelper((Window)mainWindow).Owner = revitHander;
            mainWindow.Show();

            return Result.Succeeded;
        }
    }
}