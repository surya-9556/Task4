using Microsoft.Extensions.Logging;
using ProfileInMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileInMVCProject.Services
{
    public class ProfileManager : IRepo<Profile>
    {
        ProfileContext _context;
        ILogger<ProfileManager> _Logger;

        public ProfileManager(ProfileContext context, ILogger<ProfileManager> logger)
        {
            _context = context;
            _Logger = logger;
        }

        public void Add(Profile t)
        {
            try
            {
                _context.Profiles.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
        }

        public void Delete(Profile t)
        {
            try
            {
                _context.Profiles.Remove(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
        }

        public Profile Get(int id)
        {
            try
            {
                Profile P = _context.Profiles.FirstOrDefault(i => i.Id == id);
                return P;
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Profile> GetAll()
        {
            try
            {
                if(_context.Profiles.Count() == 0)
                {
                    return null;
                }
                return _context.Profiles.ToList();
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
            return null;
        }

        public void Update(int id, Profile t)
        {
            Profile P = Get(id);
            if (P != null)
            {
                P.Name = t.Name;
                P.Age = t.Age;
                P.IsEmployeed = t.IsEmployeed;
                P.Qualification = t.Qualification;
                P.NoticePeriod = t.NoticePeriod;
                P.CurrentCTC = t.CurrentCTC;
            }
            _context.SaveChanges();
        }
    }
}
