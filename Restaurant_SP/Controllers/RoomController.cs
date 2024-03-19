using Restaurant_SP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_SP.DAL;

namespace Restaurant_SP.Controllers
{
    public class RoomController : Controller
    { 
       // GET: Rooms/GetAllRooms    
        public ActionResult Index()
        {

            RoomRepository Room = new RoomRepository();
            ModelState.Clear();
            return View(Room.GetAllRooms());
        }
        // GET: Rooms/AddRoom    
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rooms/AddRoom    
        [HttpPost]
        public ActionResult Create(Room obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RoomRepository roomrepo = new RoomRepository();

                    if (roomrepo.AddRoom(obj))
                    {
                        ViewBag.Message = "Room details added successfully";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rooms/EditRoomDetails/5    
        public ActionResult Edit(int id)
        {
            RoomRepository RoomRepo = new RoomRepository();



            return View(RoomRepo.GetAllRooms().Find(room => room.RoomID == id));

        }

        // POST: Rooms/EditRoomDetails/5     
        [HttpPost]

        public ActionResult Edit(int id, Room obj)
        {
            try
            {
                RoomRepository RoomRepo = new RoomRepository();

                RoomRepo.UpdateRoom(obj);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rooms/DeleteRoom/5    
        public ActionResult Delete(int id)
        {
            try
            {
                RoomRepository Roomrepo = new RoomRepository();
                if (Roomrepo.DeleteRoom(id))
                {
                    ViewBag.AlertMsg = "Rooms details deleted successfully";

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