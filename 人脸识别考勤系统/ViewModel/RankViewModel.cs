using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 人脸识别考勤系统.BLL;
using 人脸识别考勤系统.Helper;
using 人脸识别考勤系统.Model;

namespace 人脸识别考勤系统.ViewModel
{
    public class RankViewModel:ViewModelBase
    {
        EmployeeBLL employeeBLL = new EmployeeBLL();
        private ObservableCollection<Rank> ranks;
        public ObservableCollection<Rank> Ranks    
        {
            get { return ranks; }
            set
            {
                ranks = value;
                RaisePropertyChanged("Ranks");
            }
        }
        public RankViewModel()
        {
            MsgHelper.RefreshDataGridEvent += MsgHelper_RefreshDataGridEvent;
            if (IsInDesignMode)
            {

            }
            else
            {
                Ranks = employeeBLL.GetRanks();
            }
        }

        private void MsgHelper_RefreshDataGridEvent()
        {
            Ranks = employeeBLL.GetRanks();
        }
    }
}
