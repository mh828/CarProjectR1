﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

using dbs = CarProject.DBSEF;
using System.ComponentModel.DataAnnotations;
using CarProject.CLS;

namespace CarProject.Models.User
{
    public class UserInfo : IValidatableObject
    {
        dbs.CarAutomationEntities context = new dbs.CarAutomationEntities();

        public dbs.Person Person { get; set; }

        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public bool NoNeedPassword { get; set; }
        

        public bool IsForUpdate { get; set; }

        public static UserInfo CreateFromSessionIfExist
        {
            get
            {
                var usr = System.Web.HttpContext.Current.Session["user"];
                if (usr != null && usr is dbs.User)
                    return new UserInfo(((dbs.User)usr).UserId);
                else
                    return new UserInfo();
            }
        }

        public UserInfo()
        {
            Person = new dbs.Person();
            Person.User = new dbs.User();
            IsForUpdate = false;
            NoNeedPassword = false;
        }

        public UserInfo(int userid)
        {
            this.Person = context.People.FirstOrDefault(p => p.UserId == userid);
            IsForUpdate = true;
            NoNeedPassword = false;
        }


        public void Save()
        {
            if (!NoNeedPassword)
            {
                Person.User.Upass = Usefulls.MD5Passwords(Password);
            }
            context.People.Add(Person);

            context.SaveChanges();
        }
        public void Update()
        {
            if (!NoNeedPassword)
            {
                Person.User.Upass = Usefulls.MD5Passwords(Password);
            }
            context.SaveChanges();
        }

        bool CheckMail(string email)
        {
            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
            }

            return false;
        }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "حاصل جمع")]
        public string Captcha { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Person.PersonFirtstName))
                yield return new ValidationResult("نام کاربر وارد نشده است", new string[] { "Person.PersonFirtstName" });
            if (string.IsNullOrWhiteSpace(Person.PersonLastName))
                yield return new ValidationResult("نام خانوادگی کاربر وارد نشده است", new string[] { "Person.PersonLastName" });
            if (string.IsNullOrWhiteSpace(Person.PersonMobile))
                yield return new ValidationResult("موبایل کاربر وارد نشده است", new string[] { "Person.PersonMobile" });

            if (string.IsNullOrWhiteSpace(Person.PersonEmail))
                yield return new ValidationResult("ایمیل کاربر وارد نشده است", new string[] { "Person.PersonEmail" });
            else if (!CheckMail(Person.PersonEmail))
                yield return new ValidationResult("ایمیل وارد شده صحیح نیست", new string[] { "Person.PersonEmail" });
            else if (!IsForUpdate && context.People.Count(p => p.PersonEmail == this.Person.PersonEmail) > 0)
                yield return new ValidationResult("ایمیل وارد شده تکراری است", new string[] { "Person.PersonEmail" });
            else if (IsForUpdate && context.People.Count(p => p.PersonEmail == this.Person.PersonEmail && p.UserId != this.Person.UserId) > 0)
                yield return new ValidationResult("ایمیل وارد شده تکراری است", new string[] { "Person.PersonEmail" });
            

            if(string.IsNullOrWhiteSpace(Person.User.Uname))
                yield return new ValidationResult("نام کاربری وارد نشده است", new string[] { "Person.User.Uname" });
            else if(!IsForUpdate && context.Users.Count(u => u.Uname.ToLower() == this.Person.User.Uname.ToLower()) > 0)
                yield return new ValidationResult("نام کاربری وارد شده تکراری است", new string[] { "Person.User.Uname" });
            else if (IsForUpdate && context.Users.Count(u => u.Uname.ToLower() == this.Person.User.Uname.ToLower() && u.UserId != Person.UserId) > 0)
                yield return new ValidationResult("نام کاربری وارد شده تکراری است", new string[] { "Person.User.Uname" });


            if (!NoNeedPassword)
            {
                if (string.IsNullOrWhiteSpace(Password))
                    yield return new ValidationResult("کلمه عبور وارد نشده است", new string[] { "Password" });
                if (string.IsNullOrWhiteSpace(PasswordConfirm))
                    yield return new ValidationResult("تایید کلمه عبور وارد نشده است", new string[] { "PasswordConfirm" });
            }

            if (!string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(PasswordConfirm) && PasswordConfirm != Password)
                yield return new ValidationResult("کلمه عبور وتایید آن یکسان نیستند", new string[] { "Password", "PasswordConfirm" });
        }
    }
}