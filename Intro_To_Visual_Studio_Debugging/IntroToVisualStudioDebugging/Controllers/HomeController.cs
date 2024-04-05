using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using VehicleDataManagerLibrary;
using VehicleDataManagerLibrary.Models;

namespace IntroToVisualStudioDebugging.Controllers
{
    public class HomeController : Controller
    {
        private readonly VehicleDataManager _datamanager = null;
        private readonly string vehicleFileName = "~/vehicles.json";
        public HomeController()
        {
            _datamanager = new VehicleDataManager();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page."; 
            return View();
        }
         
        public ActionResult Vehicles()
        {
            //Debug.Write("Inside Vehicles");
            var listVehicleRecords = _datamanager.GetData(Server.MapPath(vehicleFileName));
            ViewBag.Message = "Vehicles Page.";
            return View(listVehicleRecords.OrderBy(x => x.VehicleId));
        }

        [HttpGet]
        public ActionResult Create()
        {
           return View();
        }

        [HttpPost]
        public ActionResult Create(Vehicle addedVehicle)
        {
            
            addedVehicle.CreatedDateTime = DateTime.Now;
            addedVehicle.UpdatedDateTime = DateTime.Now;

            string NewVehicleID = "1";
            var listVehicleRecords = _datamanager.GetData(Server.MapPath(vehicleFileName));
            var latestVehicle = listVehicleRecords.OrderByDescending(x => x.VehicleId).FirstOrDefault();
            if(latestVehicle != null)
            {
                var IdOfNewVehicle = Convert.ToInt32(latestVehicle.VehicleId) + 1;
                NewVehicleID = IdOfNewVehicle.ToString();
            } 
            addedVehicle.VehicleId = NewVehicleID;

            listVehicleRecords.Add(addedVehicle);
            _datamanager.SaveData(Server.MapPath(vehicleFileName),listVehicleRecords);
            return RedirectToAction("Vehicles");
        }
         

        [HttpGet]
        public ActionResult Edit(string vehicleId)
        {
           // Debug.Write("Inside Edit");

            var listVehicleRecords =  _datamanager.GetData(Server.MapPath(vehicleFileName));
            var VehicleToEdit = listVehicleRecords.Where(x => x.VehicleId == vehicleId).FirstOrDefault();
            return View(VehicleToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Vehicle editedVehicle)
        {
            // Debug.Write("Inside Save button");

            editedVehicle.UpdatedDateTime = DateTime.Now;
            var listVehicleRecords = _datamanager.GetData(Server.MapPath(vehicleFileName));
            listVehicleRecords.RemoveAll(x => x.VehicleId == editedVehicle.VehicleId);
            listVehicleRecords.Add(editedVehicle);
            _datamanager.SaveData(Server.MapPath(vehicleFileName), listVehicleRecords);
            return RedirectToAction("Vehicles");
        }
         
        [HttpGet]
        public ActionResult Details(string vehicleId)
        {
            var listVehicleRecords = _datamanager.GetData(Server.MapPath(vehicleFileName));
            var VehicleToEdit = listVehicleRecords?.Where(x => x.VehicleId == vehicleId).FirstOrDefault();
            return View(VehicleToEdit);
        }

       
        public ActionResult Delete(string vehicleId)
        {
            var listVehicleRecords = _datamanager.GetData(Server.MapPath(vehicleFileName));
            listVehicleRecords.RemoveAll(x => x.VehicleId == vehicleId);
            _datamanager.SaveData(Server.MapPath(vehicleFileName), listVehicleRecords);
            return RedirectToAction("Vehicles");
        }

        [HttpGet]
        public ActionResult Threads()
        {

            Thread thread1 = new Thread(new ThreadStart(new ThreadWork().DoWork));
            Thread thread2 = new Thread(new ThreadStart(new ThreadWork().DoWork));
            Thread thread3 = new Thread(new ThreadStart(new ThreadWork().DoWork));

            thread1.Name = "thread1";
            thread2.Name = "thread2";
            thread3.Name = "thread3";

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
             
            return View();
        } 

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page."; 
            return View();
        }

    }

    public class ThreadWork
    {
        private int variableInAThread = 0;
        public void DoWork()
        {
            for (int counter = 0; counter < 10; counter++)
            {
                variableInAThread = variableInAThread + 5;
                Thread.Sleep(2000);
            }
        }
    } 
}