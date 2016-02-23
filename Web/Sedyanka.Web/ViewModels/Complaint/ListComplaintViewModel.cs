namespace MvcTemplate.Web.ViewModels.Complaint
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Infrastructure.Mapping;

    public class ListComplaintViewModel : IMapFrom<MvcTemplate.Data.Models.Complaint>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CommentsCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<MvcTemplate.Data.Models.Complaint, ListComplaintViewModel>();
                //.ForMember(m => m.CommentsCount, opt => opt.MapFrom(i => i.Comments.Any() ? i.Comments.Count : 0));
        }
    }




}
