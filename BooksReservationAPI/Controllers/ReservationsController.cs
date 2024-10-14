using BooksReservationAPI.DTOs;
using BooksReservationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksReservationAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationsController(IReservationService reservationService) : ControllerBase
{
    private readonly IReservationService _reservationService = reservationService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetAllReservations()
    {
        try
        {
            var reservations = await _reservationService.GetAllReservationsAsync();
            return Ok(reservations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while fetching reservations.");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReservationDTO>> GetReservationById(int id)
    {
        try
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while fetching the reservation.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddReservation([FromBody] CreateReservationDTO reservationDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdReservation = await _reservationService.AddReservationAsync(reservationDTO);
            return CreatedAtAction(nameof(GetReservationById), new { id = createdReservation.Id }, createdReservation);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while creating the reservation.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservation(int id)
    {
        try
        {
            var success = await _reservationService.DeleteReservationAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while deleting the reservation.");
        }
    }
}