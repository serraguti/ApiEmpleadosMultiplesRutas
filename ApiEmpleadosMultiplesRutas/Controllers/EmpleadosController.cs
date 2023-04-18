using ApiEmpleadosMultiplesRutas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetApiPaco.Models;
using System.Runtime.CompilerServices;

namespace ApiEmpleadosMultiplesRutas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private RepositoryHospital repo;

        public EmpleadosController(RepositoryHospital repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> GetEmpleados()
        {
            return await this.repo.GetEmpleadosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> FindEmpleado(int id)
        {
            return await this.repo.FindEmpleadoAsync(id);
        }

        //api/empleados/oficios
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<string>>> Oficios()
        {
            return await this.repo.GetOficiosAsync();
        }

        [HttpGet]
        [Route("[action]/{oficio}")]
        public async Task<ActionResult<List<Empleado>>>
            EmpleadosOficio(string oficio)
        {
            return await this.repo.GetEmpleadosOficioAsync(oficio);
        }

        [HttpGet]
        [Route("[action]/{salario}/{iddepartamento}")]
        public async Task<ActionResult<List<Empleado>>>
            EmpleadosSalario(int salario, int iddepartamento)
        {
            return await
                this.repo.GetEmpleadosSalarioAsync(salario, iddepartamento);
        }
    }
}
