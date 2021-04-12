using AdresSysteem;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProjectAdresSysteem
{
    public class UnitTestAdresbeheerder
    {
        [Fact]
        public void Test_VoegAdresToe_valid()
        {
            Adres a1 = new Adres("gent", "lostraat", "12");
            Adres a2 = new Adres("gent", "lostraat", "14");
            Adresbeheerder ab = new Adresbeheerder();
            ab.VoegAdresToe(a1);

            Assert.Single(ab.Adressen);
            Assert.Contains(a1, ab.Adressen);

            ab.VoegAdresToe(a2);
            Assert.Equal(2, ab.Adressen.Count);
            Assert.Contains(a1, ab.Adressen);
            Assert.Contains(a2, ab.Adressen);
        }
        [Fact]
        public void Test_VoegAdresToe_invalid()
        {
            Adres a1 = new Adres("gent", "lostraat", "12");
            Adres a2 = new Adres("gent", "lostraat", "12");
            Adresbeheerder ab = new Adresbeheerder();
            ab.VoegAdresToe(a1);

            Assert.Single(ab.Adressen);
            Assert.Contains(a1, ab.Adressen);

            Assert.Throws<AdresbeheerderException>(() => ab.VoegAdresToe(a2));
            Assert.Single(ab.Adressen);
            Assert.Contains(a1, ab.Adressen);
        }
    }
}
