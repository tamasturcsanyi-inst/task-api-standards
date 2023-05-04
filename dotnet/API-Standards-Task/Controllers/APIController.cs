using Microsoft.AspNetCore.Mvc;

namespace API_Standards_Task.Controllers
{
    [ApiController]
    public class APIController : ControllerBase
    {
        private List<string> SuperSecretData
        {
            get
            {
                return new List<string> {
                    "Algebra",
                    "Mathematics",
                    "Physics",
                    "Chemistry",
                    "Biology",
                    "Geology",
                    "Astronomy",
                    "Computer Science",
                    "Engineering",
                    "Environmental Science",
                    "Oceanography",
                    "Psychology",
                    "Sociology",
                    "Anthropology",
                    "Political Science",
                    "Economics",
                    "History",
                    "Philosophy",
                    "Literature",
                    "Linguistics",
                    "Fine Arts",
                    "Performing Arts",
                    "Music",
                    "Film Studies",
                    "Religious Studies",
                    "Gender Studies",
                    "Geography",
                    "Archaeology",
                    "Communication Studies",
                    "Education",
                    "Law"
                };
            }
        }

        public APIController()
        {
        }

        [HttpGet]
        [Route("~/api/v1/courses")]
        public IActionResult GetPaginatedListAsync([FromQuery] string cursor)
        {
            // Find at least 2 issues with this API endpoint
            return Ok(SuperSecretData.GetRange(SuperSecretData.IndexOf(cursor), 10));
        }

        [HttpGet]
        [Route("~/api/v1/classes-by-names/{id}")]
        public IActionResult GetAsync(string id)
        {
            // This touches the same data set as the previous API, find again at least 2 issues
            var item = SuperSecretData.FirstOrDefault(d => d.Equals(id));
            if (item != null)
            {
                return Ok(item);
            }

            return StatusCode(500, $"Item with id ({id}) was not found.");            
        }

        [HttpPost]
        [Route("~/api/v1/courses")]
        public IActionResult PostAsync(string item)
        {
            // Fix at least 1 issue with this API
            if (item == null)
            {
                return BadRequest($"The new item was null, adding it to our {nameof(SuperSecretData)} store failed.");
            }

            SuperSecretData.Add(item);
            return Ok("New item was added.");
        }
    }
}