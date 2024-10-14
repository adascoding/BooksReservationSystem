import { Link } from 'react-router-dom';

export const Navigation = () => {
    return (
        <nav id="navigation" className="p-4 flex items-center justify-between">
            <div className="flex justify-center flex-grow space-x-4">
                <Link
                    to="/"
                    className="bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-700 transition"
                >
                    Home
                </Link>
                <Link
                    to="/books"
                    className="bg-green-500 text-white py-2 px-4 rounded hover:bg-green-700 transition"
                >
                    Books List
                </Link>
                <Link
                    to="/reservations"
                    className="bg-yellow-500 text-white py-2 px-4 rounded hover:bg-yellow-700 transition"
                >
                    Reservations List
                </Link>
            </div>

            <div className="ml-auto">
                <Link
                    to="/about"
                    className="bg-purple-500 text-white py-2 px-4 rounded hover:bg-purple-700 transition"
                >
                    About project
                </Link>
            </div>
        </nav>
    );
};
