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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Net.Mail;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace jadedleader3
{
    public class Lectures
    {
        public string? CourseName { get; set; }
        public string? ModuleCode { get; set; }
        public string? ModuleName { get; set; }
        public string? LecturerName { get; set; }
        public string? RoomNumber { get; set; }
        public string[] DayOfTheWeek { get; set; } = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public List<Lectures> lecturesList;

        public void AddLecture(Lectures lecture)
        {
            foreach (Lectures currentLectures in lecturesList)
            {
                if (currentLectures.RoomNumber == lecture.RoomNumber && currentLectures.RoomNumber == lecture.RoomNumber && lecture.StartTime >= currentLectures.StartTime && lecture.EndTime <= currentLectures.EndTime)
                {
                    MessageBox.Show("This room is already reserved for another lecture at this time.");
                }
                else if(VerifyLecture(lecture))
                {
                    lecturesList.Add(lecture);
                    MessageBox.Show("Lecture successfully added");
                    
                }
                else
                {
                    MessageBox.Show("Invalid data input.");
                }
            }

        }

        private bool VerifyLecture(Lectures lecture)
        {
            if (string.IsNullOrWhiteSpace(lecture.CourseName) ||
                string.IsNullOrWhiteSpace(lecture.ModuleCode) ||
                string.IsNullOrWhiteSpace(lecture.ModuleName) ||
                string.IsNullOrWhiteSpace(lecture.LecturerName) ||
                string.IsNullOrWhiteSpace(lecture.RoomNumber))
            {
                return false;
            }
            else if(VerifyTime(lecture))
            {
                return true;
            }

            return false;
        }

        private static bool VerifyTime(Lectures lecture)
        {
                DateTime minTime = DateTime.Parse("09:00 AM");
                DateTime maxTime = DateTime.Parse("05:00 PM");
                return lecture.StartTime >= minTime && lecture.EndTime <= maxTime;
        }


        public void DeleteLecture(Lectures lectureToBeDeleted)
        {
            //if(user.PermissionCheck)
            {
                MessageBoxResult check = MessageBox.Show("Are you sure you want to delete this lecture", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (check == MessageBoxResult.Yes)
                {
                    lecturesList.Remove(lectureToBeDeleted);
                    
                }
            }
        }

    }
}