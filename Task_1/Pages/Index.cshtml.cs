using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Task_1.Model;
using Task_1.Services;

namespace Task_1.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        public  ExplorerDBFolderService ExplorerDBFolderService;
        public Explorer Explorer { get; private set; } 
        public IndexModel(ILogger<IndexModel> logger, ExplorerDBFolderService explorerDBFolderService) {
            _logger = logger;
            ExplorerDBFolderService = explorerDBFolderService;
        }

        public void OnGet(int? folderId = null) {
            if (folderId == null) {
                ExplorerDBFolderService.AddDefaultExplorerDB();
                folderId = 1;
            }

            Explorer = new Explorer(folderId.Value, ExplorerDBFolderService.GetAllFolders());
        }
    }
}