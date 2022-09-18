using AutoMapper;

namespace sample;

public class sampleApplicationAutoMapperProfile : Profile
{
    public sampleApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Book, CreateUpdateBookDto>().ReverseMap();
        CreateMap<PeopleDto, Person>().ReverseMap();
        CreateMap<Person, CreateUpdatePeopleDto>().ReverseMap();

    }
}
