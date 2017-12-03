using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagementSystem.Models
{
    public class TSBusinessLayer
    {
        public UserStatus getUserValidity(User user)
        {
            if (user.phone == "18811112222" && user.password == "teacher")
            {
                return UserStatus.teacher;
            }
            else
            {
                return UserStatus.student;
            }
        }
    }
}