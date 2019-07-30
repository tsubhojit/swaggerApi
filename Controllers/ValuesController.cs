using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
       public static List<string> str =new List<string>{"AWS","ICP","AZURE","GCP","RHOS","Lightbend"};
        // string [] str =new string[]{"AWS","ICP","AZURE","GCP","RHOS","Lightbend"};

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return str;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        { 
                        
            if(id>5){
                return "The value is not in range";
            }
            return str[id];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            if(!string.IsNullOrEmpty(value))
            {
               str.Add(value);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            str[id]=value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            str.RemoveAt(id);
        }
    }
}
