using Microsoft.EntityFrameworkCore;

namespace WKTDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class BL_Blog
    {
        private readonly DA_Blog _dablog;
        public BL_Blog()
        {
            _dablog = new DA_Blog();
        }
        public List<BlogModel> GetBlogs()
        {
            var lst = _dablog.GetBlogs();
            return lst;
        }
        public BlogModel GetBlog(int id)
        {
            var item = _dablog.GetBlog(id);
            return item;
        }
        public int CreateBlog(BlogModel requestModel)
        {
            var result = _dablog.CreateBlog(requestModel);
            return result;
        }
        public int UpdateBlog(int id, BlogModel requestModel)
        {
            var result = _dablog.UpdateBlog(id, requestModel);
            return result;
        }
        public int DeleteBlog(int id)
        {
            var result = _dablog.DeleteBlog(id);
            return result;
        }
        public int PatchBlog(int id, BlogModel requestModel)
        {
            var result = _dablog.PatchBlog(id,requestModel);
            return result;
        }
    }
}
