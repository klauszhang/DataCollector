using DataCollector.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using DataCollector.DAL;
using DataCollector.Repository;
using DataCollector.DomainModel;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace DataCollector.Mvc.Controllers
{
    public class DeviceController : Controller
    {
        private DCDbContext _context;
        private DeviceRepository _deviceRepository;
        private string _userId;

        public DeviceController()
        {
            _userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            _context = new DCDbContext();
        }

        // GET: Device
        public ActionResult Create()
        {
            ViewBag.DeviceList = new SelectList(new List<string>
            {
                "Smart phone",
                "Sensor"
            });

            return View();
        }

        [HttpPost]
        public ActionResult Create(NewDeviceViewModel vm)
        {
            var result = false;
            using (var repo = new DeviceRepository(_userId))
            {
                result = repo.AddNewDevice(vm);
            }
            if (result)
                return RedirectToAction("Index", "Manage");
            ModelState.AddModelError("", "Save error");
            return View();
        }
    }
}