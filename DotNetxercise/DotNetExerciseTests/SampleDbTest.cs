using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetExercise.DAL;
using DotNetExercise.DAL.Entities;
using DotNetExercise.DAL.Interfaces;

namespace DotNetExerciseTests
{
    [TestFixture]
    public class SampleDbTest
    {
        [Test]
        public void TestSampleDb()
        {
            Employee employee;

            using (UnitOfWork uow = new UnitOfWork())
            {
                employee = uow.EmployeeRepository.FirstOrDefault(x => x.EmployeeId == 1);
            }

            Assert.IsNotNull(employee);
            Assert.AreEqual(employee.EmployeeId, 1);
        }
    }
}
