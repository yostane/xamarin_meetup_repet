# xamarin_meetup_repet

- Utilisation de [star wars API](https://www.swapi.co/) via [SharpTrooper](https://github.com/olcay/SharpTrooper)]

## Etape 1 sur PC

- Créer un projet Xamarin
- Télécharger [https://github.com/olcay/SharpTrooper](https://github.com/olcay/SharpTrooper)
- Créer un dossier Helpers -> SharpTrooper, puis copier les dossiers "Core" et "Entities" de SharpTrooper
- Ajouter le nuget "json.NET" (edité par "newtonsoft.json") car utilisé par SharpTrooper
- Créer les dossier Views et ViewModels
- Créer une view et une classe view model

## Etape 2 sur mac

- Mettre ce code dans le view model

```c#
public ObservableCollection<People> People { get; set; } = new ObservableCollection<People>();
SharpTrooperCore sharpTrooperCore = new SharpTrooperCore();

public PeopleViewModel()
{
	sharpTrooperCore.GetAllPeople().results.ForEach(person => People.Add(person));
}
```

- Dans la vue

```c#
public PeopleListViewPage()
{
	InitializeComponent();
	BindingContext = new PeopleViewModel();
}
async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
{
	if (e.Item == null)
		return;
    await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
}
```

- Dans le XAML

```xml
<ListView.ItemTemplate>
    <DataTemplate>
        <TextCell Text="{Binding name}" />
    </DataTemplate>
</ListView.ItemTemplate>
```

- Supprimer la vue par défaut et la changer dans App.xaml.cs
- Ajouter la pagination commit bouton pagination "2d92d0ac37c15b26fd9bac8d750dc9d2b064aa05"
  - Ajout d'un bouton dans le <ListView.Footer>
  - Création d'une commande qui charge la prochaine page

```xml
<ListView.Footer>
    <Button Command="{x:Binding AddPageCommand}" Text="Ajouter une page"/>
</ListView.Footer>
```

```cs
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
```

- Ajouter binding sur le bouton pagination pour le masquer 8b0b74814fa92fc7af08d50416240dc727909ba5
  - Ajouter le baseviewmodel

```cs
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
```

```xml
<ListView.Footer>
    <Button Command="{x:Binding AddPageCommand}" Text="Ajouter une page" IsVisible="{x:Binding HasMorePages}" />
</ListView.Footer>
```

## Etape 3: + de résultats en async

- Dans le view model: mettre la commande en async
- Dans le view model: ajouter un IsLoading
- Dans le view model: Supprimer le code du constructeur
- Dans le xaml: mettre une grid dans le footer
- Dans le codebehind: Executer la commande dans le OnAppearing

## Etape 4

- Ajouter le paquet nuget: mvvmlight.xamarinforms
- Créer service locator + navigation service. Commit: 'Ajouter Locator + Navigation service"
- Créer la vue détail avec le binding et son view model
- Puis renseigner les vue dans le service locator. Commit: Ajout dans le locator + appel de ma la vue
- Commit d'après qui initialise la navigationService dans la class App et gère le clic sans passer par une commande

## Etape 5

- Passer par une [commande au lieu de l'event handler](https://docs.microsoft.com/fr-fr/xamarin/xamarin-forms/app-fundamentals/behaviors/reusable/event-to-command-behavior)
  - [Téléchargement du zip et copie des dossiers Converters et Bahaviors](https://developer.xamarin.com/samples/xamarin-forms/behaviors/eventtocommandbehavior/)
- On peut aussi passer par une librairie externe [Xamarin.Forms.BehaviorsPack](https://github.com/nuitsjp/Xamarin.Forms.BehaviorsPack).

## Etape 6: EF core

- Ajouter le package: Microsoft.EntityFrameworkCore.sqlite
