using ApiEmpleadosMultiplesRutas.Data;
using NugetApiPaco.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpleadosMultiplesRutas.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await this.context.Empleados.ToListAsync();
        }

        public async Task<Empleado> FindEmpleadoAsync(int idempleado)
        {
            return await
                this.context.Empleados.FirstOrDefaultAsync
                (x => x.IdEmpleado == idempleado);
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return  await consulta.ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosOficioAsync(string oficio)
        {
            return await
                this.context.Empleados.Where(z => z.Oficio == oficio).ToListAsync();
        }

        public async Task<List<Empleado>> 
            GetEmpleadosSalarioAsync(int salario, int iddepartamento)
        {
            return await
                this.context.Empleados.Where(x => x.Salario >= salario
                && x.IdDepartamento == iddepartamento)
                .ToListAsync();
        }
    }
}
