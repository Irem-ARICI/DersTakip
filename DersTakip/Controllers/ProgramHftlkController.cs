using DersTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace DersTakip.Controllers
{
    public class ProgramHftlkController : Controller
    {
        private readonly IProgramHftlkRepository programHftlkRepository;

		public ProgramHftlkController(IProgramHftlkRepository programHftlkRepository)
		{
			this.programHftlkRepository = programHftlkRepository;
		}

		public IActionResult Index()
        {
            List<ProgramHftlk> objProgramHftlkList = programHftlkRepository.GetAll().ToList();
            return View(objProgramHftlkList);

        }



    }
}
