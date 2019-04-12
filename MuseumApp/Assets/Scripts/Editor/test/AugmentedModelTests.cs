using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using NUnit.Framework;
using GoogleARCore;


namespace Testing
{
    [TestFixture]
    public class AugmentedModelTests
    {
        public AugmentedModelTests()
        {
            
        }

        private bool ApproxEqual(float a, float b, float eps)
        {
            return Mathf.Abs(a - b) <= eps;
        }


        [Test]
        public void rotateLeftTest()
        {
            GameObject dummy = new GameObject();
            Transform b = dummy.transform;

            GameObject modelGameObj = new GameObject();
            AugmentedModel model = modelGameObj.AddComponent<AugmentedModel>();


            float expectedRotation = 0;

            for(int i = 0; i < 100; ++i)
            {
                float rotationAmt = Random.value;

                model.rotateLeft(rotationAmt);

                expectedRotation += rotationAmt;

                Assert.IsTrue(ApproxEqual(modelGameObj.transform.eulerAngles.y, expectedRotation, 0.001f));
            }
            
        }

        [Test]
        public void rotateRightTest()
        {
            GameObject dummy = new GameObject();
            Transform b = dummy.transform;

            GameObject modelGameObj = new GameObject();
            AugmentedModel model = modelGameObj.AddComponent<AugmentedModel>();


            float expectedRotation = 0;

            for (int i = 0; i < 100; ++i)
            {
                float rotationAmt = Random.value;

                model.rotateRight(rotationAmt);

                expectedRotation -= rotationAmt;

                Assert.IsTrue(ApproxEqual(modelGameObj.transform.eulerAngles.y, expectedRotation, 0.001f));
            }

        }

    }
}