using CourseManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CourseManagementSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult singin(User user)
        {
            if (ModelState.IsValid)
            {
                TSBusinessLayer tsBnl = new TSBusinessLayer();
                UserStatus status = tsBnl.getUserValidity(user);
                bool isTeacher = false;
                if (status == UserStatus.teacher)
                {
                    isTeacher = true;
                }
                else if (status == UserStatus.student)
                {
                    isTeacher = false;
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("LoginUI");
                }
                FormsAuthentication.SetAuthCookie(user.phone, false);
                Session["isTeacher"] = isTeacher;
                if (status == UserStatus.teacher)
                {
                    return RedirectToAction("Teacher_MainUI", "teacher");
                }
                else if (status == UserStatus.student)
                {
                    return RedirectToAction("Student_MainUI", "student");
                }
                else
                {
                    return View("LoginUI");
                }
            }
        }
    }
}