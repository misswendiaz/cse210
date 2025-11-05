using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");

        Console.WriteLine();

        // Wordlab
        Job job1 = new Job();
        job1._company = "Wordlab School, Inc.";
        job1._jobTitle = "Teacher";
        job1._startYear = 2012;
        job1._endYear = 2015;
        // job1.Display();

        Console.WriteLine();

        // Ateneo
        Job job2 = new Job();
        job2._company = "Ateneo de Manila High School";
        job2._jobTitle = "Mathematics Teacher";
        job2._startYear = 2015;
        job2._endYear = 2017;
        // job2.Display();

        Console.WriteLine();

        // UP
        Job job3 = new Job();
        job3._company = "University of the Philippines";
        job3._jobTitle = "Lecturer";
        job3._startYear = 2022;
        job3._endYear = 2099;
        // job3.Display();

        Console.WriteLine();

        // Hinduja
        Job job4 = new Job();
        job4._company = "Hinduja Technology, Media, and Telecom";
        job4._jobTitle = "Customer Service Representative";
        job4._startYear = 2007;
        job4._endYear = 2008;
        // job4.Display();

        Console.WriteLine();

        // HSBC
        Job job5 = new Job();
        job5._company = "HSBC";
        job5._jobTitle = "Collections Officer";
        job5._startYear = 2010;
        job5._endYear = 2011;
        // job5.Display();

        Console.WriteLine();

        // Teleperformance
        Job job6 = new Job();
        job6._company = "Teleperformance";
        job6._jobTitle = "Technical Support Representative";
        job6._startYear = 2018;
        job6._endYear = 2019;
        // job6.Display();

        Console.WriteLine();

        Resume person1 = new Resume();
        person1._name = "Wen Arcilla";
        person1._jobs.Add(job4);
        person1._jobs.Add(job5);
        person1._jobs.Add(job6);
        person1.Display();

        Console.WriteLine();

        Resume person2 = new Resume();
        person2._name = "Laureen Diaz";
        person2._jobs.Add(job1);
        person2._jobs.Add(job2);
        person2._jobs.Add(job3);
        person2.Display();
    }
}