using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreVanillaJs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("permitir")]
    public class AutomovilController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.CrudVanillaJsContext db = new Models.CrudVanillaJsContext())
            {
                var lst = (from d in db.Automovil
                           select d).ToList();

                return Ok(lst);
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Request.AutomovilRequest model)
        {
            using (Models.CrudVanillaJsContext db = new Models.CrudVanillaJsContext())
            {
                Models.Automovil oAutomovil = new Models.Automovil();
                oAutomovil.Marca = model.Marca;
                oAutomovil.Valor = model.Valor;
                db.Automovil.Add(oAutomovil);
                db.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.AutomovilEditRequest model)
        {
            using (Models.CrudVanillaJsContext db = new Models.CrudVanillaJsContext())
            {
                Models.Automovil oAutomovil = db.Automovil.Find(model.Id);
                oAutomovil.Marca = model.Marca;
                oAutomovil.Valor = model.Valor;
                db.Entry(oAutomovil).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Request.AutomovilEditRequest model)
        {
            using (Models.CrudVanillaJsContext db = new Models.CrudVanillaJsContext())
            {
                Models.Automovil oAutomovil = db.Automovil.Find(model.Id);
                db.Automovil.Remove(oAutomovil);
                db.SaveChanges();
            }

            return Ok();
        }
    }
}