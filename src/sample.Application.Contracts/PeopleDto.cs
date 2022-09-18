using System;
using Volo.Abp.Application.Dtos;

namespace sample
{
    public class PeopleDto:EntityDto<int>
    {

        public string Name { get; set; }
    }
}

