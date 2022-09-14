using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Helper
{
    public interface IMapper
    {
        Company DtoMapper(CompanyRequestDto requestDto);
        CompanyResponseDto DtoMapper(Company entity);
        School DtoMapper(SchoolRequestDto requestDto);
        SchoolResponseDto DtoMapper(School entity);
        Job DtoMapper(JobRequestDto requestDto);
        JobResponseDto DtoMapper(Job entity);
        Location DtoMapper(LocationRequestDto requestDto);
        LocationResponseDto DtoMapper(Location entity);
        LocationResponseDto DtoMapper(dynamic input);
        Match DtoMapper(MatchRequestDto requestDto);
        MatchResponseDto DtoMapper(Match entity);
        Message DtoMapper(MessageRequestDto requestDto);
        MessageResponseDto DtoMapper(Message entity);
        Recruiter DtoMapper(RegisterRecruiterRequestDto requestDto);
        Recruiter DtoMapper(RecruiterRequestDto requestDto);
        RecruiterResponseDto DtoMapper(Recruiter entity);
        RecruiterRequestDto DtoMapper(RecruiterResponseDto responseDto);
        Student DtoMapper(StudentRequestDto requestDto);
        Student DtoMapper(RegisterStudentRequestDto requestDto);
        StudentResponseDto DtoMapper(Student entity);
        StudentRequestDto DtoMapper(StudentResponseDto responseDto);
        Vacancy DtoMapper(VacancyRequestDto requestDto);
        VacancyResponseDto DtoMapper(Vacancy entity);
        Like DtoMapper(LikeRequestDto requestDto);
        LikeResponseDto DtoMapper(Like entity);
        AdminResponseDto DtoMapper(Admin entity);
    }
}
