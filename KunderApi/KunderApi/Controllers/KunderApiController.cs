using System;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using KunderApi.Models;
using System.Globalization;

namespace KunderApi.Controllers
{
    public class KunderApiController : ApiController
    {

        public IHttpActionResult PostHello([FromBody]object data){
            int numeric;
            if (data == null) { return BadRequest("Error : La peticion No Trae Valores"); }
            var d = JsonConvert.DeserializeObject<RespuestaPOST>(data.ToString());
            RespuestaPOST r = new RespuestaPOST();
            bool nn = int.TryParse(d.data.ToString(), out numeric);
            if(nn){
                throw new HttpException(400, "Bad Request - Debe ser string");
                //return BadRequest();
            }else{
                r.code = "00";
                r.data = d.data.ToUpper();
                r.description = "OK";
            }
            return Ok(r);
        }


        [System.Web.Http.AcceptVerbs("GET")]
        public IHttpActionResult GetTime([FromBody] object h){
            if (h == null) { return BadRequest("Error: La peticion No Trae Valores"); }
            var hora = JsonConvert.DeserializeObject<RespuestaGET>(h.ToString());
            RespuestaGET rg = new RespuestaGET();
            ;
            DateTime t;
            DateTime.TryParseExact(hora.Time.ToString(), "s", CultureInfo.InvariantCulture,DateTimeStyles.AssumeUniversal, out t);
            rg.Time = t;
            return Ok(rg);
        }

    }
}
