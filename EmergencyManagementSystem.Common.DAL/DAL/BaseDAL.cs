using EmergencyManagementSystem.Common.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyManagementSystem.Common.DAL.DAL
{
    public class BaseDAL<T> where T : class
    {
        public DbSet<T> Set { get; set; }
        public Context Context { get; set; }
        public BaseDAL(Context context)
        {
            Context = context;
            Set = context.Set<T>();
        }

        public Result Insert(T entity)
        {
            try
            {
                Set.Add(entity);
                return Result.BuildSucess();
            }
            catch (Exception error)
            {
                return Result.BuildError($"Erro ao adicionar {nameof(T)}", error);
            }
        }

        public Result Update(T entity)
        {
            try
            {
                Set.Update(entity);
                return Result.BuildSucess();
            }
            catch (Exception error)
            {
                return Result.BuildError($"Erro ao atualizar {nameof(T)}", error);
            }
        }

        public Result Delete(T entity)
        {
            try
            {
                Set.Remove(entity);
                return Result.BuildSucess();
            }
            catch (Exception error)
            {
                return Result.BuildError($"Erro ao deletar {nameof(T)}", error);
            }
        }

        public Result Save()
        {
            try
            {
                var result = Context.SaveChanges();
                if (result > 0)
                    return Result.BuildSucess();

                return Result.BuildError("Erro ao salvar o contexto.");
            }
            catch (Exception error)
            {
                return Result.BuildError("Erro ao salvar o contexto.", error);
            }
        }
    }
}
