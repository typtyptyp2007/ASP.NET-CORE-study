using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.ViewModels;

namespace StudentManagement.Controllers
{
    //[Route("Home")]
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        /// <summary>
        /// 使用构造函数注入IStudentRepository
        /// </summary>
        /// <param name="studentRepository"></param>
        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //public string Index()
        //{
        //    //返回学生的名字
        //    return _studentRepository.GetStudent(1).Name;
        //    //return Json(new {id = "1", name = "张三"});
        //}

        //[Route("")]
        //[Route("Index")]
        //[Route("~/")]
        public IActionResult Index()
        {
            var students = _studentRepository.GetAllStudents();
            return View(students);
        }

        //public JsonResult Details()
        //{
        //    var model = _studentRepository.GetStudent(1);
        //    return Json(model);
        //}

        //public ObjectResult Details()
        //{
        //    var model = _studentRepository.GetStudent(1);
        //    return new ObjectResult(model);
        //}

        //[Route("Details/{id?}")]
        public IActionResult Details(int? id)
        {
            //var model = _studentRepository.GetStudent(1);

            //ViewData["PageTitle"] = "学生详情";
            //ViewData["Student"] = model;

            ////将PageTitle和Student模型对象存储在ViewBag
            ////我们正在使用动态属性PageTitle和Student
            //ViewBag.PageTitle = "学生详情";
            //ViewBag.Student = model;

            //实例化HomeDetailsViewModel并存储Student详细信息和PageTitle
            var homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = _studentRepository.GetStudent(id??1),
                PageTitle = "学生详细信息"
            };

            //return View("~/MyViews/Test.cshtml");
            return View(homeDetailsViewModel);
        }

    }
}