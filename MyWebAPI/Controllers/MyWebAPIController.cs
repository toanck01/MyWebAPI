using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using MyWebAPI.Models.Dto;
using MyWebAPI.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyWebAPI.Controllers
{
    
    [Route("api/MyWebAPI")]
    [ApiController]
    public class MyWebAPIController:ControllerBase
    {
        private readonly ApplicationDBContext _db;
        

        public MyWebAPIController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<MyWeb>> GetMyWeb()
        {
            return Ok(_db.MyWebs.ToList());
            
        }
        [HttpGet("{id:int}", Name ="GetMyWeb")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MyWebDTO> GetMyWeb(int id)
        {
            if(id==0)
            {
                
                return BadRequest();
            }
            var myweb = _db.MyWebs.FirstOrDefault(u=>u.Id==id);
            if (myweb == null)
                return NotFound();
            return Ok(myweb);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MyWebDTO> CreateMyWeb([FromBody]MyWebDTO a)
        {
            if(_db.MyWebs.FirstOrDefault(u=>u.Name.ToLower()==a.Name.ToLower())!=null)
            {
                ModelState.AddModelError("CustomError", "Myweb already Exists!");
                return BadRequest(ModelState);
            }
            if(a==null)
            {
                return BadRequest(a);
            }
            if(a.Id>0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            MyWeb b = new()
            {
                Name=a.Name,
            };

            _db.MyWebs.Add(b);
            _db.SaveChanges();
            return CreatedAtRoute("GetMyWeb",new {id=a.Id},a);
          
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:int}", Name = "DeleteMyWeb")]
        public IActionResult DeleteMyWeb(int id)
        {
            if(id==0)
            {
                return BadRequest();

            }
            var a = _db.MyWebs.FirstOrDefault(u => u.Id == id);
            if(a==null)
            {
                return NotFound();
            }
            _db.MyWebs.Remove(a);
            _db.SaveChanges();
            return NoContent();
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id:int}", Name ="UpdateMyWeb")]
        public IActionResult UpdateMyWeb(int id, [FromBody] MyWebDTO a)
        {
            if(a==null|| id!=a.Id)
            {
                return BadRequest();
            }
            MyWeb b = new()
            {
                Name = a.Name
            };
            _db.MyWebs.Update(b);
            _db.SaveChanges();
            return NoContent();
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("{id:int}", Name = "UpdatePartialMyWeb")]
        public IActionResult UpdatePartialMyWeb(int id, JsonPatchDocument<MyWebDTO> a)
        {
            if(a==null|| id==0)
            {
                return BadRequest();
            }
            var b = _db.MyWebs.FirstOrDefault(u => u.Id == id);
            MyWebDTO c = new()
            {
                Name = b.Name
            };
            
            if (b==null)
            {
                return BadRequest();
            }
            a.ApplyTo(c, ModelState);
            MyWeb model = new()
            {
                Name = c.Name
            };
            _db.MyWebs.Update(model);
            _db.SaveChanges();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
