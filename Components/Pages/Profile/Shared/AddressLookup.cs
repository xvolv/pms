namespace ERP.V7.WebPMS.Components.Pages.Profile.Shared;

public static class AddressLookup
{
    public static readonly List<string> Regions = new()
    {
        "Addis Ababa", "Oromia", "Amhara", "Tigray", "Sidama", "SNNPR", "Somali", "Afar",
        "Benishangul-Gumuz", "Gambela", "Harari", "Dire Dawa",
    };

    public static readonly List<string> Cities = new()
    {
        "Addis Ababa", "Adama", "Bahir Dar", "Mekelle", "Hawassa", "Dire Dawa", "Gondar",
        "Jimma", "Dessie", "Jijiga", "Shashamane", "Bishoftu",
    };

    public static readonly List<string> SubCities = new()
    {
        "Bole", "Yeka", "Kirkos", "Arada", "Addis Ketema", "Lideta", "Akaky Kaliti",
        "Nifas Silk-Lafto", "Kolfe Keranio", "Gulele", "Lemi Kura",
    };

    public static readonly List<string> Weredas = Enumerable.Range(1, 14)
        .Select(n => $"Woreda {n:D2}")
        .ToList();
}
