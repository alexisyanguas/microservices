using System.Text;
using Api.Reservation.Business.Models;
using Api.Reservation.Business.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        // TODO

        /// <summary>
        /// The reservation service
        /// </summary>
        private readonly IUtilisateurService _utilisateurService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationsController"/> class.
        /// </summary>
        /// <param name="utilisateurService">The reservation service.</param>
        public UtilisateursController(IUtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

        // GET: api/<UtilisateursController>
        [HttpGet]
        public async Task<IActionResult> GetUtilisateursAsync()
        {
            return Ok(await _utilisateurService.GetUtilisateursAsync());
        }

        // GET api/<UtilisateursController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUtilisateurByIdAsync(int id)
        {
            return Ok(await _utilisateurService.GetUtilisateurByIdAsync(id));
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(Datas.Entities.Utilisateur), 200)]
        public async Task<IActionResult> CreateUtilisateurAsync([FromBody] CreateUtilisateurDto utilisateur)
        {
            try
            {
                var utilisateurToCreate = new Datas.Entities.Utilisateur()
                {
                    Nom = utilisateur.Nom,
                    Prenom = utilisateur.Prenom,
                    Email = utilisateur.Email,
                    DateNaissance = utilisateur.DateNaissance,
                };

                return Ok(await _utilisateurService.CreateUtilisateurAsync(utilisateurToCreate));
            }
            catch (Exception e) { return Problem(e.Message, e.StackTrace); }
        }



        // PUT api/<UtilisateursController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UtilisateursController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
