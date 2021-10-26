using SchoolMS.Data.Base;
using SchoolMS.Data.ViewModels;
using SchoolMS.Models;
using System.Threading.Tasks;

namespace SchoolMS.Data.Services
{
    public interface IAttendancesService : IEntityBaseRepository<Attendance>
    {
        Task<Attendance> GetAttendanceByIdAsync(int id);
        Task<NewAttendanceDropdownsVM> GetNewAttendanceDropdownsValues();
        Task AddNewAttendanceAsync(NewAttendanceVM data);
        Task UpdateAttendanceAsync(NewAttendanceVM data);
    }
}
