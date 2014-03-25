using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service.Model;

namespace Service.Controllers
{
    public class QuestionController : BaseApiController<Question>
    {
        public IEnumerable<Question> GetAllQuestions()
        {
            return GetAll();
        }

        public Question GetQuestion(int id)
        {
            return GetFirstByExpression(x=>x.QuestionId==id);
        }

        public HttpResponseMessage PostQuestion(Question question)
        {
            var loadObject = GetFirstByExpression(x => x.DisplayText.Equals(question.DisplayText));
            if(loadObject!=null)
                throw new HttpResponseException(HttpStatusCode.Ambiguous);
            return AddObject(question);            
        }

        public HttpResponseMessage DeleteQuestion(Question question)
        {
            return Delete(question);
        }
    }
}
