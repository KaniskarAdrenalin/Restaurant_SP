using Restaurant_SP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_SP.DAL;

namespace Restaurant_SP.Controllers
{
    public class UserController : Controller
    {
        // GET: Users/GetAllUsers
        public ActionResult Index()
        {

            UserRepository User = new UserRepository();
            ModelState.Clear();
            return View(User.GetAllUsers());
        }
        // GET: Users/AddUser    
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/AddUser    
        [HttpPost]
        public ActionResult Create(User obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserRepository Userrepo = new UserRepository();

                    if (Userrepo.AddUser(obj))
                    {
                        ViewBag.Message = "User details added successfully";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/EditUserDetails/5    
        public ActionResult Edit(int id)
        {
            UserRepository UserRepo = new UserRepository();



            return View(UserRepo.GetAllUsers().Find(User => User.UserID == id));

        }

        // POST: Users/EditUserDetails/5     
        [HttpPost]

        public ActionResult Edit(int id, User obj)
        {
            try
            {
                UserRepository UserRepo = new UserRepository();

                UserRepo.UpdateUser(obj);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/DeleteUser/5    
        public ActionResult Delete(int id)
        {
            try
            {
                UserRepository Userrepo = new UserRepository();
                if (Userrepo.DeleteUser(id))
                {
                    ViewBag.AlertMsg = "Users details deleted successfully";

                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}