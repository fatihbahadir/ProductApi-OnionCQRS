using ProductApi.Domain.Common;

namespace ProductApi.Domain.Entities
{
    public class Category : EntityBase
    {

        public Category()
        {

        }

        public Category(int parentId, string name, int priority)
        {
            Priority = priority;
            ParentId = parentId;
            Name = name;
        }
        public int ParentId { get; set; }

        public String Name { get; set; }

        public int Priority { get; set; }

        public ICollection<Detail> Details { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}

