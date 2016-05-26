using QNA.DataSet;
using QNA.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Results;

namespace QNA.WebService.Controllers
{
    public class QNAController : ApiController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["QNADataContext"].ConnectionString;

        [HttpGet]
        [Route("api/qna/question")]
        public JsonResult<List<Question>> Question()
        {
            QNAData<Question> obj = new QNAData<Question>(connectionString);
            return Json(obj.GetAll());
        }

        [HttpGet]
        [Route("api/qna/question/{id}")]
        public JsonResult<Question> Question(int id)
        {
            QNAData<Question> obj = new QNAData<Question>(connectionString);
            return Json(obj.Get(id));
        }

        [HttpPost]        
        [Route("api/qna/question/add")]
        public JsonResult<bool> PostQuestion(Question ques) 
        {
            QNAData<Question> obj = new QNAData<Models.Question>(connectionString);
            return Json(obj.Create(ques));
        }

        [HttpPut]
        [Route("api/qna/question/edit/{id}")]
        public JsonResult<bool> PutQuestion(int id,Question ques)
        {
            QNAData<Question> obj = new QNAData<Models.Question>(connectionString);            
            return Json(obj.Update<QuestionOption>(ques, id));
        }
    }
}
