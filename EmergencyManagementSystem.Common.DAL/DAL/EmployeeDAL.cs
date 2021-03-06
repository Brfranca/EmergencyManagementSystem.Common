﻿using EmergencyManagementSystem.Common.Common.Filters;
using EmergencyManagementSystem.Common.Common.Interfaces;
using EmergencyManagementSystem.Common.Common.Models;
using EmergencyManagementSystem.Common.Entities.Entities;
using EmergencyManagementSystem.Common.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EmergencyManagementSystem.Common.DAL.DAL
{
    public class EmployeeDAL : BaseDAL<Employee>, IEmployeeDAL
    {
        public EmployeeDAL(Context context) : base(context)
        {
        }

        public Employee Find(EmployeeFilter filter)
        {
            var query = Set.AsQueryable();
            if (filter.Id > 0)
                query = query.Where(d => d.Id == filter.Id);

            else if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(d => d.Name.Contains(filter.Name));

            else if (!string.IsNullOrWhiteSpace(filter.CPF))
                query = query.Where(d => d.CPF == filter.CPF);

            else if (filter.Occupation > 0)
                query = query.Where(d => d.Occupation == filter.Occupation);

            else if (filter.Guid != Guid.Empty)
                query = query.Where(d => d.Guid == filter.Guid);

            return query.FirstOrDefault();
        }
        
        public bool ExistEmployee(long employeeId)
        {
            return Set.Any(d => d.Id == employeeId);
        }

        //rever

        public bool ExistCPF(string cpf, long id)
        {
            if (id > 0)
            {
                return Set.Where(d => d.Id != id).Any(d => d.CPF == cpf);
            }
            return Set.Any(d => d.CPF == cpf);
        }

        public bool ExistRG(string rg, long id)
        {
            if (id > 0)
            {
                return Set.Where(d => d.Id != id).Any(d => d.RG == rg);
            }
            return Set.Any(d => d.RG == rg);
        }
    }
}
