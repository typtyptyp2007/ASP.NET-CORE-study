﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    public class DepartmentsController:Controller
    {
        public string List()
        {
            return "DepartmentsController中的List()方法。";
        }

        public string Details()
        {
            return "DepartmentsController中的Details()方法。";
        }
    }
}
