import React from 'react'

export const About = () => {
    return (
        <div id="about-container" className="flex flex-col items-center bg-gray-100 p-5">
            <div className="bg-white shadow-md rounded-md p-6 max-w-6xl w-full">
                <h2 className="text-2xl font-bold mb-4">About the Project</h2>
                <div id="about-description" className="text-gray-700">
                    <h3 className="text-xl font-semibold mb-2">Back-End</h3>
                    <ul className="list-disc ml-5 mb-4">
                        <li>Built with .NET 8 and C#</li>
                        <li>Entity Framework</li>
                        <li>DTOs</li>
                        <li>AutoMapper for model-to-DTO mapping</li>
                        <li>Uses services, controllers, and repositories</li>
                        <li>Dependency Injection</li>
                        <li>In-Memory database</li>
                        <li>Unit tests for price calculation and repository logic</li>
                    </ul>

                    <h4 className="text-lg font-medium mb-2">API Endpoints</h4>
                    <ul className="list-disc ml-5 mb-4">
                        <li><b>GET</b> /api/Books - Get list of books</li>
                        <li><b>GET</b> /api/Books/{'{bookId}'} - Get specific book</li>
                        <li><b>GET</b> /api/Reservations - Get reservations</li>
                        <li><b>POST</b> /api/Reservations/{'{reservationId}'} - Create a new reservation</li>
                        <li><b>DELETE</b> /api/Reservations/{'{reservationId}'} - Delete a reservation</li>
                    </ul>

                    <h3 className="text-xl font-semibold mb-2">Front-End</h3>
                    <ul className="list-disc ml-5 mb-4">
                        <li>Built with React</li>
                        <li>Styled with Tailwind CSS</li>
                        <li>Uses js services to fetch API data</li>
                        <li>Basic routing for navigation</li>
                    </ul>

                    <h3 className="text-xl font-semibold mb-2">Key Features</h3>
                    <ul className="list-disc ml-5 mb-4">
                        <li>View and search books by name, type, and year</li>
                        <li>Reserve books with options: type, days, quick pickup</li>
                        <li>View reservations</li>
                    </ul>

                    <h3 className="text-xl font-semibold mb-2">Further Improvements</h3>
                    <ul className="list-disc ml-5">
                        <li>Return Result class in the backend for better response handling</li>
                        <li>Add more validation and custom error messages in both back-end and front-end</li>
                        <li>Book return option</li>
                        <li>Book creation</li>
                        <li>Pagination for book and reservation lists</li>
                        <li>Try create custom react hooks</li>
                    </ul>
                </div>
            </div>
        </div>
    )
}
