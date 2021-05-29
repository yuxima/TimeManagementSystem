using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace TimeManagementSystem.IntegrationTests
{
    [TestFixture]
    public class ProjectControllerTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var factory = new TestWebAppFactory();
            _client = factory.CreateClient();
        }


        [Test]
        public async Task Index_WhenCalled_ReturnsCorrectForm()
        {
            var response = await _client.GetAsync("/Project");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            responseString.Should().Contain("Project1");
            responseString.Should().Contain("Project2");
        }

        // CREATE

        [Test]
        public async Task Create_WhenCalled_ReturnsCorrectForm()
        {
            var response = await _client.GetAsync("/Project/Create");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            responseString.Should().Contain("Create new Project");
        }

        [Test]
        public async Task Create_WhenPOSTExecuted_ReturnsToIndexViewWithCreatedSubject()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Project/Create");
            var formModel = new Dictionary<string, string>
            {
                { "Name", "New Name" }
            };
            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            responseString.Should().Contain("New Name");

        }

        [Test]
        public async Task Edit_WhenCalled_ReturnsCorrectForm()
        {
            var response = await _client.GetAsync("/Project/Edit/1");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            
            responseString.Should().Contain("Project1");

        }

        [Test]
        public async Task Edit_WhenPOSTExecuted_ReturnsToIndexViewWithCreatedSubject()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Project/Edit/1");
            var formModel = new Dictionary<string, string>
            {
                { "Name", "Edited Name" }
            };
            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            responseString.Should().Contain("Edited Name");
        }

        [Test]
        public async Task Delete_WhenCalled_ReturnsCorrectForm()
        {
            var response = await _client.GetAsync("/Project/Delete/1");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            responseString.Should().Contain("Are you sure you want to delete this");
            responseString.Should().Contain("Project1");

        }

        [Test]
        public async Task Delete_WhenPOSTExecuted_ReturnsToIndexViewWithDeletedSubject()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Project/Delete/1");
            var formModel = new Dictionary<string, string>
            {
                { "id", "1" }
            };
            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            responseString.Should().NotContain("Project1");
            responseString.Should().Contain("Project2");
        }
    }
}
