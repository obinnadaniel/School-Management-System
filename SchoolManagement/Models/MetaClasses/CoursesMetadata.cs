
using System.ComponentModel.DataAnnotations;


namespace SchoolManagement.Models
{
    public class CoursesMetadata
    {
        [StringLength(50)]
        public string Title { get; set; }
        [Range(1,8)]
        public int Credits { get; set; }
    }
    [MetadataType(typeof(CoursesMetadata))]
    public partial class Course
    {

    }
}