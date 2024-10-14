import { API_BASE_URL } from '../config';

export const fetchBooks = async (filters) => {
    const { name, year, type } = filters;
    const queryParams = new URLSearchParams({ name, year, type }).toString();
    const response = await fetch(`${API_BASE_URL}/Books?${queryParams}`);

    if (!response.ok) {

        throw new Error(errorMessage);
    }
    return await response.json();
};

export const fetchBookById = async (bookId) => {
    const response = await fetch(`${API_BASE_URL}/Books/${bookId}`);

    if (!response.ok) {
        throw new Error('Failed to fetch the book');
    }

    return await response.json();
};
