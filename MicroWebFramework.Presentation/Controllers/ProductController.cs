using MicroWebFramework.Presentation.Contracts;
using MicroWebFramework.Presentation.Data;
using MicroWebFramework.Presentation.Pipeline;

namespace MicroWebFramework.Presentation.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly INotification _notification;
        public ProductController(PipelineContext pipelineContext, INotification notification) : base(pipelineContext.HttpContext)
        {
            _dbContext = new ApplicationDbContext();
            _notification = notification;
        }
        public void GetAllProducts()
        {
            // sample
            _notification.SendMessage("get all products");
            Ok(_dbContext.Products);
        }
        public void GetProductById(int id)
        {
            Ok(_dbContext.Products.SingleOrDefault(i => i.Id == id));
        }
    }
}
