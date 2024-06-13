# BlazorWasmStandaloneAppAuthSample

This sample app demonstrates authentication in a Blazor WebAssembly app that calls a secured API.

## Features

1. A standalone Blazor WebAssembly application.
2. A sample API backend using the JwtBearerHandler to validate JWT tokens sent by the Blazor app.

## Configuration Steps

1. **Create an App Registration**:
    - Register a new app in your identity provider (e.g., Azure AD).
    - Select "Single-page application" as the platform.

2. **Set Redirect URIs**:
    - Add the login callback endpoint as a redirect URI:
        ```
        https://localhost:7128/authentication/login-callback
        ```

3. **Expose an API**:
    - Define and expose an API to allow scope requests.
    - Create a scope named `Weather.Get`.

4. **Update Application Settings**:
    - In the `appsettings.json` file of both the Blazor WebAssembly app and the API project, update the settings with the appropriate values:
        - `ClientId`
        - `TenantId`
        - `Scope`

## Running the Sample

### Using Visual Studio

1. Open the `BlazorWasmStandaloneAppAuthSample.sln` solution file in Visual Studio.
3. Start the app by clicking the Run button or by selecting "Start Debugging" from the Debug menu.

## Notes

- Ensure that you have the necessary permissions and API configurations set up in your identity provider.
- Verify that the redirect URI is correctly registered and matches the one configured in your app settings.
