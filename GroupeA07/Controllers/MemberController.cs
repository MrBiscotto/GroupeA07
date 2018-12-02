using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GroupeA07.Models;

namespace GroupeA07.Controllers
{
	public class MemberController : ApiController
	{

		private bddEntities db = new bddEntities();
		
		// GET: api/Member  
		public IQueryable<Member> GetMembers()
		{
			return db.Member;

		}



		// PUT: api/Member/5  

		public HttpResponseMessage PutMember(Member member)
		{
			if (!ModelState.IsValid)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}


			db.Entry(member).State = EntityState.Modified;

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

		// POST: api/Member  

		public HttpResponseMessage PostMember(Member member)
		{
			if (!ModelState.IsValid)
			{
				db.Member.Add(member);
				db.SaveChanges();
				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, member);
				response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = member.idUser }));
				return response;
			}
			else
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}

		}

		// DELETE: api/Member/5  

		public HttpResponseMessage DeleteMember(Member member)
		{
			Member remove_member = db.Member.Find(member.idUser);
			if (remove_member == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			db.Member.Remove(remove_member);
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

		private bool MemberExists(int id)
		{
			return db.Member.Count(e => e.idUser == id) > 0;
		}
	}
}