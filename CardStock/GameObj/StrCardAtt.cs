namespace CardStock.GameObj
{
    public class StrCardAtt(IString str) : IString
    {

        private IString str = str;

        public string Get()
        {
            /*
            var loc = ProcessCard(cardatt.card());
            if (loc.cardList.Count > 0)
            {
                var card = loc.Get();
                if (card is not null)
                {
                    Debug.WriteLine("Att2 is " + card.ReadAttribute(str.Get()));
                    return card.ReadAttribute(str.Get());
                }
            }*/
            return "";
        }
    }
}