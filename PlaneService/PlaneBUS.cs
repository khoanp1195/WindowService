using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaneShare;

namespace PlaneService
{
    class PlaneBUS : MarshalByRefObject, IPlaneBus
    {
        public List<Plane> GetAll()
        {
            List<Plane> planes = new PlaneDAO().SelectAll();
            return planes;
        }
        public List<Plane> Search(String keyword)
        {
            List<Plane> planes =new PlaneDAO().SelectByKeyword(keyword);
            return planes;
        }

        public Plane GetDetails(int Id)
        {
           Plane plane = new PlaneDAO().SelectById(Id);
            return plane; 
        }


        public bool Delete(int Id)
        {
            bool result = new PlaneDAO().Delete(Id);
            return result;

        }
        public bool Update(Plane newPlane)
        {
            bool result = new PlaneDAO().Update(newPlane);
            return result;
        }

        public bool AddNew(Plane newPlane)
        {
            bool result = new PlaneDAO().Insert(newPlane);
            return result;
        }
    }
}


