using System;
using System.Collections.Generic;
using PTCCommon;

namespace PTCData
{
    public class TrainingProductViewModel : BaseViewModel
    {
        public TrainingProductViewModel() : base()
        {   
    }
      
        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity{ get; set; }
        public  TrainingProduct Entity { get; set; }

        protected override void Init()
        {
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();

            base.Init();
        }

        public override void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "paul":
                    break;

                default:
                    break;
            }
            base.HandleRequest();
        }

        protected override void Save()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            if (Mode == "Add")
            {
                mgr.Insert(Entity);
            }
            else
            {
                mgr.Update(Entity);
            }

            ValidationErrors = mgr.ValidationErrors;

            base.Save();
        }

        protected override void Add()
        {
            IsValid = true;

            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = "http://";
            Entity.Price = 0;

            base.Add();
        }

        protected override void Edit()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Entity = mgr.Get(Convert.ToInt32(EventArgument));

            base.Edit(); 
        }

        protected override void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Entity = new TrainingProduct();

            Entity.ProductId = Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);
            Get();

            base.Delete();
        }
    
        protected override void ResetSearch()
        {
            SearchEntity = new TrainingProduct();

            base.ResetSearch();
        }

        protected override void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Products = mgr.Get(SearchEntity);

            base.Get();
        }
    }
}
