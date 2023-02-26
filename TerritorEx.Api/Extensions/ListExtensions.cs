namespace TerritorEx.Api.Extensions;

public static class ListExtensions
{
    public static void Move<T>(this List<T> list, Predicate<T> itemSelector, int newIndex)
    {
        if (list == null || list.Count == 0)
            return;

        if (newIndex < 0 || newIndex > list.Count - 1)
            return;

        var currentIndex = list.FindIndex(itemSelector);
        if (currentIndex < 0)
            return;

        var item = list[currentIndex];

        list.RemoveAt(currentIndex);

        list.Insert(newIndex, item);
    }
}