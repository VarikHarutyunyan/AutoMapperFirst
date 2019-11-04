using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperRunTest.Dto;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperRunTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMapper _mapper;

        private Context context;

        // Assign the object in the constructor for dependency injection
        public ValuesController(IMapper mapper, Context context)
        {
            this.context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Gett()
        {

            // Instantiate source object
            // (Get it from the database or whatever your code calls for)
            User user = await context.Users.SingleOrDefaultAsync(u => u.Id == 1);

            UserDto model = _mapper.Map<UserDto>(user);

            // .... Do whatever you want after that!
            return model;
        }

        [Route("Sett")]
        public ActionResult<User> Set()
        {
            UserDto insert = new UserDto()
            {
                
                Name = "aaaaaaaaaaaaaaaaaa"
            };
            // Instantiate source object
            // (Get it from the database or whatever your code calls for)

            User model = _mapper.Map<User>(insert);

            context.Users.Add(model);
            context.SaveChanges();
            // .... Do whatever you want after that!
            return model;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<UserDto>> Get()
        {
            UserDto userDto = await Gett();
            return userDto;
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5

    }
}
