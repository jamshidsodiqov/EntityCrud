using Project.Service.DTOs.Courses;
using Project.Service.DTOs.Students;
using Project.Service.DTOs.Teachers;
using Project.Service.Interfaces;
using Project.Service.Services;

IStudentService StudentService = new StudentService();
ICourseService CourseService = new CourseService();
ITeacherService TeacherService = new TeacherService();

Console.WriteLine( await StudentService.CreateAsync(new StudentForCreationDTO
{
    FirstName = "kamdwedeol",
    LastName = "UlUgwewebek",
    Email = "kua@gadedwemil.com",
    Password = "7454efwefef9455",
    PhoneNumber = "+9987wfwef7775336",
    Updated = DateTime.UtcNow,
    Created = DateTime.UtcNow,
    CourseId =2,
}));

//await StudentService.DeleteAsync(1); 

//await StudentService.UpdateAsync(2,new StudentForUpdateDTO
//{
//    FirstName = "Davron",
//    LastName = "Sodiqov",
//    Email = "sodiqovdavron05@gamil.com",
//    Password = "55555sjk",
//    PhoneNumber = "+998903145336",
//    Updated = DateTime.UtcNow,
//    Created = DateTime.UtcNow,
//    CourseId = 1,
//});




//await CourseService.CreateAsync(new CourseForCreationDTO
//{
//    Name = "Python",
//    Description = "Zero to hero",
//    Author = "Anvar Narzulloh ",
//    Cost = 1500000,
//    CourseType = Project.Domain.Enums.CourseType.online,
//    Updated = DateTime.UtcNow,
//    Created = DateTime.UtcNow,
//});

//await CourseService.DeleteAsync(7);


//await CourseService.UpdateAsync(6,new CourseForUpdateDTO
//{
//    Name = "blabla",
//    Description = "Tarix",
//    Author = "gerodot",
//    Cost = 150000,
//    CourseType = Project.Domain.Enums.CourseType.offline,
//    Updated = DateTime.UtcNow,
//    Created = DateTime.UtcNow,
//});



//await TeacherService.CreateAsync(new TeacherForCreationDTO
//{
//    FirstName = "Jamshid",
//    LastName = "Sodiqov",
//    Field = "History",
//    Email = "sodiqovjamshid05@gamil.com",
//    PhoneNumber = "+998903145336",
//    Updated = DateTime.UtcNow,
//    Created = DateTime.UtcNow,
//});

//await TeacherService.DeleteAsync(5);

//await TeacherService.UpdateAsync(2, new TeacherForUpdateDTO
//{
//    FirstName = "Davron",
//    LastName = "Sodiqov",
//    Field = "Kimyo",
//    Email = "sodiqovjamshid05@gamil.com",
//    PhoneNumber = "+998903145336",
//    Updated = DateTime.UtcNow,
//    Created = DateTime.UtcNow,
//});