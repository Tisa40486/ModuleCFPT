namespace Inscription.Tests
{
    public class UserTests
    {
        [Fact]
        public void RefuseAcces_EmailVide_Error()
        {
            Assert.Throws<ArgumentException>(() => new User("", ""));
        }
    }
}