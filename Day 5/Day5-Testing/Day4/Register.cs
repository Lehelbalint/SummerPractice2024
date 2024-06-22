using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Day5
{
	public class Register
	{
		private readonly ITestOutputHelper output;
		public Register(ITestOutputHelper output)
		{

		this.output = output; }
		[Fact]
		public void Test1()
		{
			var processExists = Process.GetProcesses().Any(p => p.ProcessName.Contains("Bank"));
			Application application;
			if (!processExists)
			{
				var psi = new ProcessStartInfo
				{
					FileName = @"D:\SummerPractice2024-BalintLehel\SummerPractice2024\Day 5\BS\BankSystem.exe",
					Arguments = "",
					WorkingDirectory = @"D:\SummerPractice2024-BalintLehel\SummerPractice2024\Day 5\BS"
				};
				application = Application.Launch(psi);
			}
			else
			{
				application = Application.Attach(Process.GetProcesses().First(p => p.ProcessName.Contains("Bank")));
	
			}
			var automation = new UIA3Automation();
			ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
			//inspector joc
			var mainWindow = application.GetMainWindow(automation);
			mainWindow.SetForeground();
			AutomationElement registerButton = mainWindow.FindFirstDescendant(cf.ByAutomationId("button1"));
			registerButton.AsButton().Click();
			AutomationElement firstName = mainWindow.FindFirstDescendant(cf.ByAutomationId("InFName"));
			AutomationElement lastName = mainWindow.FindFirstDescendant(cf.ByAutomationId("InLName"));
			AutomationElement Age = mainWindow.FindFirstDescendant(cf.ByAutomationId("InAge")).FindFirstChild(cf.ByAutomationId(""));
			

			firstName.AsTextBox().Enter("lehel");
			lastName.AsTextBox().Enter("balint");
			Age.Click();
			mainWindow = application.GetMainWindow(automation);
			AutomationElement setAge = mainWindow.FindFirstDescendant(cf.ByName("22"));
			setAge.Click();
			mainWindow = application.GetMainWindow(automation);
			AutomationElement Country = mainWindow.FindFirstDescendant(cf.ByAutomationId("InCountry")).FindFirstChild(cf.ByAutomationId(""));
			Country.Click();
			mainWindow = application.GetMainWindow(automation);
			AutomationElement setCountry = mainWindow.FindFirstDescendant(cf.ByName("Aruba"));
			setCountry.Click();
			mainWindow = application.GetMainWindow(automation);
			AutomationElement PhoneNumber = mainWindow.FindFirstDescendant(cf.ByAutomationId("InPhone"));
			AutomationElement Email = mainWindow.FindFirstDescendant(cf.ByAutomationId("InEmail"));
			AutomationElement Password = mainWindow.FindFirstDescendant(cf.ByAutomationId("InPass"));
			AutomationElement Visa = mainWindow.FindFirstDescendant(cf.ByAutomationId("InCard"));
			PhoneNumber.AsTextBox().Enter("0000000000");
			Email.AsTextBox().Enter("bl1234435ehel@gmail.com");
			Password.AsTextBox().Enter("1234567");
			Visa.AsTextBox().Enter("1234512345123456");
			AutomationElement okButton = mainWindow.FindFirstDescendant(cf.ByAutomationId("button1"));
			okButton.AsButton().Click();
			Thread.Sleep(200);
			Window[] windows = application.GetMainWindow(automation).ModalWindows;
			Assert.True(windows[0].FindFirstDescendant(cf.ByName("Congratulations")) != null, "Regisered");
			output.WriteLine("Test OK - Registered");
			Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.ENTER);


		}

	
	}

}