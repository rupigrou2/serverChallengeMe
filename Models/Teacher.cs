﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using serverChallengeMe.Models.DAL;
using System.Web.Security;

using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace serverChallengeMe.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string School { get; set; }
        public bool TempPassword { get; set; }

        public Teacher() { }

        public Teacher(int teacherID, string userName, string password, string firstName, string lastName, string phone, string mail, string school,bool tempPassword)
        {
            TeacherID = teacherID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Mail = mail;
            School = school;
            TempPassword = tempPassword;
        }

        public Teacher isTeacherExists(string username, string password)
        {
            DBservices dBservices = new DBservices();
            return dBservices.isTeacherExists(username, password);
            //אם קיים מחזיר מספר מזהה של מחנך, אם לא קיים מחזיר אפס
        }

        public DataTable getTeacher()
        {
            DBservices dBservices = new DBservices();
            return dBservices.getTeacher();
            //מחזיר רשימה של כל המחנכים
        }

        public int getTeacherByMail(string mail)
        {
            DBservices dBservices = new DBservices();
            var teacherID = dBservices.getTeacherByMail(mail); //אם קיים מחנך עם המייל הזה מחזיר את המספר המזהה של המחנך, אם לא קיים מחזיר אפס
            var randomPassword = "";
            if (teacherID != 0) //במידה שקיים מחנך עם המייל הזה
            {
                Random rnd = new Random();
                //string newPwd = Guid.NewGuid().ToString().Substring(0, 8) + rnd.Next(1, 10);
                randomPassword = Membership.GeneratePassword(8, 0) + rnd.Next(1, 10); //פונקציה שיוצרת סיסמא רנדומלית של 8 תווים עם לפחות תו אחד מיוחד וספרה אחת
                randomPassword = Regex.Replace(randomPassword, @"[^a-zA-Z0-9]", m => rnd.Next(0, 10).ToString());
                dBservices.updateTeacherPassword(teacherID, randomPassword, 1); //פונקציה שמעדכנת את הסיסמא הרנדומלית בטבלת מחנכים ומכניסה ערך 1 לעמודת 'סיסמא זמנית'

                
                try {
                    SmtpClient smtp = new SmtpClient();
                    smtp.UseDefaultCredentials = false;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = true;
                    MailMessage message = new MailMessage();
                    message.To.Add(new MailAddress(mail));
                    message.From = new MailAddress("challenge.me555555@gmail.com");
                    message.Subject = "challenge me new temporary password";
                    message.Body = "<div><div>הססמה הזמנית החדשה שלך היא: " + randomPassword + "</div><div>כאשר אתה נכנס אתה תצטרך לשנות את הססמה</div><div>challenge me</div><div>";
                    message.IsBodyHtml = true; //to make message body as html  
                    smtp.Host = "smtp.gmail.com"; //for gmail host  
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("challenge.me555555@gmail.com", "oren5555");

                    smtp.Send(message);
                    return 1;
            } catch (Exception e) { throw e; }
        }
    
            return 0;
            //אם המייל קיים מחזיר 1 שמסמל על זה ששונתה הססמה, אם המייל לא קיים מחזיר 0
        }

        public DataTable getTeacherById(int teacherID)
        {
            DBservices dBservices = new DBservices();
            return dBservices.getTeacherById(teacherID); 
        }
        
        public int checkIfTeacherExistByUsername(string username)
        {
            DBservices dBservices = new DBservices();
            return dBservices.checkIfTeacherExistByUsername(username);
        }
        public int postTeacher(Teacher teacher)
        {
            DBservices dbs = new DBservices();
            return dbs.postTeacher(teacher);
        }

        public int putNewTeacherPassword(int teacherID, string password)
        {
            DBservices dbs = new DBservices();
            return dbs.updateTeacherPassword(teacherID, password, 0);
        }

        public int putTeacher(Teacher t)
        {
            DBservices dbs = new DBservices();
            return dbs.updateTeacherDetails(t);
        }

    //public int deleteTeacher(int id)
    //{
    //    DBservices dbs = new DBservices();
    //    return dbs.deleteTeacher(id);
    //}
}
}