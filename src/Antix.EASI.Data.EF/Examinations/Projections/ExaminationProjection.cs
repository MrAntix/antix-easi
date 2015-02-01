using System;
using System.Linq.Expressions;
using Antix.Data.Projections;
using Antix.EASI.Data.EF.Examinations.Models;
using Antix.EASI.Data.EF.People.Examiners.Models;
using Antix.EASI.Data.EF.People.Patients.Models;
using Antix.EASI.Domain.Examinations.Models;
using Antix.EASI.Domain.People.Examiners.Models;
using Antix.EASI.Domain.People.Patients.Models;
using LinqKit;

namespace Antix.EASI.Data.EF.Examinations.Projections
{
    public class ExaminationProjection :
        ProjectionBase<ExaminationData, ExaminationModel>
    {
        readonly IProjectionProvider _projectionProvider;

        public ExaminationProjection(
            IProjectionProvider projectionProvider)
        {
            _projectionProvider = projectionProvider;
        }

        public override Expression<Func<ExaminationData, ExaminationModel>> GetExpression()
        {
            var projectExaminer = _projectionProvider
                .Get<ExaminerData, ExaminerInfoModel>();
            var projectPatient = _projectionProvider
                .Get<PatientData, PatientInfoModel>();

            return d => new ExaminationModel
            {
                Id = d.Id,
                TakenOn = d.TakenOn,
                Examiner = projectExaminer.Invoke(d.Examiner),
                Patient = projectPatient.Invoke(d.Patient)
            };
        }
    }
}