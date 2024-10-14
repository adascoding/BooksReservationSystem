import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { Home } from './components/Home';
import { BooksList } from './components/BooksList';
import { ReservationsList } from './components/ReservationsList';
import { ReserveBook } from './components/ReserveBook';
import { Navigation } from './components/Navigation';
import { About } from './components/About';

export const App = () => {
  return (
    <Router>
     <Navigation />

    <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/books" element={<BooksList />} />
        <Route path="/reservations" element={<ReservationsList />} />
        <Route path="/reserve/:bookId" element={<ReserveBook />} />
        <Route path="/about" element={<About />} />
    </Routes>
</Router>
  );
}