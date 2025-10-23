using Xunit;
using FluentAssertions;
using POSv2.UI.ViewModels.Employees;
using POSv2.Domain.Entities;
using Moq;
using POSv2.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POSv2.Tests.ViewModels
{
    public class EmployeeViewModelTests
    {
        private EmployeeViewModel GetViewModel(List<Employee>? employees = null)
        {
            var employeeService = new Mock<IEmployeeService>();
            employees ??= new List<Employee>
            {
                new Employee { Id = System.Guid.NewGuid(), Name = "Juan", Username = "juan", EmployeeNumber = 1, Role = EmployeeRole.Cashier }
            };
            employeeService.Setup(x => x.GetAllEmployeesAsync()).ReturnsAsync(employees);
            employeeService.Setup(x => x.AddEmployeeAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);
            employeeService.Setup(x => x.UpdateEmployeeAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);
            employeeService.Setup(x => x.DeleteEmployeeAsync(It.IsAny<System.Guid>())).Returns(Task.CompletedTask);

            return new EmployeeViewModel(employeeService.Object);
        }

        [Fact]
        public async Task AddEmployeeCommand_ShouldAddEmployee()
        {
            var vm = GetViewModel();
            vm.EmployeeNumber = 2;
            vm.Name = "Carlos";
            vm.Username = "carlos";
            vm.Role = EmployeeRole.Manager;
            vm.Password = "123";
            vm.ConfirmPassword = "123";
            await vm.AddEmployeeCommand.ExecuteAsync(null);

            vm.Employees.Should().Contain(e => e.Username == "carlos");
        }

        [Fact]
        public async Task EditEmployeeCommand_ShouldUpdateEmployee()
        {
            var vm = GetViewModel();
            var emp = vm.Employees[0];
            vm.SelectedEmployee = emp;
            vm.Name = "Juanito";
            vm.Password = "abc";
            vm.ConfirmPassword = "abc";
            await vm.EditEmployeeCommand.ExecuteAsync(null);

            vm.Employees[0].Name.Should().Be("Juanito");
        }

        [Fact]
        public async Task DeleteEmployeeCommand_ShouldRemoveEmployee()
        {
            var vm = GetViewModel();
            var emp = vm.Employees[0];
            vm.SelectedEmployee = emp;
            await vm.DeleteEmployeeCommand.ExecuteAsync(null);

            vm.Employees.Should().NotContain(e => e.Username == "juan");
        }
    }
}