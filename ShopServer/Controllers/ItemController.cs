
using Commons.Items;
using DoctorCSharpServer.Controllers.Manipulators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShopServer.Controllers.Exceptions;
using ShopServer.Controllers.Manipulators;
using ShopServer.Controllers.Producers;
using ShopServer.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopServer.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id,string name)
        {
            logRequest(Request);
            var selectedList = new SingleItemProducer(id).select();
            if (selectedList.Count() < 1)
            {
                Console.WriteLine("No Item found with the id " + id + "!");
                return BadRequest(new Response("No Item found with the id " + id + "!"));
            }
            else
            {
                return Ok(selectedList.First());
            }

        }
        [HttpGet]
        [Route("myitems")]
        public ActionResult<IEnumerable<User>> Get(string filter)
        {
            logRequest(Request);
            return Ok(new SingleMyItemProducer(filter).select());
        }
        [HttpGet]
        [Route("filtered")]
        public ActionResult<IEnumerable<Item>> Get(string filter,string tmp)
        {
            logRequest(Request);
            return Ok(new SingleFilterItemProducer(filter,tmp).select());
        }
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            logRequest(Request);
            return Ok(new ItemListProducer().select());
        }
        [HttpGet]
        [Route("getfirstitems")]
        public ActionResult<IEnumerable<Item>> Get(int id)
        {
            logRequest(Request);
            return Ok(new ItemListFirstTenProducer().select());
        }


        [HttpPost]
        public ActionResult<Response> Post([FromForm] SerializedItem newItem)
        {
            logRequest(Request);
            try
            {
                return new ItemCreator(newItem).execute();
            }
            catch (InvalidInputException e)
            {
                Console.WriteLine(e.message);
                return BadRequest(new Response(e.message));
            }

        }

        /*
        [HttpPut("active/{id}")]
        public ActionResult<Response> Put(int id, [FromForm] string diagnosis)
        {
            logRequest(Request);
            try
            {
                return new DiagnosisCreator(id, diagnosis).execute();
            }
            catch (InvalidInputException e)
            {
                Console.WriteLine(e.message);
                return BadRequest(new Response(e.message));
            }

        }
        */
        [HttpDelete("{id}")]
        public ActionResult<Response> Delete(int id)
        {
            logRequest(Request);
            try
            {
                return new ItemRemover(id).execute();
            }
            catch (InvalidInputException e)
            {
                Console.WriteLine(e.message);
                return BadRequest(new Response(e.message));
            }
        }

        private void logRequest(HttpRequest request)
        {
            Console.WriteLine("REST request\nMethod: " + request.Method + "\nPath: " + request.Path);
        }
        
    }
}

