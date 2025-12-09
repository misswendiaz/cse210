using System;

public class Swimming : Activity
{
    // ==============================================================================================================================
    // attributes (member variables)
    // ==============================================================================================================================
    private int _lapCount;

    // ==============================================================================================================================
    // constructors
    // ==============================================================================================================================
    public Swimming(DateTime date, TimeSpan startTime, TimeSpan endTime, int lapCount) : base(date, startTime, endTime)
    {
        _startTime = startTime;
        _endTime = endTime;
        _lapCount = lapCount;
    }

    // ==============================================================================================================================
    // behaviors (methods)
    // ==============================================================================================================================
    public override double GetMetricDistance()
    {
        double distanceInMeters = _lapCount * 50;
        double distanceInKilometers = distanceInMeters / 1000;
        return distanceInKilometers;
    }
    // -------------------------------------------------------------------------------------------------------------------------------
    public override double GetMetricSpeed()
    {
        double durationInHours = GetDurationInMinutes() / 60;
        double speed = GetMetricDistance() / durationInHours;
        return speed;
    }
    // -------------------------------------------------------------------------------------------------------------------------------
    public override double GetMetricPace()
    {
        double pace = 60 / GetMetricSpeed();
        return pace;
    }

}