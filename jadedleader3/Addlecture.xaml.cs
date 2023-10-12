using jadedleader3.Classes;
using jadedleader3.FileManager;
using System;
using System.Collections.Generic;
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

namespace jadedleader3
{
    /// <summary>
    /// Interaction logic for Addlecture.xaml
    /// </summary>
    public partial class Addlecture : Window
    {

        IJsonFileHandler<Lectures> _jsonFileHandler = new JsonFileHandler<Lectures>();
        private string path = Configuration.ConfigureLectures();
        public Addlecture()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            List<Lectures> lectures = _jsonFileHandler.DeserializingJsonFileLecture(path);
            Lectures lecture = new Lectures();
            lecture.CourseName = txtCourseName.Text;
            lecture.ModuleCode = txtModCode.Text;
            lecture.ModuleName = txtModName.Text;
            lecture.LecturerName = txtLecName.Text;
            lecture.RoomNumber = txtRoomNum.Text;
            lecture.DayOfTheWeek = txtDayWeek.Text;
            lecture.StartTime = DateTime.Parse(txtStartTime.Text);
            lecture.EndTime = DateTime.Parse(txtEndTime.Text);
        
            lecture.AddLecture(lecture, lectures);
        }

        private void txtCourseName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
