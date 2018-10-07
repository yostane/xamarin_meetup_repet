using System;
using RandomListXamarin.ViewModels;
using System.Collections.ObjectModel;
using SharpTrooper.Entities;
using SharpTrooper.Core;
using System.Threading.Tasks;
namespace SWXamarin.ViewModels
{
    public class PeopleViewModel
    {
        public ObservableCollection<People> People { get; set; } = new ObservableCollection<People>();
        SharpTrooperCore sharpTrooperCore = new SharpTrooperCore();

        public PeopleViewModel()
        {
            sharpTrooperCore.GetAllPeople().results.ForEach(person => People.Add(person));
        }
    }
}
