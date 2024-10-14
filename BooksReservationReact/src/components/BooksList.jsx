import React, { useEffect, useState, useRef } from 'react';
import { fetchBooks } from '../services/bookService';
import { Link } from 'react-router-dom';

export const BooksList = () => {
    const [books, setBooks] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [filters, setFilters] = useState({
        name: '',
        year: '',
        type: '',
    });

    const nameInputRef = useRef(null);
    const yearInputRef = useRef(null);

    useEffect(() => {
        const getBooks = async () => {
            setLoading(true);
            setError(null);
            try {
                const data = await fetchBooks(filters);
                setBooks(data);
            } catch (error) {
                setError(error.message);
            } finally {
                setLoading(false);
            }
        };
        getBooks();
    }, [filters]);

    const handleFilterChange = (e) => {
        const { name, value } = e.target;
        setFilters((prev) => ({
            ...prev,
            [name]: value,
        }));
    };

    return (
        <div id="books-container" className="flex flex-col items-center bg-gray-100 p-5">
            <div className="bg-white shadow-md rounded-md p-6 max-w-6xl w-full">
                <h2 className="text-2xl font-bold mb-2">Books</h2>

                <div id="books-filters" className='mb-2'>
                    <h3>Select filters or choose book you are interested</h3>
                    <input
                        ref={nameInputRef}
                        type="text"
                        name="name"
                        placeholder="Search by name"
                        value={filters.name}
                        onChange={handleFilterChange}
                        className="border p-2"
                        autoFocus
                    />
                    <input
                        ref={yearInputRef}
                        type="number"
                        name="year"
                        placeholder="Year"
                        value={filters.year}
                        onChange={handleFilterChange}
                        className="border p-2 ml-2 max-w-20"
                    />
                    <select
                        name="type"
                        value={filters.type}
                        onChange={handleFilterChange}
                        className="border p-2 ml-2"
                    >
                        <option value="">Select Type</option>
                        <option value="0">Book</option>
                        <option value="1">Audiobook</option>
                    </select>
                </div>

                <div id="books-list">
                    {loading && <p>Loading...</p>}
                    {error && <p>Error: {error}</p>}

                    {!loading && !error && (
                        <div className="grid gap-2 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4">
                            {books.map((book) => (
                                <div key={book.id} className="border p-4 flex flex-col items-start">
                                    <img
                                        src={book.imageUrl}
                                        alt={`${book.name} cover`}
                                        className="w-24 h-32 mb-4"
                                    />
                                    <div>
                                        <h3 className="text-xl font-bold">{book.name}</h3>
                                        <p className="text-gray-600">Year: {book.year}</p>
                                        <p className="text-gray-600 mb-2">
                                            {book.hasNormalBook && book.hasAudioBook
                                                ? "Book and Audiobook"
                                                : book.hasNormalBook
                                                    ? "Book"
                                                    : "Audiobook"}
                                        </p>
                                        <Link to={`/reserve/${book.id}`} className="bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-700 transition">
                                            Reserve
                                        </Link>
                                    </div>
                                </div>
                            ))}
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
}