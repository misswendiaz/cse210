using System;

public abstract class Activity
{
    // ==============================================================================================================================
    // attributes (member variables)
    // ==============================================================================================================================
    protected DateTime _date;
    // -------------------------------------------------------------------------------------------------------------------------------
    protected TimeSpan _startTime;
    // https://learn.microsoft.com/en-us/dotnet/api/system.timespan?view=net-9.0&utm_source=chatgpt.com#definition
    // -------------------------------------------------------------------------------------------------------------------------------
    protected TimeSpan _endTime;

    // ==============================================================================================================================
    // constructors
    // ==============================================================================================================================
    public Activity(DateTime date, TimeSpan startTime, TimeSpan endTime)
    {
        _date = date;
        _startTime = startTime;
        _endTime = endTime;
    }

    // ==============================================================================================================================
    // behaviors (methods)
    // ==============================================================================================================================
    public double GetDurationInMinutes()
    {
        TimeSpan duration = _endTime - _startTime;
        double durationInMinutes = duration.TotalMinutes;
        return durationInMinutes;
    }
    // -------------------------------------------------------------------------------------------------------------------------------
    public abstract double GetMetricDistance();
    // -------------------------------------------------------------------------------------------------------------------------------
    public abstract double GetMetricSpeed();
    // -------------------------------------------------------------------------------------------------------------------------------
    public abstract double GetMetricPace();
    // -------------------------------------------------------------------------------------------------------------------------------
    public void GetSummary()
    {
        string activity = this.GetType().Name;
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/this
        // https://learn.microsoft.com/en-us/dotnet/api/system.object.gettype?view=net-10.0&utm_source=chatgpt.com
        // https://learn.microsoft.com/en-us/dotnet/api/system.type.name?view=netstandard-1.6&viewFallbackFrom=net-10.0

        string date = _date.ToString("dd MMM yyy");
        double duration = GetDurationInMinutes();
        double distance = Math.Round(GetMetricDistance(), 2);
        double speed = Math.Round(GetMetricSpeed(), 2);
        double pace = Math.Round(GetMetricPace(), 2);

        Console.WriteLine($"{date} {activity} ({duration} mins) - Distance: {distance} km, Speed: {speed} kph, Pace: {pace} min per km");
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
    }
}