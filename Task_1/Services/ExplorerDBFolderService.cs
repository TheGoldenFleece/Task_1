using Microsoft.Data.SqlClient;
using Task_1.Model;

namespace Task_1.Services {
    public class ExplorerDBFolderService {

        public IWebHostEnvironment WebHostEnvironment { get; }
        public ExplorerDBFolderService(IWebHostEnvironment webHostEnvironment) {
            WebHostEnvironment = webHostEnvironment;
        }

        private string ExplorerDBName {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "explorer.mdb"); }
        }

        public List<Folder> GetAllFolders() {
            string connectionString = "Data Source=SPEEDY\\SQLEXPRESS;Initial Catalog=ExplorerDB;Integrated Security=True;TrustServerCertificate=True";
            List<Folder> folders = new List<Folder>();

            using (SqlConnection con = new SqlConnection(connectionString)) {
                con.Open();

                string sqlQuery = "SELECT * FROM Explorer";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        Folder catalog = new Folder {
                            FolderID = reader.GetInt32(reader.GetOrdinal("FolderID")),
                            Name = reader.GetString(reader.GetOrdinal("FolderName")),
                            ParentID = reader.IsDBNull(reader.GetOrdinal("ParentID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ParentID"))
                        };
                        folders.Add(catalog);
                    }
                }
            }

            return folders;
        }
    }
}
