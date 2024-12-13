## This section contains detailed information about the project files. Including some code snippets/examples and explanations.

#### Components/Layout
<!-- cool inline with also examples of code. explained very througlhy -->
1. **MainLayout.razor** - The main layout file for the application. Contains the navigation menu and the body of the application.

```csharp
@inherits LayoutComponentBase

<div class="sidebar">
    <NavMenu />
</div>

<main>
    <article>
        @Body // Body of the application, where the pages are rendered from the Pages directory.
    </article>
</main>

```

2. **NavMenu.razor** - The navigation menu file for the application. Contains the links to the different pages of the application.

```csharp
<h2>Navigation</h2>

<div>
    <div>
        <NavLink class="nav-link" href="eventlist">
            <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> Event List
        </NavLink>
    </div>

    <div class="nav-item px-3">
        <NavLink class="nav-link" href="addevent">
            <span class="bi bi-calendar-event" aria-hidden="true"></span> Add Event
        </NavLink>
    </div>
</div>
```

#### Components/Pages

3. **AddEvent.razor** - The Add Event page file for the application. Contains the form for adding a new event.

```csharp
@page "/addevent"

<h3>Add Event</h3>

// Checks if the DbContext is injected properly.
@if (DbContext == null)
{
    <p>Not properly injected!!?!??</p>
}

// Form for adding a new event. Here is one of the fields as an example.

<EditForm Model="newEvent" OnValidSubmit="SaveEvent" FormName="addEventForm" AdditionalAttributes="@(new Dictionary<string, object> { { "FormName", "  " } })">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <div class="form-group mb-3">
        <label for="title">Title</label>
        <InputText id="title" @bind-Value="newEvent.Title" class="form-control" />
        <ValidationMessage For="@(() => newEvent.Title)" />
    </div>

    <button type="submit" class="btn btn-success">Save</button>
</EditForm>

// Code for saving the event.
@code {
    [SupplyParameterFromForm]
    private Event newEvent { get; set; }

    protected override void OnInitialized()
    {

        if(newEvent == null)
            newEvent = new Event();
    }

    private async Task SaveEvent()
    {
        try
        {
            // Save the new event with values from the form
            DbContext.Events.Add(newEvent);
            await DbContext.SaveChangesAsync();
            //empty the fields
			newEvent = new Event();
        }
        catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
    }
}
```

4. **EditEvent.razor** - The Edit Event page file for the application. Contains the form for editing an existing event. This file is similar to the AddEvent.razor file, with the difference being that it is used for editing an existing event.

```csharp
@page "/editevent/{EventId}"
// rendermode InteractiveServer is used to enable the server-side logic to be executed in the browser.
@rendermode InteractiveServer

<h3>Edit Event</h3>

// Form for editing an existing event. Here is one of the fields as an example.
<div>
    // Makes sure that the event item is not null before rendering the form.
    @if (eventItem != null)
    {
        <EditForm Model="eventItem" OnValidSubmit="SaveEvent">
            <DataAnnotationsValidator />
            <ValidationSummary />

            <div class="mb-3">
				<label for="EventName" class="form-label">Event Name</label>
                <InputText id="EventName" class="form-control" @bind-Value="eventItem.Title" />
                <ValidationMessage For="@(() => eventItem.Title)" />
            </div>

            <button type="submit" class="btn btn-success">Save Changes<button> 
        </EditForm>
    }
    else
    {
        <p>Loading...</p>
    }
</div>

// Code for saving the event.

@code {
    [Parameter]
    public string EventId { get; set; }

    private Event eventItem;

    protected override async Task OnInitializedAsync() =>
        // Fetch the event from the database using the EventId parameter
        eventItem = await DbContext.Events.FirstOrDefaultAsync(e => e.Id == Convert.ToInt32(EventId));

    private async Task SaveEvent()
    {
        // Save the changes to the event in the database
        DbContext.Events.Update(eventItem);
        await DbContext.SaveChangesAsync();

        // Redirect to the event list page after saving
        _navigationManager.NavigateTo("/eventlist");
    }
}
```

5. **EventList.razor** - The Event List page file for the application. Contains the list of events and the ability to edit or delete an event.

