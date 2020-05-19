using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
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

        public string Index()
        {
            //返回学生的名字
            return _studentRepository.GetStudent(1).Name;
            //return Json(new {id = "1", name = "张三"});
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

        public IActionResult Details()
        {
            var model = _studentRepository.GetStudent(1);
            return View("~/MyViews/Test.cshtml");
        }

    }
}