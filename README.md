# Social Media Post Manager API

This project is a mini social media feed API built using ASP.NET Core Web API. 
It allows users to create posts, follow other users, and retrieve a feed of posts from themselves and users they are following. 
The project demonstrates scalability and performance considerations to handle high traffic loads.

## Features

- Create posts with text (maximum 140 characters).
- Follow and unfollow other users.
- Retrieve a feed of recent posts from the user and people they are following.
- Posts are sorted by likes in descending order.
- Efficient pagination of posts.
- Rate limiting to control the rate of incoming requests.

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core (SQLlite Database)
- SeriLog
- Dependency Injection
- Middleware for rate limiting

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/mannypulator/Social-Media-Post-Manager.git
   cd Social-Media-Post-Manager
   ```
2. Restore dependencies:
   ```bash
   dotnet restore
   ```
3. Build the project:
   ```bash
   dotnet build
   ```
4. Run the project
   ```bash
   dotnet run
   ```
### API Endpoints

#### Create Post
* ### URL: `POST /api/Posts
  ```json
      {
        "text": "string",
        "userId": 0
     }
  ```
#### Get Post by User
* ### URL: `GET /api/Posts/{userId}?PageNumber={pageNumber}&PageSize={pageSize}

#### Like Post
* ### URL: `GET /api/Posts/like-post
  ```json
      {
        "postId": 2,
        "userId": 4
      }
  ```
#### Create User
* ### URL: `POST /api/User
  ```json
      {
       "userName": "string"
      }
  ```
#### Follow User
* ### URL: `POST /api/Follow
  ```json
       {
        "followerId": 2,
        "followeeId": 1
      }
  ```
#### Get User Followers
* ### URL: `GET /api/Follow/{userId}


### License
This project is licensed under the MIT License. See the LICENSE file for details.

### Contributing
Contributions are welcome! Please open an issue or submit a pull request for any changes or improvements.

