using Restaurant_SP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_SP.DAL;

namespace Restaurant_SP.Controllers
{
    public class BookingController : Controller
    {
        // GET: Bookings/GetAllBookings  
        public ActionResult Index()
        {

            BookingRepository Booking = new BookingRepository();
            ModelState.Clear();
            return View(Booking.GetAllBookings());
        }
        // GET: Bookings/AddBooking    
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookings/AddBooking    
        [HttpPost]
        public ActionResult Create(Booking obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BookingRepository bookingrepo = new BookingRepository();

                    if (bookingrepo.AddBooking(obj))
                    {
                        ViewBag.Message = "Booking details added successfully";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rooms/EditBookingDetails/5    
        public ActionResult Edit(int id)
        {
            BookingRepository BookRepo = new BookingRepository();



            return View(BookRepo.GetAllBookings().Find(book => book.BookingID == id));

        }

        // POST: Bookings/EditBookingDetails/5     
        [HttpPost]

        public ActionResult Edit(int id, Booking obj)
        {
            try
            {
                BookingRepository BookRepo = new BookingRepository();

                BookRepo.UpdateBooking(obj);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bookings/DeleteBooking/5    
        public ActionResult Delete(int id)
        {
            try
            {
                BookingRepository Bookrepo = new BookingRepository();
                if (Bookrepo.DeleteBooking(id))
                {
                    ViewBag.AlertMsg = "Booking details deleted successfully";

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