using System.Timers;


namespace RedisExample.Catogory
{
    public class CategoryService : ICategoryService
    {

        List<CategoryModel> categories=new List<CategoryModel>();
        
        public ICacheService CacheService { get; }

        public CategoryService(ICacheService cacheService)
        {
            CacheService = cacheService;

        }


        public List<CategoryModel> GetAllCategory()
        {
            categories.Clear();
            Random rnd = new Random();

            for (int i = 0; i < 5000000; i++)
            {
              
                int sayi = rnd.Next(1000000);
                categories.Add(new CategoryModel { Id = sayi, Name = "Electronic" });
            }
           
            return GetCategoriesFromCache();
          
        }

      

        private List<CategoryModel> GetCategoriesFromCache()
        {
            return CacheService.GetOrAdd("allcategories", () => { return categories; });
        }
    }
}
