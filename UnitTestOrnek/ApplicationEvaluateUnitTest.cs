using JobApplicationLibrary;
using JobApplicationLibrary.Models;
using NUnit.Framework;

namespace UnitTestOrnek
{
    public class ApplicationEvaluateUnitTest
    {
        //isimlendirmede ya durum sonuç olarak kullanılır    
        //isimlendirme Condition_Result olabilir
        // UnitOfWork_Condition_ExceptedResult

        [Test]
        public void Application_WithUnderAge_TransferredToAutoRejected()
        {
            //Arrange
            var evaluator = new ApplicationEvaluator();
            var form = new JobApplication()
            {
                Applicant = new Applicant()
                {
                    Age = 18
                }
            };

            //Action
            var appResult = evaluator.Evaluate(form);

            //Assert
            Assert.AreEqual(appResult, ApplicationResult.AutoRejected);
        }


        [Test]
        public void Application_WithNoTechStack_TransferredToAutoRejected()
        {
            // Arrange
            var evaluator = new ApplicationEvaluator();
            var form = new JobApplication()
            {
                Applicant = new Applicant() { Age = 15} ,
                TechStackList = new System.Collections.Generic.List<string>() 
                {
                    "C#", "Angular" ,".Met"
                },
                YearOfExperience = 1
            };

            // Action
            var appResult = evaluator.Evaluate(form);

            // Assert
            Assert.AreEqual(appResult, ApplicationResult.AutoRejected);
        }
    }
}

