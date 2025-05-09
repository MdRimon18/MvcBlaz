using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model
{
    public class EmployeeInfo
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeMiddleName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeNameBangla { get; set; }
        public string FathersName { get; set; }
        public string FathersNameBangla { get; set; }
        public string MothersName { get; set; }
        public string MothersNameBangla { get; set; }
        public string Sex { get; set; }
        public string BirthPlace { get; set; }
        public string DateofBirth { get; set; }
        public string Age { get; set; }
        public int ReligionId { get; set; }
        public string MaritalStatus { get; set; }
        public int BloodGroupId { get; set; }
        public string Nationality { get; set; }
        public string NationalId { get; set; }
        public string PassportNo { get; set; }
        public int EmployeeCategoryId { get; set; }
        public int DesignationLebelId { get; set; }
        public int DesignationId { get; set; }
        public int FunctionalSuperiorId { get; set; }
        public int AdminSuperiorId { get; set; }
        public int IdCardNo { get; set; }
        public string JoiningDate { get; set; }
        public string ConfirmationDate { get; set; }
        public int PunchCardNo { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; }
        public int LocationId { get; set; }
        public int FloorId { get; set; }
        public int DivisionId { get; set; }
        public int DepartmentId { get; set; }
        public int SectionId { get; set; }
        public int LineNoId { get; set; }


    }
}
