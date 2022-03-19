using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneShare
{
    public interface IPlaneBus
    {
        List<Plane> GetAll();
        Plane GetDetails(int Id);
        List<Plane> Search(String keyword);
        bool AddNew(Plane newPlane);
        bool Update(Plane newPlane);
        bool Delete(int Id);
    }
}
