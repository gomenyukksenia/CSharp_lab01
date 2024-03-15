using KMA.CSharp2024.Gomenyuk_lab01.Models;
using KMA.CSharp2024.Gomenyuk_lab01.ViewModels;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace KMA.CSharp2024.Gomenyuk_lab01
{
    public partial class MainWindow : Window
    {
        private DateTime PersonBirthday
        {
            get
            {
                return (DateTime)BDpicker.SelectedDate;
            }
        }

        private string PersonFirstName
        {
            get
            {
                return FName.Text;
            }
        }

        private string PersonSecondName
        {
            get
            {
                return SName.Text;
            }
        }

        private string PersonEmail
        {
            get
            {
                return Email.Text;
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            Procider.IsEnabled = false;
        }

        private void BDsetter_Click(object sender, RoutedEventArgs e)
        {
        }

        private void UpdateControls(PersonViewModel vm)
        {
            IsAdult.Text = "Adult or child: " + vm.AgeDescription;
            SunSign.Text = "Sun Sign: " + vm.sunSignName;
            ChSign.Text = "Chinese Sign: " + vm.chineseSignName;
            IsBirthdayToday.Text = "BD: " + vm.IsBirthdayToday;
        }

        private async void Procider_Click(object sender, RoutedEventArgs e)
        {
            string fName = PersonFirstName;
            string sName = PersonSecondName;
            string email = PersonEmail;
            DateTime bd = PersonBirthday;

            Procider.IsEnabled = false;
            IsAdult.Text = "Processing...";
            SunSign.Text = "Processing...";
            ChSign.Text = "Processing...";

            PersonViewModel vm = await Task.Run(() => new PersonViewModel(fName, sName, email, bd));
            await Task.Delay(2000); // emulate calculation here...

            Procider.IsEnabled = true;

            UpdateControls(vm);
        }
        private void textChanged(object sender, EventArgs e)
        {
            string fName = PersonFirstName;
            string sName = PersonSecondName;
            string email = PersonEmail;

            Procider.IsEnabled = PersonViewModel.isNameValid(fName) 
                && PersonViewModel.isNameValid(sName)
                && PersonViewModel.isEmailValid(email)
                && BDpicker.SelectedDate != null;
        }
    }
}