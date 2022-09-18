using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace sample
{
    public class Book:Entity<int>,IMultiTenant
    {
        public string Title { get; set; }
        public int NbPage  { get; set; }

        public Guid? TenantId { get; set; }
    }
}

