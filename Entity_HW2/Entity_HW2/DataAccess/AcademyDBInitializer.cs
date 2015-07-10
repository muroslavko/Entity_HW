using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_HW2.Models;

namespace Entity_HW2.DataAccess
{
    class AcademyDBInitializer : CreateDatabaseIfNotExists<AcademyDbContext>
    {
        protected override void Seed(AcademyDbContext context)
        {
            var categ = new List<Category>()
            {
                new Category(){Name =".NET"},
                new Category(){Name ="JS"},
                new Category(){Name ="PHP"},
                new Category(){Name ="DB"},
                new Category(){Name ="OOP"},
                new Category(){Name ="English"},
            };
            context.Categories.AddRange(categ);
            context.SaveChanges();
            categ = context.Categories.ToList();
            var user1 = new User() { Name = "Oleh", Sity = "Lviv", CategoryId = categ.Where(x => x.Name == ".NET").Select(x => x.Id).FirstOrDefault() };
            var user2 = new User() { Name = "Petro", Sity = "Kyiv", CategoryId = categ.Where(x => x.Name == "JS").Select(x => x.Id).FirstOrDefault() };
            var user3 = new User() { Name = "Vasyl", Sity = "Lviv", CategoryId = categ.Where(x => x.Name == "PHP").Select(x => x.Id).FirstOrDefault() };
            var user4 = new User() { Name = "Maxim", Sity = "Kyiv", CategoryId = categ.Where(x => x.Name == "DB").Select(x => x.Id).FirstOrDefault() };
            var user5 = new User() { Name = "Dmytro", Sity = "Lviv", CategoryId = categ.Where(x => x.Name == "OOP").Select(x => x.Id).FirstOrDefault() };
            var user6 = new User() { Name = "Oleksander", Sity = "Lviv", CategoryId = categ.Where(x => x.Name == ".NET").Select(x => x.Id).FirstOrDefault() };
            var user7 = new User() { Name = "Mykhailo", Sity = "Lviv", CategoryId = categ.Where(x => x.Name == ".NET").Select(x => x.Id).FirstOrDefault() };
            var user8 = new User() { Name = "Yevheniya", Sity = "Lviv", CategoryId = categ.Where(x => x.Name == "JS").Select(x => x.Id).FirstOrDefault() };
            var user9 = new User() { Name = "Lyubochka", Sity = "Lviv", CategoryId = categ.Where(x => x.Name == "PHP").Select(x => x.Id).FirstOrDefault() };
            var user10 = new User() { Name = "Mykhaila", Sity = "Lviv", CategoryId = categ.Where(x => x.Name == "DB").Select(x => x.Id).FirstOrDefault() };
            var user11 = new User() { Name = "Marina", Sity = "Lviv", CategoryId = categ.Where(x => x.Name == "OOP").Select(x => x.Id).FirstOrDefault() };
            var user12 = new User() { Name = "Mykhaila", Sity = "Kyiv", CategoryId = categ.Where(x => x.Name == "JS").Select(x => x.Id).FirstOrDefault() };
            var user13 = new User() { Name = "Oleh Farionov", Sity = "Kyiv", CategoryId = categ.Where(x => x.Name == ".NET").Select(x => x.Id).FirstOrDefault() };
            var user14 = new User() { Name = "Petro Ivanov", Sity = "Kyiv", CategoryId = categ.Where(x => x.Name == "PHP").Select(x => x.Id).FirstOrDefault() };
            var user15 = new User() { Name = "Vasyl Ivanov", Sity = "Kyiv", CategoryId = categ.Where(x => x.Name == "DB").Select(x => x.Id).FirstOrDefault() };
            var user16 = new User() { Name = "Maxim Ivanov", Sity = "Lviv", CategoryId = categ.Where(x => x.Name == ".NET").Select(x => x.Id).FirstOrDefault() };
            var user17 = new User() { Name = "Dmytro Ivanov", Sity = "Kyiv", CategoryId = categ.Where(x => x.Name == "JS").Select(x => x.Id).FirstOrDefault() };
            var user18 = new User() { Name = "Oleksander Ivanov", Sity = "Kyiv", CategoryId = categ.Where(x => x.Name == "PHP").Select(x => x.Id).FirstOrDefault() };
            var user19 = new User() { Name = "Mykhailo Ivanov", Sity = "Kyiv", CategoryId = categ.Where(x => x.Name == "DB").Select(x => x.Id).FirstOrDefault() };
            var user20 = new User() { Name = "Yevheniya Ivanov", Sity = "Kyiv", CategoryId = categ.Where(x => x.Name == "OOP").Select(x => x.Id).FirstOrDefault() };
            var user21 = new User() { Name = "Lyubochka Ivanov", Sity = "Lviv", CategoryId = categ.Where(x => x.Name == "DB").Select(x => x.Id).FirstOrDefault() };
            var user22 = new User() { Name = "Mykhaila Ivanov", Sity = "Kyiv", CategoryId = categ.Where(x => x.Name == "JS").Select(x => x.Id).FirstOrDefault() };
            var user23 = new User() { Name = "Marina Ivanov", Sity = "Kyiv", CategoryId = categ.Where(x => x.Name == ".NET").Select(x => x.Id).FirstOrDefault() };
            //context.Users.Add(user1);
            context.Users.AddRange(new List<User>()
            {
                user7, user8, user9, user10, user11, user12,
                user13, user14, user15, user16, user17, user18, user19, user20, user21, user22, user23
            }
            );

            var test1 = new Test()
            {
                MaxTime = 60,
                PassMark = 5,
                Name = "SQL",
                //Categories = new List<Category>()
                //{
                //categ.FirstOrDefault(x => x.Name == ".NET"),
                Category = categ.FirstOrDefault(x => x.Name == "PHP")
                //}
            };
            var test2 = new Test()
            {
                MaxTime = 60,
                PassMark = 5,
                Name = "JS Basic",
                //Categories = new List<Category>()
                //{
                Category = categ.FirstOrDefault(x => x.Name == "JS"),
                //    categ.FirstOrDefault(x => x.Name == "OOP")
                //}
            };
            var test3 = new Test()
            {
                MaxTime = 60,
                PassMark = 5,
                Name = "Net Basic",
                //Categories = new List<Category>()
                //{
                //    categ.FirstOrDefault(x => x.Name == "English"),
                Category = categ.FirstOrDefault(x => x.Name == ".NET")
                //}
            };
            var test4 = new Test()
            {
                MaxTime = 60,
                PassMark = 5,
                Name = "PHP Basic",
                //Categories = new List<Category>()
                //{
                Category = categ.FirstOrDefault(x => x.Name == "PHP"),
                //    categ.FirstOrDefault(x => x.Name == "OOP")
                //}
            };
            var test5 = new Test()
            {
                MaxTime = 60,
                PassMark = 5,
                Name = "OOP Basic",
                //Categories = new List<Category>()
                //{
                Category = categ.FirstOrDefault(x => x.Name == ".NET"),
                //categ.FirstOrDefault(x => x.Name == "JS"),
                //categ.FirstOrDefault(x => x.Name == "PHP")
                //}
            };
            ///////context.Tests.AddOrUpdate(x => x.Name, test1, test2, test3, test4, test5);

            var quest1 = new Question()
            {
                CategoryId = categ.Where(x => x.Name == ".NET").Select(x => x.Id).FirstOrDefault(),
                Text = "Some Question1",
                Tests = new List<Test>() { test1, test2 }
            };
            var quest2 = new Question()
            {
                CategoryId = categ.Where(x => x.Name == "PHP").Select(x => x.Id).FirstOrDefault(),
                Text = "Some Question2",
                Tests = new List<Test>() { test3, test4 }
            };
            var quest3 = new Question()
            {
                CategoryId = categ.Where(x => x.Name == "JS").Select(x => x.Id).FirstOrDefault(),
                Text = "Some Question3",
                Tests = new List<Test>() { test5, test2, test1 }
            };

            context.Questions.AddRange(new List<Question>() { quest1, quest2, quest3 });

            //// TODO 1 : it create new user, but nead tu use old
            context.TestWorks.AddRange(
                new List<TestWork>()
                {
                    new TestWork(){Mark = 4,Test=test1,Time= 45,User=user1},
                    new TestWork(){Mark = 10,Test=test2,Time= 45,User=user2},
                    new TestWork(){Mark = 4,Test=test3,Time= 45,User=user4},
                    new TestWork(){Mark = 10,Test=test4,Time= 45,User=user5},
                    new TestWork(){Mark = 10,Test=test5,Time= 45,User=user5},
                }
                );

            var teacher1 = new Teacher()
            {
                Name = "Oleg",
                Lectures = new List<Lecture>()
                {
                new Lecture() {CategoryId = categ.Where(x => x.Name == "JS").Select(x => x.Id).FirstOrDefault(), Description = "OOP", Name = "OOP basic"},
                new Lecture() {CategoryId = categ.Where(x => x.Name == "DB").Select(x => x.Id).FirstOrDefault(), Description = "OOP", Name = "Entity"},
                new Lecture() {CategoryId = categ.Where(x => x.Name == "OOP").Select(x => x.Id).FirstOrDefault(), Description = "OOP", Name = "OOP basic 2"}
                }
            };
            var teacher2 = new Teacher()
            {
                Name = "Pedro",
                Lectures = new List<Lecture>()
                {
                new Lecture() {CategoryId = categ.Where(x => x.Name == "JS").Select(x => x.Id).FirstOrDefault(), Description = "some text", Name = "DI"},
                }
            };
            var teacher3 = new Teacher()
            {
                Name = "Jack",
                Lectures = new List<Lecture>()
                {
                new Lecture() {CategoryId = categ.Where(x => x.Name == "OOP").Select(x => x.Id).FirstOrDefault(), Description = "OOP", Name = "Soft"},
                new Lecture() {CategoryId = categ.Where(x => x.Name == "PHP").Select(x => x.Id).FirstOrDefault(), Description = "some text", Name = "Entity"},
                }
            };
            ////////context.Teachers.Add(teacher1);
            context.Teachers.AddRange(new List<Teacher>() { teacher1, teacher2, teacher3 });
            base.Seed(context);
        }
    }
}
