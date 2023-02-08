using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpfTechHub.Dal;
using EpfTechHub.Models;

namespace EpfTechHub.Controllers
{
    public class CustomerController : Controller
    {
        customerDal _customerDal = new customerDal();
        // GET: Customer
        public ActionResult Index()
        {
            var customerList = _customerDal.GetAllFinancials();

            if(customerList.Count == 0)
            {
                TempData["InFoMessage"] = "Currently customer info not available in the Database.";
            }
            return View(customerList);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(customer  Customer)
        {
            bool IsInserted = false;
            try
            {
                if (ModelState.IsValid)
                {
                    IsInserted = _customerDal.InsertCustomer(Customer);
                    if (IsInserted)
                    {
                        TempData["SuccessMessage"] = "Customer details saved successfully...!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to save the product details.";
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

              TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
