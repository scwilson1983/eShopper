using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.ValueObjects;

namespace Domain.Aggregates
{
    public class Trolley
    {
        public string Id { get; }
        public string Username { get; }
        public decimal TrolleyTotalCost => Items.Select(i => i.TotalCost).Sum();
        public ICollection<TrolleyItem> Items { get; }
        public TrolleyStatus Status { get; }        

        public Trolley(string username, params TrolleyItem[] items)
        {
            Username = username;
            Items = items;
            Id = Guid.NewGuid().ToString();
            Status = TrolleyStatus.Open;
        }

        public void AddItem(TrolleyItem item)
        {
            Items.Add(item);           
        }
    }
}
