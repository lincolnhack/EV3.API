using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EV3.API.Controllers
{
    public class EV3Controller : ApiController
    {
        [HttpGet]
        [Route("forward")]
        public HttpResponseMessage Forward()
        {
            SingletonBrick.Instance.Forward();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("back")]
        public HttpResponseMessage Back()
        {
            SingletonBrick.Instance.Back();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("left")]
        public HttpResponseMessage Left()
        {
            SingletonBrick.Instance.Left();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("right")]
        public HttpResponseMessage Right()
        {
            SingletonBrick.Instance.Right();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
