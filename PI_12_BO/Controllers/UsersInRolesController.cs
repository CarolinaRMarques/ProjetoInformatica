using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PI_12_BO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PI_12_BO.Controllers
{
    [Authorize]
    public class UsersInRolesController : Controller
    {
        private pi_12Entities db = new pi_12Entities();
        #region AspNetUsers
        // GET: UsersInRoles
        public ActionResult _Index(string userId)
        {
            List<AspNetRoles> userRoles = db.AspNetUsers
                .FirstOrDefault(x => x.Id == userId)
                .AspNetRoles
                .ToList();

            ViewBag.userId = userId;
            return PartialView(userRoles);
        }

        public ActionResult _Create(string userId)
        {
            HashSet<string> setToRemove = new HashSet<string>(db.AspNetUsers
                .FirstOrDefault(x => x.Id == userId)
                .AspNetRoles
                .Select(x => x.Id)
                .ToList());

            List<SelectListItem> newRoles = db.AspNetRoles
                                    .Where(r => !setToRemove.Contains(r.Id))
                                    .OrderBy(x => x.Name)
                                    .Select(x => new SelectListItem()
                                    {
                                        Text = x.Name,
                                        Value = x.Id.ToString()
                                    })
                                    .ToList();
            ViewBag.userId = userId;
            ViewBag.newRoles = newRoles;
            return PartialView();
        }
        // GET: Roles/AddRoleToUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRoleToUser(string userId, string roleId)
        {
            if (ModelState.IsValid && !String.IsNullOrEmpty(userId) && !String.IsNullOrEmpty(roleId))
            {
                var user = db.AspNetUsers.FirstOrDefault(x => x.Id == userId);
                var role = db.AspNetRoles.FirstOrDefault(x => x.Id == roleId);
                user.AspNetRoles.Add(role);
                db.SaveChanges();
            }
            return RedirectToAction("Details", "AspNetUsers", new { id = userId });
        }

        // GET: Roles/RemoveRoleFromUser
        public ActionResult RemoveRoleFromUser(string userId, string roleId)
        {
            if (ModelState.IsValid)
            {
                AspNetUsers user = db.AspNetUsers.Find(userId);
                AspNetRoles role = db.AspNetRoles.Find(roleId);
                if (user == null || role == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                user.AspNetRoles.Remove(role);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

            }
            return RedirectToAction("Details", "AspNetUsers", new { id = userId });
        }
        #endregion

        #region AspNetRoles     
        public ActionResult _IndexRoles(string roleId)
        {
            List<AspNetUsers> usersInRole = db.AspNetRoles
                .FirstOrDefault(x => x.Id == roleId)
                .AspNetUsers
                .ToList();

            ViewBag.roleId = roleId;
            return PartialView(usersInRole);
        }

        public ActionResult _AddUserToRole(string roleId)
        {
            HashSet<string> setToRemove = new HashSet<string>(db.AspNetRoles
                .FirstOrDefault(x => x.Id == roleId)
                .AspNetUsers
                .Select(x => x.Id)
                .ToList());

            List<SelectListItem> newUsers = db.AspNetUsers
                                    .Where(r => !setToRemove.Contains(r.Id))
                                    .OrderBy(x => x.FullName)
                                    .Select(x => new SelectListItem()
                                    {
                                        Text = x.FullName,
                                        Value = x.Id.ToString()
                                    })
                                    .ToList();
            ViewBag.roleId = roleId;
            ViewBag.newUsers = newUsers;
            return PartialView();
        }

        // POST: Users/AddUserToRole
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUserToRole(string userId, string roleId)
        {
            if (ModelState.IsValid && !String.IsNullOrEmpty(userId) && !String.IsNullOrEmpty(roleId))
            {
                var role = db.AspNetRoles.FirstOrDefault(x => x.Id == roleId);
                var user = db.AspNetUsers.FirstOrDefault(x => x.Id == userId);
                role.AspNetUsers.Add(user);
                db.SaveChanges();
            }
            return RedirectToAction("Details", "AspNetRoles", new { id = roleId });
        }

        // GET: Users/RemoveUserFromRole
        [HttpGet]
        public ActionResult RemoveUserFromRole(string userId, string roleId)
        {
            if (ModelState.IsValid)
            {
                AspNetRoles role = db.AspNetRoles.Find(roleId);
                AspNetUsers user = db.AspNetUsers.Find(userId);
                if (user == null || role == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                role.AspNetUsers.Remove(user);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

            }
            return RedirectToAction("Details", "AspNetRoles", new { id = roleId });
        }
        #endregion
    }
}
