using System;
using Volo.Abp.Application.Dtos;

namespace sample
{
    public class BookDto:EntityDto<int>
    {
        public string Title { get; set; }
        public int NbPage { get; set; }
    }
}

