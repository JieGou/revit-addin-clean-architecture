using RevitAddin.Core.DI.Interfaces;

namespace RevitAddin.Core.ViewModels
{
    /// <summary>
    /// Class MainWindowViewModel
    /// </summary>
    /// <seealso cref="RevitAddin.Core.ViewModels.ViewModelBase" />
    /// <seealso cref="RevitAddin.Core.DI.Interfaces.IMainWindowViewModel" />
    public partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private string bytes = "100000";
        private string category = "类型";

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="instanceCategories">The instance categories.</param>
        public MainWindowViewModel()
        {
        }

        public string Category
        {
            get => category;
            set
            {
                category = value;
                OnPropertyChanged();
            }
        }

        public string Bytes
        {
            get => bytes; set
            {
                bytes = value;
                OnPropertyChanged();
            }
        }

        #endregion Constructor
    }
}