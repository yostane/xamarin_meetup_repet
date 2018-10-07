using System;
using RandomListXamarin.ViewModels;
using System.Collections.ObjectModel;
using SharpTrooper.Entities;
using SharpTrooper.Core;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace SWXamarin.ViewModels
{
    public class PeopleViewModel : BaseViewModel
    {
        private ICommand _AddPageCommand = null;
        public ICommand AddPageCommand
        {
            get
            {
                return _AddPageCommand ?? (_AddPageCommand = new Command(ExecuteAddPageCommand));
            }
        }

        string nextPage = "1";
        public bool _hasMorePages = true;
        public bool HasMorePages
        {
            get => _hasMorePages;
            set => SetProperty(ref _hasMorePages, value);
        }
        void ExecuteAddPageCommand()
        {
            if (!HasMorePages)
            {
                return;
            }
            var peopleResponse = sharpTrooperCore.GetAllPeople(nextPage);
            nextPage = peopleResponse.nextPageNo;
            HasMorePages = nextPage != null;
            peopleResponse.results.ForEach(person => People.Add(person));
        }

        public ObservableCollection<People> People { get; set; } = new ObservableCollection<People>();
        SharpTrooperCore sharpTrooperCore = new SharpTrooperCore();

        public PeopleViewModel()
        {
            ExecuteAddPageCommand();
        }
    }
}
