using System;
using System.Web.Mvc;
using AddressBookApplication.Models;

namespace AddressBookApplication.Controllers
{
    public class ContactController : Controller
    {
        ContactImplementation ci = new ContactImplementation();
        
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(ci.GetContact());
        }

        public ActionResult Details(int id)
        {
           
            return View(ci.GetContact().Find(itemmodel => itemmodel.Id == id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ci.CreateContact(contact))
                    {
                        ViewBag.message = "Record Saved SuccesFully !";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(ci.GetContact().Find(itemmodel=>itemmodel.Id==id));
        }

        [HttpPost]
        public ActionResult Edit(int id, ContactModel updateContact)
        {
            try
            {
              var boolvalue=  ci.EditContact(updateContact);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ci.DeleteContact(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
