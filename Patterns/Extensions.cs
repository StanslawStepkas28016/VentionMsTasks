namespace EventsAndDelegates;

public static class Extensions
{
    public static IList<T> CustomWhere<T>(this IList<T> items)
    {
        // items.Where((i, index) => { return index % 2 == 0; });

        List<T> outList = new();

        for (var i = 0; i < items.Count; i++)
        {
            if (i % 2 == 0)
            {
                outList.Add(items[i]);
            }
        }

        return outList;
    }
}