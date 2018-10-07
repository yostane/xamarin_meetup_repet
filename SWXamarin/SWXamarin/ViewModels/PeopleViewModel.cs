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
    public class PeopleViewModel
    {

        public ICommand AddPageCommand
        {
            get
            {
                return new Command(ExecuteAddPageCommand);
            }
        }

        string nextPage = "1";
        bool hasMorePages => nextPage != null;
        void ExecuteAddPageCommand()
        {
            if (!hasMorePages)
            {
                return;
            }
            var peopleResponse = sharpTrooperCore.GetAllPeople(nextPage);
            nextPage = peopleResponse.nextPageNo;
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
