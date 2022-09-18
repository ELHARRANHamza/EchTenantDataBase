using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace sample
{
    public class BookAppService:CrudAppService<Book,BookDto,int,PagedAndSortedResultRequestDto,CreateUpdateBookDto>
    {
        public BookAppService(IRepository<Book,int> repository):base(repository)
        {

        }
    }
}

