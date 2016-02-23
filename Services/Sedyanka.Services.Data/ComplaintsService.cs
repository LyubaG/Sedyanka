namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    public class ComplaintsService : IComplaintsService
    {
        private readonly IDbRepository<Complaint> complaints;

        public ComplaintsService(IDbRepository<Complaint> complaints)
        {
            this.complaints = complaints;
        }

        public void Add(Complaint complaint)
        {
            this.complaints.Add(complaint);
            this.complaints.Save();
        }

        public Complaint Find(int id)
        {
            return this.complaints.GetById(id);
        }

        public IQueryable<Complaint> GetAll()
        {
            return this.complaints
                .All()
                .OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<Complaint> GetById(int id)
        {
            return this.complaints
                .All()
                .Where(i => i.Id == id);
        }

        public void Remove(Complaint idea)
        {
            this.complaints.Delete(idea);
            this.complaints.Save();
        }

        public void Save()
        {
            this.complaints.Save();
        }
    }
}
