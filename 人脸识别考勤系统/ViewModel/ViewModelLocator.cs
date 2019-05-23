using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MahApps.Metro.Controls.Dialogs;

namespace 人脸识别考勤系统.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region Code Example
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            #endregion
            SimpleIoc.Default.Register<EmployeeManageViewModel>();
            SimpleIoc.Default.Register<DepartmentManageViewModel>();
            SimpleIoc.Default.Register<NotificationViewModel>();
            SimpleIoc.Default.Register<RankViewModel>();
            SimpleIoc.Default.Register<ClientConfigViewModel>();

        }

        #region 实例化
        public DepartmentManageViewModel DepartmentManage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DepartmentManageViewModel>();
            }
        }
        public EmployeeManageViewModel EmployeeManage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EmployeeManageViewModel>();
            }
        }
        public NotificationViewModel NotificationManage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NotificationViewModel>();
            }
        }
        public RankViewModel RankDisplay
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RankViewModel>();
            }
        }
        public ClientConfigViewModel ClientConfig
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ClientConfigViewModel>();
            }
        }


        #endregion

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}