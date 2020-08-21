using System.Collections.Generic;
using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;

#if UITEST
using Xamarin.Forms.Core.UITests;
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace Xamarin.Forms.Controls.Issues
{
#if UITEST
	[Category(UITestCategories.ToolbarItem)]
	[Category(UITestCategories.Accessibility)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 1, "Issue Description", PlatformAffected.iOS)]
	public class IssueXXX : TestContentPage
	{
		protected override void Init()
		{
			Content = new StackLayout
			{
				Children =
				{
					new Label
					{
						Text = "Root Page",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center
					}
				}
			};

			ToolbarItems = new List<ToolbarItem>
			{
				new ToolbarItem
				{
					AutomationId = "FirstToolbarButtonAutomationId", Text = "FirstToolbarButton"
				}
			};

			var testPage = new ContentPage
			{
				Content = new StackLayout
				{
					Children =
					{
						new Label
						{
							Text = "Second Page",
							HorizontalOptions = LayoutOptions.Center,
							VerticalOptions = LayoutOptions.Center
						}
					}
				},
				ToolbarItems = new List<ToolbarItem>
				{
					new ToolbarItem
					{
						AutomationId = "SecondToolbarButtonAutomationId", Text = "SecondToolbarButton"
					}
				}
			};
			_ = Navigation.PushAsync(testPage);
		}

#if UITEST
		[Test]
		public void IssueXXXTest()
		{
			RunningApp.WaitForElement(q => q.Text("Second Page"));
			var result = RunningApp.Query(q => q.Marked("SecondToolbarButtonAutomationId"));
			Assert.IsNotEmpty(result);
		}
#endif
	}
}