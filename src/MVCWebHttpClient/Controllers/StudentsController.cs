using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MVCWebCodeByMadi.Controllers
{
    public class StudentsController : Controller
    {
        RESTApi _studentAPI = new RESTApi();

        public async Task<IActionResult> Index()
        {
            List<StudentDTO> dto = new List<StudentDTO>();

            HttpClient client = _studentAPI.InitializeClient();

            HttpResponseMessage res = await client.GetAsync("api/students");

            //Checking the response is successful or not which is sent using HttpClient    
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api     
                var result = res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list    
                dto = JsonConvert.DeserializeObject<List<StudentDTO>>(result);

            }
            //returning the list to view    
            return View(dto);
        }



        // GET: Students/Create  
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StudentId,FirstName,LastName,PhoneNumber,Email,Address,City,Zip")] StudentDTO student)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _studentAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("api/students", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(student);
        }

        // GET: Students/Edit/1  
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<StudentDTO> dto = new List<StudentDTO>();
            HttpClient client = _studentAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("api/students");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<List<StudentDTO>>(result);
            }

            var student = dto.SingleOrDefault(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Edit/1  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("StudentId,FirstName,LastName,PhoneNumber,Email,Address,City,Zip")] StudentDTO student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _studentAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PutAsync("api/students/{id}", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(student);
        }

        // GET: Students/Delete/1  
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<StudentDTO> dto = new List<StudentDTO>();
            HttpClient client = _studentAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("api/students");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<List<StudentDTO>>(result);
            }

            var student = dto.SingleOrDefault(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            HttpClient client = _studentAPI.InitializeClient();
            HttpResponseMessage res = client.DeleteAsync($"api/students/{id}").Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }

    }
}