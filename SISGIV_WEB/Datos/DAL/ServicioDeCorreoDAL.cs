using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAL
{
    public class ServicioDeCorreoDAL
    {

        // Get todos los residententes
        public List<Residente> GetResidenteDAL()
        {
            List<Residente> Recursos = new List<Residente>();

            using (SISGIV_Entities Re = new SISGIV_Entities())
            {
                Recursos = Re.Residente.ToList<Residente>();
            }
            return Recursos;
        }

    }
}
