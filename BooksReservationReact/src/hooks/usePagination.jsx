import { useState, useEffect } from 'react';

export const usePagination = (itemsPerPage, totalItems) => {
  const [currentPage, setCurrentPage] = useState(1);
  
  const totalPages = Math.ceil(totalItems / itemsPerPage);

  useEffect(() => {
    setCurrentPage(1);
  }, [totalItems]);

  const nextPage = () => {
    if (currentPage < totalPages) {
      setCurrentPage((prev) => prev + 1);
    }
  };

  const prevPage = () => {
    if (currentPage > 1) {
      setCurrentPage((prev) => prev - 1);
    }
  };

  const goToPage = (page) => {
    if (page >= 1 && page <= totalPages) {
      setCurrentPage(page);
    }
  };

  return {
    currentPage,
    totalPages,
    nextPage,
    prevPage,
    goToPage,
  };
};