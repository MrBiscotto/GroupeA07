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
	public class ModeratorController : ApiController
	{

		public List<Moderator> GetAll()
		{
			return ModeratorDAO.Query();
		}

		public Moderator Post(Moderator todo)
		{
			return ModeratorDAO.Insert(todo);
		}

		public Moderator Get(int id)
		{
			return ModeratorDAO.Get(id);
		}

		public IHttpActionResult Delete(int id)
		{
			if (ModeratorDAO.Delete(id))
			{
				return Ok();
			}

			return BadRequest();
		}

		public IHttpActionResult Put(Moderator todo)
		{
			if (ModeratorDAO.Update(todo))
			{
				return Ok();
			}
			return BadRequest();
		}
	}
}