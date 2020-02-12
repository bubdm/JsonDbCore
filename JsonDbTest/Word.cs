namespace JsonDbTest
{
    public class Word
    {
        public string W { get; set; }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
