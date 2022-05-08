using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{Id}")]
        public async Task<ActionResult<ApiDto>> AccountById(int Id)
        {

            var spec = new FullAccount(Id);

            var acc = await accRepo.GetEntityWithSpec(spec);

            return mapper.Map<Account, ApiDto>(acc);


        }

    }
}
