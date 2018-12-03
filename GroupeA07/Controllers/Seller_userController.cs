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
	public class Seller_userController : ApiController
	{

		public List<Seller_user> GetAll()
		{
			return Seller_userDAO.Query();
		}

		public Seller_user Post(Seller_user todo)
		{
			return Seller_userDAO.Insert(todo);
		}

		public Seller_user Get(int id)
		{
			return Seller_userDAO.Get(id);
		}

		public IHttpActionResult Delete(int id)
		{
			if (Seller_userDAO.Delete(id))
			{
				return Ok();
			}

			return BadRequest();
		}

		public IHttpActionResult Put(Seller_user todo)
		{
			if (Seller_userDAO.Update(todo))
			{
				return Ok();
			}
			return BadRequest();
		}
	}
}