using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult GetItems()
        {
            List<Models.ITEM> lstItem = new List<Models.ITEM>();
            using (Models.PODbEntities poEntities = new Models.PODbEntities())
            {
                lstItem = poEntities.ITEMs.ToList();
            }

            if (lstItem.Count == 0)
            {
                return NotFound();
            }

            return Ok(lstItem);
        }

        // GET api/values/5
        public IHttpActionResult GetItem(int id)
        {
            Models.ITEM itemObject = null;
            using (Models.PODbEntities poEntities = new Models.PODbEntities())
            {
                itemObject = poEntities.ITEMs.Where(w => w != null && w.ITCODE.Equals(id)).FirstOrDefault();
            }

            return Ok(itemObject);
        }

        // POST api/values
        public IHttpActionResult PostItem([FromBody]string code, string desc, string rate)
        {
            using (Models.PODbEntities poEntities = new Models.PODbEntities())
            {
                poEntities.ITEMs.Add(new Models.ITEM() { ITCODE = code, ITDESC = desc, ITRATE = Convert.ToDecimal(rate) });
                poEntities.SaveChanges();
            }
            return Ok();
        }

        // PUT api/values/5
        public IHttpActionResult PutItem(int id, [FromBody]string code, string desc, string rate)
        {
            using (Models.PODbEntities poEntities = new Models.PODbEntities())
            {
                var existingItem = poEntities.ITEMs.Where(w => w != null && w.ITCODE.Equals(id)).FirstOrDefault();
                if (existingItem != null)
                {
                    existingItem.ITCODE = code;
                    existingItem.ITDESC = desc;
                    existingItem.ITRATE = Convert.ToDecimal(rate);
                }
                poEntities.SaveChanges();
            }

            return Ok();
        }

        // DELETE api/values/5
        public IHttpActionResult DeleteItem(int id)
        {
            using (Models.PODbEntities poEntities = new Models.PODbEntities())
            {
                var existingItem = poEntities.ITEMs.Where(w => w != null && w.ITCODE.Equals(id)).FirstOrDefault();
                poEntities.Entry(poEntities.ITEMs).State = System.Data.Entity.EntityState.Deleted;
                poEntities.SaveChanges();
            }

            return Ok();
        }
    }
}
