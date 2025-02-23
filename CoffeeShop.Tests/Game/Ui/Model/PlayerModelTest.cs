using CoffeeShop.MVC.Model;
using NUnit.Framework;

namespace CoffeeShop.Tests.Game.Ui.Model;

// [TestFixture]
// [TestOf(typeof(PlayerModel))]
public class PlayerModelTest
{

    [Test]
    public void METHOD()
    {
        PlayerModel playerModel = new PlayerModel();
        playerModel.SetName("name");
        Assert.That(playerModel.GetName(), Is.EqualTo("name"));
    }
    
    
}