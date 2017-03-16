using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PTCData
{
    public class TrainingProductViewModel
    {
        public TrainingProductViewModel()
        {
           Init();

            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();
            
    }

        public string EventCommand { get; set; }
        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity{ get; set; }
        public  TrainingProduct Entity { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }
        public  string EventArgument { get; set; }

        private void Init()
        {
            EventCommand = "List";
            EventArgument = string.Empty;

            ValidationErrors = new List<KeyValuePair<string, string>>();

            ListMode();
        }

        public void HandleRequest()
        {
            switch(EventCommand.ToLower()){
                case "list":
                case "search":
                    Get();
                    break;

                case "save":
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    break;

                case "edit":
                    IsValid = true;
                    Edit();
                    break;

                case "delete":
                    ResetSearch();
                    Delete();
                    break;

                case "cancel":
                    ListMode();
                    Get();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;

                case "add":
                   Add();
                    break;


                default:
                    break;
            }
        }

        private void Save()
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

            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }
            

            if (!IsValid)
            { 
                if (Mode == "Add")
                {
                    AddMode();
                }
                else
                {
                    EditMode();
                }
            }
        }

        private void ListMode()
        {
            IsValid = true;

            IsDetailAreaVisible = false;
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;

            Mode = "List";
        }

        private void Add()
        {
            IsValid = true;

            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = "http://";
            Entity.Price = 0;

            AddMode();
        }

        private void Edit()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Entity = mgr.Get(Convert.ToInt32(EventArgument));

            EditMode(); 
        }

        private void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Entity = new TrainingProduct();

            Entity.ProductId = Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);
            Get();

            ListMode();
        }
        private void AddMode()
        {
      
            IsDetailAreaVisible = true;
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;

            Mode = "Add";
        }

        private void EditMode()
        {

            IsDetailAreaVisible = true;
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;

            Mode = "Edit";
        }

        private void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
        }

        private void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Products = mgr.Get(SearchEntity);
        }
    }
}
