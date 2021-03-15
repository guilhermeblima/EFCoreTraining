using EFCoreTrainning.ValueObjects;
namespace EFCoreTrainning.Domain
{   
    public class Product
    {
        public int Id {get; set;}
        public string BarCode {get; set;}
        public string Description {get; set;}
        public decimal Amount {get; set;}
        public ProductType ProductType {get; set;}
        public bool Active {get; set;}
    }
    
}