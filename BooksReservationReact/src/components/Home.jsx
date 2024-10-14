export const Home = () => {
    return (
            <div id="home-container" className="flex flex-col items-center bg-gray-100 p-5">
                <h1 className="text-2xl font-bold p-6">Welcome to the Books Reservation System</h1>
                <div id="prices-container" className="bg-white shadow-md rounded-md p-6 max-w-xl w-full">
                    <h2 className="text-2xl font-bold mb-2">Our Prices for Books</h2>
                    <ul>
                        <li>Paper books cost: <span className="font-bold">€2/day</span></li>
                        <li>Audio books cost: <span className="font-bold">€3/day</span></li>
                        <hr className="m-2"></hr>
                        <li className="font-bold">Don't forget our discounts! The more days you reserve a book, the bigger discount you will get:</li>
                        <li>More than <span className="font-bold">3 days</span> will get you <span className="font-bold">10% off</span></li>
                        <li>More than <span className="font-bold">10 days</span> will get you <span className="font-bold">20% off</span></li>
                        <hr className="m-2"></hr>
                        <li>Some additional fees:</li>
                        <li>There is a <span className="font-bold">€3 service fee</span> when ordering a book.</li>
                        <li>If you're in a hurry, opt for quick pick-up for a price of <span className="font-bold">€5</span>.</li>
                    </ul>
                </div>
            </div>
    );
}