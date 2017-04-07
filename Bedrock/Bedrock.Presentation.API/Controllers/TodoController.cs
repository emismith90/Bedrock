using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bedrock.Application.Model;
using Bedrock.Application.Services.Abstract.Sample;

namespace Bedrock.API.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<TodoModel> Get()
        {
            return _todoService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TodoModel Get(Guid id)
        {
            return _todoService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]TodoModel todo)
        {
            _todoService.Add(todo);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, TodoModel todo)
        {
            _todoService.Update(todo);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _todoService.Remove(id);
        }
    }
}
