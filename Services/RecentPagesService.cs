namespace ERP.V7.WebPMS.Services;

public class RecentPagesService
{
    private const int MaxItems = 5;
    private readonly List<MenuItem> recentItems = new();

    public IReadOnlyList<MenuItem> RecentItems => recentItems;

    public event Action? OnChange;

    public void Track(string relativePath)
    {
        var menuItem = MenuCatalog.FindByHref(relativePath);
        if (menuItem is null)
        {
            return;
        }

        recentItems.RemoveAll(m => m.Href == menuItem.Href);
        recentItems.Insert(0, menuItem);

        if (recentItems.Count > MaxItems)
        {
            recentItems.RemoveRange(MaxItems, recentItems.Count - MaxItems);
        }

        OnChange?.Invoke();
    }
}
