using ApiAgendaTupBrande.Data.Repository.Interfaces;
using ApiAgendaTupBrande.Entities;
using ApiAgendaTupBrande.Models.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgendaTupBrande.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        //A traves de inyecion de dependencia podemos utilizar el contexto
        public FavoriteController(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ContactDTO contactDto)
        {
            try
            {
                // Hacemos el Mappeo
                var contact = _mapper.Map<Contact>(contactDto);

                if (id != contact.Id)
                {
                    return BadRequest();
                }

                var contactItem = await _contactRepository.GetContactById(contact.Id);

                if (contactItem != null)
                {
                    return NotFound();
                }

                await _contactRepository.AddFavorite(contact);

                return Ok(new { message = "Favorito agregado" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
