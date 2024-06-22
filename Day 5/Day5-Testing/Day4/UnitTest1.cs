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
	public class UnitTest1
	{
		private readonly ITestOutputHelper output;
		public UnitTest1(ITestOutputHelper output)
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
			AutomationElement loginButton = mainWindow.FindFirstDescendant(cf.ByAutomationId("button2"));
			AutomationElement emailField = mainWindow.FindFirstDescendant(cf.ByAutomationId("EmLog"));
			AutomationElement passwordField = mainWindow.FindFirstDescendant(cf.ByAutomationId("PassLog"));

			//emailField.DrawHighlight();
			//passwordField.DrawHighlight();
			//loginButton.DrawHighlight();


			//Test1 - user si parola gresite

			emailField.AsTextBox().Enter("lehelb@gmail.com");
			passwordField.AsTextBox().Enter("54321");
			loginButton.AsButton().Click();
			Thread.Sleep(200);
			Window[] windows = application.GetMainWindow(automation).ModalWindows;
			Assert.True(windows.Length > 0, "Nu avem fereastra modala - test failed");
			output.WriteLine("Test OK - Login with wrong credentials has failed");
			Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.ENTER);

			//Test2 
			emailField.AsTextBox().Enter("blehel@yahoo.com");
			passwordField.AsTextBox().Enter("54321");
			loginButton.AsButton().Click();
			Thread.Sleep(200);
			Assert.True(windows.Length > 0, "Nu avem fereastra modala - test failed");
			output.WriteLine("Test OK - Login with good username/ wrong pass");
			Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.ENTER);

			//Test3

			emailField.AsTextBox().Enter("blehel@yahoo.com");
			passwordField.AsTextBox().Enter("12345");
			loginButton.AsButton().Click();
			Thread.Sleep(200);
			windows = application.GetMainWindow(automation).ModalWindows;
			Assert.True(windows.Length == 0, "Not logged in - test failed");
			output.WriteLine("Test OK - Login with good username and good password succesfull");


		}

	
	}

}