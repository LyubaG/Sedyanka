namespace MvcTemplate.Services.Data
{
    using MvcTemplate.Data.Models;
    using System.Linq;

    public interface IComplaintsService
    {
        void Add(Complaint idea);

        Complaint Find(int id);

        IQueryable<Complaint> GetAll();

        IQueryable<Complaint> GetById(int id);

        void Remove(Complaint idea);

        void Save();
    }
}
