using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace sample
{
    public class PeopleAppService : CrudAppService<Person, PeopleDto, int, PagedAndSortedResultRequestDto, CreateUpdatePeopleDto>
    {
        public PeopleAppService(IRepository<Person, int> repository) : base(repository)
        {

        }
    }
}
