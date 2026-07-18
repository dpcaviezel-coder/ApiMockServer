// This file is for documentation only.
// It does not need to be compiled.

//
// How to add a custom route
//

// 1. Open Config/routes.json
// 2. Add a new route entry:
//
// {
//   "Method": "GET",
//   "Path": "/custom",
//   "Endpoint": "Custom"
// }
//
// 3. Create or edit Endpoints/CustomEndpoint.cs
// 4. Restart the server OR use hot reload if implemented
//
// Now you can call:
// http://localhost:5000/custom
