using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using jadedleader3.Classes;
using jadedleader3.FileManager;

namespace jadedleader3
{
    public partial class TimetableView : Window
    {
        IJsonFileHandler<Lectures> _jsonFileHandler = new JsonFileHandler<Lectures>();
        private string path = Configuration.ConfigureLectures();

        public ObservableCollection<Lectures>? LectureSchedule { get; set; }
        private ObservableCollection<Lectures>? originalLectureData { get; set; }
        public TimetableView()
        {
            InitializeComponent();
            PopulateData();
            
        }

        private void PopulateData()
        {
            DataContext = this;
            LectureSchedule = new ObservableCollection<Lectures>(_jsonFileHandler.DeserializingJsonFileLecture(path));
            originalLectureData = new ObservableCollection<Lectures>(LectureSchedule.Select(lecture => new Lectures
            {
                CourseName = lecture.CourseName,
                ModuleCode = lecture.ModuleCode,
                ModuleName = lecture.ModuleName,
                LecturerName = lecture.LecturerName,
                RoomNumber = lecture.RoomNumber,
                DayOfTheWeek = lecture.DayOfTheWeek,
                StartTime = lecture.StartTime,
                EndTime = lecture.EndTime
            }));
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult check = MessageBox.Show("Are you sure you want to edit this lecture", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (check == MessageBoxResult.Yes)
            {
                if (timetableDataGrid.SelectedItem is Lectures selectedLecture)
                {
                    Lectures originalLecture = FindOriginalLecture(selectedLecture);
                    if (originalLecture != null)
                    {

                        if (HasLectureChanged(originalLecture, selectedLecture))
                        {
                            _jsonFileHandler.EditLecture(originalLecture, selectedLecture, path);
                        }
                    }
                }
            }
        }

        private Lectures FindOriginalLecture(Lectures editedLecture)
        {
            foreach (Lectures originalLecture in originalLectureData)
            {
                if (originalLecture.CourseName == editedLecture.CourseName &&
                    originalLecture.ModuleCode == editedLecture.ModuleCode &&
                    originalLecture.ModuleName == editedLecture.ModuleName)
                {
                    return originalLecture;
                }
            }
            return null; 
        }

        private bool HasLectureChanged(Lectures originalLecture, Lectures editedLecture)
        {

            bool courseNameChanged = originalLecture.CourseName != editedLecture.CourseName;
            bool moduleCodeChanged = originalLecture.ModuleCode != editedLecture.ModuleCode;
            bool moduleNameChanged = originalLecture.ModuleName != editedLecture.ModuleName;
            bool lecturerNameChanged = originalLecture.LecturerName != editedLecture.LecturerName;
            bool roomNumberChanged = originalLecture.RoomNumber != editedLecture.RoomNumber;
            bool dayOfTheWeekChanged = originalLecture.DayOfTheWeek != editedLecture.DayOfTheWeek;
            bool startTimeChanged = originalLecture.StartTime != editedLecture.StartTime;
            bool endTimeChanged = originalLecture.EndTime != editedLecture.EndTime;


            return courseNameChanged || moduleCodeChanged || moduleNameChanged ||
                   lecturerNameChanged || roomNumberChanged || dayOfTheWeekChanged ||
                   startTimeChanged || endTimeChanged;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult check = MessageBox.Show("Are you sure you want to delete this lecture", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (check == MessageBoxResult.Yes)
            {
                if (timetableDataGrid.SelectedItem is Lectures selectedLecture)
                {
                    _jsonFileHandler.DeleteFromJSON(path, selectedLecture);
                    LectureSchedule.Remove(selectedLecture);
                    timetableDataGrid.Items.Refresh();
                }
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow therealmainwindow = new MainWindow();

            therealmainwindow.Show();

            this.Close();
        }
    }
}
