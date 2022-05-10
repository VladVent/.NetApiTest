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

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ApiDto>>> GetGames()
        {
            var spec = new FullAccount();

            var acc = await accRepo.ListAsync(spec);

            return Ok(mapper
                .Map<IReadOnlyList<Account>, IReadOnlyList<ApiDto>>(acc));
        }

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

      [HttpPut("account/{name}")]
        public string UpdateContact([FromBody]Contact contact, string name)
        {
            return accRepo.UpdateContacts(contact, name);
        }

    }
}
