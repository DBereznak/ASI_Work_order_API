using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Work_Order_API.Data;
using Work_Order_API.DTOs;
using Work_Order_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Work_Order_API.Controllers
{
    [Route("api/workorder")]
    [ApiController]
    public class WorkOrdersController : ControllerBase
    {
        private readonly IWorkOrderRepo _repo;
        private readonly IMapper _mapper;
        public WorkOrdersController(IWorkOrderRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/workorder>
        /// <summary>
        /// Gets All work orders
        /// </summary>
        /// <returns>A list of Work Orders</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllWorkOrders()
        {
            var workOrders =  await _repo.GetAllWorkOrders();
            var response = _mapper.Map<IEnumerable<WorkOrderReadDto>>(workOrders);
            return Ok(response);
        }

        // GET api/workorder/5
        /// <summary>
        /// Get a work order by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name="GetWorkOrderByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWorkOrderByID(int id)
        {
            var workOrder = await _repo.GetWorkOrderByID(id);
            if(workOrder != null)
            {
                var response = _mapper.Map<WorkOrderReadDto>(workOrder);
                return Ok(response);
            }

            return NotFound();
        }

        // POST api/workorder
        /// <summary>
        /// Creates a new work order
        /// </summary>
        /// <param name="workOrderCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateWorkOrder([FromBody] WorkOrderCreateDto workOrderCreateDto)
        {
            if(workOrderCreateDto == null)
            {
                return BadRequest(ModelState);
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workOrderModel = _mapper.Map<WorkOrder>(workOrderCreateDto);
            await _repo.CreateWorkOrder(workOrderModel);

            await _repo.SaveChanges();

            var workOrderReadDto = _mapper.Map<WorkOrderReadDto>(workOrderModel);

            return CreatedAtRoute(nameof(GetWorkOrderByID), new {Id = workOrderReadDto.Id}, workOrderReadDto);
        }

        // PUT api/workorder/5
        /// <summary>
        /// Updates a book by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="workOrderUpdate"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateWorkOrder(int id, WorkOrderReadDto workOrderUpdate)
        {
            var workorder = _mapper.Map<WorkOrder>(workOrderUpdate);
            if (id < 1 || workOrderUpdate == null || id != workOrderUpdate.Id)
            {
                return BadRequest();
            }
            if(workorder == null)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }


            var success = await _repo.UpdateWorkOrder(workorder);

            if (!success)
            {
                return StatusCode(500, "Something went wrong");
            }
            return NoContent();
        }
        /// <summary>
        /// Deletes a work order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/workorder/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkOrder(int id)
        {
            var workorder = await _repo.GetWorkOrderByID(id);

            try
            {
                if (id < 1)
                {
                    return BadRequest();
                }
                if (workorder == null)
                {
                    return NotFound();
                }

                var success = await _repo.DeleteWorkOrder(workorder);
                if (!success)
                {
                    return StatusCode(500, "Something went wrong");
                }

                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }
    }
}
