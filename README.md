# xamarin_meetup_repet

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
````

- Supprimer la vue par défaut et la changer dans App.xaml.cs

