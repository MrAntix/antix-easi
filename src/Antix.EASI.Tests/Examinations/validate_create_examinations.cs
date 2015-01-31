using System;
using Antix.EASI.Domain.Examinations.Models;
using Antix.EASI.Domain.Examinations.Validation;
using Antix.EASI.Domain.People.Examiners.Validation.Predicates;
using Antix.EASI.Domain.People.Patients.Validation.Predicates;
using Antix.EASI.Domain.Validation;
using Antix.Services.Validation;
using Antix.Services.Validation.Predicates;
using Moq;
using Xunit;

namespace Antix.EASI.Tests.Examinations
{
    public class validate_create_examinations
    {
        readonly static Guid ExaminerId = new Guid("D6C024EA-0756-430C-93C0-BC536422F3F7");
        readonly static Guid PatientId = new Guid("E6D93C84-91B5-4035-B212-6A9D72618030");

        [Fact]
        public void happy_path()
        {
            var model = GetValidModel();
            var service = GetService();

            var result = service.Validate(model);

            Console.WriteLine(
                string.Join("\n", result));

            Assert.Empty(result);
        }

        static CreateExaminationModel GetValidModel()
        {
            return new CreateExaminationModel
            {
                ExaminerId = ExaminerId,
                PatientId = PatientId,
                TakenOn = DateTimeOffset.UtcNow
            };
        }

        static IValidator<CreateExaminationModel> GetService()
        {
            return
                new CreateExaminationValidator(
                    GetExistsPredicate<IExaminerExistsPredicate>(),
                    GetExistsPredicate<IPatientExistsPredicate>(),
                    new DomainValidationPredicates(),
                    () => new ValidationRuleBuilder<CreateExaminationModel>());
        }

        static T GetExistsPredicate<T>()
            where T : class, IValidationPredicate<Guid>
        {
            var mock = new Mock<T>();
            mock
                .Setup(o => o.Is(It.IsAny<Guid>()))
                .Returns((Guid id) => id != Guid.Empty);
            mock
                .Setup(o => o.Name)
                .Returns("exists");

            return mock.Object;
        }
    }
}