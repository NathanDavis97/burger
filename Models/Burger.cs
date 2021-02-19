using System;

namespace burger.Models
{
    public class Burger
    {
       public Burger()
    {

    }
        public Burger( string description, float price, string name)
        {
            Price = price;
            Name = name;
      Description = description;
    }

    public string Description { get; set; }
    public float Price { get; set; }
    public string Name { get; set; }
    public int Id { get; set; }
  }
}