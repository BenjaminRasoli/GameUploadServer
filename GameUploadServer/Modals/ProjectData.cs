using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameUploadServer.Modals
{
    public class ProjectData
    {

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectImageUrl { get; set; }
        public string ProjectGameId { get; set; }
        public string ProjectOwner { get; set; }


        public List<CommentData>? Comments { get; set; }
    }
       
  }


