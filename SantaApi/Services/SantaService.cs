using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using SantaApi.Helpers;
using SantaApi.Models;
using SantaApi.ViewModels;

namespace SantaApi.Services
{
    public interface ISantaService
    {
        ValueTask<ServiceResult<VerdictDto>> GetEmployeeVerdict(string name, int age);
        ValueTask<ServiceResult<List<VerdictDto>>> GetVerdictList();
        ValueTask<ServiceResult<VerdictDto>> AddVerdict(CreateVerdictDto verdictDto);
    }
    public class SantaService : ISantaService
    {
        private SantaDbContext _context;
        private DbSet<EmployeeCard> _dbSet;

        public SantaService(SantaDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<EmployeeCard>();
        }
        public async ValueTask<ServiceResult<VerdictDto>> GetEmployeeVerdict(string name, int age)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new ServiceResult<VerdictDto>(new ErrorResponse(ErrorCode.ValidationError, "invalid name"));
            }

            var employee = await _dbSet.AsAsyncEnumerable().FirstOrDefault(s => s.Age == age && s.Name == name);

            return employee == null 
                ? new ServiceResult<VerdictDto>(new ErrorResponse(ErrorCode.EntityNotFound, "entity not found")) 
                : new ServiceResult<VerdictDto>(true, new VerdictDto()
                {
                    Age = employee.Age,
                    Name = employee.Name,
                    Verdict = employee.Verdict
                });
        }

        public async ValueTask<ServiceResult<List<VerdictDto>>> GetVerdictList()
        {
            var verdicts = await _dbSet.AsNoTracking().AsAsyncEnumerable().ToList();

            var results = verdicts.Select(v => new VerdictDto()
            {
                Age = v.Age,
                Name = v.Name,
                Verdict = v.Verdict
            }).ToList();
            
            return new ServiceResult<List<VerdictDto>>(true, results);
        }

        public async ValueTask<ServiceResult<VerdictDto>> AddVerdict(CreateVerdictDto verdictDto)
        {
            if (verdictDto == null || string.IsNullOrEmpty(verdictDto.Name) || !verdictDto.Verdict.HasValue)
            {
                return new ServiceResult<VerdictDto>(false,null);
            }

            var verdict = new EmployeeCard
            {
                Name = verdictDto.Name,
                Age = verdictDto.Age,
                Verdict = verdictDto.Verdict.Value
            };

            _dbSet.Add(verdict);
            await _context.SaveChangesAsync();
            
            return new ServiceResult<VerdictDto>(true, new VerdictDto()
            {
                Age = verdict.Age,
                Name = verdict.Name,
                Verdict = verdict.Verdict
            });
        }
    }
}