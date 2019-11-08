using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise1
{
    class Program
    {
        class Student
        {
            public string name, family;
            public List<int> marks = new List<int>();
        }
        static void Main(string[] args)
        {
            List<Student> students = new List<Student> {
                new Student{name = "sara", family = "razmkhah", marks = {10, 20, 15}},
                new Student{name = "hanie", family = "narimani", marks = {20}},
                new Student{name = "reza", family = "mohammadpour", marks = {12, 9, 8}},
                new Student{name = "ali", family = "sharifi", marks = {20, 20}},
            };

            var sortedStudents = students.GroupBy(x => x.marks.Average())
                .Select(x => new
                {
                    key = x.Key,
                    values = x
                .OrderByDescending(x => x.marks.Count)
                }).ToList();

            sortedStudents.ForEach(x =>
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"key = {x.key}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                x.values.ToList().ForEach(y =>
                {
                    Console.Write($"\t{y.name} {y.family} ");
                    foreach (var item in y.marks)
                    {
                        Console.Write($"- {item} ");
                    }
                    Console.WriteLine("\n");
                });
            });
        }
    }
}
