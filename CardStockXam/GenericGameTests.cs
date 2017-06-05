using NUnit.Framework;
using System;
namespace CardStockXam
{
    [TestFixture()]
    public class NUnitTestClass
	// TODO need access to CardGame class at different points in game to ensure
    //   games function properly - right now instance is bured in ParseEngine 
    //   game loop 

    // Tests should run each time a GameAction is executed(?) & will propably
    //  need to be tailored to each game
	{
        
        [Test()]
        public void ConsistentCards()
        {
             
             //check if always correct number of cards in:
	             //-all hands
	             //-stock
	             //-trick
	             //-bounty
	             //-etc
        }

        [Test()]
        public void ConsistentOrder()
        {
            // check if player turn order works
        }

        [Test()]
        public void NoDupes()
        {
            // check if always only one instance of each card 
        }

        // other ideas:
        //   check if betting works (if bet adds or subtracts from chips properly)
        //   check card information (if cards are invisible when supposed to be)
        //   check 

    }
}
