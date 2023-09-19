using Task_1.Model;
using Task_1.Models;

namespace Task_1.Services {
    public class Explorer {
        public int currentFolderID { private set; get; }
        private List<Folder> Folders;
        public FolderDisplayer folderDisplayer { private set; get; }
        public Explorer(int currentFolderID, List<Folder> folders) {
            Folders = folders;
            this.currentFolderID = currentFolderID;
            folderDisplayer = GetFolderDislayer();
        }

        public void SetCurrentID(int folderID) {
            currentFolderID = folderID;
            folderDisplayer = GetFolderDislayer();
        }

        private FolderDisplayer GetFolderDislayer() {
            string folderName = Folders[currentFolderID - 1].Name;
            int? parentID = Folders[currentFolderID - 1].ParentID;

            List<Folder> folderChildrens = new List<Folder>();

            foreach (Folder folder in Folders) {
                if (folder.ParentID == currentFolderID) {
                    folderChildrens.Add(folder);
                }
            }

            FolderDisplayer fd = new FolderDisplayer(folderName, parentID, folderChildrens);
            return fd;
        }
    }
}
