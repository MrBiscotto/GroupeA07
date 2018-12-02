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
    public class Sold_objectController : ApiController
    {
		private bddEntities db = new bddEntities();

		public IQueryable<Sold_object> GetSold_object()
		{
			return db.Sold_object;

		}

		public HttpResponseMessage PutSold_object(Sold_object sold)
		{
			if (!ModelState.IsValid)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}


			db.Entry(sold).State = EntityState.Modified;

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


		public HttpResponseMessage PostSold_objectr(Sold_object sold)
		{
			if (!ModelState.IsValid)
			{
				db.Sold_object.Add(sold);
				db.SaveChanges();
				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, sold);
				response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = sold.idObject }));
				return response;
			}
			else
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}

		}


		public HttpResponseMessage DeleteSold_object(Sold_object sold)
		{
			Sold_object remove_sold = db.Sold_object.Find(sold.idObject);
			if (remove_sold == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			db.Sold_object.Remove(remove_sold);
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

		private bool Sold_objectExists(int id)
		{
			return db.Sold_object.Count(e => e.idObject == id) > 0;
		}
	}
}