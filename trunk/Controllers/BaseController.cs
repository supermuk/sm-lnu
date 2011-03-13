using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMT.Models;

namespace CMT.Controllers
{
    public class BaseController : Controller
    {
        protected Storage mStorage = new Storage();
    }
}