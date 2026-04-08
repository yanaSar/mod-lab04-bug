// BugTests/UnitTest1.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BugPro;

namespace BugTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_InitialState_ShouldBeNewDefected()
        {
            // Arrange & Act
            var bug = new Bug();

            // Assert
            Assert.AreEqual(Bug.State.NewDefected, bug._machine.State);
        }

        [TestMethod]
        public void Test_NewDefected_To_RazborDefectoved_AfterRazborDefectov()
        {
            // Arrange
            var bug = new Bug();

            // Act
            bug._machine.Fire(Bug.Action.RazborDefectov);

            // Assert
            Assert.AreEqual(Bug.State.RazborDefectoved, bug._machine.State);
        }

        [TestMethod]
        public void Test_RazborDefectoved_To_NeedMoreInfoed_AfterNeedMoreInfo()
        {
            // Arrange
            var bug = new Bug();
            bug._machine.Fire(Bug.Action.RazborDefectov);

            // Act
            bug._machine.Fire(Bug.Action.NeedMoreInfo);

            // Assert
            Assert.AreEqual(Bug.State.NeedMoreInfoed, bug._machine.State);
        }

        [TestMethod]
        public void Test_RazborDefectoved_To_NoVosproizvodimoed_AfterNoVosproizvodimo()
        {
            // Arrange
            var bug = new Bug();
            bug._machine.Fire(Bug.Action.RazborDefectov);

            // Act
            bug._machine.Fire(Bug.Action.NoVosproizvodimo);

            // Assert
            Assert.AreEqual(Bug.State.NoVosproizvodimoed, bug._machine.State);
        }

        [TestMethod]
        public void Test_RazborDefectoved_To_Ispravlenied_AfterIspravlenie()
        {
            // Arrange
            var bug = new Bug();
            bug._machine.Fire(Bug.Action.RazborDefectov);

            // Act
            bug._machine.Fire(Bug.Action.Ispravlenie);

            // Assert
            Assert.AreEqual(Bug.State.Ispravlenied, bug._machine.State);
        }

        [TestMethod]
        public void Test_NeedMoreInfoed_BackTo_RazborDefectoved_AfterRazborDefectov()
        {
            // Arrange
            var bug = new Bug();
            bug._machine.Fire(Bug.Action.RazborDefectov);
            bug._machine.Fire(Bug.Action.NeedMoreInfo);

            // Act
            bug._machine.Fire(Bug.Action.RazborDefectov);

            // Assert
            Assert.AreEqual(Bug.State.RazborDefectoved, bug._machine.State);
        }

        [TestMethod]
        public void Test_NeedMoreInfoed_To_Ispravlenied_AfterIspravlenie()
        {
            // Arrange
            var bug = new Bug();
            bug._machine.Fire(Bug.Action.RazborDefectov);
            bug._machine.Fire(Bug.Action.NeedMoreInfo);

            // Act
            bug._machine.Fire(Bug.Action.Ispravlenie);

            // Assert
            Assert.AreEqual(Bug.State.Ispravlenied, bug._machine.State);
        }

        [TestMethod]
        public void Test_NoVosproizvodimoed_To_Closed_AfterClose()
        {
            // Arrange
            var bug = new Bug();
            bug._machine.Fire(Bug.Action.RazborDefectov);
            bug._machine.Fire(Bug.Action.NoVosproizvodimo);

            // Act
            bug._machine.Fire(Bug.Action.Close);

            // Assert
            Assert.AreEqual(Bug.State.Closed, bug._machine.State);
        }

        [TestMethod]
        public void Test_NoVosproizvodimoed_To_Returned_AfterReturn()
        {
            // Arrange
            var bug = new Bug();
            bug._machine.Fire(Bug.Action.RazborDefectov);
            bug._machine.Fire(Bug.Action.NoVosproizvodimo);

            // Act
            bug._machine.Fire(Bug.Action.Return);

            // Assert
            Assert.AreEqual(Bug.State.Returned, bug._machine.State);
        }

        [TestMethod]
        public void Test_Returned_To_RazborDefectoved_AfterRazborDefectov()
        {
            // Arrange
            var bug = new Bug();
            bug._machine.Fire(Bug.Action.RazborDefectov);
            bug._machine.Fire(Bug.Action.NoVosproizvodimo);
            bug._machine.Fire(Bug.Action.Return);

            // Act
            bug._machine.Fire(Bug.Action.RazborDefectov);

            // Assert
            Assert.AreEqual(Bug.State.RazborDefectoved, bug._machine.State);
        }

        [TestMethod]
        public void Test_Ispravlenied_To_ProblemaReshenaed_AfterProblemaReshena()
        {
            // Arrange
            var bug = new Bug();
            bug._machine.Fire(Bug.Action.RazborDefectov);
            bug._machine.Fire(Bug.Action.Ispravlenie);

            // Act
            bug._machine.Fire(Bug.Action.ProblemaReshena);

            // Assert
            Assert.AreEqual(Bug.State.ProblemaReshenaed, bug._machine.State);
        }

        [TestMethod]
        public void Test_ProblemaReshenaed_To_Closed_AfterClose()
        {
            // Arrange
            var bug = new Bug();
            bug._machine.Fire(Bug.Action.RazborDefectov);
            bug._machine.Fire(Bug.Action.Ispravlenie);
            bug._machine.Fire(Bug.Action.ProblemaReshena);

            // Act
            bug._machine.Fire(Bug.Action.Close);

            // Assert
            Assert.AreEqual(Bug.State.Closed, bug._machine.State);
        }

        [TestMethod]
        public void Test_ProblemaReshenaed_To_Returned_AfterReturn()
        {
            // Arrange
            var bug = new Bug();
            bug._machine.Fire(Bug.Action.RazborDefectov);
            bug._machine.Fire(Bug.Action.Ispravlenie);
            bug._machine.Fire(Bug.Action.ProblemaReshena);

            // Act
            bug._machine.Fire(Bug.Action.Return);

            // Assert
            Assert.AreEqual(Bug.State.Returned, bug._machine.State);
        }

        [TestMethod]
        public void Test_Closed_To_PereOpened_AfterPereOpene()
        {
            // Arrange
            var bug = new Bug();
            bug._machine.Fire(Bug.Action.RazborDefectov);
            bug._machine.Fire(Bug.Action.Ispravlenie);
            bug._machine.Fire(Bug.Action.ProblemaReshena);
            bug._machine.Fire(Bug.Action.Close);

            // Act
            bug._machine.Fire(Bug.Action.PereOpene);

            // Assert
            Assert.AreEqual(Bug.State.PereOpened, bug._machine.State);
        }

        [TestMethod]
        public void Test_PereOpened_To_RazborDefectoved_AfterRazborDefectov()
        {
            // Arrange
            var bug = new Bug();
            bug._machine.Fire(Bug.Action.RazborDefectov);
            bug._machine.Fire(Bug.Action.Ispravlenie);
            bug._machine.Fire(Bug.Action.ProblemaReshena);
            bug._machine.Fire(Bug.Action.Close);
            bug._machine.Fire(Bug.Action.PereOpene);

            // Act
            bug._machine.Fire(Bug.Action.RazborDefectov);

            // Assert
            Assert.AreEqual(Bug.State.RazborDefectoved, bug._machine.State);
        }

        [TestMethod]
        public void Test_FullWorkflow_NewDefectedToClosed_ShouldCompleteSuccessfully()
        {
            // Arrange
            var bug = new Bug();

            // Act
            bug._machine.Fire(Bug.Action.RazborDefectov);
            bug._machine.Fire(Bug.Action.Ispravlenie);
            bug._machine.Fire(Bug.Action.ProblemaReshena);
            bug._machine.Fire(Bug.Action.Close);

            // Assert
            Assert.AreEqual(Bug.State.Closed, bug._machine.State);
        }

        [TestMethod]
        public void Test_FullWorkflow_WithReopen_ShouldReturnToRazborDefectoved()
        {
            // Arrange
            var bug = new Bug();

            // Act
            bug._machine.Fire(Bug.Action.RazborDefectov);
            bug._machine.Fire(Bug.Action.Ispravlenie);
            bug._machine.Fire(Bug.Action.ProblemaReshena);
            bug._machine.Fire(Bug.Action.Close);
            bug._machine.Fire(Bug.Action.PereOpene);
            bug._machine.Fire(Bug.Action.RazborDefectov);

            // Assert
            Assert.AreEqual(Bug.State.RazborDefectoved, bug._machine.State);
        }
    }
}