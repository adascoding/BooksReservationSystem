import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { fetchBookById } from '../services/bookService';
import { createReservation } from '../services/reservationService';
import { Modal } from './Modal';

export const ReserveBook = () => {
    const { bookId } = useParams();
    const navigate = useNavigate(); 
    const [book, setBook] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [days, setDays] = useState(1);
    const [quickPickup, setQuickPickup] = useState(false);
    const [selectedType, setSelectedType] = useState('');
    const [showModal, setShowModal] = useState(false);
    const [modalMessage, setModalMessage] = useState('');

    useEffect(() => {
        const getBook = async () => {
            try {
                const fetchedBook = await fetchBookById(bookId);
                setBook(fetchedBook);
                setLoading(false);
            } catch (error) {
                setError(error.message);
                setLoading(false);
            }
        };

        getBook();
    }, [bookId]);

    const handleReservation = async () => {
        if (!selectedType) {
            setModalMessage('Please select a type of book.');
            setShowModal(true);
            return;
        }

        if (days < 1 || days > 365) {
            setModalMessage('Please enter a valid number of days (between 1 and 365).');
            setShowModal(true);
            return;
        }

        const bookType = selectedType === 'normal' ? 0 : 1;

        try {
            const reservationData = {
                bookType,
                daysReserved: days,
                isQuickPickup: quickPickup,
                bookId: parseInt(bookId),
            };

            await createReservation(reservationData);

            setModalMessage('Reservation successful!');
            setShowModal(true);

            setTimeout(() => {
                navigate('/reservations');
            }, 2000);
        } catch (error) {
            setModalMessage(`Error: ${error.message}`);
            setShowModal(true);
        }
    };

    const closeModal = () => {
        setShowModal(false);
    };

    if (loading) return <p>Loading...</p>;
    if (error) return <p>Error: {error}</p>;

    return (
        <div id="book-container" className='flex flex-col items-center bg-gray-100 p-5'>
            <div className="bg-white shadow-md rounded-md p-6 max-w-md w-full">
                <h2 className="text-2xl font-bold mb-4">Reserve: {book.name}</h2>
                <img src={book.imageUrl} alt={`${book.name} cover`} className="w-48 h-64 mb-4" />
                <p>Year: {book.year}</p>
                <p>Available Formats:</p>
                <ul className="mb-4">
                    {book.hasNormalBook && <li>Normal Book</li>}
                    {book.hasAudioBook && <li>Audiobook</li>}
                </ul>

                <label className="block mb-2">
                    Select Type:
                    <select
                        value={selectedType}
                        onChange={(e) => setSelectedType(e.target.value)}
                        className="border p-2 w-full mt-1"
                    >
                        <option value="">Select a type</option>
                        {book.hasNormalBook && <option value="normal">Normal Book</option>}
                        {book.hasAudioBook && <option value="audio">Audiobook</option>}
                    </select>
                </label>

                <label className="block mb-2">
                    Number of Days:
                    <input
                        type="number"
                        value={days}
                        min="1"
                        max="365"
                        onChange={(e) => setDays(parseInt(e.target.value))}
                        className="border p-2 w-full mt-1"
                    />
                </label>

                <label className="flex items-center mb-4">
                    <input
                        type="checkbox"
                        checked={quickPickup}
                        onChange={() => setQuickPickup(!quickPickup)}
                    />
                    <span className="ml-2">Quick Pickup</span>
                </label>

                <button
                    onClick={handleReservation}
                    className="bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-700 transition"
                >
                    Reserve
                </button>
            </div>

            {showModal && (
                <Modal
                    title="Reservation Status"
                    message={modalMessage}
                    onClose={closeModal}
                />
            )}
        </div>
    );
}