namespace CardStock.GameObj
{
    public class StrLit(string s) : IString
    {

        private readonly string s = s;

        public string Get()
        {
            return s;
        }
    }
}