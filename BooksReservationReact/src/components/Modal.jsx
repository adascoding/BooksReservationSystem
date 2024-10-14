import React from 'react';

export const Modal = ({ title, message, onClose }) => {
    return (
        <div id="modal" className="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50 z-50">
            <div className="bg-white p-6 rounded shadow-lg max-w-sm w-full">
                <h2 className="text-lg font-bold mb-4">{title}</h2>
                <p>{message}</p>
                <button 
                    className="mt-4 bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600"
                    onClick={onClose}
                >
                    Close
                </button>
            </div>
        </div>
    );
};
