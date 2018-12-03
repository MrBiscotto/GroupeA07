using System.Collections.Generic;
using System.Web.Http;
using GroupeA07.DAO;
using GroupeA07.Models;

namespace GroupeA07.Controllers
{
	public class MemberController : ApiController
	{

		public List<Member> GetAll()
		{
			return MemberDAO.Query();
		}

		public Member Post(Member todo)
		{
			return MemberDAO.Insert(todo);
		}

		public Member Get(int id)
		{
			return MemberDAO.Get(id);
		}

		public IHttpActionResult Delete(int id)
		{
			if (MemberDAO.Delete(id))
			{
				return Ok();
			}

			return BadRequest();
		}

		public IHttpActionResult Put(Member todo)
		{
			if (MemberDAO.Update(todo))
			{
				return Ok();
			}
			return BadRequest();
		}
	}
}