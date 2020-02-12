using System.Collections.Generic;

namespace JsonDbTest
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<string> Content { get; set; }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
