using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jadedleader3.Classes
{
public class Lectures : INotifyPropertyChanged
    {
        private string _courseName;
        public string CourseName
        {
            get { return _courseName; }
            set
            {
                if (_courseName != value)
                {
                    _courseName = value;
                    OnPropertyChanged(nameof(CourseName));
                }
            }
        }

        private string _moduleCode;
        public string ModuleCode
        {
            get { return _moduleCode; }
            set
            {
                if (_moduleCode != value)
                {
                    _moduleCode = value;
                    OnPropertyChanged(nameof(ModuleCode));
                }
            }
        }

        private string _moduleName;
        public string ModuleName
        {
            get { return _moduleName; }
            set
            {
                if (_moduleName != value)
                {
                    _moduleName = value;
                    OnPropertyChanged(nameof(ModuleName));
                }
            }
        }

        private string _lecturerName;
        public string LecturerName
        {
            get { return _lecturerName; }
            set
            {
                if (_lecturerName != value)
                {
                    _lecturerName = value;
                    OnPropertyChanged(nameof(LecturerName));
                }
            }
        }

        private string _roomNumber;
        public string RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                if (_roomNumber != value)
                {
                    _roomNumber = value;
                    OnPropertyChanged(nameof(RoomNumber));
                }
            }
        }

        private string _dayOfTheWeek;
        public string DayOfTheWeek
        {
            get { return _dayOfTheWeek; }
            set
            {
                if (_dayOfTheWeek != value)
                {
                    _dayOfTheWeek = value;
                    OnPropertyChanged(nameof(DayOfTheWeek));
                }
            }
        }

        private string _startTime;
        public string StartTime
        {
            get { return _startTime; }
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    OnPropertyChanged(nameof(StartTime));
                }
            }
        }

        private string _endTime;
        public string EndTime
        {
            get { return _endTime; }
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    OnPropertyChanged(nameof(EndTime));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

