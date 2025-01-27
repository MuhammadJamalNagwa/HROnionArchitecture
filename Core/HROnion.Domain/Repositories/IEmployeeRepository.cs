﻿using HROnion.Domain.Entities;

namespace HROnion.Domain.Repositories;

public interface IEmployeeRepository
{
	Task<Employee?> GetByIdAsync(int id);
	Task<IEnumerable<Employee>> GetAllAsync();
	Task<int> AddAsync(Employee employee);
	Task UpdateAsync(Employee employee);
	Task DeleteAsync(int id);
}
