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
	public class Sold_objectController : ApiController
	{

		public List<Sold_object> GetAll()
		{
			return Sold_objectDAO.Query();
		}

		public Sold_object Post(Sold_object todo)
		{
			return Sold_objectDAO.Insert(todo);
		}

		public Sold_object Get(int id)
		{
			return Sold_objectDAO.Get(id);
		}

		public IHttpActionResult Delete(int id)
		{
			if (Sold_objectDAO.Delete(id))
			{
				return Ok();
			}

			return BadRequest();
		}

		public IHttpActionResult Put(Sold_object todo)
		{
			if (Sold_objectDAO.Update(todo))
			{
				return Ok();
			}
			return BadRequest();
		}
	}
}