using System.Collections.Generic;
using burger.Models;

namespace burger.db
{
    public class FakeDb
    {
    public static List<Burger> Burgers { get; set; } = new List<Burger>();
  }
}