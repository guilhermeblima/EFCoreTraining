using System;
using System.Collections.Generic;
using EFCoreTrainning.ValueObjects;
namespace EFCoreTrainning.Domain
{   
    public class Order
    {
        public int Id {get; set;}
        public int CustomerId {get; set;}
        public Customer Customer {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}
        public ShippingType ShippingType {get; set;}
        public OrderStatus OrderStatus {get; set;}
        public string Comments {get; set;}
        public ICollection<OrderItem> OrderItems {get; set;}
    }
    
}