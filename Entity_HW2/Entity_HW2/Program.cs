using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Entity_HW2.DataAccess;
using Entity_HW2.Models;

namespace Entity_HW2
{
    class Program
    {
        static IUnitOfWorkFactory _unitOfWorkFactory = new UnitOfWorkFactory();
        static void Main(string[] args)
        {
            using (var db = _unitOfWorkFactory.Create())
            {
                //Список людей, которые прошли тесты OK
                (from item in db.Repository<TestWork>().Query()
                 group item.User by item.User.Name
                     into u
                     select u.FirstOrDefault())
                     .ToList()
                     .ForEach(x => Console.WriteLine(x.Name));
                Console.WriteLine();


                //Список тех, кто прошли тесты успешно и уложилися во время. OK
                (from item in db.Repository<TestWork>().Query()
                 where item.Time <= item.Test.MaxTime && item.Mark >= item.Test.PassMark
                 group item.User by item.User.Name
                     into u
                     select u.FirstOrDefault()).ToList().ForEach(x => Console.WriteLine(x.Name));
                Console.WriteLine();



                //Список людей, которые прошли тесты успешно и не уложились во время
                (from item in db.Repository<TestWork>().Query()
                 where item.Time > item.Test.MaxTime && item.Mark >= item.Test.PassMark
                 group item.User by item.User.Name
                     into u
                     select u.FirstOrDefault()).ToList().ForEach(x => Console.WriteLine(x.Name));
                Console.WriteLine();


                //Список студентов по городам. (Из Львова: 10 студентов, из Киева: 20)
                (from user in db.Repository<User>().Query()
                 group user by user.Sity
                     into u
                     select new { Sity = u.Key, Count = u.Count() })
                     .ToList().ForEach(x => Console.WriteLine("{0}: {1}", x.Sity, x.Count));
                Console.WriteLine();


                //Список успешных студентов по городам.
                (from u in db.Repository<TestWork>().Query()
                 where (u.Time <= u.Test.MaxTime && u.Mark >= u.Test.PassMark)
                 group u.User by u.User.Name
                     into g
                     select g.FirstOrDefault()
                     ).OrderBy(x => x.Sity)
                     .ToList()
                     .ForEach(x => Console.WriteLine("{0}  {1}", x.Name, x.Sity));
                Console.WriteLine();



                //Результат для каждого студента - его баллы, время, баллы в процентах для каждой категории.
                (from item in db.Repository<TestWork>().Query()
                 group item by item.User.Name
                     into g
                     select new
                     {
                         Name = g.Key,
                         Works = g.Select(item =>
                             new
                             {
                                 Name = item.Test.Name,
                                 Mark = item.Mark,
                                 Time = item.Time,
                                 Persent = item.Mark * 10
                             })
                     }).ToList()
                                .ForEach(groupUser =>
                                {
                                    Console.WriteLine("Name: {0}", groupUser.Name);
                                    groupUser.Works.ToList()
                                        .ForEach(test =>
                                            Console.WriteLine("\t{0}, {1}, {2}%, {3}",
                                            test.Name, test.Mark, test.Persent, test.Time));
                                }

                    );
                Console.WriteLine();


                //Рейтинг популярности вопросов в тестах (выводить количество использования данного вопроса в тестах)
                (from item in db.Repository<Question>().Query()
                 orderby item.Tests.Count() descending 
                 select new { Count = item.Tests.Count(), Text = item.Text })
                    .ToList().ForEach(x => Console.WriteLine("{0}  {1}", x.Count, x.Text));
                Console.WriteLine(  );



                //Рейтинг учителей по количеству лекций (Количество прочитанных лекций)
                (from teacher in db.Repository<Teacher>().Query()
                 orderby teacher.Lectures.Count() descending 
                 select teacher)
                           .ToList().ForEach(x => Console.WriteLine(x.Name));
                Console.WriteLine(  );

                //Средний бал тестов по категориям, отсортированый по убыванию.
                (from item in db.Repository<TestWork>().Query()
                    group item by item.Test.Category.Name
                    into grp
                               select new {Category = grp.Key, Mark = grp.Select(x => x.Mark).Average()})
                               .OrderByDescending(x => x.Mark)
                               .ToList().ForEach(x => Console.WriteLine("{0}   {1}",x.Category,x.Mark));
                Console.WriteLine(  );


                //Рейтинг вопросов по набранным баллам
                (from item in db.Repository<TestWork>().Query()
                    orderby item.Mark descending
                 select new {Mark = item.Mark, Name = item.Test.Name})
                 .ToList().ForEach(x => Console.WriteLine("{0} - {1}",x.Mark,x.Name));

            }
            Console.ReadLine();
        }
    }
}
