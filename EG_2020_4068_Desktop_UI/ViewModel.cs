using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EG_2020_4068_Desktop_UI
{
    public partial class ViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Person> students;

        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public string firstName;

        [ObservableProperty]
        public string lastName;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string dateOfBirth;

        [ObservableProperty]
        public double gpaValue;

        [ObservableProperty]
        public string image;

        [RelayCommand]
        public void InsertPerson()
        {
            Person p = new Person() // store in the data person class
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                DateOfBirth = dateOfBirth,
                GpaValue = gpaValue,
                Image = image
            };

            using (var db = new PersonContext())
            {
                db.Persons.Add(p);
                db.SaveChanges();
            }

            LoadPerson();
        }

        public void LoadPerson() 
        {
            using (var db = new PersonContext())
            {
                var list = db.Persons.OrderBy(p => p.Id).ToList();
                Students = new ObservableCollection<Person>(list);
            }
        }


        [ObservableProperty]
        public Person selectedstudent = null;


        [RelayCommand]
        public void DeleteStudent()
        {
            using (var db = new PersonContext())
            {
                if (selectedstudent != null)
                {
                    db.Persons.Remove(selectedstudent);
                    db.SaveChanges();
                }
                LoadPerson();
            }
                
        }
        

        [RelayCommand]
        public void EditStudent()
        {
            if (selectedstudent != null)
            {
                EditStudentWindow editStudentWindow = new EditStudentWindow(selectedstudent);
                editStudentWindow.Show();
            }
        }



        public ViewModel()
        {
            LoadPerson();
            
        }
    }
}
