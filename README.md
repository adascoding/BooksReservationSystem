# About the Project

## Back-End
- Built with .NET 8 and C#
- Entity Framework
- DTOs
- AutoMapper for model-to-DTO mapping
- Uses services, controllers, and repositories
- Dependency Injection
- In-Memory database
- Unit tests for price calculation and repository logic

### API Endpoints
- `GET /api/Books` - Get list of books
- `GET /api/Books/{bookId}` - Get specific book
- `GET /api/Reservations` - Get reservations
- `POST /api/Reservations/{reservationId}` - Create a new reservation
- `DELETE /api/Reservations/{reservationId}` - Delete a reservation

## Front-End
- Built with React
- Styled with Tailwind CSS
- Uses JS services to fetch API data
- Basic routing for navigation

## Key Features
- View and search books by name, type, and year
- Reserve books with options: type, days, quick pickup
- View reservations

## Further Improvements
- Return Result class in the backend for better response handling
- Add more validation and custom error messages in both back-end and front-end
- Book return option
- Book creation
- Pagination for book and reservation lists
- Try creating custom React hooks
