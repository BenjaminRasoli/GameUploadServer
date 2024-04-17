using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameUploadServer.Modals
{
    public class ProjectData
    {

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectImage { get; set; }

        public List<CommentData> Comments { get; set; }
    }
       
  }


