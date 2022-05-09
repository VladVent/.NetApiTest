using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC.DAL.Context;
using MVC.DAL.Entities;
using MVC.DAL.Interfaces;
using MVC.DAL.Specification;
using MVCApi.Dto;

namespace MVCApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IGenericRepository<Account> accRepo;
        private readonly IGenericRepository<Incident> incedRepo;
        private readonly IGenericRepository<Contact> contRero;
        private readonly IMapper mapper;

        public HomeController(IGenericRepository<Account> accRepo, IGenericRepository<Incident> incedRepo, IGenericRepository<Contact> contRero, IMapper mapper)
        {
            this.accRepo = accRepo;
            this.incedRepo = incedRepo;
            this.contRero = contRero;
            this.mapper = mapper;
        }

        //public async Task<IActionResult> Incedents(ApiDto _api)
        //{

        //    var incident = new Incident
        //    {
        //        Accounts = new List<Account>
        //     {
        //     new Account
        //     {
        //         AccountName = _api.AccountName,
        //         Contact = new List<Contact>
        //         {
        //             new Contact
        //             {
        //                 ContactFirstName = _api.ContactFirstName,
        //                 ContactLastName = _api.ContactLastName,
        //                 ContactEmail = _api.ContactEmail,
        //             }
        //         },
        //     }
        // }
        //    };
        //    return Ok(_api);
        //}

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ApiDto>>> GetGames()
        {
            var spec = new FullAccount();

            var acc = await accRepo.ListAsync(spec);

            return Ok(mapper
                .Map<IReadOnlyList<Account>, IReadOnlyList<ApiDto>>(acc));
        }

        /* [HttpGet("{Id}")]
         public async Task<ActionResult<ApiDto>> AccountById(int Id)
         {

             var spec = new FullAccount(Id);

             var acc = await accRepo.GetEntityWithSpec(spec);

             return mapper.Map<Account, ApiDto>(acc);


         }*/

        [HttpGet("account/{name}")]
        public async Task<ActionResult<ApiDto>> GetAccountByName(string name)
        {
            var spec = new FullAccount(name);

            var acc = await accRepo.GetAccountByName(spec);
            if (acc == null)
            {
                return NotFound();
            }
                return mapper.Map<Account, ApiDto>(acc);

        }

      

    }
}
