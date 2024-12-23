using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiHelloWorld.Controllers
{
    // 어튜리뷰트 라우팅(라우팅이라는 특성을 이용한 토큰 사용)
    [Route("api/[controller]")]
    [ApiController]
    public class ApiHelloWorldController : ControllerBase
    {
        // GET: api/<ApiHelloWorldController>
        [HttpGet]
        public IEnumerable<Value> Get()
        {
            //return new string[] { "안녕하세용", "반갑습니당" };
            return new Value[]
            {
                new Value{Id = 1, Text = "안녕하세용"},
                new Value{Id = 2, Text = "홍길동입니당"}
            };
        }

        // 라우트 매개변수
        // 인라인 제약조건 -> int형으로 라우팅 매개변수 제한
        // GET api/<ApiHelloWorldController>/5
        [HttpGet("{id:int}")]
        public Value Get(int id)
        {
            //return $"넘어온 값 {id}";
            return new Value { Id = id, Text = $"넘어온 값 {id}" };
        }

        // POST api/<ApiHelloWorldController>
        [HttpPost]
        public IActionResult Post([FromBody] Value value)
        {
            // 모델 유효성 검사
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 에러 출력
            }

            // 넘어온 json 데이터를 처리 후 id 반환
            return CreatedAtAction("Get", new { id = value.Id }, value);
        }

        // PUT api/<ApiHelloWorldController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiHelloWorldController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    // 새로운 클래스 Value를 만들어서 Value 타입으로 데이터를 전송 (xml, json 형태)
    public class Value
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Text 속성은 필수 입력 값입니다")]
        public string Text { get; set; }
    }
}
