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
	[Issue(IssueTracker.Github, 13000, "Issue Description", PlatformAffected.iOS)]
	public class IssueXXX : TestContentPage
	{
		// When the page appears, it has already been pushed onto the navigation stack.
		// This will reproduce the problem, which is that on iOS, when the page is not the first one on the stack,
		// the AutomationId for the toolbar button will not exist. This does not happen if the page is the first one on the stack.

		protected override void Init()
		{
			Content = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Children =
				{
					new Label
					{
						Text = "A Page",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center
					},
					new Label
					{
						Text = "This can only be tested by running the UI test.",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center
					}
				}
			};

			ToolbarItems.Add(new ToolbarItem
			{
				AutomationId = "ToolbarButtonAutomationId",
				Text = "ToolbarButton"
			});
		}

#if UITEST
		[Test]
		public void IssueXXXTest()
		{
			RunningApp.WaitForElement(q => q.Text("A Page"));
			var result = RunningApp.Query(q => q.Marked("ToolbarButtonAutomationId"));
			Assert.IsNotEmpty(result);
		}
#endif
	}
}