```csharp
@page "/eventlist"
// rendermode InteractiveServer is used to enable the server-side logic to be executed in the browser.
@rendermode InteractiveServer
// Using Microsoft.EFCore to interact with the database.
@using Microsoft.EntityFrameworkCore
// Using Globalization for filtering the by date.
@using System.Globalization

<h3>Event List</h3>

// Filter by Month dropdown
<select class="form-select" @onchange="async (e) => await FilterByMonth(e)">
    <option value="">Filter by Month</option>
    @foreach (var month in Enumerable.Range(1, 12))
    {
        <option value="@month">@GetMonthName(month)</option>
    }
</select>

// Filtering for category and/or location

<input size="$0" class="form-control" placeholder="Filter by Category" @oninput="DebounceCategoryFilter" />

<input size="$0" class="form-control" placeholder="Filter by Location" @oninput="DebounceLocationFilter" />

@code {
    // workaround for blazor str format BS
	private void DebounceCategoryFilter(ChangeEventArgs e) => DebouncedFilter(e, "category");
    private void DebounceLocationFilter(ChangeEventArgs e) => DebouncedFilter(e, "location");

    private Timer DebounceTimer;

    private void DebouncedFilter(ChangeEventArgs e, string FP)
    {
        DebounceTimer?.Dispose();
        DebounceTimer = new Timer(async _ =>
        {
			if (FP == "category") 
                await FilterByCategory(e);
			else if (FP == "location")
				await FilterByLocation(e);
        }, null, 200, Timeout.Infinite);
    }
}

// <HTML code>

// Methods for interacting with the database & events and filtering the events.
@code {
    private List<Event> events = new();

    protected override async Task OnInitializedAsync()
    {
        events = await DbContext.Events.ToListAsync();
    }

    private async Task FilterByMonth(ChangeEventArgs e)
    {
        var selectedMonth = e.Value?.ToString();
        if (string.IsNullOrEmpty(selectedMonth))
        {
            events = await DbContext.Events.ToListAsync();
        }
        else
        {
            var month = int.Parse(selectedMonth);
            events = await DbContext.Events
                .Where(ev => ev.StartDate.Month == month || ev.EndDate.Month == month)
                .ToListAsync();
        }
        StateHasChanged(); // Trigger a UI refresh if needed
    }

    private async Task FilterByCategory(ChangeEventArgs e)
    {
        var category = e.Value?.ToString();
        if (string.IsNullOrEmpty(category))
        {
            events = await DbContext.Events.ToListAsync();
        }
        else
        {
            events = await DbContext.Events
                .Where(ev => ev.Category.Contains(category))
                .ToListAsync();
        }
        await InvokeAsync(StateHasChanged);
    }

	private async Task FilterByLocation(ChangeEventArgs e)
	{
		var location = e.Value?.ToString();
		if (string.IsNullOrEmpty(location))
		{
			events = await DbContext.Events.ToListAsync();
		}
		else
		{
			events = await DbContext.Events
				.Where(ev => ev.Location.Contains(location))
				.ToListAsync();
		}
		await InvokeAsync(StateHasChanged);
	}

    private async Task DeleteEvent(int id)
    {
        var eventItem = await DbContext.Events.FindAsync(id);
        if (eventItem != null)
        {
            DbContext.Events.Remove(eventItem);
            await DbContext.SaveChangesAsync();
            events = await DbContext.Events.ToListAsync(); // Refresh the list of events
            StateHasChanged(); // Trigger a UI refresh if needed
        }
    }

    private string GetMonthName(int month)
    {
        return DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
    }
}

```

#### Data

6. **Event.cs** - The Event class file for the application. Contains the properties of an event.

```csharp
// Example of the Event class, using Title as the example property.

// Required attribute is used to make sure the Title is not null.
[Required(ErrorMessage = "Title is required")]
// Validation for the length of the Title property.
[StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
// Getters and setters for the Title property.
public string? Title { get; set; }
```

7. **EventDbContext.cs** - The EventDbContext class file for the application. Contains the database context for the application.

```csharp
// The class contains only the Event DbSet for interacting with the database.
public class EventDbContext : DbContext
{
    public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { }
    public DbSet<Event> Events { get; set; }
}
```

#### Other Files

8. **appsettings.json** - The configuration file for the application. Contains the connection string for the database.

9. **Program.cs** - The entry point for the application. Contains the configuration for the application.
