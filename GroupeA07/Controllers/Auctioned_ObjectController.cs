using GroupeA07.DAO;
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
		public List<Auctioned_object> GetAll()
		{
			return Auctioned_ObjectDAO.Query();
		}

		public Auctioned_object Post(Auctioned_object todo)
		{
			return Auctioned_ObjectDAO.Insert(todo);
		}

		public Auctioned_object Get(int id)
		{
			return Auctioned_ObjectDAO.Get(id);
		}

		public IHttpActionResult Delete(int id)
		{
			if (Auctioned_ObjectDAO.Delete(id))
			{
				return Ok();
			}

			return BadRequest();
		}

		public IHttpActionResult Put(Auctioned_object todo)
		{
			if (Auctioned_ObjectDAO.Update(todo))
			{
				return Ok();
			}
			return BadRequest();
		}
	}
}