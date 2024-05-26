using System.ComponentModel.DataAnnotations.Schema;

namespace GameUploadServer.Modals
{
    public class CommentData
    {
        public int Id { get; set; }
        public string ProjectComment { get; set; }
        public string CommentOwner { get; set; }
        public string CommentName { get; set; }

      
        public int? ProjectDataId { get; set; }

          [ForeignKey("ProjectDataId")]
        public ProjectData? ProjectData { get; set; }

    }
}
