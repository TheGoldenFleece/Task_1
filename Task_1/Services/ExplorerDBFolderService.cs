using Task_1.Model;
using Task_1.Models;

namespace Task_1.Services {
    public class ExplorerDBFolderService {

        public IWebHostEnvironment WebHostEnvironment { get; }
        public ExplorerDBFolderService(IWebHostEnvironment webHostEnvironment) {
            WebHostEnvironment = webHostEnvironment;
        }

        public List<Folder> GetAllFolders() {
            using (var context = new ExplorerContext()) {
                return context.Folders.ToList();
            }
        }

        public void AddDefaultExplorerDB() {
            using (var context = new ExplorerContext()) {

                if (context.Folders.Any()) return;

                List<Folder> folders = new List<Folder>() {
                    new Folder {
                        Name = "Creating Digital Images",
                        ParentID = null
                    },
                    new Folder {
                        Name = "Resources",
                        ParentID = 1
                    },
                    new Folder {
                        Name = "Evidence",
                        ParentID = 1
                    },
                    new Folder {
                        Name = "Graphic Products",
                        ParentID = 1
                    },
                    new Folder {
                        Name = "Primary Sources",
                        ParentID = 2
                    },
                    new Folder {
                        Name = "Secondary Sources",
                        ParentID = 2
                    },
                    new Folder {
                        Name = "Process",
                        ParentID = 4
                    },
                    new Folder {
                        Name = "Final Product",
                        ParentID = 4
                    }
                };

                context.Folders.AddRange(folders);
                context.SaveChanges();
            }
        }
    }
}
