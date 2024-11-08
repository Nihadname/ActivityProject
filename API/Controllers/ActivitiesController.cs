using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;
namespace API.Controllers
{
    public class ActivitiesController:BaseApiController
    {
        private readonly DataContext _dataContext;

        public ActivitiesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public  async Task<ActionResult<List<Activity>>> GetActivities(){
return await _dataContext.Activities.ToListAsync();
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetActivityById(Guid Id){
            
            var ExistedActivity=await _dataContext.Activities.FirstOrDefaultAsync(s=>s.Id==Id);
            if(ExistedActivity is null) return NotFound();
            return  Ok(ExistedActivity);
        }
    }
}