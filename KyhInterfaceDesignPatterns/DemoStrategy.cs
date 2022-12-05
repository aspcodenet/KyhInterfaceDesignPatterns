

using System.Xml.Xsl;

public interface ISortStrategy
{
    public void Sort(List<string> list);
}
/// <summary>
/// A 'ConcreteStrategy' class
/// </summary>
public class QuickSort : ISortStrategy
{
    public void Sort(List<string> list)
    {
        list.Sort();  // Default is Quicksort
        Console.WriteLine("QuickSorted list ");
    }
}
/// <summary>
/// A 'ConcreteStrategy' class
/// </summary>
public class ShellSort : ISortStrategy
{
    public void Sort(List<string> list)
    {
        //list.ShellSort();  not-implemented
        Console.WriteLine("ShellSorted list ");
    }
}
/// <summary>
/// A 'ConcreteStrategy' class
/// </summary>
public class MergeSort : ISortStrategy
{
    public void Sort(List<string> list)
    {
        //list.MergeSort(); not-implemented
        Console.WriteLine("MergeSorted list ");
    }
}


public class SortableList
{
    private List<string> list = new List<string>();
    public SortableList()
    {
    }
    public void Add(string name)
    {
        list.Add(name);
    }
    public void Sort(ISortStrategy sortstrategy)
    {
        sortstrategy.Sort(list);
        // Iterate over list and display results
        foreach (string name in list)
        {
            Console.WriteLine(" " + name);
        }
        Console.WriteLine();
    }
}

public interface IRouteStrategy
{
    public List<string> Waypoints(string from, string to);
}
public class ShortestRouteStrategy : IRouteStrategy
{
    public List<string> Waypoints(string from, string to)
    {
        return new List<string>
        {
            "Testgatan",
            "Vänster Hejgatan"
        };
    }
}

public class FastestRouteStrategy : IRouteStrategy
{
    public List<string> Waypoints(string from, string to)
    {
        return new List<string>
        {
            "Testgatan",
            "Höger in på Blue Street",
            "Höger in på Kanelvägen",
            "Höger in på Hejgatan"
        };
    }
}

public class MostBeautifulRouteStrategy : IRouteStrategy
{
    public List<string> Waypoints(string from, string to)
    {
        return new List<string>
        {
            "Testgatan till vägen tar slut",
            "Höger över cykelbanan",
            "Kör genom skogen i 2.2 km",
            "Höger in på Hejgatan"
        };
    }
}


public class RouteCalculator
{
    public bool PresentRoute(string from, string to, IRouteStrategy strategy)
    {
        if (!ValidLocation(from)) return false;
        if (!ValidLocation(to)) return false;
        //Calculate best route
        foreach(var route in strategy.Waypoints(from,to))
            Console.WriteLine(route);
        return true;
    }

    private bool ValidLocation(string from)
    {
        //Kolla i databas etc etc
        return true;
    }
}

public class DemoStrategy
{
    public void Run()
    {
        var routeCalulator = new RouteCalculator();
        

        //När du har saker som du vill BEARBETA på olika sätt beroende på olika faktorer
        //
        IRouteStrategy strategy = null;
        Console.WriteLine("1. Snabbaste");
        Console.WriteLine("2. Vackraste");
        Console.WriteLine("3. Billigaste");
        var sel = Console.ReadLine();
        if (sel == "1")
            strategy = new FastestRouteStrategy();
        else if (sel == "2")
            strategy = new MostBeautifulRouteStrategy();
        else if (sel == "3")
            strategy = new ShortestRouteStrategy();
        var res = routeCalulator.PresentRoute("Uppsala", "Stockholm", strategy);

        // FACTORY!!!

        var l1 = new SortableList();
        l1.Add("Stefan");
        l1.Add("Oliver");

        l1.Sort(new MergeSort());
        l1.Sort(new QuickSort());
        l1.Sort(new ShellSort());

    }
}