using AdresSysteem;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProjectAdresSysteem
{
    public class UnitTestAdresbeheerder
    {
        private Adres a1, a2,a3;
        private Adresbeheerder ab;

        public UnitTestAdresbeheerder()
        {
            a1 = new Adres("gent", "lostraat", "12");
            a2 = new Adres("gent", "lostraat", "14");
            a3 = new Adres("Gent", "lostraat", "12");
        }

        [Fact]
        public void Test_VoegAdresToe_valid()
        {
            
            ab = new Adresbeheerder();
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
            ab = new Adresbeheerder();
            ab.VoegAdresToe(a1);

            Assert.Single(ab.Adressen);
            Assert.Contains(a1, ab.Adressen);

            Assert.Throws<AdresbeheerderException>(() => ab.VoegAdresToe(a3));
            Assert.Single(ab.Adressen);
            Assert.Contains(a1, ab.Adressen);
        }
    }
}
