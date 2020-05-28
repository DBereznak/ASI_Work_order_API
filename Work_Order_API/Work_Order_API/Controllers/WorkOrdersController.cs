using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        [HttpGet]
        public ActionResult<IEnumerable<WorkOrderReadDto>> GetAllWorkOrders()
        {
            var workOrders = _repo.GetAllWorkOrders();
            return Ok(_mapper.Map<IEnumerable<WorkOrderReadDto>>(workOrders));
        }

        // GET api/workorder/5
        [HttpGet("{id}", Name="GetWorkOrderByID")]
        public ActionResult <WorkOrderReadDto> GetWorkOrderByID(int id)
        {
            var workOrder = _repo.GetWorkOrderByID(id);
            if(workOrder != null)
            {
                return Ok(_mapper.Map<WorkOrderReadDto>(workOrder));
            }

            return NotFound();
        }

        // POST api/workorder
        [HttpPost]
        public ActionResult <WorkOrderReadDto> CreateWorkOrder(WorkOrderCreateDto workOrderCreateDto)
        {
            var workOrderModel = _mapper.Map<WorkOrder>(workOrderCreateDto);
            _repo.CreateWorkOrder(workOrderModel);
            _repo.SaveChanges();

            var workOrderReadDto = _mapper.Map<WorkOrderReadDto>(workOrderModel);

            return CreatedAtRoute(nameof(GetWorkOrderByID), new {Id = workOrderReadDto.Id}, workOrderReadDto);
        }

        // PUT api/workorder/5
        [HttpPut("{id}")]
        public ActionResult UpdateWorkOrder(int id, WorkOrderUpdateDto workOrderUpdate)
        {
            var model = _repo.GetWorkOrderByID(id);
            if(model == null)
            {
                return NotFound();
            }

            _mapper.Map(workOrderUpdate, model);
            _repo.UpdateWorkOrder(model);
            _repo.SaveChanges();

            return NoContent();
        }

        // DELETE api/workorder/5
        [HttpDelete("{id}")]
        public ActionResult DeleteWorkOrder(int id)
        {
            var model = _repo.GetWorkOrderByID(id);

            if(model == null)
            {
                return NotFound();
            }

            _repo.DeleteWorkOrder(model);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}
