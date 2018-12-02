using GroupeA07.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace GroupeA07.Controllers
{
    public class ModeratorController : ApiController
    {
		private bddEntities db = new bddEntities();

		public IQueryable<Moderator> GetModerator()
		{
			return db.Moderator;

		}

		public HttpResponseMessage PutModerator(Moderator mod)
		{
			if (!ModelState.IsValid)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}


			db.Entry(mod).State = EntityState.Modified;

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
			}

			return Request.CreateResponse(HttpStatusCode.OK);
		}


		public HttpResponseMessage PostModerator(Moderator mod)
		{
			if (!ModelState.IsValid)
			{
				db.Moderator.Add(mod);
				db.SaveChanges();
				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, mod);
				response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = mod.idModerator }));
				return response;
			}
			else
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}

		}


		public HttpResponseMessage DeleteModerator(Moderator mod)
		{
			Moderator remove_mod = db.Moderator.Find(mod.idModerator);
			if (remove_mod == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			db.Moderator.Remove(remove_mod);
			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
			}

			return Request.CreateResponse(HttpStatusCode.OK);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool ModeratorExists(int id)
		{
			return db.Moderator.Count(e => e.idModerator == id) > 0;
		}
	}
}