using Microsoft.EntityFrameworkCore;
using Q.EntidadesNegocio.EN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.AccesoADatos.DAL
{
    public class PersonaQDAL
    {
        public static async Task<PersonaQ> GetById(PersonaQ pRole)
        {
            var role = new PersonaQ();
            using (var dbContext = new ComunDB())
            {
                role = await dbContext.QB.FirstOrDefaultAsync(s => s.ID == pRole.ID);
            }
            return role;
        }
        public static async Task<int> Create(PersonaQ pRole)
        {
            int result = 0;
            using (var bdContext = new ComunDB())
            {
                bdContext.Add(pRole);
                result = await bdContext.SaveChangesAsync();
            }
            return result;

        }
        public static async Task<int> Update(PersonaQ pRole)
        {
            int result = 0;
            using (var dbContext = new ComunDB())
            {
                var role = await dbContext.QB.FirstOrDefaultAsync(r => r.ID == pRole.ID);
                role.Nombreq = pRole.Nombreq;
                role.Apellidoq = pRole.Apellidoq;
                role.FechadeNacimientoq = pRole.FechadeNacimientoq;
                role.Sueldoq = pRole.Sueldoq;
                role.Estatusq = pRole.Estatusq;
                role.Comentarioq = pRole.Comentarioq;
                dbContext.Update(role);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> Delete(PersonaQ pRole)
        {
            int result = 0;
            using (var dbContext = new ComunDB())
            {
                var role = await dbContext.QB.FirstOrDefaultAsync(r => r.ID == pRole.ID);
                dbContext.Remove(role);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<List<PersonaQ>> GetAll()
        {
            var roles = new List<PersonaQ>();
            using (var dbContext = new ComunDB())
            {
                roles = await dbContext.QB.ToListAsync();
            }
            return roles;

        }
    }
}