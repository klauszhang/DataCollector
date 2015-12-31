using DataCollector.DAL;
using DataCollector.DomainModel;
using DataCollector.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace DataCollector.Repository
{
    public class DeviceRepository:IDisposable
    {
        private DCDbContext _context;
        private ModelFactory _modelFactory;
        private string _userId;

        public DeviceRepository(string userId)
        {
            _context = new DCDbContext();
            _userId = userId;
            _modelFactory = new ModelFactory();
        }

        public bool AddNewDevice(NewDeviceViewModel vm)
        {
            var newDevice = _context.UserDevices.Add(_modelFactory.Create(vm, _userId));

            return newDevice != null ? true : false;
        }

        public void Dispose()
        {
            _context.SaveChanges();
            _context.Dispose();
        }

        public IEnumerable<UserDevice> FindAllDeviceOfCurrentUser()
        {
            var result= _context.UserDevices.Where(ud => ud.UserId == _userId).ToList();
            return result;
        }
    }
}
