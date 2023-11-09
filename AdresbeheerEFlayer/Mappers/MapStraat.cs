using AdresbeheerDomain.Model;
using AdresbeheerEFlayer.Exceptions;
using AdresbeheerEFlayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerEFlayer.Mappers
{
    public static class MapStraat
    {
        //public static Straat MapToDomain(StraatEF db)
        //{
        //    try
        //    {
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new MapException("MapStraat - MapToDomain", ex);
        //    }
        //}
        public static StraatEF MapToDB(Straat s,AdresbeheerContext ctx)
        {
            try
            {
                GemeenteEF gemeente = ctx.Gemeente.Find(s.Gemeente.NIScode);
                if (gemeente == null) gemeente=MapGemeente.MapToDB(s.Gemeente);
                return new StraatEF(s.ID,s.Straatnaam,s.Gemeente.NIScode,gemeente);
            }
            catch (Exception ex)
            {
                throw new MapException("MapStraat - MapToDomain", ex);
            }
        }
    }
}
