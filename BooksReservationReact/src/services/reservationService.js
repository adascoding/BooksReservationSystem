import { API_BASE_URL } from '../config';

export const fetchAllReservations = async () => {
    const response = await fetch(`${API_BASE_URL}/Reservations`);

    if (!response.ok) {
        throw new Error('Failed to fetch reservations');
    }

    return await response.json();
};

export const createReservation = async (reservationData) => {
    const response = await fetch(`${API_BASE_URL}/Reservations`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(reservationData),
    });

    if (!response.ok) {
        throw new Error('Failed to create the reservation');
    }

    return await response.json();
};
export const deleteReservation = async (reservationId) => {
    const response = await fetch(`${API_BASE_URL}/Reservations/${reservationId}`, {
        method: 'DELETE',
    });

    if (!response.ok) {
        throw new Error('Failed delete reservation');
    }

    return response.status === 204 ? null : await response.json();
};