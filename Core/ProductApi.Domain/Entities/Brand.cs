using ProductApi.Domain.Common;

namespace ProductApi.Domain.Entities
{
    public class Brand : EntityBase {

        public Brand() {
            
        }

        public Brand(string name) {
            Name = name;
        }
        public String Name { get; set; }
    }
}
