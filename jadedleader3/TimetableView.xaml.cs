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
using jadedleader3.Classes;
using jadedleader3.FileManager;

namespace jadedleader3
{
    public partial class TimetableView : Window
    {
        IJsonFileHandler<Lectures> _jsonFileHandler = new JsonFileHandler<Lectures>();

        private string path = Configuration.ConfigureLectures();

        public ObservableCollection<Lectures>? LectureSchedule { get; set; }
        public TimetableView()
        {
            InitializeComponent();
            PopulateData();
        }
        
        private void PopulateData()
        {
            DataContext = this;
            LectureSchedule = new ObservableCollection<Lectures>(_jsonFileHandler.DeserializingJsonFileLecture(path));
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
