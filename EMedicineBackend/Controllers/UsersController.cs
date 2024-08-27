using EMedicineBackend.Models;
using EMedicineBackend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EMedicineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        //CTOR
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registration")]
        public Response register(Users users)
        {
            Response response = new Response();
            DAL dal = new DAL();
            
            response = dal.register(users, _configuration);
            
            return response;
        }

        [HttpPost]
        [Route("login")]
        public Response login(string Email, string Password)
        {
            Response response = new Response();
            DAL dal = new DAL();

            response = dal.login(Email, Password, _configuration);

            return response;
        }

    }
}
