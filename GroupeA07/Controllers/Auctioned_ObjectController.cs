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
    public class Auctioned_ObjectController : ApiController
    {
		private bddEntities db = new bddEntities();
		 
		public IQueryable<Auctioned_object> GetAuctioned_Object()
		{
			return db.Auctioned_object;

		}  

		public HttpResponseMessage PutAuctioned_Object(Auctioned_object ao)
		{
			if (!ModelState.IsValid)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}


			db.Entry(ao).State = EntityState.Modified;

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
 

		public HttpResponseMessage PostAuctioned_Object(Auctioned_object ao)
		{
			if (!ModelState.IsValid)
			{
				db.Auctioned_object.Add(ao);
				db.SaveChanges();
				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, ao);
				response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = ao.idObject }));
				return response;
			}
			else
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}

		}
		

		public HttpResponseMessage DeleteAuctioned_Object(Auctioned_object ao)
		{
			Auctioned_object remove_ao = db.Auctioned_object.Find(ao.idObject);
			if (remove_ao == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			db.Auctioned_object.Remove(remove_ao);
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

		private bool Auctioned_ObjectExists(int id)
		{
			return db.Auctioned_object.Count(e => e.idObject == id) > 0;
		}
	}
}