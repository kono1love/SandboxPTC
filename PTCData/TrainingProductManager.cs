using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PTCData
{
    public class TrainingProductManager
    {
        public TrainingProductManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
     }

        public List<KeyValuePair<string, string>>  ValidationErrors  { get; set; }

        public bool Validate(TrainingProduct entity)
        {
            ValidationErrors.Clear();

            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                if (entity.ProductName.ToLower() == entity.ProductName)
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("ProductName", "Product Name must not be lower case"));
                }
            }
            return (ValidationErrors.Count == 0);
        }

        public bool Delete(TrainingProduct entity)
        {
            //TODO: Create delete code

            return true;
        }

        public TrainingProduct Get(int productId)
        {
            List<TrainingProduct> list = new List<TrainingProduct>();
            
            TrainingProduct ret = new TrainingProduct();

            //TODO: Call your data access method here
            list = CreateMockData();

            ret = list.Find(p => p.ProductId == productId);

            return ret;
        }

        public bool Update(TrainingProduct entity)
        {
            bool ret = false;

            ret = Validate(entity);

            if (ret)
            {
                //TODO: Create UPDATE code here
            }

            return ret;
        }
        public bool Insert(TrainingProduct entity)
        {
            bool ret = false;

            ret = Validate(entity);

            if (ret)
            {
                //TODO: Create INSERT code here
            }

            return ret;
        }

        public List<TrainingProduct> Get(TrainingProduct entity)
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();

            //TODO: Add your data access method here
            ret = CreateMockData();

            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(entity.ProductName, StringComparison.CurrentCultureIgnoreCase));
            }

            return ret;
        }
        private List<TrainingProduct> CreateMockData()
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();

            ret.Add(new TrainingProduct() {
                ProductId = 1,
                ProductName = "Extending Bootstrap with CSS, JS and Jquery",
                IntroductionDate = Convert.ToDateTime("6/11/2017"),
                Url = "http://bit.ly",
                Price = Convert.ToDecimal(29.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 1,
                ProductName = "Extending Bootstrap with CSS, JS and Jquery",
                IntroductionDate = Convert.ToDateTime("6/11/2016"),
                Url = "http://bit.ly",
                Price = Convert.ToDecimal(29.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 2,
                ProductName = "Building mobile version of web sites",
                IntroductionDate = Convert.ToDateTime("6/12/2016"),
                Url = "http://bit.ly",
                Price = Convert.ToDecimal(31.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 3,
                ProductName = "Whatever, I'm just training",
                IntroductionDate = Convert.ToDateTime("1/01/2017"),
                Url = "http://bit.ly",
                Price = Convert.ToDecimal(228.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 4,
                ProductName = "So.. bla bla",
                IntroductionDate = Convert.ToDateTime("3/02/2017"),
                Url = "http://bit.ly",
                Price = Convert.ToDecimal(14.88)
            });

            return ret;
        }
    }
}
