﻿using Htmxor.TestApp;
using Microsoft.Playwright;

namespace Htmxor.Blazewright;

public class PageTest : IClassFixture<PlaywrightFixture>, IAsyncLifetime
{
    private readonly PlaywrightFixture fixture;

    public IBrowserContext Context { get; private set; } = null!;

    public IServiceProvider Services { get; }

    public PageTest(PlaywrightFixture fixture)
    {
        this.fixture = fixture;
        Services = fixture.Services;
    }

    public async Task InitializeAsync()
    {
        Context = await fixture.NewContext();
    }

    public Task DisposeAsync()
    {
        return Context.CloseAsync();
    }

    public void SetDefaultExpectTimeout(float timeout) => Assertions.SetDefaultExpectTimeout(timeout);

    public ILocatorAssertions Expect(ILocator locator) => Assertions.Expect(locator);

    public IPageAssertions Expect(IPage page) => Assertions.Expect(page);

    public IAPIResponseAssertions Expect(IAPIResponse response) => Assertions.Expect(response);
}
