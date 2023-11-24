using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobileliblary.shared.Configutations
{
    public class BaseProductEndpoint
    {
        public string Base_url { get; set; }

        public string GetAllProductsEndpoint { get; set; }

        public string GetProductEndpoint { get; set; }

        public string ChangeProductEndpoint { get; set; }

        public string DeleteProductEndpoint { get; set; }

        public string AddProductEndpoint { get; set; }
    }
}
