import React, { useEffect, useState } from 'react';
import { fetchAllReservations, deleteReservation } from '../services/reservationService';
import { Modal } from './Modal'

export const ReservationsList = () => {
    const [reservations, setReservations] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [showModal, setShowModal] = useState(false);
    const [modalMessage, setModalMessage] = useState('');

    useEffect(() => {
        const getReservations = async () => {
            setLoading(true);
            setError(null);
            try {
                const data = await fetchAllReservations();
                setReservations(data);
            } catch (error) {
                setError(error.message);
            } finally {
                setLoading(false);
            }
        };

        getReservations();
    }, []);

    const handleReturnBook = async (reservationId) => {
        try {
            await deleteReservation(reservationId);
            setReservations(reservations.filter((reservation) => reservation.id !== reservationId));
            setModalMessage('Book returned successfully!');
            setShowModal(true);
        } catch (error) {
            setModalMessage(error.message);
            setShowModal(true);
        }
    };

    const closeModal = () => {
        setShowModal(false);
    };

    return (
        <div id="reservations-container" className="flex flex-col items-center bg-gray-100 p-5">
            <div className="bg-white shadow-md rounded-md p-6 max-w-4xl w-full">
                <h2 className="text-2xl font-bold mb-4">Reservations</h2>

                <div id="reservations-list">
                    {loading && <p>Loading...</p>}
                    {error && <p>Error: {error}</p>}

                    {!loading && !error && reservations.length === 0 && (
                        <p>No reservations found.</p>
                    )}

                    {!loading && !error && reservations.length > 0 && (
                        <div className="space-y-4">
                            {reservations.map((reservation) => (
                                <div key={reservation.id} className="border p-4 rounded shadow-md bg-white flex">
                                    <img
                                        src={reservation.book.imageUrl}
                                        alt={`${reservation.book.name} cover`}
                                        className="w-32 h-48 mr-6"
                                    />
                                    <div>
                                        <h3 className="text-xl font-bold mb-2">Reservation ID: {reservation.id}</h3>
                                        <p className="text-gray-600">Book Name: {reservation.book.name}</p>
                                        <p className="text-gray-600">Year: {reservation.book.year}</p>
                                        <p className="text-gray-600">
                                            Book Type: {reservation.bookType === 0 ? 'Normal Book' : 'Audiobook'}
                                        </p>
                                        <p className="text-gray-600">Days Reserved: {reservation.daysReserved}</p>
                                        <p className="text-gray-600">
                                            Quick Pickup: {reservation.isQuickPickup ? 'Yes' : 'No'}
                                        </p>
                                        <p className="text-gray-600">Total Price: ${reservation.totalPrice}</p>

                                        <div className="mt-4">
                                            <button
                                                className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
                                                onClick={() => handleReturnBook(reservation.id)}
                                            >
                                                Return Book
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            ))}
                        </div>
                    )}
                </div>
            </div>

            {showModal && (
                <Modal
                    title="Return Book Status"
                    message={modalMessage}
                    onClose={closeModal}
                />
            )}
        </div>
    );
};