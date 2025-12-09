using System;

public class Running : Activity
{
    // ==============================================================================================================================
    // attributes (member variables)
    // ==============================================================================================================================
    private double _distance;

    // ==============================================================================================================================
    // constructors
    // ==============================================================================================================================
    public Running(DateTime date, TimeSpan startTime, TimeSpan endTime, double distance) : base(date, startTime, endTime)
    {
        _startTime = startTime;
        _endTime = endTime;
        _distance = distance;
    }

    // ==============================================================================================================================
    // behaviors (methods)
    // ==============================================================================================================================
    public override double GetMetricDistance()
    {
        return _distance;
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