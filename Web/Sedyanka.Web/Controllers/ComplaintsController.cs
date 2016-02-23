using Microsoft.AspNet.Identity;
using MvcTemplate.Data.Models;
using MvcTemplate.Services.Data;
using MvcTemplate.Web.ViewModels.Complaint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTemplate.Web.Controllers
{
    public class ComplaintsController : BaseController
    {
        private readonly UserManager<ApplicationUser> manager;
        private readonly IComplaintsService complaints;

        public ComplaintsController(UserManager<ApplicationUser> manager, IComplaintsService complaints)
        {
            this.manager = manager;
            this.complaints = complaints;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostComplaintViewModel complaint)
        {
            if (complaint != null && this.ModelState.IsValid)
            {
                var newComplaint = this.Mapper.Map<Complaint>(complaint);
                if (this.User.Identity.IsAuthenticated)
                {
                    var currentUserId = this.User.Identity.GetUserId();
                    var currentUser = this.manager.Users.FirstOrDefault(u => u.Id == currentUserId);

                    newComplaint.Author = currentUser;
                    newComplaint.IpAddress = currentUser.IpAddress;
                }

                this.complaints.Add(newComplaint);

                var viewModel = this.Mapper.Map<ListComplaintViewModel>(newComplaint);

                return this.PartialView("_ComplaintPartial", viewModel);
            }

            throw new HttpException(400, "Invalid complaint request");
        }

        public ActionResult Details(int id, int? pageNumber)
        {
            var complaintViewModel = this.complaints
                .GetById(id)
                .FirstOrDefault();

            return this.View(complaintViewModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult PostComment(PostCommentViewModel comment)
        //{
        //    if (comment != null && this.ModelState.IsValid)
        //    {
        //        var newComment = this.Mapper.Map<Comment>(comment);

        //        if (this.User.Identity.IsAuthenticated)
        //        {
        //            var userId = this.User.Identity.GetUserId();
        //            var currentUser = this.manager.Users.FirstOrDefault(u => u.Id == userId);
        //            newComment.Author = currentUser;
        //        }

        //        var idea = this.ideas.GetById(comment.IdeaId).FirstOrDefault();
        //        if (idea == null)
        //        {
        //            throw new HttpException(404, "Idea not found.");
        //        }

        //        idea.Comments.Add(newComment);
        //        this.ideas.Save();

        //        var viewModel = this.Mapper.Map<CommentViewModel>(newComment);

        //        return this.PartialView("_CommentPartial", viewModel);
        //    }

        //    throw new HttpException(400, "Invalid comment");
        //}
        

        // GET: Complaints
        public ActionResult Index()
        {
            return View();
        }

        // GET: Complaints/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Complaints/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Complaints/Edit/5
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

        // GET: Complaints/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Complaints/Delete/5
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
