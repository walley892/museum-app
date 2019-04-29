using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using NUnit.Framework;

namespace Testing
{
    [TestFixture]
    public class LocalModelManagerTests
    {
        private LocalModelManager _mm;

        public LocalModelManagerTests()
        {
            _mm = new LocalModelManager("artifacts/");
        }

        //Assures there's some (possibly empty) list of model ids
        [Test]
        public void availableModelIdsTest()
        {
            int[] ids = _mm.availableModelIds();
            Assert.IsNotNull(ids);
        }

        //Ensure each model has a mesh
        [Test]
        public void LoadMeshTest()
        {
            int[] ids = _mm.availableModelIds();
            foreach (int id in ids)
            {
                Mesh mesh = _mm.getMesh(id);
                Assert.IsNotNull(mesh);
            }
        }

        //Ensure each model has a texture
        [Test]
        public void LoadTextureTest()
        {
            int[] ids = _mm.availableModelIds();
            foreach (int id in ids)
            {
                Texture2D tex = _mm.getTexture(id);
                Assert.IsNotNull(tex);
            }
        }

        //Ensure that each model has a tracked image
        [Test]
        public void GetTrackedImageTest()
        {
            int[] ids = _mm.availableModelIds();
            foreach (int id in ids)
            {
                Texture2D im = _mm.getTrackedImage(id);
                Assert.IsNotNull(im);
            }
        }

        //Checks if two Unity colors have the same rgb values
        public bool Equal(Color a, Color b)
        {
            return a.r == b.r && a.g == b.g && a.b == b.b && a.a == b.a;
        }

        //Checks if two Unity textures have all the same pixel values
        public bool Equal(Texture2D a, Texture2D b)
        {

            Color[] aPixels = a.GetPixels();
            Color[] bPixels = b.GetPixels();
            if (aPixels.Length != bPixels.Length)
            {
                return false;
            }

            for (int i = 0; i < aPixels.Length; ++i)
            {
                if (!Equals(aPixels[i], bPixels[i]) )
                {
                    return false;
                }
            }

            return true;
        }


        //Ensure that no two models have the same tracked image assigned
        [Test]
        public void NoTwoImagesSameTest()
        {
            int[] ids = _mm.availableModelIds();

            Texture2D[] images = new Texture2D[ids.Length];

            for (int i = 0; i < ids.Length; ++i)
            {
                images[i] = _mm.getTrackedImage(i);
            }

            for (int i = 0; i < ids.Length; ++i)
            {
                for(int j = i + 1; j < ids.Length; ++j)
                {
                    Assert.IsFalse( Equals(images[i], images[j]) );
                }
            }
        }
    }
}