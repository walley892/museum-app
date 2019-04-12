using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class UITests : UITest
    {

        // ************************* MAIN MENU TESTS ****************************************************************************************

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator UIInstantiates()
        {
            yield return LoadScene("MainMenu");

            Assert.IsTrue(GameObject.Find("Entrance").activeInHierarchy);
            Assert.IsNull(GameObject.Find("Main Menu"));
            
            yield return null;
        }

        [UnityTest]
        public IEnumerator EntranceButton()
        {
            yield return LoadScene("MainMenu");

            Assert.IsTrue(GameObject.Find("Entrance").activeInHierarchy);
            Assert.IsNull(GameObject.Find("Main Menu"));
            
            yield return Press("EnterButton");

            Assert.IsTrue(GameObject.Find("Main Menu").activeInHierarchy);
            Assert.IsNull(GameObject.Find("Entrance"));

            yield return null;
        }

        [UnityTest]
        public IEnumerator BackButton()
        {
            yield return LoadScene("MainMenu");
            yield return Press("EnterButton");
            yield return Press("BackButton");

            Assert.IsTrue(GameObject.Find("Entrance").activeInHierarchy);
            Assert.IsNull(GameObject.Find("Main Menu"));

            yield return null;
        }

        [UnityTest]
        public IEnumerator TourButton()
        {
            yield return LoadScene("MainMenu");
            yield return Press("EnterButton");
            yield return Press("TourButton");

            Assert.AreEqual("AugmentedReality", SceneManager.GetActiveScene().name);

            yield return null;
        }

        [UnityTest]
        public IEnumerator LibraryButton()
        {
            yield return LoadScene("MainMenu");
            yield return Press("EnterButton");
            yield return Press("LibraryButton");

            Assert.AreEqual("Library", SceneManager.GetActiveScene().name);

            yield return null;
        }     
        
        // *********************** LIBRARY UI TESTS *************************************************************************************************

        [UnityTest]
        public IEnumerator LibUIInstantiates()
        {
            yield return LoadScene("Library");

            Assert.IsTrue(GameObject.Find("BackButton").activeInHierarchy);
            Assert.IsNull(GameObject.Find("Library UI"));
            
            yield return null;
        }

        [UnityTest]
        public IEnumerator LibBackButton()
        {
            yield return LoadScene("Library");
            yield return Press("BackButton");

            Assert.AreEqual("MainMenu", SceneManager.GetActiveScene().name);

            yield return null;
        }     



    }
}
