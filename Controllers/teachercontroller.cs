﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using serverChallengeMe.Models;

namespace serverChallengeMe.Controllers
{
    public class TeacherController : ApiController
    {
        //GET api/Teacher
        public DataTable Get()
        {
            Teacher teacher = new Teacher();
            return teacher.getTeacher();
        }

        // GET api/Teacher?username={username}&password={password}
        public Teacher Get(string username, string password)
        {
            Teacher teacher = new Teacher();
            return teacher.isTeacherExists(username, password);
        }

        // GET api/Teacher?mail={mail}
        public int GetByMail(string mail)
        {
            Teacher teacher = new Teacher();
            return teacher.getTeacherByMail(mail);
        }

        // GET api/Teacher?teacherID={teacherID}
        public DataTable GetByTeacherID(int teacherID)
        {
            Teacher teacher = new Teacher();
            return teacher.getTeacherById(teacherID);
        }

        // GET api/Teacher?usernameNewTeacher={username}
        public int GetByTeacherID2(string usernameNewTeacher)
        {
            Teacher teacher = new Teacher();
            return teacher.checkIfTeacherExistByUsername(usernameNewTeacher);
        }

        // POST api/<controller>
        public int Post(Teacher teacher)
        {
            Teacher t = new Teacher();
            return t.postTeacher(teacher);
        }

        // PUT api/Teacher?teacherID={teacherID}&password={password}
        public int PutTeacherPassword(int teacherID, string password)
        {
            Teacher teacher = new Teacher();
            return teacher.putNewTeacherPassword(teacherID, password);
        }

        // PUT api/<controller>/5
        public int Put(Teacher t)
        {
            Teacher teacher = new Teacher();
            return teacher.putTeacher(t);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}