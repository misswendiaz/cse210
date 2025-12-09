using System;

public class Cycling : Activity
{
    // ==============================================================================================================================
    // attributes (member variables)
    // ==============================================================================================================================
    private double _speed;

    // ==============================================================================================================================
    // constructors
    // ==============================================================================================================================
    public Cycling(DateTime date, TimeSpan startTime, TimeSpan endTime, double speed) : base(date, startTime, endTime)
    {
        _startTime = startTime;
        _endTime = endTime;
        _speed = speed;
    }

    // ==============================================================================================================================
    // behaviors (methods)
    // ==============================================================================================================================
    public override double GetMetricDistance()
    {
        double durationInHours = GetDurationInMinutes() / 60;
        double distance = _speed * durationInHours;
        return distance;
    }
    // -------------------------------------------------------------------------------------------------------------------------------
    public override double GetMetricSpeed()
    {
        return _speed;
    }
    // -------------------------------------------------------------------------------------------------------------------------------
    public override double GetMetricPace()
    {
        double pace = 60 / GetMetricSpeed();
        return pace;
    }

}