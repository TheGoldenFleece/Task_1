using Task_1.Model;

namespace Task_1.Models {
    public class FolderDisplayer {
        public string Name { get; private set; }
        public List<Folder> ChildFolders { get; private set; }
        public int? parentID {get; private set;}

        public FolderDisplayer(string folderName, int? parentID, List<Folder> childFolders) {
            Name = folderName;
            ChildFolders = childFolders;
            this.parentID = parentID;
        }
    }
}
