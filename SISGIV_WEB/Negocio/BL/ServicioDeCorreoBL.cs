using Datos.DAL;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.BL
{
    public class ServicioDeCorreoBL
    {
        ResidenteDAL ResidentesDAL = new ResidenteDAL();



        // Get Todos los residentes
        public List<Residente> GetResidenteBL()
        {
            var Query = (from Re in ResidentesDAL.GetResidenteDAL()
                         select Re).ToList();

            return Query;
        }



        // Get Residente por ID
        public Residente GetResidentePorIDBL(int IdResidente)
        {
            var Query = (from Re in ResidentesDAL.GetResidenteDAL()
                         where Re.IdResidente == IdResidente
                         select Re).Last();
            return Query;
        } 
    }
}
