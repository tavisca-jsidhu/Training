using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomAttribute;

namespace Testing.Model
{
    [TestClass]
    class Height
    {
        [TestMethod]
        [TestCategory("Smoke Test")]
        public void SphereHeight()
        {
        }
        [TestMethod]
        public void CubeHeight()
        {
        }
        [Ignore]
        public void CuboidHeight()
        {
        }
    }

    [TestClass]
    class Length
    {
        [TestMethod]
        [TestCategory("Smoke Test")]
        public void SphereLength()
        {
        }
        [Ignore]
        public void CubeLength()
        {
        }
        [TestMethod]
        [TestCategory("Smoke Test")]
        public void CuboidLength()
        {
        }
    }

    [TestClass]
    class Breadth
    {
        [TestMethod]
        public void SphereBreadth()
        {
        }
        [TestMethod]
        [TestCategory("Smoke Test")]
        public void CubeBreadth()
        {
        }
        [Ignore]
        public void CuboidBreadth()
        {
        }
    }
}