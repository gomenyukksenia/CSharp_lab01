using KMA.CSharp2024.Gomenyuk_lab01.ViewModels;
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

namespace KMA.CSharp2024.Gomenyuk_lab01
{
    public partial class MainWindow : Window
    {
        public DateTime Birthday
        {
            get
            {
                return (DateTime)BDpicker.SelectedDate;
            }
            set
            {
                BDpicker.SelectedDate = value;
            }
        }

        private BirthdayViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel = new BirthdayViewModel(DateTime.Now);
        }

        private void BDsetter_Click(object sender, RoutedEventArgs e)
        {
            if (BDpicker.SelectedDate == null) return;

            _viewModel.UpdateDate(Birthday);
            UpdateControls();
        }

        private void UpdateControls()
        {
            var prompt = _viewModel.Greating();
            MessageBox.Show(prompt);

            string description = "Your birth day is " + _viewModel.Description();
            description += "\nYour chinese zodiac sign: " + _viewModel.ChinesZodiacName();
            description += "\nYour western zodiac sign: " + _viewModel.WesternZodiacName();

            BDlabel.Text = description;
            AgeView.Text = "You age is " + _viewModel.AgeDescription();
        }
    }
}