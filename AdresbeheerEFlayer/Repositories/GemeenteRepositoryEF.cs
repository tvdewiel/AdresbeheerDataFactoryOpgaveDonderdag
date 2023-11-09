using AdresbeheerDomain.Interfaces;
using AdresbeheerDomain.Model;
using AdresbeheerEFlayer.Exceptions;
using AdresbeheerEFlayer.Mappers;
using AdresbeheerEFlayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerEFlayer.Repositories
{
    public class GemeenteRepositoryEF : IGemeenteRepository
    {
        private AdresbeheerContext ctx;

        public GemeenteRepositoryEF(string connectionString)
        {
            this.ctx = new AdresbeheerContext(connectionString);
        }
        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }
        public Gemeente GeefGemeente(int id)
        {
            try
            {
                return MapGemeente.MapToDomain(ctx.Gemeente.Where(x => x.NIScode == id)
                    .AsNoTracking().FirstOrDefault());
            }
            catch(Exception ex)
            {
                throw new GemeenteRepositoryException("GeefGemeente", ex);
            }
        }
        public List<Gemeente> GeefGemeenten()
        {
            try
            {
                return ctx.Gemeente.AsNoTracking().Select(x=>MapGemeente.MapToDomain(x)).ToList();
            }
            catch (Exception ex)
            {
                throw new GemeenteRepositoryException("HeeftGemeente", ex);
            }
        }
        public bool HeeftGemeente(int id)
        {
            try
            {
                return ctx.Gemeente.Any(x=>x.NIScode==id);
            }
            catch (Exception ex)
            {
                throw new GemeenteRepositoryException("HeeftGemeente", ex);
            }
        }
        public bool HeeftStraten(int id)
        {
            try
            {
                return ctx.Straat.Any(x=>x.Gemeente.NIScode==id);
            }
            catch (Exception ex)
            {
                throw new GemeenteRepositoryException("HeeftGemeente", ex);
            }
        }
        public void UpdateGemeente(Gemeente gemeente)
        {
            try
            {
                ctx.Gemeente.Update(MapGemeente.MapToDB(gemeente));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new GemeenteRepositoryException("HeeftGemeente", ex);
            }
        }
        public void VerwijderGemeente(int id)
        {
            try
            {
                ctx.Gemeente.Remove(new GemeenteEF() { NIScode = id });
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new GemeenteRepositoryException("VerwijderGemeente", ex);
            }
        }
        public void VoegGemeenteToe(Gemeente gemeente)
        {
            try 
            { 
                ctx.Gemeente.Add(MapGemeente.MapToDB(gemeente));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new GemeenteRepositoryException("VoegGemeenteToe", ex);
            }
        }
    }
}
