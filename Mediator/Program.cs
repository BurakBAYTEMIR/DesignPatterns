﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    /// <summary>
    /// Nesneler arasındaki kaotik bağımlılıkları azaltmanızı sağlar. 
    /// Desen, nesneler arasındaki doğrudan iletişimi kısıtlar ve yalnızca bir arabulucu nesne aracılığıyla işbirliği yapmaya zorlar.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher engin = new Teacher(mediator);
            engin.Name = "Engin";
            mediator.Teacher = engin;

            Student derin = new Student(mediator);
            derin.Name = "Derin";

            Student salih = new Student(mediator);
            salih.Name = "Salih";

            mediator.Students = new List<Student> { derin, salih };

            engin.SendNewImageUrl("slide1.jpg");
            engin.RecieveQuestion("is it true?",salih);

            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;
        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; set; }
        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0},{1}", student.Name, question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher recieved a question from {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}", student.Name, answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} Student received image : {0}", url, Name);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student received answer : {0}", answer);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
