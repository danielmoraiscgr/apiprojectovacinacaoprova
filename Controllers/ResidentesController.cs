using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectoVacinacao.Model;
using ProjectoVacinacao.ViewModel;

namespace ProjectoVacinacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentesController : ControllerBase
    {

        private readonly Residente _residentes;

        public ResidentesController()
        {
            _residentes = new Residente();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_residentes.ListarResidentes());
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public ResidentesListaViewModel Get(int id)
        {
            try
            {
                var residente = _residentes.ListarResidentes().Where(r => r.DId == id).FirstOrDefault();

                var residenteViewModel = new ResidentesListaViewModel(
                    residente.DId,
                    residente.DNomeCompleto,
                    residente.DEmail,
                    residente.DTelefone);

                return residenteViewModel;
                
            }
            catch (Exception ex)
            {
                return null;

            }

        }

        [HttpPut("{id}")]
        public Residente Put(int id, [FromBody] Residente residente)
        {
            try
            {
                _residentes.AlterarResidente(id, residente);
                return residente;
                
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [HttpPost]
        public Residente Post([FromBody] Residente residente)
        {
            try
            {
                _residentes.InserirResidente(residente);
                return residente;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {         
            _residentes.DeletarResidente(id);
        
        }    


        
    }
}
