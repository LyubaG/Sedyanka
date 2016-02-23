namespace MvcTemplate.Web.ViewModels.Complaint
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ComplaintDetailsViewModel : IMapFrom<MvcTemplate.Data.Models.Complaint>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CommentsCount { get; set; }

        //public IEnumerable<Comment> Comments { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<MvcTemplate.Data.Models.Complaint, ComplaintDetailsViewModel>();
                //.ForMember(m => m.VotesCount, opt => opt.MapFrom(i => i.Votes.Any() ? i.Votes.Sum(v => v.Points) : 0))
                //.ForMember(m => m.CommentsCount, opt => opt.MapFrom(i => i.Comments.Any() ? i.Comments.Count : 0));
        }
    }
}
