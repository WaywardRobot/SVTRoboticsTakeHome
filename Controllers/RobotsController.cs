using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RestSharp;

namespace SVTRoboticsTakeHome.Controllers
{
    [ApiController]
    [Route("api/robots")]
    public class RobotsController : ControllerBase
    {

        private readonly ILogger<RobotsController > _logger;

        public RobotsController(ILogger<RobotsController > logger)
        {
            _logger = logger;
        }

        [HttpPost("closest")]
        public IActionResult Closest([FromBody]Load load)
        {

          //If the request is missing a body, it will throw Unsupported Media Type before here but checking for a null load just in case.
          if (load == null) {
            return BadRequest("Load data required.");
          }

          //Fetch the list of robots from the server
          Robot[] robots = Get();

          if (robots.Count<Robot>() > 0) {
            Robot closestRobot = load.findClosestRobot(robots);
            return Ok(new ClosestResponse(load, closestRobot));
          } else {
            //There were no robots
            return NoContent();
          }

        }

        //Dev Note: Though a robots get wasn't requested, I included one for easier testing.
        [HttpGet]
        public Robot[] Get()
        {
          var client = new RestClient("https://60c8ed887dafc90017ffbd56.mockapi.io/");

          var request = new RestRequest("robots");
          Robot[] response = client.Get<Robot[]>(request);

          return response;
        }

    }

  [Serializable]
  public partial class ClosestResponse
  {
    public int robotId { get; set; }
    public int batteryLevel { get; set; }
    public double distanceToGoal { get; set; }
    public ClosestResponse(Load load, Robot robot)
    {
      robotId = robot.robotId;
      batteryLevel = robot.batteryLevel;
      distanceToGoal = robot.distanceToGoal(load.x, load.y);
    }
  }
}
