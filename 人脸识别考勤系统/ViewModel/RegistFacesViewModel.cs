using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 人脸识别考勤系统.ViewModel
{
    public class RegistFacesViewModel:ViewModelBase
    {
        private int processNum;
        public int ID { get; set; }
        public int ProcessNum
        {
            get { return processNum; }
            set
            {
                processNum = value;
                RaisePropertyChanged("ProcessNum");
            }
        }
        public RegistFacesViewModel(int eid)
        {
            this.ID = eid;
        }
    }
}
