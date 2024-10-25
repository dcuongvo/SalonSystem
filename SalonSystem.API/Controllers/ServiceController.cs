using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.Services;
using SalonSystem.Services;

namespace ServiceSystem.API.Controllers  
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase 
    {
        private readonly ServiceService _serviceService;

        public ServiceController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        //GET http request to get all techncians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetAllService()
        {
            var services = await _serviceService.GetAllServicesAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetServiceById(int id) 
        {
            var service = await _serviceService.GetServiceByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            } 
            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<Service>> AddService(Service service)
        {
            var newService = await _serviceService.AddServiceAsync(service);                                       
            return CreatedAtAction(nameof(GetServiceById), new {id = newService.ServiceId}, newService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, Service service) 
        {
            if (id != service.ServiceId) 
            {
                return BadRequest();
            }

            var updatedService = await _serviceService.UpdateServiceAsync(id,service);
            if (updatedService == null) 
            {
                return NotFound();
            }
            return NoContent();
            //return Ok(updatedService)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var result = await _serviceService.DeleteServiceAsync(id);
            if (!result) 
            {
                return NotFound();
            }
            return NoContent();
            //return Ok()?
        }

    } 
}