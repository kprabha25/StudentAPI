using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using StudentAP.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Threading;

//Install-Package Microsoft.AspNet.Cors -Version 5.0.0
namespace StudentAP.Controllers
{
    public class StudentsController : ApiController
    {
        private StudentDbContext db = new StudentDbContext();

        // GET api/<controller>
        
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return db.Students.AsEnumerable();
        }

        // GET api/<controller>/5
        public Student Get(int id)
        {
            Student Student = db.Students.Find(id);
            if (Student == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Student;
        }
        [HttpPost]
        public Student Search(string ba, Student Student)
        {
            string a = "";
            db.Students.Add(Student);
            db.SaveChanges();
            return Student;
        }       
        [HttpGet]
        public Int64 Add(int a, int b) {

            Thread.Sleep(5000);
            return a + b;
        }        
        [HttpGet]
        public Int32 Multiply (int c, int d) {
            Thread.Sleep(5000);
            return (c * d);
        }

        // POST api/<controller>
        
        public HttpResponseMessage Post(Student Student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(Student);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, Student);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = Student.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Student Student)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != Student.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(Student).State = EntityState.Modified;

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

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            Student Student = db.Students.Find(id);
            if (Student == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Students.Remove(Student);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Student);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
