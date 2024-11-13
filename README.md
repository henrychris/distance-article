# Distance Article

## Description

This project demonstrates how to calculate distances between geographic points using NetTopologySuite with PostgreSQL's PostGIS extension. It provides a practical example of:

- Using geography and geometry types in PostgreSQL
- Implementing distance calculations between coordinates
- Working with NetTopologySuite in .NET
- Using Entity Framework Core with spatial data

## Features

- Calculate distances between geographic points using PostGIS
- Support for both geometry and geography types
- RESTful API endpoints for querying nearby venues
- Sample data including popular New York landmarks
- Haversine distance calculation implementation

## Prerequisites

- .NET 8.0
- PostgreSQL with PostGIS extension
- Docker (optional)

## Installation

1. Clone the repository

 ```bash
 git clone https://github.com/henrychris/distancearticle.git
 ```

2. Navigate to the project directory

 ```bash
 cd distancearticle
 ```

3. Set up your database connection string in `appsettings.Development.json`:

 ```json
 {
 "DatabaseSettings": {
 "ConnectionString": "Host=localhost;Database=your_database;Username=your_username;Password=your_password"
 }
 }
 ```

4. Run database migrations

 ```bash
 dotnet ef database update
 ```

## Usage

1. Start the API

```bash
dotnet run
```

2. Test the API endpoints

- `GET /venue/nearby` - Find venues near a specific location using geography type
- `GET /venue/geometry` - Find venues near a specific location using geometry type

```bash
curl --request GET \
  --url 'http://localhost:5051/api/venue/nearby?latitude=40.7128&longitude=-74.0060&rangeInKm=1'
```

## Links

This repository accompanies this article written by me on [Medium](link).
