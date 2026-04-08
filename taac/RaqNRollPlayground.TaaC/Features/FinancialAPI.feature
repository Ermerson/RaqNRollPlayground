@database
Feature: Financial API Smoke Tests
  As a QA Engineer
  I want to test the Financial API endpoints
  So that I can verify the basic functionality is working

  Background:
    Given the API is running at "http://localhost:8080"
    And the current period is "2026-04"

  @smoketest @api
  Scenario: Get current month summary
    When I call the endpoint "GET /api/FinancialSummary/current-month"
    Then the response status should be 200
    And the response should contain a valid JSON

  @smoketest @api
  Scenario: Get outcome summary for a specific period
    When I call the endpoint "GET /api/FinancialSummary/outcomes/2026-04"
    Then the response status should be 200
    And the response should contain a valid JSON

  @smoketest @api
  Scenario: Get income summary for a specific period
    When I call the endpoint "GET /api/FinancialSummary/incomes/2026-04"
    Then the response status should be 200
    And the response should contain a valid JSON

  @smoketest @api
  Scenario: Get financial report for a specific period
    When I call the endpoint "GET /api/FinancialSummary/report/2026-04"
    Then the response status should be 200
    And the response should contain a valid JSON

  @smoketest @api
  Scenario: Test invalid period format
    When I call the endpoint "GET /api/FinancialSummary/outcomes/invalid-date"
    Then the response status should be 400
    And the response should contain error message

  @smoketest @health
  Scenario: Verify API is accessible
    When I make a GET request to the root endpoint
    Then the response status should be 200 or 404
    And the API should be responsive

