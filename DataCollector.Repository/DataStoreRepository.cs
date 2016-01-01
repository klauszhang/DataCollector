using DataCollector.DAL;
using DataCollector.DomainModel;
using DataCollector.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.Repository
{
    public class DataStoreRepository : IDisposable
    {

        private DCDbContext _context;
        private ModelFactory _modelFactory;

        public DataStoreRepository()
        {
            _context = new DCDbContext();
            _modelFactory = new ModelFactory();
        }

        public void Dispose()
        {
            _context.SaveChanges();
            _context.Dispose();
        }

        public List<KeyValueOutputViewModel> GetAllDataOfCurrentUser(string _currentUserId)
        {
            var data = _context.KeyValueData.Where(kv => kv.CreatedBy.Id == _currentUserId).ToList();
            List<KeyValueOutputViewModel> result = _modelFactory.Create(data);
            return result;
        }

        public bool SaveData(KeyValueDataViewModel vm, string currentUserId)
        {
            try
            {
                UserDevice device = _context.UserDevices.Where(ud => ud.Id == vm.DeviceId).FirstOrDefault();
                _context.KeyValueData.Add(_modelFactory.Create(vm, currentUserId, device));
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}
