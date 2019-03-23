namespace WPFAdoNet3EF6Catel.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using System.Threading.Tasks;
    using System.Windows;

    public class MainWindowViewModel : ViewModelBase
    {

        public static readonly PropertyData MyTextProperty =
            RegisterProperty(nameof(MyText), typeof(string), null);
        public Command MyButtonCommand { get; private set; }


        public MainWindowViewModel()
        {
            MyButtonCommand = new Command(OnMyButtonCommandExecute);
        }

        public override string Title { get { return "WPFAdoNet3EF6Catel"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets


        public string MyText
        {
            get { return GetValue<string>(MyTextProperty); }
            set { SetValue(MyTextProperty, value); }
        }

        private void OnMyButtonCommandExecute()
        {
            MessageBox.Show(MyText);
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
