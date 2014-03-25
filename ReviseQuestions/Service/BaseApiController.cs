using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Raven.Client;
using Service.Bootstrapper;
using Service.Data.Interface;

namespace Service
{
    public class BaseApiController<T> : ApiController
        where T:class 
    {
        protected readonly IDataContext DataContext;
        protected  readonly IDocumentSession DocumentSession;

        public BaseApiController()
        {
            DataContext = IocContainer.ResolveInstance<IDataContext>();
            DocumentSession = DataContext.Session;
        }

        protected IEnumerable<T> GetAll()
        {
            return DocumentSession.Query<T>();
        }

        protected T GetFirstByExpression(Expression<Func<T, bool>> expression)
        {
            var questions = DocumentSession.Query<T>().Where(expression);
            if (questions == null && questions.Any())
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return questions.FirstOrDefault();
        }

        protected HttpResponseMessage AddObject(T entityObject)
        {
            DocumentSession.Store(entityObject);
            DocumentSession.SaveChanges();
            if (Request != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.Created, entityObject);
                string uri = Url.Link("DefaultApi", new { id = 3 });
                if (uri != null) response.Headers.Location = new Uri(uri);
                return response;
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        protected HttpResponseMessage Delete(T entityObject)
        {
            DocumentSession.Delete(entityObject);
            DocumentSession.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}