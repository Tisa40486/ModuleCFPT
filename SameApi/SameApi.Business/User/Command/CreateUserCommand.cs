using AutoMapper;
using MediatR;
using SameApi.Db.UnitOfWork;
using SameApi.Dto;
using SameApi.Model;

namespace SameApi.Business.User.Command
{
    public class CreateUserCommand : UserInput, IRequest
    {
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IApiSameUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(
            IApiSameUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var dao = _mapper.Map<UserDao>(request);
            var genderEntity = await _uow.GenderRepository.GetByIdAsync(request.GenderId, withNoTracking: false);
            var schoolEntity = await _uow.SchoolRepository.GetByIdAsync(request.SchoolId, withNoTracking: false);
            var professionEntity = await _uow.ProfessionRepository.GetByIdAsync(request.ProfessionId, withNoTracking: false);
            if (genderEntity != null)
            {
                dao.GenderDao = genderEntity;
            }


            if (schoolEntity != null)
            {
                dao.SchoolDao = schoolEntity;
            }


            if (professionEntity != null)
            {
                dao.ProfessionDao = professionEntity;
            }

            if (dao.Birthdate.HasValue)
            {
                var today = DateTime.Today;
                var age = today.Year - dao.Birthdate.Value.Year;
                if (dao.Birthdate.Value.Date > today.AddYears(-age)) age--;
                dao.Age = age;
            }

            await _uow.UserRepository.AddAndSaveAsync(dao);
        }
    }
}