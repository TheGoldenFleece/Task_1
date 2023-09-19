using System.Text.Json.Serialization;

namespace Task_1.Model {
    public class Folder {
        public int FolderID { get; set; }
        public string Name { get; set; }
        public int? ParentID { get; set; }
    }
}
