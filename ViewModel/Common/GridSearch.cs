namespace SpeakerManagementSystem.ViewModel.Common
{
    public class GridSearch
    {
#pragma warning disable IDE1006 // Naming Styles
        public long? id { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public int draw { get; set; }
        public string search { get; set; }
        public string order { get; set; }
        public string orderDir { get; set; }
        public string searchColumn { get; set; }
        public string searchType { get; set; }
        public string searchValue { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
