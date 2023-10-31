using Microsoft.AspNetCore.Cors; // EnableCors attributesini kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalApiProject.DAL.Context;
using TraversalApiProject.DAL.Entities; // Visitor sınıfını kullanabilmek için ekledik

namespace TraversalApiProject.Controllers
{
    [EnableCors] // startup tarafında eklenen ifadeleri kullanabilmek için yazdık
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var c = new VisitorContext())
            {
                var values = c.Visitors.ToList(); // Visitor propertylerini iste haline çevirdi
                /* view yok onun yerine OK kullanıyoruz*/
                return Ok(values);
            }
        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor vst)
        {
            using(var c=new VisitorContext())
            {
                c.Add(vst);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("{id}")] /* id demez isek tüm parametreleri getirir sadece verilen id değerine göre getirmesi için id değeri verdik parametre olarak*/
        public IActionResult VisitorGet(int id)
        {
            using (var c = new VisitorContext())
            {
                var values = c.Visitors.Find(id);
                if(values==null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(values);
                }
            }
        }
        [HttpDelete("{id}")] // silme için
        public IActionResult VisitorDelete(int id)
        {
            using (var c = new VisitorContext())
            {
                var values = c.Visitors.Find(id);
                if(values==null)
                {
                    return NotFound();
                }
                else
                {
                    c.Remove(values);
                    c.SaveChanges();
                    return Ok();
                }
                
            }
        }
        [HttpPut] // güncelleme için
        public IActionResult VisitorUpdate(Visitor v)
        {
            using (var c = new VisitorContext())
            {
                var values = c.Find<Visitor>(v.VisitorID);
                if(values==null)
                {
                    return NotFound();
                }
                else
                {
                    values.City = v.City;
                    values.Country = v.Country;
                    values.Name = v.Name;
                    values.Surname = v.Surname;
                    values.Mail = v.Mail;
                    c.Update(values);
                    c.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
