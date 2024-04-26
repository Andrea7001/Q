using Q.AccesoADatos.DAL;
using Q.EntidadesNegocio.EN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.LogicaDeNegocio.BL
{
    public class PersonaQBL
    {
        public static async Task<PersonaQ> GetById(PersonaQ pRole)
        {
            return await PersonaQDAL.GetById(pRole);
        }
        public static async Task<int> Create(PersonaQ pRole)
        {
            return await PersonaQDAL.Create(pRole);
        }
        public static async Task<int> Update(PersonaQ pRole)
        {
            return await PersonaQDAL.Update(pRole);
        }
        public static async Task<int> Delete(PersonaQ pRole)
        {
            return await PersonaQDAL.Delete(pRole);
        }

        public static async Task<List<PersonaQ>> GetAll()
        {
            return await PersonaQDAL.GetAll();
        }
    }
}
