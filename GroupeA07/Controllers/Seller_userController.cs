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
    public class Seller_userController : ApiController
    {
		private bddEntities db = new bddEntities();

		public IQueryable<Seller_user> GetSeller_user()
		{
			return db.Seller_user;

		}

		public HttpResponseMessage PutSeller_user(Seller_user su)
		{
			if (!ModelState.IsValid)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}


			db.Entry(su).State = EntityState.Modified;

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


		public HttpResponseMessage PostSeller_user(Seller_user su)
		{
			if (!ModelState.IsValid)
			{
				db.Seller_user.Add(su);
				db.SaveChanges();
				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, su);
				response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = su.idSeller }));
				return response;
			}
			else
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}

		}


		public HttpResponseMessage DeleteSeller_user(Seller_user su)
		{
			Seller_user remove_su = db.Seller_user.Find(su.idSeller);
			if (remove_su == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			db.Seller_user.Remove(remove_su);
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

		private bool Seller_userExists(int id)
		{
			return db.Seller_user.Count(e => e.idSeller == id) > 0;
		}
	}
}