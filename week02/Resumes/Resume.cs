using System;
public class Resume
{
    // attributes (member variables)
    public string _name;
    public List<Job> _jobs = new List<Job>();

    // constructor
    public Resume()
    {

    }

    // behaviors (methods)
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}