using ApiCoreCrudDoctores.Models;
using ApiCoreCrudDoctores.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDoctores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private RepositoryDoctores repo;

        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> Get()
        {
            return await this.repo.GetDoctoresAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> FindDoctor(int id)
        {
            return await this.repo.FindDoctorAsync(id);
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<ActionResult<List<string>>> Hospitales()
        {
            return await this.repo.GetHospital();
        }

        [HttpGet]
        [Route("[action]/{hospital}")]
        public async Task<ActionResult<List<Doctor>>>
            DoctoresHospital(string nombreHospital)
        {
            return await this.repo.GetDoctoresHospitalAsync(nombreHospital);
        }

        [HttpGet]
        [Route("[action]/{salario}/{iddoctor}")]
        public async Task<ActionResult<List<Doctor>>>
            DoctorHospital(int salario, int iddoctor)
        {
            return await
                this.repo.GetDoctoresSalarioAsync(salario, iddoctor);
        }

    

    [HttpPost]
        public async Task<ActionResult>
         InsertDoctor(Doctor doctor)
        {
            await this.repo.InsertarDoctor
                (doctor.IdHospital, doctor.IdDoctor, doctor.Apellido,
                doctor.Especialidad , doctor.Salario);
            return Ok();
        }



        [HttpPost]
        [Route("[action]/{idhospital}/{iddoctor}/{apellido}/{especialidad}/{salario}")]
        public async Task<ActionResult>
            InsertarDoctor(Doctor doctor)
        {
            await this.repo.InsertarDoctor(doctor.IdHospital, doctor.IdDoctor,
                doctor.Apellido, doctor.Especialidad,doctor.Salario);
            return Ok();
        }

        [HttpPut]

        public async Task<ActionResult> UpdateDoctor(Doctor doctor)
        {
            await this.repo.UpdateDoctorAsync(doctor.IdHospital, doctor.IdDoctor,
                doctor.Apellido, doctor.Especialidad, doctor.Salario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctores(int id)
        {
            await this.repo.DeleteDoctorAsync(id);
            return Ok();
        }
    }
}
