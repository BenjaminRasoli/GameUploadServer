namespace GameUploadServer.Modals.ViewModals
{
    public class ProjectViewModel
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectImageUrl { get; set; }
        public string ProjectGameId { get; set; }
        public string ProjectOwner { get; set; }



        public class ProjectCommentViewModel
        {
            public int Id { get; set; }
            public string ProjectName { get; set; }
            public string ProjectDescription { get; set; }
            public string ProjectImageUrl { get; set; }
            public string ProjectGameId { get; set; }
            public string ProjectOwner { get; set; }


            public List<string> Comments { get; set; }
        }
    }
}
