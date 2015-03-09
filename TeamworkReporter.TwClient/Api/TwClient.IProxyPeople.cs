using System.Collections.Generic;
using TeamworkReporter.TwClient.Api.Contracts;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient.Api
{
    public partial class TwClient : IProxyPeople
    {
        IEnumerable<TwPerson> IProxyPeople.Get(PageInfo page)
        {
            var query = "/people.json";
            if (page != null)
                query = string.Format("/people.json?page={0}&pageSize={1}", page.Page, page.PageSize);

            var result = Request<PeopleApiRequest>(query);
            return result.People;
        }

        TwPerson IProxyPeople.Get(int personId)
        {
            var result = Request<PersonApiRequest>(string.Format("/people/{0}.json", personId));
            return result.Person;
        }

        IEnumerable<TwPerson> IProxyPeople.GetByProject(int projectId)
        {
            var result = Request<PeopleApiRequest>(string.Format("/projects/{0}/people.json", projectId));
            return result.People;
        }

        IEnumerable<TwPerson> IProxyPeople.GetByCompany(int companyId)
        {
            var result = Request<PeopleApiRequest>(string.Format("/companies/{0}/people.json", companyId));
            return result.People;
        }
    }
}