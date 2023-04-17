using ApiCoreCrudDoctores.Data;
using ApiCoreCrudDoctores.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiCoreCrudDoctores.Repositories
{
    public class RepositoryDoctores
    {
        private DoctoresContext context;

        public RepositoryDoctores(DoctoresContext context)
        {
            this.context = context;
        }

        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            return await this.context.Doctores.ToListAsync();
        }

        public async Task<Doctor> FindDoctorAsync(int id)
        {
            return await
                this.context.Doctores
                .FirstOrDefaultAsync(x => x.IdDoctor == id);
        }
        

        public async Task<List<string>> GetHospital()
        {
            var consulta = (from datos in this.context.Hospitales
                            select datos.Nombre).Distinct();
            return await consulta.ToListAsync();
        }

        public async Task<List<Doctor>> GetDoctoresHospitalAsync(string nombreHospital)
        {
            Hospital hosp = await this.context.Hospitales.FirstOrDefaultAsync(x => x.Nombre == nombreHospital);
            return await
                this.context.Doctores.Where(z => z.IdHospital == hosp.IdHospital).ToListAsync();
        }

        public async Task<List<Doctor>> GetDoctoresSalarioAsync(int salario, int iddoctor)
        {
            return await
                this.context.Doctores.Where(x => x.Salario >= salario
                && x.IdDoctor == iddoctor)
                .ToListAsync();
        }


        public async Task InsertarDoctor(int idHospital, int idDoctor,
           string apellido, string especialidad, int salario)
        {
            Doctor doctor = new Doctor();
            doctor.IdHospital = idHospital;
            doctor.IdDoctor = idDoctor;
            doctor.Apellido = apellido;
            doctor.Especialidad = especialidad;
            doctor.Salario = salario;
            this.context.Doctores.Add(doctor);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateDoctorAsync(int idHospital, int idDoctor,
           string apellido, string especialidad, int salario)
        {
            Doctor doctor = await this.FindDoctorAsync(idDoctor);

            doctor.IdHospital = idHospital;
            doctor.Apellido = apellido;
            doctor.Especialidad = especialidad;
            doctor.Salario = salario;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            Doctor doctor = await this.FindDoctorAsync(id);
            this.context.Doctores.Remove(doctor);
            await this.context.SaveChangesAsync();
        }

    }
}
