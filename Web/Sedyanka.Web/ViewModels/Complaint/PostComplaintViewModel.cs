namespace MvcTemplate.Web.ViewModels.Complaint
{
    using Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class PostComplaintViewModel : IMapFrom<MvcTemplate.Data.Models.Complaint>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
